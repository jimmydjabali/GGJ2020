using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using static System.Convert;

public class Player2 : MonoBehaviour
{
    public bool walltop;
    public bool wallbotom;
    public bool wallright;
    public bool wallleft;
    public float speed;
    public Rotation playerSprite;

    private Vector3 Xdir;
    private Vector3 Ydir;

    private float RadtoDeg(float angle)
    {
        return angle * 180 / ToSingle(PI);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xAxis = Input.GetAxis("Player Xaxis");
        float yAxis = Input.GetAxis("Player Yaxis");

        if (wallright == false && xAxis < 0)
        {
            Xdir = transform.up * speed * xAxis;
        }
        else if (wallleft == false && xAxis > 0)
        {
            Xdir = transform.up * speed * xAxis;
        }
        else if (xAxis == 0)
        {
            Xdir = transform.up * 0;
        }
        if (walltop == false && yAxis < 0)
        {
            Ydir = transform.right * speed * yAxis;
        }
        else if (wallbotom == false && yAxis > 0)
        {
            Ydir = transform.right * speed * yAxis;
        }
        else if (yAxis == 0)
        {
            Ydir = transform.right * 0;
        }
        GetComponent<Rigidbody2D>().velocity = Xdir + Ydir;
    }
}
