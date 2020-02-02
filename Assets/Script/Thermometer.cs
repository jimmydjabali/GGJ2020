using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermometer : MonoBehaviour
{
    public Sprite thermometer1;
    public Sprite thermometer2;
    public Sprite thermometer3;
    public Sprite thermometer4;
    public Sprite thermometer5;

    SpriteRenderer spriteRenderer;

    public int level = 1; 

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void setLevel(int newLevel)
    {
        level = newLevel;
        if (level == 1)
            spriteRenderer.sprite = thermometer1;
        if (level == 2)
            spriteRenderer.sprite = thermometer2;
        if (level == 3)
            spriteRenderer.sprite = thermometer3;
        if (level == 4)
            spriteRenderer.sprite = thermometer4;
        if (level == 5)
            spriteRenderer.sprite = thermometer5;
    }
}
