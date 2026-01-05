using Main.Scripts.Domain.Combat;
using Main.Scripts.Domain.Signals;
using Main.Scripts.Domain.Weapons;
using Main.Scripts.Unity.Enemy;
using Zenject;

namespace Main.Scripts.Installers
{
    public class GameInstaller : MonoInstaller
    {
        public EnemyView _enemyPrefab;
        public override void InstallBindings()  
        {
            Container.Bind<IHealth>()
                .To<Health>()
                .AsTransient()
                .WithArguments(100);
        
            Container.Bind<IWeapon>().To<Gun>().AsSingle();
        
            Container.DeclareSignal<EntityDiedSignal>();
            
            Container.BindMemoryPool<EnemyView, EnemyPool>()
                .WithInitialSize(10)
                .FromComponentInNewPrefab(_enemyPrefab)
                .AsSingle();
        }
    }
}