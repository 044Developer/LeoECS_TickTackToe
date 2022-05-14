using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Scripts;
using UnityEngine;

namespace TickToe.Core.Systems
{
    public class CreateCellViewSystem : IEcsRunSystem
    {
        private Configuration _configuration = null;
        private EcsFilter<Cell, Position>.Exclude<CellViewRef> _filter = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                ref var position = ref _filter.Get2(index);

                var cellView = Object.Instantiate(_configuration.CellView);
                cellView.Entity = _filter.GetEntity(index);
                cellView.transform.position = new Vector3(position.Value.x + _configuration.Offset.x * position.Value.x, position.Value.y + _configuration.Offset.y * position.Value.y);
                
                _filter.GetEntity(index).Get<CellViewRef>().Value = cellView;
            }
        }
    }
}