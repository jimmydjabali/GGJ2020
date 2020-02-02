using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs : MonoBehaviour
{
    public GameObject gellule;
    public float speed;
    public float delay;
    public bool random_color;
    public Sprite img1, img2, img3;

    private bool destruct = false;
    private int i = 1;
   

    // Start is called before the first frame update
    void Start()
    {
        if (random_color)
        {
            i = Random.Range(1, 4);
            if (i == 1)
            {
                gellule.GetComponent<SpriteRenderer>().sprite = img1;
            }
            else if (i == 2)
            {
                gellule.GetComponent<SpriteRenderer>().sprite = img2;
            }
            else if (i == 3)
            {
                gellule.GetComponent<SpriteRenderer>().sprite = img3;
            }
            else
            {
                gellule.GetComponent<SpriteRenderer>().sprite = img1;
            }
        }

        gellule.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
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
        if(other.gameObject.tag =="Cible1" && gameObject.tag == "Weapon1")
        {
            destruct = true;
        }
        if (other.gameObject.tag == "Cible2" && gameObject.tag == "Weapon2")
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
