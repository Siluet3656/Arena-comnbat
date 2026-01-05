using Main.Scripts.Unity.Enemy;
using Zenject;

namespace Main.Scripts.Systems
{
    public abstract class EnemySpawnSystem
    {
        EnemyPool _pool;

        [Inject]
        public void Construct(EnemyPool pool)
        {
            _pool = pool;
        }

        public void SpawnEnemy()
        {
            var enemy = _pool.Spawn();
        }

        public void DespawnEnemy(EnemyView enemy)
        {
            _pool.Despawn(enemy);
        }
    }
}