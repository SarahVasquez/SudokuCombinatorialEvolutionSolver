using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Spark.Sql;
using Microsoft.VisualBasic.FileIO;

namespace SudokuCombinatorialEvolutionSolver
{
    internal static class Program
    {

        static readonly string _filePath = Path.Combine("/Users/sarahvasquez/Desktop/Sudoku/5ESGF-BD-2021/SudokuCombinatorialEvolutionSolver/dataset", "sudoku.csv");

        private static void Main(string[] args)
        {

            var temps1 = new System.Diagnostics.Stopwatch();
            

            //int nbsudokus = 3000;
            //int noyau = 1;
            //int noeud = 1;

            temps1.Start();

            //SparkSession spark = SparkSession
                //.Builder()
                //.AppName(nbsudokus + " sudokus à résoudre avec " + noyau + " noyau(x) et " + noeud + " noeud(s)")
                //.Config("spark.executor.cores", noyau)
                //.Config("spark.executor.instances", noeud)
                //.GetOrCreate();

            //var strPathCSV = @"/Users/sarahvasquez/Sudoku/Sudoku.CNN/Dataset/sudoku.csv";
            var sudoku = Sudoku.CSV(_filePath);
            //string[] lines = File.ReadAllLines(" / Users/sarahvasquez/Desktop/Sudoku/SudokuCombinatorialEvolutionSolver/dataset/sudoku.csv");

            Console.WriteLine("Begin solving Sudoku using combinatorial evolution");
            Console.WriteLine("The Sudoku is:");

            //var sudoku = lines;

            
            Console.WriteLine(sudoku.ToString());

            const int numOrganisms = 200;
            const int maxEpochs = 5000;
            const int maxRestarts = 40;
            Console.WriteLine($"Setting numOrganisms: {numOrganisms}");
            Console.WriteLine($"Setting maxEpochs: {maxEpochs}");
            Console.WriteLine($"Setting maxRestarts: {maxRestarts}");

            var solver = new SudokuSolver();
            var solvedSudoku = solver.Solve(sudoku, numOrganisms, maxEpochs, maxRestarts);

            Console.WriteLine("Best solution found:");
            Console.WriteLine(solvedSudoku.ToString());
            Console.WriteLine(solvedSudoku.Error == 0 ? "Success" : "Did not find optimal solution");
            Console.WriteLine("End Sudoku using combinatorial evolution");

            temps1.Stop();

           

            Console.WriteLine($"Temps d'exécution pour 1 noyau et 1 noeud: {temps1.ElapsedMilliseconds} ms");



        }

        private static void Sudokures(string noyau, string noeud, int nbsudokus)
        {
            // Initialisation de la session Spark
            SparkSession spark = SparkSession
                .Builder()
                .AppName(nbsudokus + " sudokus à résoudre avec " + noyau + " noyau(x) et " + noeud + " noeud(s)")
                .Config("spark.executor.cores", noyau)
                .Config("spark.executor.instances", noeud)
                .GetOrCreate();

            // Intégration du csv dans un dataframe
            DataFrame df = spark
                .Read()
                .Option("header", true)
                .Option("inferSchema", true)
                .Csv(_filePath);

            //limit du dataframe avec un nombre de ligne prédéfini lors de l'appel de la fonction
            DataFrame df2 = df.Limit(nbsudokus);

            //Watch seulement pour la résolution des sudokus
            var watch2 = new System.Diagnostics.Stopwatch();
            watch2.Start();

            const int numOrganisms = 200;
            const int maxEpochs = 5000;
            const int maxRestarts = 40;

            // Création de la spark User Defined Function
            spark.Udf().Register<string, string>(
                "SukoduUDF",
                (sudoku) =>
                {
                    SudokuSolver.Solve(Sudoku.CSV(sudoku), numOrganisms, maxEpochs, maxRestarts);
                });

            // Appel de l'UDF dans un nouveau dataframe spark qui contiendra les résultats aussi
            df2.CreateOrReplaceTempView("Resolved");
            DataFrame sqlDf = spark.Sql("SELECT Sudokus, SukoduUDF(Sudokus) as Resolution from Resolved");
            sqlDf.Show();

            watch2.Stop();

            spark.Stop();

        }

    }
}