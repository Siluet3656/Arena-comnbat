using R3;

namespace Main.Scripts.Enemy
{
    public class EnemyModel
    {
        private static int _nextId = 0;

        public int Id { get; }
        public ReactiveProperty<int> Health { get; }
        public ReactiveProperty<float> Speed { get; }
        public int Damage { get; }
        public int Armor { get; }
        public ReadOnlyReactiveProperty<bool> IsAlive { get; }

        public EnemyModel(CMSEntity enemyData)
        {
            Id = _nextId++;
            
            TagEnemyStats stats = enemyData.Get<TagEnemyStats>();

            Health = new ReactiveProperty<int>(stats._health);
            Speed = new ReactiveProperty<float>(stats._speed);
            Damage = stats._damage;
            Armor = stats._armor;

            IsAlive = Health.Select(h => h > 0).ToReadOnlyReactiveProperty();
        }
    }
}