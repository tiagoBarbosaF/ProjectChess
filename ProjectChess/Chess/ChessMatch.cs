using System.Collections.Generic;
using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class ChessMatch
    {
        public BoardGame Brdg { get; private set; }
        public int Turn { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }
        public HashSet<Piece> Pieces;
        public HashSet<Piece> Captured;
        public bool Check { get; private set; }
        public Piece VulnerableEnPassant { get; private set; }

        public ChessMatch()
        {
            Brdg = new BoardGame(8, 8);
            Turn = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Check = false;
            VulnerableEnPassant = null;
            Pieces = new HashSet<Piece>();
            Captured = new HashSet<Piece>();
            placePieces();
        }

        public Piece performMoviment(Position origin, Position destiny)
        {
            Piece p = Brdg.removePiece(origin);
            p.incrementQteMoviments();
            Piece CapturePiece = Brdg.removePiece(destiny);
            Brdg.placePiece(p, destiny);
            if (CapturePiece != null)
            {
                Captured.Add(CapturePiece);
            }

            // #specialmove small roque
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Brdg.removePiece(originT);
                T.incrementQteMoviments();
                Brdg.placePiece(T, destinyT);
            }

            // #specialmove big roque
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Brdg.removePiece(originT);
                T.incrementQteMoviments();
                Brdg.placePiece(T, destinyT);
            }

            // #specialmove En Passant
            if (p is Peon)
            {
                if (origin.Column != destiny.Column && CapturePiece == null)
                {
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(destiny.Line + 1, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(destiny.Line - 1, destiny.Column);
                    }
                    CapturePiece = Brdg.removePiece(posP);
                    Captured.Add(CapturePiece);
                }
            }

            return CapturePiece;
        }

        public void undoMoviment(Position origin, Position destiny, Piece CapturePiece)
        {
            Piece p = Brdg.removePiece(destiny);
            p.decrementQteMoviments();
            if (CapturePiece != null)
            {
                Brdg.placePiece(CapturePiece, destiny);
                Captured.Remove(CapturePiece);
            }
            Brdg.placePiece(p, origin);

            // #specialmove small roque
            if (p is King && destiny.Column == origin.Column + 2)
            {
                Position originT = new Position(origin.Line, origin.Column + 3);
                Position destinyT = new Position(origin.Line, origin.Column + 1);
                Piece T = Brdg.removePiece(originT);
                T.decrementQteMoviments();
                Brdg.placePiece(T, originT);
            }

            // #specialmove small roque
            if (p is King && destiny.Column == origin.Column - 2)
            {
                Position originT = new Position(origin.Line, origin.Column - 4);
                Position destinyT = new Position(origin.Line, origin.Column - 1);
                Piece T = Brdg.removePiece(originT);
                T.decrementQteMoviments();
                Brdg.placePiece(T, originT);
            }

            // #specialmove En Passant
            if (p is Peon)
            {
                if (origin.Column != destiny.Column && CapturePiece == VulnerableEnPassant)
                {
                    Piece peon = Brdg.removePiece(destiny);
                    Position posP;
                    if (p.Color == Color.White)
                    {
                        posP = new Position(3, destiny.Column);
                    }
                    else
                    {
                        posP = new Position(4, destiny.Column);
                    }
                    Brdg.placePiece(peon, posP);
                }
            }

        }

        public void performPlay(Position origin, Position destiny)
        {
            Piece CapturePiece = performMoviment(origin, destiny);

            if (itIsCheck(CurrentPlayer))
            {
                undoMoviment(origin, destiny, CapturePiece);
                throw new BoardException("You can´t put yourself in Check!");
            }
            if (itIsCheck(adversary(CurrentPlayer)))
            {
                Check = true;
            }
            else
            {
                Check = false;
            }

            if (testCheckMate(adversary(CurrentPlayer)))
            {
                Finished = true;
            }
            else
            {
                Turn++;
                changePlayer();
            }

            Piece p = Brdg.piece(destiny);


            // #specialmove En Passant
            if (p is Peon && (destiny.Line == origin.Line - 2 || destiny.Line == origin.Line + 2))
            {
                VulnerableEnPassant = p;
            }
            else
            {
                VulnerableEnPassant = null;
            }
        }

        public void validOriginPosition(Position pos)
        {
            if (Brdg.piece(pos) == null)
            {
                throw new BoardException("There are no piece in origin moviment!");
            }
            if (CurrentPlayer != Brdg.piece(pos).Color)
            {
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
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public HashSet<Piece> capturePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Captured)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesInGame(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturePieces(color));
            return aux;
        }

        private Color adversary(Color color)
        {
            if (color == Color.White)
            {
                return Color.Black;
            }
            else
            {
                return Color.White;
            }
        }

        private Piece king(Color color)
        {
            foreach (Piece x in piecesInGame(color))
            {
                if (x is King)
                {
                    return x;
                }
            }
            return null;
        }

        public bool itIsCheck(Color color)
        {
            Piece K = king(color);
            if (K == null)
            {
                throw new BoardException($"Not have a King with color {color} on Board Game!");
            }

            foreach (Piece x in piecesInGame(adversary(color)))
            {
                bool[,] mat = x.possibleMoviments();
                if (mat[K.Position.Line, K.Position.Column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Color color)
        {
            if (!itIsCheck(color))
            {
                return false;
            }
            foreach (Piece x in piecesInGame(color))
            {
                bool[,] mat = x.possibleMoviments();
                for (int i = 0; i < Brdg.Lines; i++)
                {
                    for (int j = 0; j < Brdg.Columns; j++)
                    {
                        if (mat[i, j])
                        {
                            Position origin = x.Position;
                            Position destiny = new Position(i, j);
                            Piece capturePiece = performMoviment(origin, destiny);
                            bool testCheck = itIsCheck(color);
                            undoMoviment(origin, destiny, capturePiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void placeNewPiece(char column, int line, Piece piece)
        {
            Brdg.placePiece(piece, new ChessPosition(column, line).toPosition());
            Pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('a', 1, new Tower(Color.White, Brdg));
            placeNewPiece('b', 1, new Horse(Brdg, Color.White));
            placeNewPiece('c', 1, new Bishop(Brdg, Color.White));
            placeNewPiece('d', 1, new Queen(Brdg, Color.White));
            placeNewPiece('e', 1, new King(Color.White, Brdg, this));
            placeNewPiece('f', 1, new Bishop(Brdg, Color.White));
            placeNewPiece('g', 1, new Horse(Brdg, Color.White));
            placeNewPiece('h', 1, new Tower(Color.White, Brdg));
            placeNewPiece('a', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('b', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('c', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('d', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('e', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('f', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('g', 2, new Peon(Brdg, Color.White, this));
            placeNewPiece('h', 2, new Peon(Brdg, Color.White, this));

            placeNewPiece('a', 8, new Tower(Color.Black, Brdg));
            placeNewPiece('b', 8, new Horse(Brdg, Color.Black));
            placeNewPiece('c', 8, new Bishop(Brdg, Color.Black));
            placeNewPiece('d', 8, new Queen(Brdg, Color.Black));
            placeNewPiece('e', 8, new King(Color.Black, Brdg, this));
            placeNewPiece('f', 8, new Bishop(Brdg, Color.Black));
            placeNewPiece('g', 8, new Horse(Brdg, Color.Black));
            placeNewPiece('h', 8, new Tower(Color.Black, Brdg));
            placeNewPiece('a', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('b', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('c', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('d', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('e', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('f', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('g', 7, new Peon(Brdg, Color.Black, this));
            placeNewPiece('h', 7, new Peon(Brdg, Color.Black, this));
        }
    }
}
