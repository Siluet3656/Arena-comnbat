using R3;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Enemy
{
    public class EnemyController
    {
        private readonly SignalBus signalBus;

        private CharacterController characterController;
        private Transform target;
        private Transform myTransform;
        private float verticalVelocity;
        
        public readonly ModelEnemy Model;
        
        private readonly CompositeDisposable disposables = new();
        
        public EnemyController(ModelEnemy model, SignalBus signalBus)
        {
            this.Model = model;
            this.signalBus = signalBus;
        }
        
        public void BindView(CharacterController controller, Transform enemyTransform, Transform playerTransform)
        {
            characterController = controller;
            myTransform = enemyTransform;
            target = playerTransform;
            
            Model.IsAlive
                .Subscribe(DeathCheck)
                .AddTo(disposables);
        }
        
        public Vector3 CalculateMovementDelta()
        {
            if (target == null || myTransform == null)
            {
                return Vector3.zero;
            }

            Vector3 direction = (target.position - myTransform.position).normalized;
            
            if (!characterController.isGrounded)
            {
                verticalVelocity += G.GravityValue * Time.deltaTime;
            }
            else
            {
                verticalVelocity = 0f;
            }

            Vector3 horizontalMove = direction * Model.Speed;
            Vector3 delta = horizontalMove * Time.deltaTime + Vector3.up * verticalVelocity;

            return delta;
        }

        private void DeathCheck(bool isAlive)
        {
            
        }

        public void Dispose()
        {
            disposables.Dispose();
        }
    }
}
