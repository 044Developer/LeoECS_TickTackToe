using System.Collections;
using System.Collections.Generic;
using Leopotam.Ecs;
using NUnit.Framework;
using TickToe.Core.Components;
using TickToe.Core.Enums;
using TickToe.Extensions.Dictionary;
using UnityEngine;
using UnityEngine.TestTools;

namespace TickToe.Editor.GameLogic
{
    [TestFixture]
    public class GameLogicTests
    {
        [Test]
        public void CheckHorizontalChainZero()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };
            
            var chainLength = cells.GetLongestChain(Vector2Int.zero);
            Assert.AreEqual(0, chainLength);
        }
        
        [Test]
        public void CheckHorizontalChainOne()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            cells[Vector2Int.zero].Get<Taken>().Value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(Vector2Int.zero);
            Assert.AreEqual(1, chainLength);
        }
        
        [Test]
        public void CheckHorizontalChainTwoLeft()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            cells[new Vector2Int(2, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().Value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(2, 0));
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckHorizontalChainTwoRight()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            cells[new Vector2Int(2, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 0)].Get<Taken>().Value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(1, 0));
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckVerticalChainTwo()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            cells[new Vector2Int(0, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(0, 1)].Get<Taken>().Value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0));
            Assert.AreEqual(2, chainLength);
        }
        
        [Test]
        public void CheckVerticalChainDiagonalOne()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            cells[new Vector2Int(0, 0)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(2, 2)].Get<Taken>().Value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(0, 0));
            Assert.AreEqual(3, chainLength);
        }
        
        [Test]
        public void CheckVerticalChainDiagonalTwo()
        {
            var world = new EcsWorld();

            Dictionary<Vector2Int, EcsEntity> cells = new Dictionary<Vector2Int, EcsEntity>()
            {
                {new Vector2Int(0, 0), CreateCell(world, new Vector2Int(0, 0))},
                {new Vector2Int(0, 1), CreateCell(world, new Vector2Int(0, 1))},
                {new Vector2Int(0, 2), CreateCell(world, new Vector2Int(0, 2))},
                {new Vector2Int(1, 0), CreateCell(world, new Vector2Int(1, 0))},
                {new Vector2Int(1, 1), CreateCell(world, new Vector2Int(1, 1))},
                {new Vector2Int(1, 2), CreateCell(world, new Vector2Int(1, 2))},
                {new Vector2Int(2, 0), CreateCell(world, new Vector2Int(2, 0))},
                {new Vector2Int(2, 1), CreateCell(world, new Vector2Int(2, 1))},
                {new Vector2Int(2, 2), CreateCell(world, new Vector2Int(2, 2))},
            };

            cells[new Vector2Int(0, 2)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(1, 1)].Get<Taken>().Value = SignType.Cross;
            cells[new Vector2Int(2, 0)].Get<Taken>().Value = SignType.Cross;
            
            var chainLength = cells.GetLongestChain(new Vector2Int(1, 1));
            Assert.AreEqual(3, chainLength);
        }

        private static EcsEntity CreateCell(EcsWorld world, Vector2Int position)
        {
            var entity = world.NewEntity();
            entity.Get<Position>().Value = position;
            entity.Get<Cell>();

            return entity;
        }
    }
}
