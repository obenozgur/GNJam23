using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    private const float PositionTolerance = 0.5f;
    public LeftArm leftArm;
    public LeftLeg leftLeg;
    
    void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

        var transformPosition = transform.position;
        
        if (transformPosition.z >= 15 - PositionTolerance && transformPosition.z <= 15 + PositionTolerance)
        {
            transformPosition.z = 0;
            transform.position = transformPosition;
            leftArm.isMarked = false;
            leftLeg.isMarked = false;
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall") && other.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            if (!leftArm.isMarked)
            {
                leftArm.gameObject.SetActive(false);
            }
            
            if (!leftLeg.isMarked)
            {
                leftLeg.gameObject.SetActive(false);
            }
        }
    }
}
