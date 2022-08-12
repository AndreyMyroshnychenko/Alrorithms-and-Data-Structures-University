using System;
using System.Collections.Generic;

namespace Lab1__8_queens_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] queens = new bool[8, 8]
            {
                { false, false, true, false, false, false, false, false},
                { false, false, false, false, false, true, false, false},
                { false, false, false, true, false, false, false, false },
                { true, false, false, false, false, false, false, false },
                { false, false, false, true, false, false, false, true },
                { false, false, false, false, true, false, false, false },
                { false, false, false, false, false, false, true, false },
                { false, true, false, false, false, false, false, false }


            };
            Board b = new Board(8);
            b.Generator();
            b.Drawing();
            Console.WriteLine(b.Conflicts());
            IDS ids = new IDS();
            List<bool[,]> q = new List<bool[,]>();
            List<bool[,]> chk = new List<bool[,]>();
            int iterations = 0;
            while (b.Conflicts() != 0)
            {
                b = ids.Search(b, ref q, ref chk, ref iterations);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Visited = " + chk.Count);
            Console.WriteLine("Iterations = " + iterations);
            Console.WriteLine("Memory = " + q.Count);
            Console.ReadKey();



            Board b1 = new Board(8, queens);
            b1.Drawing();
            RBFS rbfs = new RBFS();
            List<bool[,]> visited = new List<bool[,]>();
            Queue<bool[,]> que = new Queue<bool[,]>();
            bool[,] _second_map = new bool[b1.Size, b1.Size];
            _second_map = Problem.Copy(b1.Size, b1.Map);
            que.Enqueue(_second_map);
            iterations = 0;
            while (b1.Conflicts()!=0)
            {
                b1 = rbfs.Search(b1, ref que, ref chk, ref iterations);
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Visited = " + visited.Count);
            Console.WriteLine("Iterations = " + iterations);
            Console.WriteLine("Memory = " + que.Count);
            Console.ReadKey();
        }
    }
}

