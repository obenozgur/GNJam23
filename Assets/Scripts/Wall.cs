using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private const int WallCount = 8;
    private Sprite[] spriteArray = new Sprite[WallCount];
    private int currentWallIndex;
    void Start()
    {
        for (int i = 0; i < WallCount; i++)
        {
            string spritePath = $"Wall/dodging_wall_({i+1})";
            spriteArray[i] = Resources.Load<Sprite>(spritePath);
        }
    }
    
    public void UpdateWall()
    {
        int wallIndex = Random.Range(0, WallCount);
        
        while (wallIndex == currentWallIndex)
        {
            wallIndex = Random.Range(0, WallCount);
        }

        currentWallIndex = wallIndex;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null && spriteArray[wallIndex] != null)
        {
            spriteRenderer.sprite = spriteArray[wallIndex];
        }
    }
}
