using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПА_Лаб._5
{

    class Gameboard
    {

        public bool crossTurn;
        public bool crossIsHuman = false;
        public bool circleIsHuman = true;
        public static bool extensiveBoard = false;
        private Computer bot = new Computer();
        public int previousMove = -1;
        public int size;
        public int[] board;
        public int lastSquare;


        public Gameboard(int size, bool crossIsHuman, bool circleIsHuman)
        {
            this.size = size;
            board = new int[size * size];
            this.crossIsHuman = crossIsHuman;
            this.circleIsHuman = circleIsHuman;


            crossTurn = true;
        }


        public Gameboard(Gameboard toCopy)
        {
            size = toCopy.size;
            board = (int[])toCopy.board.Clone();
            crossTurn = toCopy.crossTurn;
            lastSquare = toCopy.lastSquare;
        }


        public void LoadMoves()
        {
            foreach (Move move in LocalStorage.moves)
            {
                board[move.position] = (move.isCross) ? 1 : 2;
            }

            crossTurn = LocalStorage.moves[LocalStorage.moves.Count - 1].isCross ? false : true;
        }


        public void StartIteration()
        {
            lastSquare = (size * size) / 2;
            while (true)
            {
                DrawGameboard(lastSquare);

                if ((crossTurn && crossIsHuman) || (!crossTurn && circleIsHuman))
                {
                    lastSquare = HumanSelectSquare();
                }

                else
                {
                    lastSquare = bot.ComputerSelectSquare(this, 4, 8);
                }

                if (board[lastSquare] == 0 || board[lastSquare] == 3)
                {
                    SwitchSquare(lastSquare);
                    bot.AssessGameboard(this);
                    int win = EvaluateWin(lastSquare);
                    if (win != 0)
                    {
                        DrawGameboard(lastSquare);
                        DisplayEndingText(win);
                        LocalStorage.moves.Clear();
                        LocalStorage.ClearMoves();
                        TakeInput();
                    }

                    LocalStorage.moves.Add(new Move(crossTurn, previousMove));
                    SwitchTurn();
                }
            }
        }


        public void DrawGameboard(int cursorPos = 0)
        {
            ClearGameboard();
            string colLabels = "    ";
            for (int i = 0; i < size; i++)
            {
                colLabels += (char)('a' + i);
                if (extensiveBoard)
                {
                    colLabels += " ";
                }
            }
            Console.WriteLine(colLabels);
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine();
                Console.Write((i + 1).ToString("00") + "  ");
                for (int j = 0; j < size; j++)
                {
                    if (board[i * size + j] == 0)
                    {
                        Console.ResetColor();
                        Console.Write("-");
                    }
                    else if (board[i * size + j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                    }
                    else if (board[i * size + j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write("T");
                    }
                    if (extensiveBoard)
                    {
                        Console.Write(" ");
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            if (extensiveBoard)
            {
                Console.SetCursorPosition(4 + ColFromPos(cursorPos) * 2,
                                         2 + RowFromPos(cursorPos));
            }
            else
            {
                Console.SetCursorPosition(4 + ColFromPos(cursorPos),
                                         2 + RowFromPos(cursorPos));
            }
        }


        public int HumanSelectSquare()
        {

            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            ConsoleKey key = Console.ReadKey(true).Key;


            if (key == ConsoleKey.UpArrow && Console.CursorTop > 2)
            {
                Console.CursorTop -= 1;
            }


            else if (key == ConsoleKey.DownArrow && Console.CursorTop < size + 1)
            {
                Console.CursorTop += 1;
            }


            else if (key == ConsoleKey.LeftArrow && Console.CursorLeft > 4)
            {
                if (extensiveBoard)
                {
                    Console.CursorLeft -= 2;
                }
                else
                {
                    Console.CursorLeft -= 1;
                }
            }

            else if ((key == ConsoleKey.RightArrow && Console.CursorLeft < size * 2 + 2 && extensiveBoard)
                      || (key == ConsoleKey.RightArrow && Console.CursorLeft < size + 3))
            {
                if (extensiveBoard)
                {
                    Console.CursorLeft += 2;
                }
                else
                {
                    Console.CursorLeft += 1;
                }
            }

            
            else if (key == ConsoleKey.Escape)
            {
                LocalStorage.WriteMoves();
                Menu.Initialize();
            }


            else if (key == ConsoleKey.Z)
            {

                if (LocalStorage.moves.Count > 0)
                {
                    int i = LocalStorage.moves.Count - 1;
                    crossTurn = !crossTurn;
                    Move lastMove = LocalStorage.moves[i];
                    board[lastMove.position] = 0;
                    DrawGameboard(lastSquare);
                    if (i - 1 >= 0) i--;
                    Console.SetCursorPosition(0, 16);
                    Console.WriteLine("\n\nPress Enter to continue game...");
                    ConsoleKey _key = Console.ReadKey(true).Key;


                    while (_key != ConsoleKey.Enter)
                    {
 
                        if (_key == ConsoleKey.Z && i > -1)
                        {
                            lastMove = LocalStorage.moves[i];
                            board[lastMove.position] = 0;
                            if (i - 1 >= -1) i--;

                        }


                        else if (_key == ConsoleKey.X)
                        {
                            if (i + 1 < LocalStorage.moves.Count) i++;
                            lastMove = LocalStorage.moves[i];
                            board[lastMove.position] = (lastMove.isCross) ? 1 : 2;
                        }

                        crossTurn = !crossTurn;
                        DrawGameboard(lastSquare);
                        Console.SetCursorPosition(0, 16);
                        Console.WriteLine("\n\nPress Enter to continue game...");
                        _key = Console.ReadKey(true).Key;
                    }


                    Console.Clear();
                    if (i + 1 < LocalStorage.moves.Count)
                    {
                        LocalStorage.moves.RemoveRange(i + 1, LocalStorage.moves.Count - (i + 1));
                    }
                    StartIteration();
                }
            }


            int cursorLeftPos = Console.CursorLeft;
            int cursorTopPos = Console.CursorTop;
            if (extensiveBoard)
            {
                Console.SetCursorPosition(size * 2 + 6, 0);
                Console.Write(((cursorLeftPos - 4) / 2 + (cursorTopPos - 2) * size).ToString("000"));
                Console.SetCursorPosition(size * 2 + 6, 1);
                Console.Write((char)('a' + (cursorLeftPos - 4) / 2) + (cursorTopPos - 1).ToString("00"));
            }
            else
            {
                Console.SetCursorPosition(size + 6, 0);
                Console.Write((cursorLeftPos - 4 + (cursorTopPos - 2) * size).ToString("000"));
                Console.SetCursorPosition(size + 6, 1);
                Console.Write((char)('a' + cursorLeftPos - 4) + (cursorTopPos - 1).ToString("00"));
            }
            Console.SetCursorPosition(cursorLeftPos, cursorTopPos);
            if (key == ConsoleKey.Enter)
            {
                if (extensiveBoard)
                {
                    return (cursorLeftPos - 4) / 2 + (Console.CursorTop - 2) * size;
                }
                else
                {
                    return Console.CursorLeft - 4 + (Console.CursorTop - 2) * size;
                }
            }
            else
            {
                return HumanSelectSquare();
            }
        }


        public int EvaluateWin(int position)
        {
            int targetCursor = board[position];
            int pos2 = position;
            int inRow = 0;
            for (; ColFromPos(pos2) >= 0; pos2--)
            {
                if (ColFromPos(pos2) - 1 < 0 || board[pos2 - 1] != targetCursor)
                {
                    break;
                }
            }
            for (; ColFromPos(pos2) < size; pos2++)
            {
                inRow++;
                if (ColFromPos(pos2) + 1 >= size || board[pos2 + 1] != targetCursor)
                {
                    if (inRow >= 5)
                    {
                        return targetCursor;
                    }
                    break;
                }
            }
            pos2 = position;
            inRow = 0;
            for (; RowFromPos(pos2) >= 0; pos2 -= size)
            {
                if (RowFromPos(pos2) - 1 < 0 || board[pos2 - size] != targetCursor)
                {
                    break;
                }
            }
            for (; RowFromPos(pos2) < size; pos2 += size)
            {
                inRow++;
                if (RowFromPos(pos2) + 1 >= size || board[pos2 + size] != targetCursor)
                {
                    if (inRow >= 5)
                    {
                        return targetCursor;
                    }
                    break;
                }
            }
            pos2 = position;
            inRow = 0;
            for (; RowFromPos(pos2) >= 0 && ColFromPos(pos2) >= 0; pos2 = pos2 - size - 1)
            {
                if (RowFromPos(pos2) - 1 < 0 || ColFromPos(pos2) - 1 < 0 || board[pos2 - size - 1] != targetCursor)
                {
                    break;
                }
            }
            for (; RowFromPos(pos2) < size && ColFromPos(pos2) < size; pos2 += size + 1)
            {
                inRow++;
                if (RowFromPos(pos2) + 1 >= size || ColFromPos(pos2) + 1 >= size || board[pos2 + size + 1] != targetCursor)
                {
                    if (inRow >= 5)
                    {
                        return targetCursor;
                    }
                    break;
                }
            }
            pos2 = position;
            inRow = 0;
            for (; RowFromPos(pos2) >= 0 && ColFromPos(pos2) < size; pos2 = pos2 - size + 1)
            {
                if (RowFromPos(pos2) - 1 < 0 || ColFromPos(pos2) + 1 >= size || board[pos2 - size + 1] != targetCursor)
                {
                    break;
                }
            }
            for (; RowFromPos(pos2) < size && ColFromPos(pos2) >= 0; pos2 += size - 1)
            {
                inRow++;
                if (RowFromPos(pos2) + 1 >= size || ColFromPos(pos2) - 1 < 0 || board[pos2 + size - 1] != targetCursor)
                {
                    if (inRow >= 5)
                    {
                        return targetCursor;
                    }
                    break;
                }
            }
            if (GetBestMoves(1).Length == 0 && board[0] != 0)
            {
                return -1;
            }
            return 0;
        }


        public void SwitchSquare(int pos)
        {
            previousMove = pos;
            board[pos] = crossTurn ? 1 : 2;
        }


        public void SwitchTurn()
        {
            crossTurn = !crossTurn;
        }


        public void TakeInput()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
            ConsoleKey key = Console.ReadKey(true).Key;


            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                board = new int[size * size];
                StartIteration();
            }


            else if (key == ConsoleKey.Escape)
            {
                Menu.Initialize();
            }


            else
            {
                TakeInput();
            }
        }


        public void DisplayEndingText(int won)
        {
            Console.Clear();
            DrawGameboard();
            Console.SetCursorPosition(2, 3 + size);
            if (won == 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("X");
                Console.ResetColor();
                Console.WriteLine(" won!");
            }
            else if (won == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("O");
                Console.ResetColor();
                Console.WriteLine(" won!");
            }
            else if (won == -1)
            {
                Console.WriteLine("Stalemate!");
            }
            Console.WriteLine();
            Console.WriteLine("Press enter to play another game or ESC to return to main menu.");
        }


        public int ColFromPos(int position)
        {
            return position % size;
        }


        public int RowFromPos(int position)
        {
            return (position / size);
        }


        public void ClearGameboard()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < size + 2; i++)
            {
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.SetCursorPosition(0, 0);
        }


        public int[] GetBestMoves(int range = 1)
        {
            List<int> moves = new List<int>();
            for (int i = 0; i < this.board.Length; i++)
            {
                if (this.board[i] != 0)
                {
                    if (this.RowFromPos(i) - 1 >= 0 && this.ColFromPos(i) - 1 >= 0 && !moves.Contains(i - 1 - this.size) && this.board[i - 1 - this.size] == 0)
                    {
                        moves.Add(i - 1 - this.size);
                    }
                    if (this.RowFromPos(i) - 1 >= 0 && this.ColFromPos(i) + 1 < this.size && !moves.Contains(i + 1 - this.size) && this.board[i + 1 - this.size] == 0)
                    {
                        moves.Add(i + 1 - this.size);
                    }
                    if (this.RowFromPos(i) + 1 < this.size && this.ColFromPos(i) - 1 >= 0 && !moves.Contains(i - 1 + this.size) && this.board[i - 1 + this.size] == 0)
                    {
                        moves.Add(i - 1 + this.size);
                    }
                    if (this.RowFromPos(i) + 1 < this.size && this.ColFromPos(i) + 1 < this.size && !moves.Contains(i + 1 + this.size) && this.board[i + 1 + this.size] == 0)
                    {
                        moves.Add(i + 1 + this.size);
                    }
                    if (this.RowFromPos(i) - 1 >= 0 && !moves.Contains(i - this.size) && this.board[i - this.size] == 0)
                    {
                        moves.Add(i - this.size);
                    }
                    if (this.RowFromPos(i) + 1 < this.size && !moves.Contains(i + this.size) && this.board[i + this.size] == 0)
                    {
                        moves.Add(i + this.size);
                    }
                    if (this.ColFromPos(i) - 1 >= 0 && !moves.Contains(i - 1) && this.board[i - 1] == 0)
                    {
                        moves.Add(i - 1);
                    }
                    if (this.ColFromPos(i) + 1 < this.size && !moves.Contains(i + 1) && this.board[i + 1] == 0)
                    {
                        moves.Add(i + 1);
                    }
                }
            }
            return moves.ToArray();
        }
    }
}
