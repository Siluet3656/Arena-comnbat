using Main.Scripts.Domain.Combat;
using Main.Scripts.Domain.Signals;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Unity.Combat
{
    public class HealthView : MonoBehaviour
    {
        IHealth _health;
        SignalBus _signalBus;

        [Inject]
        public void Construct(IHealth health, SignalBus signalBus)
        {
            _health = health;
            _signalBus = signalBus;

            _health.Died += OnDied;
        }
    
        private void OnDied()
        {
            _signalBus.Fire(new EntityDiedSignal
            {
                Entity = gameObject
            });
        }

        private void OnDestroy()
        {
            if (_health != null)
                _health.Died -= OnDied;
        }

        public void Hit(int dmg)
        {
            _health.TakeDamage(dmg);
        }
    }
}