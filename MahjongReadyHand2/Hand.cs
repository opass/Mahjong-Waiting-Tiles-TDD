using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace MahjongReadyHand2
{
    public class Hand
    {
        private IEnumerable<Tile> _tiles;

        public Hand(string tilesString)
        {
            _tiles = TileFactory.CreateTiles(tilesString);
        }

        public IEnumerable<Tile> GetWaitingTiles()
        {
            return new PossibleWaitingTilesGenerator().GetAll(_tiles)
                .Select(tile =>
                    (tile: tile, isWinning: new WinningDecider().Check(_tiles.Append(tile))))
                .Where(tuple => tuple.isWinning)
                .Select(tuple => tuple.tile);
        }

        public override string ToString()
        {
            return string.Join(",", _tiles.OrderBy(tile => tile, new TileConventionComparer()));
        }
    }
}