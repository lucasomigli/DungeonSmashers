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

            float angleToAim = AngleArrow();
            arrowClone.transform.Rotate(90f, 0f, 0f);

            Vector3 arrowDirection = Quaternion.Euler(0f, 0f, angleToAim) * Vector3.forward;
            arrowClone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(arrowDirection * arrowSpeed);
        }
    }

    float calculateAngle(Vector2 pointA, Vector2 pointB)
    {
        return Mathf.Rad2Deg * (Mathf.Atan2(pointB.y - pointA.y, pointB.x - pointA.x));
    }

    float AngleArrow()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        Vector2 mouseWorldPosition2d = new Vector2(mouseWorldPosition.x, mouseWorldPosition.z);
        Vector2 arrowPosition2d = new Vector2(transform.position.x, transform.position.z);
        return calculateAngle(arrowPosition2d, mouseWorldPosition2d);
    }
}