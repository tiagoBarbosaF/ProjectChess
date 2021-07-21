using System;
using ProjectChess.Board;
using ProjectChess.Chess;

namespace ProjectChess.Chess
{
    class ChessMatch
    {
        public BoardGame Brdg { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
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

        public void performPlay(Position origin, Position destiny)
        {
            performMoviment(origin, destiny);
            Turn++;
            changePlayer();
        }

        public void validOriginPosition(Position pos)
        {
            if(Brdg.piece(pos) == null)
            {
                throw new BoardException("There are no piece in origin moviment!");
            } 
            if (CurrentPlayer != Brdg.piece(pos).Color) {
                throw new BoardException("The origin Piece is not yours!");
            } 
            if (!Brdg.piece(pos).existPossibleMoviments())
            {
                throw new BoardException("There are not possible moviments for this piece!");
            }
        }

        public void validDestinyPosition(Position origin, Position destiny)
        {
            if (!Brdg.piece(origin).canMoveFor(destiny))
            {
                throw new BoardException("Invalid destiny position!");
            }
        }

        private void changePlayer()
        {
            if(CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
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
