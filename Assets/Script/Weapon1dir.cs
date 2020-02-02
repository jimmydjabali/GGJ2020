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
    public Rigidbody2D Superdrugs;
    public Rigidbody2D Cible;
    public float speed;

    private Vector3 aimposition;
    private int fire;
    private int overheatingtemp;

    float dir()
    {
        double angle;
        angle = Mathf.Atan(aimposition.y / aimposition.x);
        angle = angle * Mathf.Rad2Deg;
        return ToSingle(270.0f + angle);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        aimposition = Aim.transform.localPosition;
        transform.rotation = Quaternion.Euler( new Vector3 (0.0f, 0.0f, dir()));
        if (Input.GetAxis("Left fire") > 0 && fire == 0 && overheating == false)
        {
            fire = rateoffire;
            overheatingtemp = overheatingtemp + 100;
            Rigidbody2D projectile = Instantiate(Drugs, transform.position, transform.rotation);
            projectile.gameObject.tag = "Weapon1";
            Rigidbody2D cible = Instantiate(Cible, Aim.transform.position, Aim.transform.rotation);
            cible.gameObject.tag = "Cible1";

        }
        if (Input.GetButtonDown("Left supercharge") && fire == 0 && overheating == false)
        {
            fire = rateoffire * 2;
            overheatingtemp = overheatingtemp + 200;
            Rigidbody2D projectile = Instantiate(Superdrugs, transform.position, transform.rotation);
            projectile.gameObject.tag = "SuperWeapon1";
            Rigidbody2D cible = Instantiate(Cible, Aim.transform.position, Aim.transform.rotation);
            cible.gameObject.tag = "Cible1";
        }
        else if (fire > 0)
        {
            fire = fire - 1;
        }
        //Debug.Log(overheatingtemp);
        if (overheatingtemp >= 1000)
        {
            overheating = true;
        }
        if (overheatingtemp == 0)
        {
            overheating = false;
        }
        if(overheatingtemp > 0)
        {
            overheatingtemp = overheatingtemp - 1;
        }
        
    }

}
