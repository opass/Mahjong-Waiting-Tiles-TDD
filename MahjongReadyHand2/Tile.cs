namespace MahjongReadyHand2
{
    public class Tile
    {
        private readonly string _tileString;

        public Tile(string tileString)
        {
            _tileString = tileString;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tile);
        }

        public bool Equals(Tile other)
        {
            return _tileString == other._tileString;
        }

        public override int GetHashCode()
        {
            return _tileString.GetHashCode();
        }
    }
}