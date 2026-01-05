using System;

namespace Main.Scripts.Domain.Combat
{
    public interface IHealth
    {
        int Current { get; }
        void TakeDamage(int amount);
        public event Action Died;
    }
}