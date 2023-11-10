using PetProject.Player;
using Zenject;

namespace PetProject.Installers
{
    public class PlayerInstaller : Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .BindFactory<PlayerView, PlayerView.Factory>()
                .FromComponentInNewPrefabResource("Player");

            Container
                .Bind<PlayerAnimation>()
                .AsSingle();

            Container
                .Bind<PlayerMovement>()
                .AsSingle();

            Container
                .Bind<PlayerController>()
                .AsSingle()
                .NonLazy();
        }
    }
}