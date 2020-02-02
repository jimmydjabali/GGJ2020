using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public float movementspeed;

    float Abs(float number)
    {
        if (number < 0)
        {
            return number * -1;
        }
        else
        {
            return number * 1;
        }
    } //Renvoie valeur absolue

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Aim Yaxis") < 0 && transform.position.y > -1.6)
        {
            //movementspeed = Abs(movementspeed) * -1;
            transform.position = transform.position + new Vector3(0, Time.deltaTime * movementspeed * Input.GetAxis("Aim Yaxis"), 0);
        }
        else if (Input.GetAxis("Aim Yaxis") > 0 && transform.position.y < 5.0)
        {
            //movementspeed = Abs(movementspeed);
            transform.position = transform.position + new Vector3(0, Time.deltaTime * movementspeed * Input.GetAxis("Aim Yaxis"), 0);
        }

        if (Input.GetAxis("Aim Xaxis") < 0 && transform.position.x > 0.2)
        {
            //movementspeed = Abs(movementspeed) * -1;
            transform.position = transform.position + new Vector3(Time.deltaTime * movementspeed * Input.GetAxis("Aim Xaxis"), 0, 0);
        }
        else if (Input.GetAxis("Aim Xaxis") > 0 && transform.position.x < 9.5)
        {
            //movementspeed = Abs(movementspeed);
            transform.position = transform.position + new Vector3(Time.deltaTime * movementspeed * Input.GetAxis("Aim Xaxis"), 0, 0);
        }

    }
}
