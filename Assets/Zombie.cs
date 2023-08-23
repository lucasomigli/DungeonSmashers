using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : NPC
{

    void Start()
    {
        SaySomething();
    }

    public override void SaySomething()
    {
        Debug.Log("Current Life: " + this._life); //Debug
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Weapon")
        {
            DamageInfo damageInfo = other.collider.gameObject.GetComponent<arrowController>().getDamageInfo();
            TakeDamage(10f, damageInfo);
            SaySomething();
        }
    }
}
