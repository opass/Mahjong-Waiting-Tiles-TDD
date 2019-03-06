using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MahjongReadyHand2
{
    public class Hand
    {
        private IEnumerable<Tile> _tiles;

        public Hand(string tilesString)
        {
            _tiles = tilesString.Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(tileString => new Tile(tilesString));
        }

        public IEnumerable<Tile> GetWaitingTiles()
        {
            return PossibleWaitingTilesGenerator.PossibleWaitingTiles(_tiles)
                .Select(tile =>
                    (tile: tile, isWinning: new WinningDecider(_tiles.Append(tile)).IsWinning()))
                .Where(tuple => tuple.isWinning)
                .Select(tuple => tuple.tile);
        }
    }

    public class WinningDecider
    {
        private readonly IEnumerable<Tile> _tiles;

        public WinningDecider(IEnumerable<Tile> tiles)
        {
            _tiles = tiles;
        }

        public bool IsWinning()
        {
            var count = _tiles.Count();
            if (count == 0 || count == 2)
            {
                return true;
            }

            return false;
        }
    }
}