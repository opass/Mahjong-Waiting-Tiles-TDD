using System;
using System.Collections.Generic;
using System.Data;
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
            {"R", Suit.RedDragon},
            {"G", Suit.GreenDragon},
            {"Z", Suit.WhiteDragon},
        };

        public Tile(string tileString)
        {
            Suit = SuitParsingTable[tileString.Substring(0, 1)];
            Rank = IsNumberTile() ? int.Parse(tileString.Substring(1, 1)) : 0;
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

        public override string ToString()
        {
            var suitPart = SuitParsingTable.FirstOrDefault(kvp => kvp.Value == Suit).Key;
            return IsNumberTile() ? $"{suitPart}{Rank}" : suitPart;
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

        public Tile PreviousRankTile()
        {
            var nextRank = Rank - 1;
            if (nextRank >= 1)
            {
                return new Tile(Suit, nextRank);
            }

            throw new InvalidOperationException();
        }

        public bool IsNumberTile()
        {
            return Suit == Suit.Bamboo || Suit == Suit.Character || Suit == Suit.Dot;
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
        South,
        RedDragon,
        GreenDragon,
        WhiteDragon
    }
}