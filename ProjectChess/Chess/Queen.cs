using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class Queen : Piece
    {
        public Queen(BoardGame Brdg, Color color) : base(color, Brdg)
        {

        }

        public override string ToString()
        {
            return "Q";
        }

        private bool canMove(Position pos)
        {
            Piece p = Brdg.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Brdg.Lines, Brdg.Columns];

            Position pos = new Position(0, 0);

            // left
            pos.setValues(Position.Line, Position.Column - 1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line, pos.Column - 1);
            }

            // right
            pos.setValues(Position.Line, Position.Column + 1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line, pos.Column + 1);
            }

            // above
            pos.setValues(Position.Line - 1, Position.Column);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line - 1, pos.Column);
            }

            // down
            pos.setValues(Position.Line + 1, Position.Column);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line + 1, pos.Column);
            }

            // Northweast
            pos.setValues(Position.Line - 1, Position.Column = -1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = -1, pos.Column - 1);
            }

            // North-east
            pos.setValues(Position.Line - 1, Position.Column = +1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = -1, pos.Column + 1);
            }

            // South-east
            pos.setValues(Position.Line + 1, Position.Column = +1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = +1, pos.Column + 1);
            }

            // Southweast
            pos.setValues(Position.Line + 1, Position.Column = -1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = +1, pos.Column - 1);
            }
            return mat;
        }
    }
}
