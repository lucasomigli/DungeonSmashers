using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float walkingSpeed = 2f;
    public float rotateSpeed = 5f;
    public GameObject target;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 targetPosition = target.transform.position;
        RotateTowardsPlayer(targetPosition, rotateSpeed);
        MoveTowards(targetPosition, walkingSpeed);
    }

    void RotateTowardsPlayer(Vector3 _targetPosition, float _rotateSpeed)
    {
        Vector3 direction = _targetPosition - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
    }

    void MoveTowards(Vector3 _targetPosition, float _walkingSpeed)
    {
        Vector3 _moveVector = _targetPosition - transform.position;
        rb.MovePosition(transform.position + _moveVector * _walkingSpeed * Time.deltaTime);
    }
}
