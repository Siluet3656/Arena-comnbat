using UnityEngine;

namespace Main.Scripts.Enemy.Interfaces
{
    public interface IMovement
    {
        public void SetTarget(Transform newTarget);
        public Vector3 CalculateMovementDelta();
        
    }
}
