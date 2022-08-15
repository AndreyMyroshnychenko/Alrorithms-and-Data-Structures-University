using System;

namespace ПА_Лаб._1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] initialBoard = new int[Board.boardRows, Board.boardColumns];
            Board.setManualBoardState(initialBoard);

            Console.WriteLine("Initial board state: ");
            Board.showBoard(initialBoard);

            int conflictsByState = Problem.conflictsCount(initialBoard);
            Console.WriteLine($"Number of conflicts is {conflictsByState}.");
            Console.WriteLine();

            Tree tree = new Tree();
            tree.root = new Node(initialBoard, null, 0);

            Console.WriteLine("Recursive best first search:");
            var result2 = SearchAlgorithms.RecursiveBestFirstSearch(tree.root, int.MaxValue);

            if (result2 != null)
            {
                Board.showBoard(result2.State);

                Console.WriteLine($"\nDepth of a goal state is: {result2.Depth}.");
                Console.WriteLine($"Generated states: {TaskCounters.generatedStatesCounterRBFS}\n" +
                    $"Num of iterations: {TaskCounters.iterationsCounterRBFS}");
            }
            else
            {
                Console.WriteLine("Solution is not found");
            }

            Console.WriteLine("\n\n");

            Console.WriteLine("Iterative deepening search:");
            var result = SearchAlgorithms.IterativeDeepeningSearch(tree.root);

            if (result != null)
            {
                Board.showBoard(result.State);

                Console.WriteLine($"\nDepth of a goal state is: {result.Depth}.");
                Console.WriteLine($"Generated states: {TaskCounters.generatedStatesCounterIDS}\n" +
                    $"Num of iterations: {TaskCounters.iterationsCounterIDS}");
            }
            else
            {
                Console.WriteLine("Solution is not found");
            }
        }
    }

}
