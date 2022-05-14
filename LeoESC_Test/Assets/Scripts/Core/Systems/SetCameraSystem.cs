using Leopotam.Ecs;
using TickToe.Core.Components;
using TickToe.Core.UnityComponents;
using TickToe.Scripts;
using UnityEngine;

namespace TickToe.Core.Systems
{
    public class SetCameraSystem : IEcsInitSystem
    {
        private EcsWorld _ecsWorld = null;
        private SceneData _sceneData = null;
        private Configuration _configuration = null;

        public void Init()
        {
            var height = _configuration.LevelHeight;
            var width = _configuration.LevelWidth;
            var offset = _configuration.Offset;

            var horizontalOffset = width / 2f + (width - 1) * offset.x / 2;
            var verticalOffset = height / 2f + (height - 1) * offset.y / 2;
            
            var mainCamera = Object.Instantiate(_configuration.MainCamera).GetComponent<MainCamera>();
            
            ref var camera = ref _ecsWorld.NewEntity().Get<CameraMain>();
            camera.Camera = mainCamera.Camera;
            camera.CameraTransform = mainCamera.CameraTransform;
            
            camera.Camera.orthographic = true;
            camera.Camera.orthographicSize = verticalOffset;
            camera.CameraTransform.position = new Vector3(horizontalOffset, verticalOffset);
        }
    }
}