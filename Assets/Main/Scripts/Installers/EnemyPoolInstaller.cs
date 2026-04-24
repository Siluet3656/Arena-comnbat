using Main.Scripts.Enemy;
using Main.Scripts.Pooling;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Installers
{
    public class EnemyPoolInstaller : MonoInstaller
    {
        [SerializeField] private EnemyView _enemyPrefab;
        [SerializeField] private Transform _enemyContainer;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<EnemyView, EnemyPool>()
                .WithInitialSize(5)
                .FromComponentInNewPrefab(_enemyPrefab)
                .UnderTransform(_enemyContainer)
                .AsCached();
        }
    }
}