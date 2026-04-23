using R3;
using UnityEngine;
using Zenject;

namespace Main.Scripts.Enemy
{
    [RequireComponent(typeof(CharacterController))]
    public class BehaviourEnemy : MonoBehaviour
    {   
        private EnemyController controller;
        private Transform playerTransform;
    
        private CharacterController characterController;

        private readonly CompositeDisposable disposables = new();
        
        [Inject]
        private void Construct(EnemyController enemyController, Player player)
        {
            playerTransform = player.transform;
            controller = enemyController;
        }

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            controller.BindView(characterController, transform, playerTransform);
        }

        private void Update()
        {
            Vector3 moveDelta = controller.CalculateMovementDelta();
            
            if (moveDelta != Vector3.zero)
                transform.forward = new Vector3(moveDelta.x, 0, moveDelta.z);
            
            characterController.Move(moveDelta);
        }

        private void OnDestroy()
        {
            controller.Dispose();
            disposables.Dispose();
        }
    }
}