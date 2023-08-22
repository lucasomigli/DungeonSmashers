using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody rb;
    bool isSprinting = false;
    float baseSpeed;

    public float playerSpeed = 7f;
    public float sprint = 5f;
    public float lookSpeed = 9f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        baseSpeed = playerSpeed;
    }

    void Update()
    {
        Aim();
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get normalised axis input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 moveVector = new Vector3(h, 0f, v).normalized;

        // Sprint and Move
        PlayerSprint();
        rb.MovePosition(transform.position + moveVector * playerSpeed * Time.deltaTime);
    }

    void Aim()
    {
        // Get Coordinates of viewPoint
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + Vector3.forward * 10f);
        mouseWorldPosition = new Vector3(mouseWorldPosition.x, transform.position.y, mouseWorldPosition.z);

        //Rotate towards direction of the mouse
        Vector3 direction = mouseWorldPosition - transform.position;
        Quaternion toRotation = Quaternion.LookRotation(direction, transform.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, lookSpeed * Time.deltaTime);
    }

    void PlayerSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (!isSprinting)
            {
                playerSpeed += sprint;
                isSprinting = true;
            }

        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerSpeed = baseSpeed;
            isSprinting = false;
        }
    }

}
