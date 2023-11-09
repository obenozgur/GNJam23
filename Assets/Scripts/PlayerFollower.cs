using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    // Reference to the player GameObject
    public Transform player;

    // Offset to control the distance between the player and the camera
    public Vector3 offset = new Vector3(0f, 5f, -10f);

    // Update is called once per frame
    void Update()
    {
        // Check if the player reference is not null
        if (player != null)
        {
            // Set the camera's position to the player's position plus the offset
            transform.position = player.position + offset;
        }
    }
}
