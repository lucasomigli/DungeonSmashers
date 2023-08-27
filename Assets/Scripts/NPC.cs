using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour, IDamageable
{
    public float _life;

    public virtual void TakeDamage(float damage, DamageInfo info)
    {
        _life = Mathf.Max(_life - damage, 0);
    }

    public abstract void SaySomething();
}