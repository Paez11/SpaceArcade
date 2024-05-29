namespace Ships.Common
{
    public interface Damageable
    {
        Teams Team { get;}

        void AddDamage(int amount);
    }
}