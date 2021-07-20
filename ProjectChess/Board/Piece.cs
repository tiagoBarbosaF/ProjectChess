namespace ProjectChess.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMoves { get; protected set; }
        public BoardGame Brd { get; protected set; }

        public Piece(Color color, BoardGame brd)
        {
            Position = null;
            Color = color;
            Brd = brd;
            QtdMoves = 0;
        }
    }
}
