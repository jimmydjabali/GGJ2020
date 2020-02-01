using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs : MonoBehaviour
{
    public GameObject gellule;
    public float speed;
    public float delay;

    private bool destruct = false;
   

    // Start is called before the first frame update
    void Start()
    {
        gellule.GetComponent<Rigidbody2D>().velocity = transform.up * 20;
    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.tag == "Shiplife")
        {
            destruct = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shiplife")
        {
            destruct = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name =="Aim1" && gameObject.tag == "Weapon1")
        {
            destruct = true;
        }
        if (other.gameObject.name == "Aim2" && gameObject.tag == "Weapon2")
        {
            destruct = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay - 1*Time.deltaTime;
        if (delay <= 0 | destruct == true)
        {
            Destroy(gameObject);
        }


    }
}
