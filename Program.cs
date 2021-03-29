using System;
using System.Collections.Immutable;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Spark.Sql;
using Microsoft.VisualBasic.FileIO;

namespace SudokuCombinatorialEvolutionSolver
{
    internal static class Program
    {

        //static readonly string _filePath = Path.Combine("/Users/sarahvasquez/Desktop/Sudoku/SudokuCombinatorialEvolutionSolver/dataset", "sudoku.csv");

        private static void Main(string[] args)
        {

            var temps1 = new System.Diagnostics.Stopwatch();
            var temps2 = new System.Diagnostics.Stopwatch();

            int nbsudokus = 3000;
            int noyau = 1;
            int noeud = 1;

            temps1.Start();

            SparkSession spark = SparkSession
                .Builder()
                .AppName(nbsudokus + " sudokus à résoudre avec " + noyau + " noyau(x) et " + noeud + " noeud(s)")
                .Config("spark.executor.cores", noyau)
                .Config("spark.executor.instances", noeud)
                .GetOrCreate();

            string[] lines = File.ReadAllLines("/Users/sarahvasquez/Desktop/Sudoku/SudokuCombinatorialEvolutionSolver/dataset/sudoku.csv");

            Console.WriteLine("Begin solving Sudoku using combinatorial evolution");
            Console.WriteLine("The Sudoku is:");

            var sudoku = lines;

            public static Sudoku ExtremelyDifficult
            {
                get
                {
                var problem = new[,]
                {
            {lines[0].Substring(0, 9)},
            {lines[0].Substring(9, 9)},
            {lines[0].Substring(18, 9)},
            {lines[0].Substring(27, 9)},
            {lines[0].Substring(36, 9)},
            {lines[0].Substring(45, 9)},
            {lines[0].Substring(54, 9)},
            {lines[0].Substring(63, 9)},
            {lines[0].Substring(72, 9)}
                };
            Console.WriteLine(sudoku.ToString());

            const int numOrganisms = 200;
            const int maxEpochs = 5000;
            const int maxRestarts = 40;
            Console.WriteLine($"Setting numOrganisms: {numOrganisms}");
            Console.WriteLine($"Setting maxEpochs: {maxEpochs}");
            Console.WriteLine($"Setting maxRestarts: {maxRestarts}");

            var solver = new SudokuSolver();
            var solvedSudoku = solver.Solve(problem, numOrganisms, maxEpochs, maxRestarts);

            Console.WriteLine("Best solution found:");
            Console.WriteLine(solvedSudoku.ToString());
            Console.WriteLine(solvedSudoku.Error == 0 ? "Success" : "Did not find optimal solution");
            Console.WriteLine("End Sudoku using combinatorial evolution");

            temps1.Stop();

            temps2.Start();

            //MultiSpark("1", "2", 1000);

            temps2.Stop();

            Console.WriteLine($"Temps d'exécution pour 1 noyau et 1 noeud: {temps1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Temps d'exécution pour 1 noyau et 2 noeuds: {temps2.ElapsedMilliseconds} ms");


        }
    }

}