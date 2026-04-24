using System;
using UnityEngine;

namespace Main.Scripts.Enemy
{
    [Serializable]
    public class TagEnemyStats : EntityComponentDefinition
    {
        public int _health;
        public int _damage;
        public int _armor;
        public float _speed;
    }
    
    [Serializable]
    public class TagEnemyVisual : EntityComponentDefinition
    {
        public Color _color;
    }
}