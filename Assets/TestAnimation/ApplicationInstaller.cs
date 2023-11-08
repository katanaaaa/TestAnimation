using UnityEngine;
using Zenject;

public class ApplicationInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container
            .Bind<Light>()
            .FromComponentInNewPrefabResource("Directional Light")
            .AsSingle()
            .NonLazy();

        Container
            .Bind<Camera>()
            .FromComponentInNewPrefabResource("Main Camera")
            .AsSingle()
            .NonLazy();

        Container
            .Bind<PlayerView>()
            .FromComponentInNewPrefabResource("Player")
            .AsSingle()
            .NonLazy();
    }
}