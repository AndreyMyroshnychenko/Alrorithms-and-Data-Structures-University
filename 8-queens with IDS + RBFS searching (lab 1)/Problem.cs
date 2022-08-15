using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПА_Лаб._1
{
    static class Problem
    {
        public static int[] findQueensByColumns(int[,] board)
        {
            int[] queenCoordinates = new int[16];
            int arrCounter = 0;

            for (int column = 0; column < 8; column++)
            {
                for (int row = 0; row < 8; row++)
                {
                    if (board[row, column] == 1)
                    {
                        queenCoordinates[arrCounter] = row;
                        arrCounter++;

                        queenCoordinates[arrCounter] = column;
                        arrCounter++;
                    }
                }

            }

            return queenCoordinates;
        }

        public static int[] findQueens(int[,] board)
        {
            int[] queenCoordinates = new int[16];
            int arrCounter = 0;

            for (int i = 0; i < Board.boardRows; i++)
            {
                for (int j = 0; j < Board.boardColumns; j++)
                {
                    if (board[i, j] == 1)
                    {
                        queenCoordinates[arrCounter] = i;
                        arrCounter++;

                        queenCoordinates[arrCounter] = j;
                        arrCounter++;
                    }
                }
            }
            return queenCoordinates;
        }

        public static bool isAGoal(int[,] state)
        {
            int[] queensCoordinates = Problem.findQueens(state);

            int i = 0;
            while (i < 16)
            {
                bool isGoal = Problem.isAGoalQueen(state, queensCoordinates[i], queensCoordinates[i + 1]);

                if (isGoal == false)
                {
                    return false;
                }

                i += 2;
            }

            return true;
        }

        public static bool isAGoalQueen(int[,] currentState, int row, int column)
        {
            int rows = currentState.GetUpperBound(0) + 1;
            int columns = currentState.GetUpperBound(1) + 1;

            for (int i = row + 1; i < rows; i++)
            {
                if (currentState[i, column] == 1)
                {
                    return false;
                }
            }

            for (int j = column + 1; j < columns; j++)
            {
                if (currentState[row, j] == 1)
                {
                    return false;
                }
            }


            for (int j = column - 1; j >= 0; j--)
            {
                if (currentState[row, j] == 1)
                {
                    return false;
                }
            }

            int counter = 1;

            while (counter < 9)
            {

                if ((row - counter > -1) && (column - counter > -1) &&
                    (currentState[row - counter, column - counter] == 1))
                {
                    return false;
                }


                if ((row - counter > -1) && (column + counter < 8) &&
                    (currentState[row - counter, column + counter] == 1))
                {
                    return false;
                }


                if ((row + counter < 8) && (column - counter > -1) &&
                    (currentState[row + counter, column - counter] == 1))
                {
                    return false;
                }


                if ((row + counter < 8) && (column + counter < 8) &&
                    (currentState[row + counter, column + counter] == 1))
                {
                    return false;
                }

                counter++;
            }

            return true;
        }


        public static int conflictsCount(int[,] state)
        {

            int[] queensCoordinates = Problem.findQueensByColumns(state);

            int conflictsCount = 0;

            int i = 0;
            while (i < 16)
            {
                int conflictsCountByQueen = Problem.conflictsCountByQueen(state, queensCoordinates[i], queensCoordinates[i + 1]);

                conflictsCount += conflictsCountByQueen;

                i += 2;
            }


            return conflictsCount / 2;
        }

        public static int conflictsCountByQueen(int[,] currentState, int row, int column)
        {
            int rows = currentState.GetUpperBound(0) + 1;
            int columns = currentState.GetUpperBound(1) + 1;

            int conflictsByQueenCounter = 0;


            for (int i = row + 1; i < rows; i++)
            {
                if (currentState[i, column] == 1)
                {
                    conflictsByQueenCounter++;
                }
            }


            for (int j = column + 1; j < columns; j++)
            {
                if (currentState[row, j] == 1)
                {
                    conflictsByQueenCounter++;
                }
            }


            for (int j = column - 1; j >= 0; j--)
            {
                if (currentState[row, j] == 1)
                {
                    conflictsByQueenCounter++;
                }
            }

            int counter = 1;

            while (counter < 9)
            {
                if ((row - counter > -1) && (column - counter > -1) &&
                    (currentState[row - counter, column - counter] == 1))
                {
                    conflictsByQueenCounter++;
                }

                if ((row - counter > -1) && (column + counter < 8) &&
                    (currentState[row - counter, column + counter] == 1))
                {
                    conflictsByQueenCounter++;
                }

                if ((row + counter < 8) && (column - counter > -1) &&
                    (currentState[row + counter, column - counter] == 1))
                {
                    conflictsByQueenCounter++;
                }

                if ((row + counter < 8) && (column + counter < 8) &&
                    (currentState[row + counter, column + counter] == 1))
                {
                    conflictsByQueenCounter++;
                }

                counter++;
            }

            return conflictsByQueenCounter;
        }

    }

}
