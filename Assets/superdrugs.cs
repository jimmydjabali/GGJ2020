using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class superdrugs : MonoBehaviour
{
    public GameObject supergellule;
    public float speed;
    public float delay;
    public bool random_color;
    public Sprite img1, img2;

    private bool destruct = false;
    private int i = 1;


    // Start is called before the first frame update
    void Start()
    {
        if (random_color)
        {
            i = Random.Range(1, 3);
            if (i == 1)
            {
                supergellule.GetComponent<SpriteRenderer>().sprite = img1;
            }
            else if (i == 2)
            {
                supergellule.GetComponent<SpriteRenderer>().sprite = img2;
            }
            else
            {
                supergellule.GetComponent<SpriteRenderer>().sprite = img1;
            }
        }

        supergellule.GetComponent<Rigidbody2D>().velocity = transform.up * 20;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Shiplife")
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
        if (other.gameObject.tag == "Cible1" && gameObject.tag == "SuperWeapon1")
        {
            destruct = true;
        }
        if (other.gameObject.tag == "Cible2" && gameObject.tag == "SuperWeapon2")
        {
            destruct = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay - 1 * Time.deltaTime;
        if (delay <= 0 | destruct == true)
        {
            Destroy(gameObject);
        }


    }
}
