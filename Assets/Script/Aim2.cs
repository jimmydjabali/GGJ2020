using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim2 : MonoBehaviour
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
        if (Input.GetAxis("Aim2 Yaxis") < 0 && transform.localPosition.y > 1)
        {
            //movementspeed = Abs(movementspeed) * -1;
            transform.localPosition = transform.localPosition + new Vector3(0, Time.deltaTime * movementspeed * Input.GetAxis("Aim2 Yaxis"), 0);
        }
        else if (Input.GetAxis("Aim2 Yaxis") > 0 && transform.position.y < 5.0)
        {
            //movementspeed = Abs(movementspeed);
            transform.localPosition = transform.localPosition + new Vector3(0, Time.deltaTime * movementspeed * Input.GetAxis("Aim2 Yaxis"), 0);
        }
        if (Input.GetAxis("Aim2 Xaxis") < 0 && transform.localPosition.x > -8.7)
        {
            //movementspeed = Abs(movementspeed) * -1;
            transform.localPosition = transform.localPosition + new Vector3(Time.deltaTime * movementspeed * Input.GetAxis("Aim2 Xaxis"), 0, 0);
        }
        else if (Input.GetAxis("Aim2 Xaxis") > 0 && transform.localPosition.x < -0.8)
        {
            //movementspeed = Abs(movementspeed);
            transform.localPosition = transform.localPosition + new Vector3(Time.deltaTime * movementspeed * Input.GetAxis("Aim2 Xaxis"), 0, 0);
        }
    }
}
