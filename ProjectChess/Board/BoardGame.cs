namespace ProjectChess.Board
{
    class BoardGame
    {
        public int Lines { get; set; }
        public int Columns { get; set; }
        public Piece[,] Pieces { get; set; }

        public BoardGame(int lines, int columns)
        {
            Lines = lines;
            Columns = columns;
            Pieces = new Piece[Lines,Columns];
        }

        public Piece piece (int line, int column)
        {
            return Pieces[line, column];
        }

        public Piece piece (Position pos)
        {
            return Pieces[pos.Line, pos.Column];
        }

        public bool existPiece (Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }

        public void placePiece(Piece p, Position pos)
        {
            if (existPiece(pos))
            {
                throw new BoardException("There is a Piece in this Position!");
            }
            Pieces[pos.Line, pos.Column] = p;
            p.Position = pos;
        }

        public bool validPosition(Position pos)
        {
            if (pos.Line < 0 || pos.Line >= Lines || pos.Column < 0 || pos.Column >= Columns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition (Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid Position!");
            }
        }
    }
}
