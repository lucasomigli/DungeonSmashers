using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{

    void Start()
    {
    }

    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        RotateTowardsTarget(targetPosition, rotateSpeed);
        MoveTowardsTarget(targetPosition, walkingSpeed);
    }

    public override void SaySomething()
    {
        Debug.Log("Current Life: " + this._life); //Debug
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Weapon")
        {
            DamageInfo damageInfo = other.collider.gameObject.GetComponent<Arrow>().getDamageInfo();
            TakeDamage(10f, damageInfo);
            SaySomething();
            isDead();
        }
    }

    void isDead()
    {
        if (this._life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
