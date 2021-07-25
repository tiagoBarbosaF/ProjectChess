using ProjectChess.Board;

namespace ProjectChess.Chess
{
    class Peon : Piece
    {
        public Peon(BoardGame Brdg, Color color) : base(color, Brdg)
        {

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
            }
            return mat;
        }
    }
}
