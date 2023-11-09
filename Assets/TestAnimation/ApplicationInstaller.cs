using Zenject;

namespace PetProject.Installers
{
    public class ApplicationInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            PlayerInstaller.Install(Container);
            MiscInstaller.Install(Container);

            Container
                .Bind<GameController>()
                .AsSingle()
                .NonLazy();
        }
    }
}