using System;
using ProjectChess.Board;
using ProjectChess.Chess;

namespace ProjectChess
{
    class Screen
    {
        public static void printBoard(BoardGame brd)
        {
            for(int i = 0; i < brd.Lines; i++)
            {
                Console.Write($"{8 - i} ");
                for(int j = 0; j < brd.Columns; j++)
                {
                    if(brd.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PiecePrint(brd.piece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
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
            if(piece.Color == Color.White)
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
        }
    }
}
