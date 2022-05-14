using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.UnityComponents;
using UnityEngine;

namespace TickToe.Core.Systems
{
    public class ControlSystem : IEcsRunSystem
    {
        private SceneData _sceneData = null;
        private EcsFilter<CameraMain> _filter = null;

        public void Run()
        {
            if (!Input.GetMouseButtonDown(0))
                return;
            
            foreach (int index in _filter)
            {
                ref var camera = ref _filter.Get1(index);
                var ray = camera.Camera.ScreenPointToRay(Input.mousePosition);

                if (!Physics.Raycast(ray, out var hitInfo)) 
                    continue;
                
                var cellView = hitInfo.collider.GetComponent<CellView>();
                if (cellView)
                {
                    cellView.Entity.Get<Clicked>();
                }
            }
        }
    }
}