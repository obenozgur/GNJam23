using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gap : MonoBehaviour
{
    private const int GapCount = 9;
    private Sprite[] spriteArray = new Sprite[GapCount];
    private int currentGapIndex;
    
    public GameObject leftArmCollider;
    public GameObject leftLegCollider;
    public GameObject rightArmCollider;
    public GameObject rightLegCollider;

    private static readonly Vector3 LeftArmUpPosition = new(0f, 0f, 0f);
    private static readonly Vector3 LeftArmDownPosition = new(0f, 0f, 0f);
    private static readonly Vector3 LeftLegUpPosition = new(0f, 0f, 0f);
    private static readonly Vector3 LeftLegDownPosition = new(0f, 0f, 0f);
    private static readonly Vector3 RightArmUpPosition = new(0f, 0f, 0f);
    private static readonly Vector3 RightArmDownPosition = new(0f, 0f, 0f);
    private static readonly Vector3 RightLegUpPosition = new(0f, 0f, 0f);
    private static readonly Vector3 RightLegDownPosition = new(0f, 0f, 0f);

    void Start()
    {
        for (int i = 0; i < GapCount; i++)
        {
            string spritePath = $"Doll/pose ({i+1})";
            spriteArray[i] = Resources.Load<Sprite>(spritePath);
        }
    }
    
    public void UpdateGap()
    {
        
        int gapIndex = Random.Range(0, GapCount);
        
        while (gapIndex == currentGapIndex)
        {
            gapIndex = Random.Range(0, GapCount);
        }

        currentGapIndex = gapIndex;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteArray[gapIndex] != null)
        {
            spriteRenderer.sprite = spriteArray[gapIndex];
        }
        
        UpdateColliderPositions();
    }

    private void UpdateColliderPositions()
    {
        leftArmCollider.transform.position =
            PoseData.IsLimbUp(currentGapIndex, Limb.LeftArm) ? LeftArmUpPosition : LeftArmDownPosition;
        leftLegCollider.transform.position =
            PoseData.IsLimbUp(currentGapIndex, Limb.LeftLeg) ? LeftLegUpPosition : LeftLegDownPosition;
        rightArmCollider.transform.position =
            PoseData.IsLimbUp(currentGapIndex, Limb.RightArm) ? RightArmUpPosition : RightArmDownPosition;
        rightLegCollider.transform.position =
            PoseData.IsLimbUp(currentGapIndex, Limb.RightLeg) ? RightLegUpPosition : RightLegDownPosition;
    }
}
