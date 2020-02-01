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

        if(wallright == false & Input.GetAxis("Player Xaxis") > 0)
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
        
        if(Input.GetAxis("Sight Yaxis") > 0 & Input.GetAxis("Sight Xaxis") > 0)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, RadtoDeg(ToSingle(Acos(Input.GetAxis("Sight Yaxis") / Input.GetAxis("Sight Xaxis")))), 1);
        }
        else if (Input.GetAxis("Sight Yaxis") < 0 & Input.GetAxis("Sight Xaxis") > 0)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 90.0f + RadtoDeg(ToSingle(Acos(-Input.GetAxis("Sight Yaxis") / Input.GetAxis("Sight Xaxis")))), 1);
        }
        else if (Input.GetAxis("Sight Yaxis") < 0 & Input.GetAxis("Sight Xaxis") < 0)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 180.0f + RadtoDeg(ToSingle(Acos(-Input.GetAxis("Sight Yaxis") / -Input.GetAxis("Sight Xaxis")))), 1);
        }
        else if (Input.GetAxis("Sight Yaxis") > 0 & Input.GetAxis("Sight Xaxis") < 0)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 270.0f + RadtoDeg(ToSingle(Acos(Input.GetAxis("Sight Yaxis") / -Input.GetAxis("Sight Xaxis")))), 1);
        }

        else if (Input.GetAxis("Sight Yaxis") == 0 & Input.GetAxis("Sight Xaxis") == 1 )
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 90.0f, 1.0f);
        }
        else if (Input.GetAxis("Sight Yaxis") == 0 & Input.GetAxis("Sight Xaxis") == -1)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 270.0f, 1.0f);
        }
        else if (Input.GetAxis("Sight Xaxis") == 0 & Input.GetAxis("Sight Yaxis") == 1)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1.0f);
        }
        else if (Input.GetAxis("Sight Xaxis") == 0 & Input.GetAxis("Sight Yaxis") == -1)
        {
            transform.rotation = new Quaternion(0.0f, 0.0f, 180.0f, 1.0f);
        }

        //if (Input.GetAxis("Sight Xaxis") < 0 && wallleft == false)
        //{
        //    transform.position = transform.position + new Vector3(Time.deltaTime * speed * Input.GetAxis("Sight Xaxis"), 0.0f, 0.0f);
        //}
        //if (Input.GetAxis("Sight Yaxis") > 0 && walltop == false)
        //{
        //    transform.position = transform.position + new Vector3(0.0f, Time.deltaTime * speed * Input.GetAxis("Sight Yaxis"), 0.0f);
        //}
        //if (Input.GetAxis("Sight Yaxis") < 0 && wallbotom == false)
        //{
        //    transform.position = transform.position + new Vector3(0.0f, Time.deltaTime * speed * Input.GetAxis("Sight Yaxis"), 0.0f);
        //}
    }
}
