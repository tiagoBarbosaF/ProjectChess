namespace ProjectChess.Board
{
    abstract class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMoves { get; protected set; }
        public BoardGame Brdg { get; protected set; }

        public Piece(Color color, BoardGame brdg)
        {
            Position = null;
            Color = color;
            Brdg = brdg;
            QtdMoves = 0;
        }

        public bool existPossibleMoviments()
        {
            bool[,] mat = possibleMoviments();
            for (int i = 0; i < Brdg.Lines; i++)
            {
                for (int j = 0; j < Brdg.Columns; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool canMoveFor(Position pos)
        {
            return possibleMoviments()[pos.Line, pos.Column];
        }

        public abstract bool[,] possibleMoviments();

        public void incrementQteMoviments()
        {
            QtdMoves++;
        }

        public void decrementQteMoviments()
        {
            QtdMoves--;
        }
    }
}
