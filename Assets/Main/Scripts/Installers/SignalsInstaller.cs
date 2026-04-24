using Main.Scripts.Signals;
using R3;
using Zenject;

namespace Main.Scripts.Installers
{
    public class SignalsInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            ObservableSystem.DefaultFrameProvider = UnityFrameProvider.Update;
            
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<SignalEnemyDeath>();
        }
    }
}