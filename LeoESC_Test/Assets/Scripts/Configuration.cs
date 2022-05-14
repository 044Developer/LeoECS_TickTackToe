using TickToe.Core.UnityComponents;
using UnityEngine;

namespace TickToe.Scripts
{
    [CreateAssetMenu]
    public class Configuration : ScriptableObject
    {
        public int LevelWidth = 3;
        public int LevelHeight = 3;
        public int MinChainLength = 3;

        public CellView CellView = null;
        public Vector2 Offset = Vector2.zero;

        public MainCamera MainCamera = null;
        public SignView CrossSignPrefab = null;
        public SignView CircleSignPrefab = null;
    }
}