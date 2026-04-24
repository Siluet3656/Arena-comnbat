using Main.Scripts.Enemy;
using Zenject;

namespace Main.Scripts.Pooling
{
    public class EnemyPool : MemoryPool<EnemySpawnParams, EnemyView>
    {
         private SignalBus signalBus;
         
        [Inject]
        private void Construct(SignalBus bus)
        {
            signalBus = bus;
        }
        
        protected override void Reinitialize(EnemySpawnParams spawnParams, EnemyView enemy)
        {
            base.Reinitialize(spawnParams, enemy);
            enemy.transform.position = spawnParams.Position;

            CMSEntity data = CMS.Get<CMSEntity>(spawnParams.EnemyTypeId);
            EnemyModel model = new EnemyModel(data);
            EnemyController controller = new EnemyController(model, signalBus);

            enemy.Initialize(controller);
        }

        protected override void OnDespawned(EnemyView enemy)
        {
            base.OnDespawned(enemy);
            enemy.Deinitialize();
        }
        
        protected override void OnSpawned(EnemyView enemy)
        {
            base.OnSpawned(enemy);
        }
    }
}