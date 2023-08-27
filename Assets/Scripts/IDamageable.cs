using UnityEngine;

public interface IDamageable
{
    public void TakeDamage(float damage, DamageInfo info);
}

public enum DamageType { Sword, Arrow, Bomb, Magic }

public struct DamageInfo
{
    public DamageType type;
    public Object damageSource;
}