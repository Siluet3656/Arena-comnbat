using Main.Scripts.Enemy.Interfaces;
using Main.Scripts.Globals;
using UnityEngine;

namespace Main.Scripts.Enemy
{
    public class EnemyMovement : IMovement
    {
        private readonly CharacterController characterController;
        private readonly Transform myTransform;
        private readonly EnemyModel myModel;
        private Transform target;

        private float verticalVelocity;

        public EnemyMovement(CharacterController cc, Transform transform, EnemyModel model)
        {
            characterController = cc;
            myTransform = transform;
            myModel = model;
        }

        public void SetTarget(Transform newTarget) => target = newTarget;

        public Vector3 CalculateMovementDelta()
        {
            if (target == null)
                return Vector3.zero;

            Vector3 direction = (target.position - myTransform.position).normalized;

            if (!characterController.isGrounded)
                verticalVelocity += G.GravityValue * Time.deltaTime;
            else if (verticalVelocity < 0)
                verticalVelocity = G.LightGroundPressure;

            Vector3 horizontalVelocity = direction * myModel.Speed.Value;
            Vector3 totalVelocity = horizontalVelocity + Vector3.up * verticalVelocity;
            return totalVelocity * Time.deltaTime;
        }
    }
}