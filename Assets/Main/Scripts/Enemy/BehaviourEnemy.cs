using UnityEngine;
using Zenject;

namespace Main.Scripts.Enemy
{
    public class EnemyBehaviour : MonoBehaviour
    {   
        private Transform target;
        private Vector3 velocity;
    
        public CharacterController _controller;
        public float enemySpeed;

        [Inject]
        private void Construct(Player player)
        {
            target = player.transform;
        }
    
        void Update()
        {
            Vector3 moveDirection = (target.position - transform.position).normalized;

            if (moveDirection != Vector3.zero)
                transform.forward = moveDirection;
            
            velocity.y += G.GravityValue * Time.deltaTime;
            
            Vector3 finalMove = moveDirection * enemySpeed;
            _controller.Move(finalMove * Time.deltaTime + Vector3.up * velocity.y);
        }
    }
}
