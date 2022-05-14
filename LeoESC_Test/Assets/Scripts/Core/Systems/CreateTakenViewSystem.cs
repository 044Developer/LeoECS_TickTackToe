using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.Enums;
using TickToe.Core.UnityComponents;
using TickToe.Scripts;
using UnityEngine;

namespace TickToe.Core.Systems
{
    public class CreateTakenViewSystem : IEcsRunSystem
    {
        private EcsFilter<Taken, CellViewRef>.Exclude<TakenRef> _filter = null;
        private Configuration _configuration = null;

        public void Run()
        {
            foreach (int index in _filter)
            {
                var position = _filter.Get2(index).Value.transform.position;
                var takenType = _filter.Get1(index).Value;

                SignView signView = null;
                
                switch (takenType)
                {
                    case SignType.Cross:
                        signView = _configuration.CrossSignPrefab;
                        break;
                    case SignType.Circle:
                        signView = _configuration.CircleSignPrefab;
                        break;
                }
                
                var instance = Object.Instantiate(signView, position, Quaternion.identity);
                _filter.GetEntity(index).Get<TakenRef>().Value = instance;
            }
        }
    }
}