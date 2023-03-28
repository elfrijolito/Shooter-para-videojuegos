using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float offset = 0f;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.position.x + offset, player.position.y + offset, transform.position.z);
    }
}
