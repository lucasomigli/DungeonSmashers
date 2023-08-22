using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bowController : MonoBehaviour
{
    bool isShooting = false;

    public GameObject arrow;
    public float arrowSpeed = 30f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject arrowClone = default;
            arrowClone = Instantiate(arrow, transform.position, transform.rotation);
            arrowClone.transform.Rotate(90f, 0f, 0f);
            arrowClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward * arrowSpeed);
        }
    }
}