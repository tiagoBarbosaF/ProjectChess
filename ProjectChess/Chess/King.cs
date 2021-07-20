using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class King : Piece
    {
        public King(Color color, BoardGame brd) : base(color, brd)
        {
        }

        public override string ToString()
        {
            return "K";
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
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // north east
            pos.setValues(Position.Line - 1, Position.Column + 1);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // right
            pos.setValues(Position.Line, Position.Column + 1);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // southeast
            pos.setValues(Position.Line + 1, Position.Column + 1);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // south
            pos.setValues(Position.Line + 1, Position.Column);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // south-west
            pos.setValues(Position.Line + 1, Position.Column - 1);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // left
            pos.setValues(Position.Line, Position.Column - 1);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            // northwest
            pos.setValues(Position.Line - 1, Position.Column - 1);
            if(Brd.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }

            return mat;
        }
    }
}
