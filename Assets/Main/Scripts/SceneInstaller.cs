using UnityEngine;
using Zenject;

namespace Main.Scripts
{
    public class SceneInstaller: MonoInstaller
    {
        [SerializeField] private Player _player;
        public override void InstallBindings()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle();
        }
    }
}