using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 180f;
    public bool marked = false;

    // Update is called once per frame
    void Update()
    {
        // Check if the "A" key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            // Rotate the LeftArm in the Z-axis
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.forward, rotationAmount);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftArm"))
        {
            Debug.Log("LeftArm");
            marked = true;
        }
    }
}