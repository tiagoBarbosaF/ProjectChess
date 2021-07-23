using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class Horse : Piece
    {
        public Horse(BoardGame Brdg, Color color) : base(color, Brdg)
        {

        }

        public override string ToString()
        {
            return "H";
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

            pos.setValues(Position.Line - 1, Position.Column - 2);
            if(Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line - 2, Position.Column - 1);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line - 2, Position.Column + 1);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line - 1, Position.Column + 2);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line + 1, Position.Column + 2);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line + 2, Position.Column + 1);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line + 2, Position.Column - 1);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            pos.setValues(Position.Line + 1, Position.Column - 2);
            if (Brdg.validPosition(pos) && canMove(pos))
            {
                mat[pos.Line, pos.Column] = true;
            }
            return mat;
        }
    }
}
