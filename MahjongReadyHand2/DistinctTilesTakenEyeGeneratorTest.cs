using System;
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

        [TestMethod]
        public void tiles_without_eyes_return_empty_collection()
        {
            GivenTiles("D1,D2,D3");
            ShouldGenerateEmptyCollection();
        }

        private void ShouldGenerateEmptyCollection()
        {
            var tilesCollection = new DistinctTilesTakenEyeGenerator(_tiles).GetAll();
            tilesCollection.Should().BeEmpty();
        }

        private void GivenTiles(string tiles)
        {
            _tiles = TileFactory.CreateTiles(tiles);
        }

        [TestMethod]
        public void only_two_same_tiles_should_return_collection_with_one_empty_tiles()
        {
            GivenTiles("D1,D1");
            ShouldBeEquivalentToCollection(new[] {Enumerable.Empty<Tile>()});
        }

        private void ShouldBeEquivalentToCollection(IEnumerable<IEnumerable<Tile>> expectations)
        {
//            example:
//            var t1 = new []
//            {
//                new [] {1,2,3},
//                new [] {4,5,6}
//            };
//            var t2 = new []
//            {
//                new [] {4,5,6},
//                new [] {1,3,2}
//            };
//            t1.Should().BeEquivalentTo(t2);   // true, order doesn't matter
            var tilesCollection = new DistinctTilesTakenEyeGenerator(_tiles).GetAll();
            tilesCollection.Should().BeEquivalentTo(expectations);
        }

        [TestMethod]
        public void D1114_should_return_collection_with_D14()
        {
            GivenTiles("D1,D1,D1,D4");
            ShouldBeEquivalentToCollection(new[] {TileFactory.CreateTiles("D1,D4")});
        }
    }
}