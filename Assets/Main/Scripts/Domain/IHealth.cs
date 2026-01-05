public interface IHealth
{
    int Current { get; }
    void TakeDamage(int amount);
}