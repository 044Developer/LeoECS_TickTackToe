using System.Collections.Generic;
using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.Enums;
using UnityEngine;

namespace TickToe.Extensions.Dictionary
{
    public static class GameExtensions
    {
        public static int GetLongestChain(this Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position)
        {
            var startEntity = cells[position];

            if (!startEntity.Has<Taken>())
                return 0;

            var startType = startEntity.Ref<Taken>().Unref().Value;

            var directionOne = new Vector2Int(-1, 0);
            var directionTwo = new Vector2Int(1, 0);
            var horizontalLength = Count(cells, position, directionOne, startType, directionTwo);
            
            directionOne = new Vector2Int(0, -1);
            directionTwo = new Vector2Int(0, 1);
            var verticalLength = Count(cells, position, directionOne, startType, directionTwo);
            
            directionOne = new Vector2Int(-1, -1);
            directionTwo = new Vector2Int(1, 1);
            var diagonalOneLength = Count(cells, position, directionOne, startType, directionTwo);
            
            directionOne = new Vector2Int(-1, 1);
            directionTwo = new Vector2Int(1, -1);
            var diagonalTwoLength = Count(cells, position, directionOne, startType, directionTwo);

            return Mathf.Max(horizontalLength, verticalLength, diagonalOneLength, diagonalTwoLength);
        }

        private static int Count(Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position, Vector2Int direction, SignType startType, Vector2Int direction2)
        {
            var currentLength = 1;
            
            var firstDirection = CheckDirection(cells, position, direction, startType);
            currentLength += firstDirection;
            var secondDirection = CheckDirection(cells, position, direction2, startType);
            currentLength += secondDirection;

            return currentLength;
        }

        private static int CheckDirection(Dictionary<Vector2Int, EcsEntity> cells, Vector2Int position, Vector2Int direction, SignType startType)
        {
            var currentLength = 0;
            var currentPosition = position + direction;
            while (cells.TryGetValue(currentPosition, out var entity))
            {
                if (!entity.Has<Taken>())
                    break;

                var type = entity.Ref<Taken>().Unref().Value;

                if (type != startType)
                    break;

                currentLength++;
                currentPosition += direction;
            }

            return currentLength;
        }
    }
}