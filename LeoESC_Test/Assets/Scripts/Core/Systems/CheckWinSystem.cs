using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Extensions.Dictionary;
using TickToe.Scripts;

namespace TickToe.Core.Systems
{
    public class CheckWinSystem : IEcsRunSystem
    {
        private EcsFilter<Position, Taken, CheckWinEvent> _filter = null;
        private GameState _gameState = null;
        private Configuration _configuration = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var position = ref _filter.Get1(index);

                var chainLength = _gameState.Cells.GetLongestChain(position.Value);

                if (chainLength >= _configuration.MinChainLength) 
                    _filter.GetEntity(index).Get<Winner>();
            }
        }
    }
}