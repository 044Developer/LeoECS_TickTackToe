using Leopotam.Ecs;
using TickToe.Core;
using TickToe.Core.Components;
using TickToe.Core.Systems;
using TickToe.Core.UnityComponents;
using TickToe.Scripts;
using UnityEngine;

sealed class EcsStartup : MonoBehaviour 
{
    public Configuration Configuration = null;
    public SceneData SceneData = null;
    
    private EcsWorld _world = null;
    private EcsSystems _systems = null;

    private void Start () 
    {
        _world = new EcsWorld ();
        _systems = new EcsSystems (_world);
        var gameState = new GameState();
#if UNITY_EDITOR
        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
        _systems
            .Add (new InitializeFieldSystem ())
            .Add (new CreateCellViewSystem ())
            .Add (new SetCameraSystem ())
            .Add (new ControlSystem ())
            .Add (new AnalyzeClickSystem ())
            .Add (new CreateTakenViewSystem ())
            .Add (new CheckWinSystem ())
            .Add (new WinSystem ())
            .Add (new DrawSystem ())
            .OneFrame<UpdateCameraEvent>()
            .OneFrame<Clicked>()
            .OneFrame<CheckWinEvent>()
            .Inject (Configuration)
            .Inject (SceneData)
            .Inject (gameState)
            .Init ();
    }

    private void Update ()
    {
        _systems?.Run ();
    }

    private void OnDestroy () 
    {
        if (_systems != null) 
        {
            _systems.Destroy ();
            _systems = null;
            _world.Destroy ();
            _world = null;
        }
    }
}