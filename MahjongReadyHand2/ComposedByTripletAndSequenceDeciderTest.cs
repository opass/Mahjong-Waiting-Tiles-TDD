using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class ComposedByTripletAndSequenceDeciderTest
    {
        private IEnumerable<Tile> _tiles;

        [TestMethod]
        public void empty_tiles_case_pass()
        {
            GivenTiles("");
            ShouldComposedByTripletAndSequence();
        }

        [TestMethod]
        public void triplet_tiles_pass()
        {
            GivenTiles("D1,D1,D1");
            ShouldComposedByTripletAndSequence();
        }

        private void ShouldComposedByTripletAndSequence()
        {
            new ComposedByTripletAndSequenceDecider(_tiles).Check().Should().BeTrue();
        }

        private void GivenTiles(string tilesString)
        {
            _tiles = TileFactory.CreateTiles(tilesString);
        }
    }
}