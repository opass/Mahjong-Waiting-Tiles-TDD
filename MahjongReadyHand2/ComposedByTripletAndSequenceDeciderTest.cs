using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class ComposedByTripletAndSequenceDeciderTest
    {
        [TestMethod]
        public void empty_tiles_case_pass()
        {
            var emptyTiles = TileFactory.CreateTiles("");
            new ComposedByTripletAndSequenceDecider(emptyTiles).Check().Should().BeTrue();
        }

        [TestMethod]
        public void triplet_tiles_pass()
        {
        }
    }
}