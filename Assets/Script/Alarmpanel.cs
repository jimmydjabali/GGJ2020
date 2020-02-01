using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarmpanel : MonoBehaviour
{
    public float movementspeed; //Vitesse déplacement alarmpanel
    
    private bool move;

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
    void FixedUpdate()
    {
        if (Input.GetAxis("DPAD Vertical") == -1 & transform.position.y > -5.4)
        {
            movementspeed = Abs(movementspeed) * -1;
            move = true;
        }

        else if (Input.GetAxis("DPAD Vertical") == 1 & transform.position.y < -1.8)
        {
            movementspeed = Abs(movementspeed);
            move = true;
        }
        else if (transform.position.y >= -1.8)
        {
            move = false;
        }
        else if (transform.position.y <= -5.4)
        {
            move = false;
        }
        else
        {

        }

        if (move)
        {
            transform.position = transform.position + new Vector3(0, Time.deltaTime*movementspeed, 0);
        }

    }
}
