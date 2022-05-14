using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.UnityComponents;

namespace TickToe.Core.Systems
{
    public class WinSystem : IEcsRunSystem
    {
        private EcsFilter<Winner, Taken> _filter = null;
        private SceneData _sceneData = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                if (_sceneData.UIController.WinScreen.gameObject.activeSelf)
                    return;

                ref var winner = ref _filter.Get2(index);
                _sceneData.UIController.WinScreen.Show(true);
                _sceneData.UIController.WinScreen.SetWinner(winner.Value);
            }
        }
    }
}