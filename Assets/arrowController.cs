using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowController : MonoBehaviour
{
    public float secsToSelfDestruct = 7f;

    void Start()
    {
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

}
