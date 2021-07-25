using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class Peon : Piece
    {
        private ChessMatch match;

        public Peon(BoardGame Brdg, Color color, ChessMatch match) : base(color, Brdg)
        {
            this.match = match;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool thereIsEnemy(Position pos)
        {
            Piece p = Brdg.piece(pos);
            return p != null && p.Color != Color;
        }

        private bool free(Position pos)
        {
            return Brdg.piece(pos) == null;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Brdg.Lines, Brdg.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.setValues(Position.Line - 1, Position.Column);
                if (Brdg.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 2, Position.Column);
                if (Brdg.validPosition(pos) && free(pos) && QtdMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column - 1);
                if (Brdg.validPosition(pos) && thereIsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line - 1, Position.Column + 1);
                if (Brdg.validPosition(pos) && thereIsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #specialmove En Passant
                if (Position.Line == 3)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Brdg.validPosition(left) && thereIsEnemy(left) && Brdg.piece(left) == match.VulnerableEnPassant)
                    {
                        mat[left.Line - 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Brdg.validPosition(right) && thereIsEnemy(right) && Brdg.piece(right) == match.VulnerableEnPassant)
                    {
                        mat[right.Line - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.setValues(Position.Line + 1, Position.Column);
                if (Brdg.validPosition(pos) && free(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 2, Position.Column);
                if (Brdg.validPosition(pos) && free(pos) && QtdMoves == 0)
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column - 1);
                if (Brdg.validPosition(pos) && thereIsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }
                pos.setValues(Position.Line + 1, Position.Column + 1);
                if (Brdg.validPosition(pos) && thereIsEnemy(pos))
                {
                    mat[pos.Line, pos.Column] = true;
                }

                // #specialmove En Passant
                if (Position.Line == 4)
                {
                    Position left = new Position(Position.Line, Position.Column - 1);
                    if (Brdg.validPosition(left) && thereIsEnemy(left) && Brdg.piece(left) == match.VulnerableEnPassant)
                    {
                        mat[left.Line + 1, left.Column] = true;
                    }

                    Position right = new Position(Position.Line, Position.Column + 1);
                    if (Brdg.validPosition(right) && thereIsEnemy(right) && Brdg.piece(right) == match.VulnerableEnPassant)
                    {
                        mat[right.Line + 1, right.Column] = true;
                    }
                }
            }
            return mat;
        }
    }
}
