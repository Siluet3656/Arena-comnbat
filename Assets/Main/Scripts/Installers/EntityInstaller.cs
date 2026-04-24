using UnityEngine;
using Zenject;

namespace Main.Scripts.Installers
{
    public class EntityInstaller: MonoInstaller
    {
        [SerializeField] private Player _player;
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
            
            //CMSEntity data = CMS.Get<CMSEntity>(Models.Enemy1);
            //EnemyModel model = new EnemyModel(data);
            
            //Container.Bind<EnemyMovement>().AsSingle();
            //Container.Bind<EnemyModel>().FromInstance(model).AsSingle();
            //Container.Bind<EnemyController>().AsSingle();
        }
    }
}