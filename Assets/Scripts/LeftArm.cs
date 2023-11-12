using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftArm : MonoBehaviour
{
    private const float RotationTolerance = 0.01f;
    public float rotationSpeed = 180f;
    private const float ReverseRotationMultiplier = 0.8f; 
    public bool isMarked = false;
    private Quaternion defaultRotation;
    private Quaternion targetRotation;
    public AudioSource audioSource;
    public AudioClip cutOff;
    private bool isDisabled = false;
    void Start()
    {
        defaultRotation = transform.rotation;
        targetRotation = new Quaternion();
        targetRotation.x = 0.0f;
        targetRotation.y = 0.0f;
        targetRotation.z = 0.45f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (!(transform.rotation.z >= targetRotation.z - RotationTolerance && transform.rotation.z <= RotationTolerance + targetRotation.z))
            {
                float rotationAmount = rotationSpeed * Time.deltaTime;
                transform.Rotate(Vector3.back, rotationAmount);
            }
        }
        else
        {
            if (!(transform.rotation.z >= defaultRotation.z - RotationTolerance && transform.rotation.z <= RotationTolerance + defaultRotation.z))
            {
                float rotationAmount = rotationSpeed * ReverseRotationMultiplier * Time.deltaTime;
                transform.Rotate(Vector3.forward, rotationAmount);   
            }
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LeftArm"))
        {
            Debug.Log("LeftArm");
            isMarked = true;
        }
    }

    public void PlayAudioAndDisable()
    {
        if (!isDisabled)
        {
            audioSource.PlayOneShot(cutOff);
            isDisabled = true;
            gameObject.SetActive(false);
        }

       
    }
}
