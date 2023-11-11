using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 3f;
    private const float PositionTolerance = 0.5f;
    public LeftArm leftArm;
    public LeftLeg leftLeg;
    public RightArm rightArm;
    public RightLeg rightLeg;

    public GameManagerMenu gameManager;
    public Wall wall;
    public Gap gap;
    private bool isDead = false;
    
    void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

        var transformPosition = transform.position;
        
        if (transformPosition.z >= 15 - PositionTolerance && transformPosition.z <= 15 + PositionTolerance)
        {
            wall.UpdateWall();
            gap.UpdateGap();
            transformPosition.z = 0;
            transform.position = transformPosition;
            leftArm.isMarked = false;
            leftLeg.isMarked = false;
            rightArm.isMarked = false;
            rightLeg.isMarked = false;
        }

        if (!leftArm.gameObject.activeSelf && !leftLeg.gameObject.activeSelf &&
        !rightArm.gameObject.activeSelf && !rightLeg.gameObject.activeSelf && !isDead)
        {
            isDead = true;
            Debug.Log("dead");
            gameManager.GameOver();
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

            if (!rightArm.isMarked)
            {
                rightArm.gameObject.SetActive(false);
            }
            
            if (!rightLeg.isMarked)
            {
                rightLeg.gameObject.SetActive(false);
            }
        }
    }
}
