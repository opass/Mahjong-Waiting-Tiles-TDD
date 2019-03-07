using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            if (!(1 <= rank && rank <= 9))
            {
                throw new ArgumentException("Rank should be between 1 to 9");
            }
            
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

        public Tile NextRankTile()
        {
            var nextRank = Rank + 1;
            if (nextRank <= 9)
            {
                return new Tile(Suit, nextRank);
            }

            throw new InvalidOperationException();
        }

        public Suit Suit { get; }

        public virtual bool IsValid()
        {
            return false;
        }

        public Tile PreviousRankTile()
        {
            var nextRank = Rank - 1;
            if (nextRank >= 1)
            {
                return new Tile(Suit, nextRank);
            }

            throw new InvalidOperationException();
        }
    }

    public enum Suit
    {
        Dot,
    }
}