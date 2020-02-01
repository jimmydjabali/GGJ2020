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
    public GameObject player;
    public GameObject playerSprite;

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
        if (wallright == false & Input.GetAxis("Player Xaxis") > 0)
        {
            Xdir = transform.right * speed * Input.GetAxis("Player Xaxis");
        }
        else if (wallleft == false & Input.GetAxis("Player Xaxis") < 0)
        {
            Xdir = transform.right * speed * Input.GetAxis("Player Xaxis");
        }
        else if (Input.GetAxis("Player Xaxis") == 0)
        {
            Xdir = transform.right * 0;
        }
        if (walltop == false & Input.GetAxis("Player Yaxis") > 0)
        {
            Ydir = transform.up * speed * -Input.GetAxis("Player Yaxis");
        }
        else if (wallbotom == false & Input.GetAxis("Player Yaxis") < 0)
        {
            Ydir = transform.up * speed * -Input.GetAxis("Player Yaxis");
        }
        else if (Input.GetAxis("Player Yaxis") == 0)
        {
            Ydir = transform.up * 0;
        }

        player.GetComponent<Rigidbody2D>().velocity = Xdir + Ydir;
    }
}
