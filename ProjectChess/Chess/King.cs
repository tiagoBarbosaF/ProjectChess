using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class King : Piece
    {
        private ChessMatch match;
        public King(Color color, BoardGame Brdg, ChessMatch match) : base(color, Brdg)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "K";
        }

        private bool canMove(Position pos)
        {
            Piece p = Brdg.piece(pos);
            return p == null || p.Color != Color;
        }

        private bool testTowerForRoque(Position pos)
        {
            Piece p = Brdg.piece(pos);
            return p != null && p is Tower && p.Color == Color && p.QtdMoves == 0;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Brdg.Lines, Brdg.Columns];

            Position pos = new Position(0, 0);

            // above
            pos.setValues(Position.Line - 1, Position.Column);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // north east
            pos.setValues(Position.Line - 1, Position.Column + 1);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // right
            pos.setValues(Position.Line, Position.Column + 1);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // southeast
            pos.setValues(Position.Line + 1, Position.Column + 1);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // south
            pos.setValues(Position.Line + 1, Position.Column);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // south-west
            pos.setValues(Position.Line + 1, Position.Column - 1);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // left
            pos.setValues(Position.Line, Position.Column - 1);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // northwest
            pos.setValues(Position.Line - 1, Position.Column - 1);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // #specialmove roque
            if(QtdMoves == 0 && !match.Check)
            {
                // #specialmove small roque
                Position posT1 = new Position(Position.Line, Position.Column + 3);
                if (testTowerForRoque(posT1))
                {
                    Position p1 = new Position(Position.Line, Position.Column + 1);
                    Position p2 = new Position(Position.Line, Position.Column + 2);

                    if(Brdg.piece(p1) == null && Brdg.piece(p2) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }

                // #specialmove big roque
                Position posT2 = new Position(Position.Line, Position.Column - 4);
                if (testTowerForRoque(posT2))
                {
                    Position p1 = new Position(Position.Line, Position.Column - 1);
                    Position p2 = new Position(Position.Line, Position.Column - 2);
                    Position p3 = new Position(Position.Line, Position.Column - 3);

                    if (Brdg.piece(p1) == null && Brdg.piece(p2) == null && Brdg.piece(p3) == null)
                    {
                        mat[Position.Line, Position.Column + 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
