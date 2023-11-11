using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gap : MonoBehaviour
{
    private const int GapCount = 9;
    private Sprite[] spriteArray = new Sprite[GapCount];
    private int currentGapIndex;
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
    }
}
