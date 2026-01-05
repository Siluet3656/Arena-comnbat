public class Health : IHealth
{
    public int Current { get; private set; }

    public Health(int startHealth)
    {
        Current = startHealth;
    }

    public void TakeDamage(int amount)
    {
        Current -= amount;
    }
}