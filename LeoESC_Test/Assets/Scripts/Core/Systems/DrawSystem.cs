using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.UnityComponents;

namespace TickToe.Core.Systems
{
    public class DrawSystem : IEcsRunSystem
    {
        private EcsFilter<Cell>.Exclude<Taken> _freeCells = null;
        private EcsFilter<Winner> _winner = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            if (_freeCells.IsEmpty() && _winner.IsEmpty()) 
                _sceneData.UIController.LooseScreen.Show(true);
        }
    }
}