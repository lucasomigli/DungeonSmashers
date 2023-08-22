using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;

    public float CamMoveSpeed = 15f;
    public Vector3 offset = new Vector3(0f, 10f, -5f);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position + offset;

        transform.LookAt(player.transform, Vector3.up);
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, CamMoveSpeed * Time.deltaTime);
    }

}
