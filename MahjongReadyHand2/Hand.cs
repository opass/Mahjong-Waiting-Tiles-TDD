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
            return new DistinctTilesTakenEyeGenerator(_tiles).GetAll()
                .Select(tiles => new ComposedByTripletAndSequenceDecider(tiles).Check())
                .Any(result => result);
        }
    }
}