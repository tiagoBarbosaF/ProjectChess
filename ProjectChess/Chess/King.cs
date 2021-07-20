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
    }
}
