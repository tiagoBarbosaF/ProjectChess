using System;
using ProjectChess.Board;
using ProjectChess.Chess;

namespace ProjectChess.Chess
{
    class ChessMatch
    {
        public BoardGame Brdg { get; private set; }
        private int Turn;
        private Color CurrentPlayer;
        public bool Finished { get; private set; }

        public ChessMatch()
        {
            Brdg = new BoardGame(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            placePieces();
        }

        public void performMoviment (Position origin, Position destiny)
        {
            Piece p = Brdg.removePiece(origin);
            p.incrementQteMoviments();
            Piece CapturePiece = Brdg.removePiece(destiny);
            Brdg.placePiece(p, destiny);
        }

        private void placePieces()
        {
            Brdg.placePiece(new Tower(Color.White,Brdg), new ChessPosition('c', 1).toPosition());
            Brdg.placePiece(new Tower(Color.White,Brdg), new ChessPosition('c', 2).toPosition());
            Brdg.placePiece(new Tower(Color.White,Brdg), new ChessPosition('d', 2).toPosition());
            Brdg.placePiece(new Tower(Color.White,Brdg), new ChessPosition('e', 2).toPosition());
            Brdg.placePiece(new Tower(Color.White,Brdg), new ChessPosition('e', 1).toPosition());
            Brdg.placePiece(new King(Color.White,Brdg), new ChessPosition('d', 1).toPosition());

            Brdg.placePiece(new Tower(Color.Black, Brdg), new ChessPosition('c', 7).toPosition());
            Brdg.placePiece(new Tower(Color.Black, Brdg), new ChessPosition('c', 8).toPosition());
            Brdg.placePiece(new Tower(Color.Black, Brdg), new ChessPosition('d', 7).toPosition());
            Brdg.placePiece(new Tower(Color.Black, Brdg), new ChessPosition('e', 7).toPosition());
            Brdg.placePiece(new Tower(Color.Black, Brdg), new ChessPosition('e', 8).toPosition());
            Brdg.placePiece(new King(Color.Black, Brdg), new ChessPosition('d', 8).toPosition());
        }
    }
}
