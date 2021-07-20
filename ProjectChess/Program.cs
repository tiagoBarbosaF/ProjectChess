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
                b.placePiece(new King(Color.Orange, b), new Position(0, 2));

                Screen.printBoard(b);
            }
            catch(BoardException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
