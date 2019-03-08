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

        [TestMethod]
        public void four_same_tiles_fail()
        {
            GivenTiles("D1,D1,D1,D1");
            ShouldNotComposedByTripletAndSequence();
        }

        [TestMethod]
        public void D144_should_fail()
        {
            GivenTiles("D1,D4,D4");
            ShouldNotComposedByTripletAndSequence();
        }

        [TestMethod]
        public void D123_should_pass()
        {
            GivenTiles("D1,D2,D3");
            ShouldComposedByTripletAndSequence();
        }

        [TestMethod]
        public void D889_should_fail()
        {
            GivenTiles("D8,D8,D9");
            ShouldNotComposedByTripletAndSequence();
        }

        [TestMethod]
        public void D333678_should_pass()
        {
            GivenTiles("D3,D3,D3,D6,D7,D8");
            ShouldComposedByTripletAndSequence();
        }

        [TestMethod]
        public void D135B246_should_fail()
        {
            GivenTiles("D1,D3,D5,B2,B4,B6");
            ShouldNotComposedByTripletAndSequence();
        }

        private void ShouldComposedByTripletAndSequence()
        {
            new ComposedByTripletAndSequenceDecider().Check(_tiles).Should().BeTrue();
        }

        private void ShouldNotComposedByTripletAndSequence()
        {
            new ComposedByTripletAndSequenceDecider().Check(_tiles).Should().BeFalse();
        }

        private void GivenTiles(string tilesString)
        {
            _tiles = TileFactory.CreateTiles(tilesString);
        }
    }
}