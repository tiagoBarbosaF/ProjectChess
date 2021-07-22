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

               while (!match.Finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.printMatch(match);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.readChessPosition().toPosition();
                        match.validOriginPosition(origin);

                        bool[,] possiblePositions = match.Brdg.piece(origin).possibleMoviments();

                        Console.Clear();
                        Screen.printBoard(match.Brdg, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.readChessPosition().toPosition();
                        match.validDestinyPosition(origin,destiny);

                        match.performPlay(origin, destiny);
                    }
                    catch (BoardException exc)
                    {
                        Console.WriteLine(exc.Message);
                        Console.ReadLine();
                    }
                }
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
