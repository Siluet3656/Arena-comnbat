using Main.Scripts.Pooling;
using R3;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Enemy
{
    [RequireComponent(typeof(CharacterController))]
    public class EnemyView : MonoBehaviour
    {
        private EnemyController enemyController;
        private Transform playerTransform;
        private EnemyPool enemyPool;
        private CharacterController characterController;
        
        private CompositeDisposable disposables;

        [Inject]
        private void Construct(Player player, EnemyPool pool)
        {
            playerTransform = player.transform;
            enemyPool = pool;
        }

        public void Initialize(EnemyController controller)
        {
            enemyController = controller;
            characterController = GetComponent<CharacterController>();
            enemyController.BindView(characterController, transform, playerTransform);
            
            disposables = new CompositeDisposable();
            
            Observable.EveryUpdate()
                .Subscribe(_ => ApplyMovement())
                .AddTo(disposables);
            
            enemyController.Model.IsAlive
                .Where(alive => !alive)
                .Subscribe(_ => enemyPool.Despawn(this))
                .AddTo(disposables);
        }

        public void Deinitialize()
        {
            disposables?.Dispose();
            disposables = null;
            enemyController?.Dispose();
            enemyController = null;
        }

        private void ApplyMovement()
        {
            if (enemyController == null || characterController == null)
                return;

            Vector3 moveDelta = enemyController.CalculateMovementDelta();
            if (moveDelta != Vector3.zero)
                transform.forward = new Vector3(moveDelta.x, 0, moveDelta.z);
            characterController.Move(moveDelta);
        }

        private void OnDestroy()
        {
            disposables?.Dispose();
            if (enemyController != null)
            {
                enemyController.Dispose();
                enemyController = null;
            }
        }
    }
}