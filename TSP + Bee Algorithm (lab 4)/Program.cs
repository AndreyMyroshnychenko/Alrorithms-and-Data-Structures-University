using System;
using System.IO;
using System.Text;

namespace ПА_Лаб._4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = RandomWeightMatrix();

            var citiesData = new CitiesData(matrix);

            var hive = new BeeColony(citiesData, 50, 10, 10, 2000, 30);
            var listSolution = hive.Solve(out var dist);

            Console.WriteLine($"Solution distance: {dist}");

            StringBuilder way = new StringBuilder();
            foreach (int cityNumber in listSolution)
            {
                way.Append("-->" + cityNumber);
            }

            Console.WriteLine(way);
        }

        private static int[,] RandomWeightMatrix()
        {
            var random = new Random();
            var matrix = new int[100, 100];

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 0;
                        continue;
                    }

                    matrix[i, j] = random.Next(5, 151);
                }
            }

            return matrix;
        }
    }
}
