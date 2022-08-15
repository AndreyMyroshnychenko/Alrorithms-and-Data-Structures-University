using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПА_Лаб._1
{
    static class Board
    {
        public const int boardRows = 8;
        public const int boardColumns = 8;

        public static void setBoardState(int[,] boardToFill)
        {
            Random ran = new Random();
            int QueenRowInit = ran.Next(0, 7);

            for (int i = 0; i < Board.boardRows; i++)
            {
                for (int j = 0; j < Board.boardColumns; j++)
                {
                    if (j == QueenRowInit)
                    {
                        boardToFill[j, i] = 1;
                    }
                    else
                    {
                        boardToFill[j, i] = 0;
                    }
                }
                QueenRowInit = ran.Next(0, 7);
            }
        }

        public static void setManualBoardState(int[,] boardToFill)
        {
            Random ran = new Random();
            int boardChoice = ran.Next(0, 9);

            if (boardChoice == 0)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 6 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }

            if (boardChoice == 1)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 3 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 1 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 1 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }

            if (boardChoice == 2)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 1 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }

            if (boardChoice == 3)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 1 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 1 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }

            if (boardChoice == 4)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 6 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }

            if (boardChoice == 5)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 2 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 1 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 1 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }
            if (boardChoice == 6)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 5 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }
            if (boardChoice == 7)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 0 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 1 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }
            if (boardChoice == 8)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 2 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 6 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 3 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }
            if (boardChoice == 9)
            {
                for (int i = 0; i < Board.boardRows; i++)
                {
                    for (int j = 0; j < Board.boardColumns; j++)
                    {
                        if (i == 2 && j == 0)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 2 && j == 1)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 2)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 3)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 4)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 4 && j == 5)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 0 && j == 6)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else if (i == 5 && j == 7)
                        {
                            boardToFill[i, j] = 1;
                        }
                        else
                        {
                            boardToFill[i, j] = 0;
                        }
                    }
                }
            }
        }

        public static List<int[,]> getNewStates(int[,] currentState)
        {
            List<int[,]> newStates = new List<int[,]>();

            int[] queensCoordinates = Problem.findQueensByColumns(currentState);

            int arrCounter = 0;

            while (arrCounter < 16)
            {
                int i = 1;
                int j = 0;

                while (queensCoordinates[arrCounter] + i != 8)
                {
                    int[,] arrToAdd = arrayCopy(currentState);
                    arrToAdd[queensCoordinates[arrCounter], queensCoordinates[arrCounter + 1]] = 0;


                    arrToAdd[queensCoordinates[arrCounter] + j, queensCoordinates[arrCounter + 1]] = 0;
                    arrToAdd[queensCoordinates[arrCounter] + i, queensCoordinates[arrCounter + 1]] = 1;
                    newStates.Add(arrToAdd);
                    i++;
                    j++;
                }

                int k = 1;
                int c = 0;
                while (queensCoordinates[arrCounter] - k > -1)
                {

                    int[,] arrToAdd = arrayCopy(currentState);
                    arrToAdd[queensCoordinates[arrCounter], queensCoordinates[arrCounter + 1]] = 0;


                    arrToAdd[queensCoordinates[arrCounter] - c, queensCoordinates[arrCounter + 1]] = 0;
                    arrToAdd[queensCoordinates[arrCounter] - k, queensCoordinates[arrCounter + 1]] = 1;
                    newStates.Add(arrToAdd);
                    k++;
                    c++;
                }

                arrCounter += 2;
            }


            return newStates;
        }

        public static void showBoard(int[,] board)
        {
            for (int i = 0; i < Board.boardRows; i++)
            {
                Console.WriteLine("\n");
                for (int j = 0; j < Board.boardColumns; j++)
                {
                    Console.Write($"{board[i, j]} \t");
                }
                Console.WriteLine();
            }
        }

        public static int[,] arrayCopy(int[,] initialArray)
        {
            int[,] copiedArray = new int[8, 8];

            for (int i = 0; i < initialArray.GetLength(0); i++)
            {
                for (int j = 0; j < initialArray.GetLength(1); j++)
                {
                    copiedArray[i, j] = initialArray[i, j];
                }
            }

            return copiedArray;
        }
    }

}
