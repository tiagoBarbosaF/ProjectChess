using System;
using ProjectChess.Board;

namespace ProjectChess
{
    class Program
    {
        static void Main(string[] args)
        {
            BoardGame b = new BoardGame(8, 8);

            Screen.printBoard(b);

            Console.WriteLine("Okay");
        }
    }
}
