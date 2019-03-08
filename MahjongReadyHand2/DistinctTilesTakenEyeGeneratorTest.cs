using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MahjongReadyHand2
{
    [TestClass]
    public class DistinctTilesTakenEyeGeneratorTest
    {
        private IEnumerable<Tile> _tiles;

        [TestMethod]
        public void no_tiles_return_empty_collection()
        {
            GivenTiles("");
            ShouldGenerateEmptyCollection();
        }

        private void ShouldGenerateEmptyCollection()
        {
            var tilesCollection = new DistinctTilesTakenEyeGenerator(_tiles).GetAll();
            tilesCollection.Should().BeEmpty();
        }

        [TestMethod]
        public void tiles_without_eyes_return_empty_collection()
        {
            GivenTiles("D1,D2,D3");
            ShouldGenerateEmptyCollection();
        }

        private void GivenTiles(string tiles)
        {
            _tiles = TileFactory.CreateTiles(tiles);
        }

        [TestMethod]
        public void only_two_same_tiles_should_return_collection_with_one_empty_tiles()
        {
            GivenTiles("D1,D1");
            var tilesCollection = new DistinctTilesTakenEyeGenerator(_tiles).GetAll();
            var collection = tilesCollection as IEnumerable<Tile>[] ?? tilesCollection.ToArray();
            collection.Should().ContainSingle();
            collection.Single().Should().BeEmpty();
        }

        [TestMethod]
        public void D1114_should_return_collection_with_D14()
        {
            GivenTiles("D1,D1,D1,D4");
            var tilesCollection = new DistinctTilesTakenEyeGenerator(_tiles).GetAll();
            var collection = tilesCollection as IEnumerable<Tile>[] ?? tilesCollection.ToArray();
            collection.Should().ContainSingle();
            collection.Single().Should().BeEquivalentTo(new Tile("D1"), new Tile("D4"));
        }
    }
}