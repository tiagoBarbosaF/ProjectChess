using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class Tower : Piece
    {
        public Tower(Color color, BoardGame brd) : base(color, brd)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        private bool canMove(Position pos)
        {
            Piece p = Brd.piece(pos);
            return p == null || p.Color != Color;
        }

        public override bool[,] possibleMoviments()
        {
            bool[,] mat = new bool[Brd.Lines, Brd.Columns];

            Position pos = new Position(0, 0);

            // above
            pos.setValues(Position.Line - 1, Position.Column);
            while (Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Brd.piece(pos) != null && Brd.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line - 1;
            }

            // right
            pos.setValues(Position.Line, Position.Column + 1);
            while(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Brd.piece(pos) != null && Brd.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column + 1;
            }

            // south
            pos.setValues(Position.Line + 1, Position.Column);
            while(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Brd.piece(pos) != null && Brd.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Line = pos.Line + 1;
            }

            // left
            pos.setValues(Position.Line, Position.Column - 1);
            while(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
                if(Brd.piece(pos) != null && Brd.piece(pos).Color != Color)
                {
                    break;
                }
                pos.Column = pos.Column - 1;
            }

            return mat;
        }
    }
}
