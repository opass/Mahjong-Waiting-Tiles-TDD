using System;
using System.Collections.Generic;

namespace MahjongReadyHand2
{
    public class Tile
    {
        private readonly string _tileString;

        private Dictionary<Suit, string> _suitStringMap = new Dictionary<Suit, string>
        {
            {Suit.Dot, "D"}
        };

        public Tile(string tileString)
        {
            _tileString = tileString;
            Rank = int.Parse(_tileString.Substring(1, 1));
        }

        public Tile(Suit suit, int rank)
        {
            Rank = rank;
            Suit = suit;
            _tileString = $"{_suitStringMap[suit]}{rank}";
        }

        public int Rank { get; }

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

        public Tile Next()
        {
            return new Tile(Suit, Rank + 1);
        }

        public Suit Suit { get; }
    }

    public enum Suit
    {
        Dot,
    }
}