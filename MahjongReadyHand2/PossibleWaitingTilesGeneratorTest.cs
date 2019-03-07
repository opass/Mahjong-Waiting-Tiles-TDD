using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class PossibleWaitingTilesGeneratorTest
    {
        private IEnumerable<Tile> _possibleWaitingTiles;

        [TestMethod]
        public void no_tiles_generate_no_possible_waiting_tiles()
        {
            _possibleWaitingTiles = CalculatePossibleWaitingTiles(Enumerable.Empty<Tile>());
            _possibleWaitingTiles.Should().BeEmpty();
        }

        private static IEnumerable<Tile> CalculatePossibleWaitingTiles(IEnumerable<Tile> tiles)
        {
            return PossibleWaitingTilesGenerator.PossibleWaitingTiles(tiles);
        }

        [TestMethod]
        public void tiles_themselves_are_also_possible_waiting_tiles()
        {
            var tiles = new[]
            {
                new Tile("D1"),
                new Tile("D5"),
                new Tile("D9"),
            };

            _possibleWaitingTiles = CalculatePossibleWaitingTiles(tiles);
            tiles.Should().BeSubsetOf(_possibleWaitingTiles);
        }

        [TestMethod]
        public void possible_waiting_tiles_should_have_only_unique_tiles()
        {
            var tiles = new[]
            {
                new Tile("D1"),
                new Tile("D1"),
            };

            _possibleWaitingTiles = CalculatePossibleWaitingTiles(tiles);
            _possibleWaitingTiles.Should().OnlyHaveUniqueItems();
        }

        [TestMethod]
        public void possible_waiting_tiles_should_include_sibling()
        {
            _possibleWaitingTiles = CalculatePossibleWaitingTiles(TileFactory.CreateTiles("D2,D3"));
            _possibleWaitingTiles.Should().Contain(TileFactory.CreateTiles("D1,D4"));
        }
    }
}