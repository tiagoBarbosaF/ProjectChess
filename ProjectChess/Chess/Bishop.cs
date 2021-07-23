using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class Bishop : Piece
    {
        public Bishop(BoardGame Brdg, Color color) : base(color, Brdg)
        {

        }

        public override string ToString()
        {
            return "B";
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

            // Northweast
            pos.setValues(Position.Line - 1, Position.Column = - 1);
            while(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = - 1, pos.Column - 1);
            }

            // North-east
            pos.setValues(Position.Line - 1, Position.Column = + 1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = - 1, pos.Column + 1);
            }

            // South-east
            pos.setValues(Position.Line + 1, Position.Column = + 1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = + 1, pos.Column + 1);
            }

            // Southweast
            pos.setValues(Position.Line + 1, Position.Column = - 1);
            while (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if (Brdg.piece(pos) != null && Brdg.piece(pos).Color != Color)
                {
                    break;
                }
                pos.setValues(pos.Line = + 1, pos.Column - 1);
            }
            return mat;
        }
    }
}
