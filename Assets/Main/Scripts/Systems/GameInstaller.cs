using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IHealth>()
            .To<Health>()
            .AsTransient()
            .WithArguments(100);
    }
}