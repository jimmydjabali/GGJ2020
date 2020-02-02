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
    public QTE qteObject;
    public Events events;

    private Vector3 Xdir;
    private Vector3 Ydir;

    private bool canMove = true;

    private GameObject currentEvent = null;

    private float RadtoDeg(float angle)
    {
        return angle * 180 / ToSingle(PI);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name != "FireEvent(Clone)" && col.gameObject.name != "DropEvent(Clone)") return;
        currentEvent = col.gameObject;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name != "FireEvent(Clone)" && col.gameObject.name != "DropEvent(Clone)") return;
        currentEvent = null;
    }

    public void setCanMove(bool newCanMove)
    {
        canMove = newCanMove;
        playerSprite.setMove(newCanMove);
    }

    public void successQte()
    {
        events.DeleteEvent(currentEvent.transform.localPosition);
        setCanMove(true);
        Destroy(currentEvent.gameObject);
    }

    public void failedQte()
    {
        setCanMove(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("A Button") && currentEvent != null)
        {
            setCanMove(false);
            qteObject.startQte();
        }

        if (!canMove) return;

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
