using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightArm : MonoBehaviour
{
    private const float RotationTolerance = 0.01f;
    public float rotationSpeed = 180f;
    private const float ReverseRotationMultiplier = 0.8f; 
    public bool isMarked = false;
    private Quaternion defaultRotation;
    private Quaternion targetRotation;

    void Start()
    {
        defaultRotation = transform.rotation;
        targetRotation = new Quaternion();
        targetRotation.x = 0.0f;
        targetRotation.y = 0.0f;
        targetRotation.z = 0.25f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (!(transform.rotation.z >= targetRotation.z - RotationTolerance && transform.rotation.z <= RotationTolerance + targetRotation.z))
            {
                float rotationAmount = rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.forward, rotationAmount);
            }
        }
        else
        {
            if (!(transform.rotation.z >= defaultRotation.z - RotationTolerance && transform.rotation.z <= RotationTolerance + defaultRotation.z))
            {
                float rotationAmount = rotationSpeed * ReverseRotationMultiplier * Time.deltaTime;
                transform.Rotate(Vector3.back, rotationAmount);   
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("RightArm"))
        {
            Debug.Log("RightArm");
            isMarked = true;
        }
    }
}