using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace MahjongReadyHand2
{
    public class Tile
    {
        private static readonly Dictionary<string, Suit> SuitParsingTable = new Dictionary<string, Suit>
        {
            {"D", Suit.Dot},
            {"B", Suit.Bamboo},
            {"C", Suit.Character},
            {"N", Suit.North},
            {"E", Suit.East},
            {"W", Suit.West},
            {"S", Suit.South},
        };

        public Tile(string tileString)
        {
            Suit = SuitParsingTable[tileString.Substring(0, 1)];
            Rank = IsWind() ? 0 : int.Parse(tileString.Substring(1, 1));
        }

        public Tile(Suit suit, int rank)
        {
            if (!(1 <= rank && rank <= 9))
            {
                throw new ArgumentException("Rank should be between 1 to 9");
            }

            Rank = rank;
            Suit = suit;
        }

        public int Rank { get; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Tile);
        }

        public bool Equals(Tile other)
        {
            return Suit == other.Suit && Rank == other.Rank;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hash = 31;
                hash = hash * 23 + Rank.GetHashCode();
                hash = hash * 23 + Suit.GetHashCode();
                return hash;
            }
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

        public bool IsWind()
        {
            return new [] {Suit.North, Suit.East, Suit.West, Suit.South}.Contains(Suit);
        }
    }

    public enum Suit
    {
        Dot,
        Bamboo,
        Character,
        North,
        East,
        West,
        South
    }
}