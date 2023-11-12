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
    public ScoreManager sm; //call scoreManager script

    public GameManagerMenu gameManager;
    public Wall wall;
    public Gap gap;
    private bool isDead = false;
    
    public AudioSource audioSource;
    public AudioClip pass;
    
    private void Start()
    {
        UpdateObstacle();
    }

    void Update()
    {
        transform.Translate(Vector3.forward * (moveSpeed * Time.deltaTime));

        var transformPosition = transform.position;
        
        if (transformPosition.z >= 15 - PositionTolerance && transformPosition.z <= 15 + PositionTolerance)
        {
            audioSource.PlayOneShot(pass);
            UpdateObstacle();
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

    private void UpdateObstacle()
    {
        wall.UpdateWall();
        gap.UpdateGap();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            if(!leftArm.isMarked)
            {
                leftArm.PlayAudioAndDisable();
            }
           
            if (!leftLeg.isMarked)
            {
                leftLeg.PlayAudioAndDisable();
            }

            if (!rightArm.isMarked)
            {
                rightArm.PlayAudioAndDisable();
            }
            
            if (!rightLeg.isMarked)
            {
                rightLeg.PlayAudioAndDisable();
            }

            if(leftArm.isMarked || leftLeg.isMarked || rightArm.isMarked || rightLeg.isMarked)
            {
                sm.score++;
            }
        }

       
    }
}
