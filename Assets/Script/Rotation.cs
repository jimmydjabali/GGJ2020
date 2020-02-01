using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Sprite idle;
    public Sprite walk1;
    public Sprite walk2;

    private int walkState = 0;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Player Yaxis");
        float xAxis = Input.GetAxis("Player Xaxis");

        float angle = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180.0f));

        if (xAxis == 0 && yAxis == 0)
        {
            walkState = 0;
            spriteRenderer.sprite = idle;
            CancelInvoke();
        }
        else if (walkState == 0)
        {
            walkState = 1;
            InvokeRepeating("walk", 0.0f, 0.25f);
        }
    }

    void walk()
    {
        if (walkState == 1)
        {
            spriteRenderer.sprite = walk1;
            walkState = 2;
        }
       else if (walkState == 2)
        {
            spriteRenderer.sprite = walk2;
            walkState = 1;
        }

    }
}
