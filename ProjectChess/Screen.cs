using System;
using System.Collections.Generic;
using ProjectChess.Board;
using ProjectChess.Chess;

namespace ProjectChess
{
    class Screen
    {
        public static void printMatch(ChessMatch match)
        {
            printCapturePiecesBlack(match);
            Console.WriteLine();
            printBoard(match.Brdg);
            Console.WriteLine();
            printCapturePiecesWhite(match);
            //printCapturePieces(match);
            Console.WriteLine();
            Console.WriteLine($"\nTurn: {match.Turn}");
            if (!match.Finished)
            {
                Console.WriteLine($"Waiting move: {match.CurrentPlayer}");
                if (match.Check)
                {
                    Console.WriteLine("You're in Check!");
                }
            } else
            {
                Console.WriteLine($"\nCHECKMATE!! ==>  Winner: {match.CurrentPlayer.ToString().ToUpper()} pieces!!  <==");
            }
        }
        public static void printCapturePieces(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("Whites: ");
            printSet(match.capturePieces(Color.White));
            Console.Write("\nBlacks: ");
            printSet(match.capturePieces(Color.Black));
        }

        public static void printCapturePiecesWhite(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("Whites: ");
            Console.Write("[");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            printSet(match.capturePieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.Write("]");
        }

        public static void printCapturePiecesBlack(ChessMatch match)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("Blacks: ");
            Console.Write("[");
            printSet(match.capturePieces(Color.White));
            Console.Write("]");
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> set)
        {
            //Console.Write("[");
            foreach(Piece x in set)
            {
                Console.Write($"{x} ");
            }
            //Console.Write("]");
        }
        public static void printBoard(BoardGame brd)
        {
            Console.WriteLine();
            for (int i = 0; i < brd.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < brd.Columns; j++)
                {
                    PiecePrint(brd.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(BoardGame brd, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor changedBackground = ConsoleColor.DarkGray;

            Console.WriteLine();
            for (int i = 0; i < brd.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < brd.Columns; j++)
                {
                    if (possiblePositions[i, j]) {
                        Console.BackgroundColor = changedBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PiecePrint(brd.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void PiecePrint(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.Color == Color.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
