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
            var emptyTiles = Enumerable.Empty<Tile>();
            new ComposedByTripletAndSequenceDecider(emptyTiles).Check().Should().BeTrue();
        }
    }
}