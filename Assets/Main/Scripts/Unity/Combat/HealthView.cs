using UnityEngine;
using Zenject;

public class HealthView : MonoBehaviour
{
    IHealth _health;

    [Inject]
    public void Construct(IHealth health)
    {
        _health = health;
    }

    public void Hit(int dmg)
    {
        _health.TakeDamage(dmg);
    }
}