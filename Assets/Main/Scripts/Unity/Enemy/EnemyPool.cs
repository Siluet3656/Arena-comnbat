using Zenject;

namespace Main.Scripts.Unity.Enemy
{
    public class EnemyPool : MonoMemoryPool<EnemyView>
    {
        protected override void OnSpawned(EnemyView item)
        {
            item.gameObject.SetActive(true);
        }

        protected override void OnDespawned(EnemyView item)
        {
            item.gameObject.SetActive(false);
        }
    }
}