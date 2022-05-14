using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.Enums;

namespace TickToe.Core.Systems
{
    public class AnalyzeClickSystem : IEcsRunSystem
    {
        private EcsFilter<Cell, Clicked>.Exclude<Taken> _filter = null;
        private GameState _gameState = null;
        
        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var freeCell = ref _filter.GetEntity(index);
                freeCell.Get<Taken>().Value = _gameState.CurrentSign;
                freeCell.Get<CheckWinEvent>();

                _gameState.CurrentSign = _gameState.CurrentSign == SignType.Cross ? SignType.Circle : SignType.Cross;
            }
        }
    }
}