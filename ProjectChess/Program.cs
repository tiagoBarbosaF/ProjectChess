using System;
using ProjectChess.Board;
using ProjectChess.Chess;

namespace ProjectChess
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch match = new ChessMatch();

                Screen.printBoard(match.Brdg);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }

            //ChessPosition pos = new ChessPosition('c',7);

            //Console.WriteLine(pos);

            //Console.WriteLine(pos.toPosition());

        }
    }
}
