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
    }
}
