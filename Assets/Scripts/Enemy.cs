using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : NPC
{
    public float walkingSpeed = 8f;
    public float rotateSpeed = 5f;

    public virtual void RotateTowardsTarget(Vector3 _targetPosition, float _rotateSpeed)
    {
        Vector3 direction = _targetPosition - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, _rotateSpeed * Time.deltaTime);
    }

    public virtual void MoveTowardsTarget(Vector3 _targetPosition, float _walkingSpeed)
    {
        Vector3 _moveVector = (_targetPosition - transform.position).normalized;
        GetComponent<Rigidbody>().MovePosition(transform.position + _moveVector * _walkingSpeed * Time.deltaTime);
    }
}
