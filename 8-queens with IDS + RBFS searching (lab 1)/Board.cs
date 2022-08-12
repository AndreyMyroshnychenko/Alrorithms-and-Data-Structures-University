using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1__8_queens_
{
    public class Board
    {
        public int Size { get; set; }
        public bool [,] Map { get; set; }

        public Board()
        {
            Size = 8;
            Map = new bool[Size, Size];
        }

        public Board(int _size)
        {
            Size = _size;
            Map = new bool[_size, _size];
        }

        public Board(int _size, bool [,] _map)
        {
            Size = _size;
            Map = _map;
        }

        public void Drawing()
        {
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    if (this.Map[i,j])
                    {
                        Console.Write(" Q ");
                    }
                    else
                    {
                        Console.Write(" . ");
                    }
                }
                Console.WriteLine();

                
            }
        }

        public int Conflicts()
        {
            int con = 0;
            for (int i = 0; i < this.Size; i++)
            {
                for (int j = 0; j < this.Size; j++)
                {
                    for (int row = 0; row < this.Size; row++)
                    {
                        if (this.Map[i,j]&&this.Map[i,row]&&row!=j)
                        {
                            con++;
                        }
                        if (i-row>=0&&j-row>=0&&this.Map[i,j]&&this.Map[i-row,j-row]&&row!=0)
                        {
                            con++;
                        }
                        if (i-row>=0&&j+row<this.Size&&this.Map[i,j]&&this.Map[i-row,j+row]&&row!=0)
                        {
                            con++;
                        }
                        if (i+row<this.Size&&j-row>=0&&this.Map[i,j]&&this.Map[i+row,j-row]&&row!=0)
                        {
                            con++;
                        }
                        if (i + row<this.Size&&j+row<this.Size&&this.Map[i,j]&&this.Map[i+row,j+row]&&row != 0)
                        {
                            con++;
                        }
                    }
                }
            }
            return (con / 2);
        }
        public static int Conflicts(int size, bool[,] map)
        {
            int con = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    for (int row = 0; row < size; row++)
                    {
                        if (map[i, j] && map[i, row] && row != j)
                        {
                            con++;
                        }
                        if (i - row >= 0 && j - row >= 0 && map[i, j] && map[i - row, j - row] && row != 0)
                        {
                            con++;
                        }
                        if (i - row >= 0 && j + row < size && map[i, j] && map[i - row, j + row] && row != 0)
                        {
                            con++;
                        }
                        if (i + row < size && j - row >= 0 && map[i, j] && map[i + row, j - row] && row != 0)
                        {
                            con++;
                        }
                        if (i + row < size && j + row < size && map[i, j] && map[i + row, j + row] && row != 0)
                        {
                            con++;
                        }
                    }
                }
            }
            return (con / 2);
        }
        public void Generator()
        {
            Random ran = new Random();
            int i = 0;
            for (int j = 0; j < this.Size; j++)
            {
                i = ran.Next(0, 8);
                this.Map[i, j] = true;

            }
            return;
        }
    }
}
