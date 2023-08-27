using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spotLightController : MonoBehaviour
{
    GameObject player;
    Vector3 offset;

    public float lightHeight = 15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        offset = new Vector3(4f, lightHeight, 0f);
        transform.position = player.transform.position + offset;
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform);
    }
}
