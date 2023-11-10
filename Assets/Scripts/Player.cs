using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float TOLERANCE = 0.5f;
    public LeftArm leftArm;
    public LeftLeg leftLeg;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Moi moi!");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        var transformPosition = transform.position;
        
        if (transformPosition.z >= 15 - TOLERANCE && transformPosition.z <= 15 + TOLERANCE)
        {
            Debug.Log("Teleporting!");
            transformPosition.z = 0;
            transform.position = transformPosition;
            leftArm.leftArmMarked = false;
            leftLeg.leftLegMarked = false;

        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a specific tag
        if (other.gameObject.CompareTag("Wall") && other.gameObject.layer == LayerMask.NameToLayer("Default"))
        {
            Debug.Log("Wall");
            if (!leftArm.leftArmMarked)
            {
                leftArm.gameObject.SetActive(false);
            }
            else if (!leftLeg.leftLegMarked)
            {
                Debug.Log("Not Marked");
                leftLeg.gameObject.SetActive(false);
            }
            
        }
    }

}
