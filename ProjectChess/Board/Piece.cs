namespace ProjectChess.Board
{
    class Piece
    {
        public Position Position { get; set; }
        public Color Color { get; protected set; }
        public int QtdMoves { get; protected set; }
        public BoardGame Brd { get; protected set; }

        public Piece(Position position, Color color, BoardGame brd)
        {
            Position = position;
            Color = color;
            Brd = brd;
            QtdMoves = 0;
        }
    }
}
