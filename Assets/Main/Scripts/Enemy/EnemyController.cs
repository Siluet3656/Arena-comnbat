using System;
using Main.Scripts.Signals;
using R3;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Enemy
{
    public class EnemyController: IInitializable, IDisposable
    {
        private readonly SignalBus signalBus;
        
        private EnemyMovement movement;
        
        private readonly CompositeDisposable disposables = new();

        public EnemyModel Model { get; }

        public EnemyController(EnemyModel model, SignalBus Bus)
        {
            Model = model;
            signalBus = Bus;
        }

        public void BindView(CharacterController cc, Transform enemyTransform, Transform playerTransform)
        {
            movement = new EnemyMovement(cc, enemyTransform, Model);
            movement.SetTarget(playerTransform);
            
            Model.IsAlive
                .Where(alive => !alive)
                .Subscribe(_ => OnDeath())
                .AddTo(disposables);
        }

        public Vector3 CalculateMovementDelta()
        {
            if (Model.IsAlive.CurrentValue)
                return movement.CalculateMovementDelta();
            return Vector3.zero;
        }

        public void ApplyDamage(int rawDamage)
        {
            if (!Model.IsAlive.CurrentValue)
                return;

            int finalDamage = Mathf.Max(0, rawDamage - Model.Armor);
            Model.Health.Value = Mathf.Max(0, Model.Health.Value - finalDamage);
        }

        private void OnDeath()
        {
            signalBus.Fire(new SignalEnemyDeath { EnemyId = Model.Id });
        }
        
        public void Initialize()
        {
            
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}