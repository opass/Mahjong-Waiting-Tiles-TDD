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
            CalculateWaitingTiles("D1,D5,D9");
            _possibleWaitingTiles.Should().Contain(TileFactory.CreateTiles("D1,D5,D9"));
        }

        [TestMethod]
        public void possible_waiting_tiles_should_have_only_unique_tiles()
        {
            CalculateWaitingTiles("D1,D1");
            _possibleWaitingTiles.Should().OnlyHaveUniqueItems();
        }

        [TestMethod]
        public void possible_waiting_tiles_should_include_sibling()
        {
            CalculateWaitingTiles("D2,D3");
            _possibleWaitingTiles.Should().Contain(TileFactory.CreateTiles("D1,D4"));
        }

        [TestMethod]
        public void possible_waiting_tiles_should_exclude_4_tiles()
        {
            CalculateWaitingTiles("D3,D3,D3,D3");
            _possibleWaitingTiles.Should().NotContain(TileFactory.CreateTiles("D3"));
        }

        private void CalculateWaitingTiles(string tiles)
        {
            _possibleWaitingTiles = CalculatePossibleWaitingTiles(TileFactory.CreateTiles(tiles));
        }
    }
}