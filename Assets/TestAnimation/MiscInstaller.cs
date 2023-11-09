using PetProject.Camera;
using UnityEngine;
using Zenject;

namespace PetProject.Installers
{
    public class MiscInstaller : Installer<MiscInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<Light>()
                .FromComponentInNewPrefabResource("Directional Light")
                .AsSingle()
                .NonLazy();

            Container
                .BindFactory<CameraView, CameraView.Factory>()
                .FromComponentInNewPrefabResource("Main Camera");

            Container
                .Bind<CameraController>()
                .AsSingle()
                .NonLazy();
        }
    }
}