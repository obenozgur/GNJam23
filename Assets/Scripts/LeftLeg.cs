using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLeg : MonoBehaviour
{
    // Rotation speed in degrees per second
    public float rotationSpeed = 180f;
    public float rotationRange = 180f;
    public bool leftLegMarked = false;
    private bool isRotating = false;
    private Quaternion defaultLocation;
    private Quaternion targetLocation;

    void Start()
    {
        //store default location
        defaultLocation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the "A" key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            // Rotate the LeftArm in the Z-axis
            isRotating = true;
            targetLocation = defaultLocation * Quaternion.Euler(0, 0, rotationRange);
        }

        if (isRotating)
        {
             //rotate the left arm towards the target lotation
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetLocation) < 0.01f)
            {
                //the left arm has reached the target lotation
                isRotating = false;
            }
        }
        else
        {
            //player releases the key it'll return to the default position
            transform.rotation = Quaternion.RotateTowards(transform.rotation, defaultLocation, rotationSpeed * Time.deltaTime);
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftLeg"))
        {
            Debug.Log("LeftLeg");
            leftLegMarked = true;
        }
    }
}