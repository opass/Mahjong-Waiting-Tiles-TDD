using System.Collections.Generic;
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

        [TestMethod]
        public void tiles_without_eyes_return_empty_collection()
        {
            var tiles = new[]
            {
                new Tile("D1"),
                new Tile("D2"),
                new Tile("D3"),
            };
            var tilesCollection = new DistinctTilesTakenEyeGenerator(tiles).GetAll();
            tilesCollection.Should().BeEmpty();
        }

        [TestMethod]
        public void only_two_same_tiles_should_return_collection_with_one_empty_tiles()
        {
            var tiles = new[]
            {
                new Tile("D1"),
                new Tile("D1"),
            };
            var tilesCollection = new DistinctTilesTakenEyeGenerator(tiles).GetAll();
            var collection = tilesCollection as IEnumerable<Tile>[] ?? tilesCollection.ToArray();
            collection.Should().ContainSingle();
            collection.Single().Should().BeEmpty();
        }
        
        
    }
}