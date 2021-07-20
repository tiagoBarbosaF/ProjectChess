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
                BoardGame b = new BoardGame(8, 8);

                b.placePiece(new Tower(Color.Black, b), new Position(0, 0));
                b.placePiece(new Tower(Color.Black, b), new Position(1, 3));
                b.placePiece(new King(Color.Black, b), new Position(0, 2));

                b.placePiece(new Tower(Color.White, b), new Position(3, 5));
                b.placePiece(new King(Color.White, b), new Position(5, 5));

                Screen.printBoard(b);
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
