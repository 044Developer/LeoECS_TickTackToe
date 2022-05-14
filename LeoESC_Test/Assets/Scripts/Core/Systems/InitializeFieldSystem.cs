using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Scripts;
using UnityEngine;

namespace TickToe.Core.Systems
{
    internal class InitializeFieldSystem : IEcsInitSystem
    {
        private Configuration _configuration = null;
        private EcsWorld _ecsWorld = null;
        private GameState _gameState = null;
        
        public void Init()
        {
            for (int x = 0; x < _configuration.LevelWidth; x++)
            {
                for (int y = 0; y < _configuration.LevelHeight; y++)
                {
                    var cellEntity = _ecsWorld.NewEntity();
                    cellEntity.Get<Cell>();
                    var position = new Vector2Int(x, y);
                    cellEntity.Get<Position>().Value = new Vector2Int(x, y);
                    
                    _gameState.Cells.Add(position, cellEntity);
                }
            }
            
            _ecsWorld.NewEntity().Get<UpdateCameraEvent>();
        }
    }
}