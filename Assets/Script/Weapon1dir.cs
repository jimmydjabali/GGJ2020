﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;
using static System.Convert;

public class Weapon1dir : MonoBehaviour
{
    public GameObject Aim;
    public int rateoffire;
    public bool overheating;
    public Rigidbody2D Drugs;
    public float speed;

    private Vector3 aimposition;
    private int fire;
    private int overheatingtemp;

    float dir()
    {
        double angle;
        angle = Mathf.Asin(aimposition.x / pyth(aimposition.x - 0.6f, aimposition.y +1.679f));
        angle = angle * Mathf.Rad2Deg;
        return ToSingle(angle);
    }
    float pyth(float x, float y)
    {
        x = Mathf.Pow(x,2);
        y = Mathf.Pow(y, 2);

        return Mathf.Sqrt(x + y);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aimposition = Aim.transform.position;
        transform.rotation = Quaternion.Euler( new Vector3 (0.0f, 0.0f, -dir()));
        if (Input.GetAxis("Left fire") > 0 && fire == 0 & overheating == false)
        {
            fire = rateoffire;
            overheatingtemp = overheatingtemp + 100;
            Rigidbody2D projectile = Instantiate(Drugs, transform.position, transform.rotation);
            projectile.gameObject.tag = "Weapon1";

        }
        else if (fire > 0)
        {
            fire = fire - 1;
        }
        if (overheatingtemp >= 1000)
        {
            overheating = true;
        }
        if (overheatingtemp == 0)
        {
            overheating = false;
        }
        overheatingtemp = overheatingtemp - 1;
    }

}
