using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Weapon
{

    DamageInfo damageInfo = new DamageInfo();

    public float secsToSelfDestruct = 7f;

    void Start()
    {
        damageInfo.type = DamageType.Arrow;
        damageInfo.damageSource = this.gameObject;

        this.tag = "Weapon";
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {

    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(secsToSelfDestruct);
        Destroy(gameObject);
    }

    public DamageInfo getDamageInfo()
    {
        return this.damageInfo;
    }

}
