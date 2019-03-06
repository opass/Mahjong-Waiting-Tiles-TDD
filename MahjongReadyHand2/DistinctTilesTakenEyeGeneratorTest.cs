using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class DistinctTilesTakenEyeGeneratorTest
    {
        [TestMethod]
        public void no_tiles_return_empty_collection()
        {
            var tilesCollection = new DistinctTilesTakenEyeGenerator(Enumerable.Empty<Tile>()).GetAll();
            tilesCollection.Should().BeEmpty();
        }
    }
}