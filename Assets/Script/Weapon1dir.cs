using System.Collections;
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
        angle = 0;

        angle = -Atan2(aimposition.x - 2, aimposition.y + 3.8);

        return ToSingle(angle);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aimposition = Aim.transform.position;
        transform.rotation = new Quaternion(0.0f, 0.0f, dir(),1);
        if (Input.GetAxis("Left fire") > 0 & fire == 0 & overheating == false)
        {
            fire = rateoffire;
            overheatingtemp = overheatingtemp + 100;
            Rigidbody2D p = Instantiate(Drugs, transform.position, transform.rotation);
            Debug.Log("eugcre");

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
