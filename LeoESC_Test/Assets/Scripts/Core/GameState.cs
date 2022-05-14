using System.Collections.Generic;
using Leopotam.Ecs;
using TickToe.Core.Enums;
using UnityEngine;

namespace TickToe.Core
{
    public class GameState
    {
        public SignType CurrentSign = SignType.Circle;
        public readonly Dictionary<Vector2Int, EcsEntity> Cells = new Dictionary<Vector2Int, EcsEntity>();
    }
}