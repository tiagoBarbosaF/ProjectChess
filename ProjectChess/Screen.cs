using System;
using ProjectChess.Board;

namespace ProjectChess
{
    class Screen
    {
        public static void printBoard(BoardGame brd)
        {
            for(int i = 0; i < brd.Lines; i++)
            {
                for(int j = 0; j < brd.Columns; j++)
                {
                    if(brd.piece(i,j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write($"{brd.piece(i,j)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
