using System;
using UnityEngine;

namespace Main.Scripts.Domain.Combat
{
    public class Health : IHealth
    {
        public int Current { get; private set; }
        public event Action Died;

        public Health(int startHealth)
        {
            Current = startHealth;
        }

        public void TakeDamage(int amount)
        {
            if (amount <= 0)
            {
                Debug.LogError("Damage amount must be greater than 0");
                return;
            }
        
            Current -= amount;

            if (Current <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}