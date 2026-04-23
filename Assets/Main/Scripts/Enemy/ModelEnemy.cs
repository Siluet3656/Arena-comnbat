using R3;
using UnityEngine;

namespace Main.Scripts.Enemy
{
    public class ModelEnemy
    {
        public ReactiveProperty<int> Health {  private set; get; }
        public int Damage { private set; get; }
        public int Armor { private set; get; }
        public float Speed { private set; get; }
        public ReadOnlyReactiveProperty<bool> IsAlive { private set; get; }

        public ModelEnemy(CMSEntity enemyData)
        {
            TagEnemyStats enemyStats = enemyData.Get<TagEnemyStats>();
            TagEnemyVisual enemyVisual = enemyData.Get<TagEnemyVisual>();
            
            Health = new ReactiveProperty<int>(enemyStats._health);
            Damage = enemyStats._damage;
            Armor = enemyStats._armor;
            Speed = enemyStats._speed;
            
            IsAlive = Health.Select(h => h > 0).ToReadOnlyReactiveProperty();
        }
        
        public void TakeDamage(int amount)
        {
            if (Health.Value <= 0) return;

            int finalDamage = Mathf.Max(0, amount - Armor);
            Health.Value = Mathf.Max(0, Health.Value - finalDamage);
        }

        public void SetSpeed(float value)
        {
            Speed = value;
        }
    }
}
