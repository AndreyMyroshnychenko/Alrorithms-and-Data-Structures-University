using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1__8_queens_
{
    class Problem
    {
        public static bool [,] Copy(int size, bool[,] f1)
        {
            bool[,] ar = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    ar[i, j] = f1[i, j];
                }
            }
            return ar;
        }

        public static bool Same(int size, bool[,] fst, bool[,] scd)
        {
            int count = 0;
            bool[,] new_ar = new bool[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (fst[i, j] == scd[i, j])
                        count++;
                }
            }
            if (count == (size * size))
            {
                return true;
            }
            return false;
        }

    }
}



