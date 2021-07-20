using System;
using ProjectChess.Board;
using ProjectChess.Chess;

namespace ProjectChess
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    boardgame b = new boardgame(8, 8);

            //    b.placepiece(new tower(color.black, b), new position(0, 0));
            //    b.placepiece(new tower(color.black, b), new position(1, 3));
            //    b.placepiece(new king(color.orange, b), new position(0, 2));

            //    screen.printboard(b);
            //}
            //catch (boardexception e)
            //{
            //    console.writeline(e.message);
            //}

            ChessPosition pos = new ChessPosition('c',7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.toPosition());

        }
    }
}
