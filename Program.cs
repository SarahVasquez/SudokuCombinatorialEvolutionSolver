using System;
using System.Threading;
using System.Threading.Tasks;

namespace SudokuCombinatorialEvolutionSolver
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Begin solving Sudoku using combinatorial evolution");
            Console.WriteLine("The Sudoku is:");

            var sudoku = Sudoku.Easy;
            Console.WriteLine(sudoku.ToString());

            const int numOrganisms = 200;
            const int maxEpochs = 5000;
            const int maxRestarts = 40;
            Console.WriteLine($"Setting numOrganisms: {numOrganisms}");
            Console.WriteLine($"Setting maxEpochs: {maxEpochs}");
            Console.WriteLine($"Setting maxRestarts: {maxRestarts}");

            

            var result = Parallel.For(1, 101, (i, state) =>
            {

                Console.WriteLine($"Beginning iteration {i}");

                DateTime start = DateTime.Now;

                var solver = new SudokuSolver();

                var solvedSudoku = solver.Solve(sudoku, numOrganisms, maxEpochs, maxRestarts);

                TimeSpan dur = DateTime.Now - start;

                if (solvedSudoku != null)
                {
                    state.Break();
                }


                if (state.ShouldExitCurrentIteration)
                {
                    if (state.LowestBreakIteration < i)
                        return;
                }

                
                    


                Console.WriteLine($"Break in iteration {i}");
                Console.WriteLine("Best solution found:");
                Console.WriteLine(solvedSudoku.ToString());
                Console.WriteLine($"Temps d'exécution: {dur}");
                Console.WriteLine($"Completed iteration {i}");
                //Console.WriteLine(solvedSudoku.Error == 0 ? "Success" : "Did not find optimal solution");
                //Console.WriteLine("End Sudoku using combinatorial evolution");



            });

            




        }
    }
}