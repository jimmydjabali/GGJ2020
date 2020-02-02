using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemis : MonoBehaviour
{
    public bool random_color;
    public GameObject ennemis;
    public Sprite img1, img2, img3, img4, img5;
    //public Sprite img6, img7, img8, img9, img10;
    public int life;
    public int probasuper;
    public int probakawai;
    public bool randomcoordonate;
    public bool randomvitesse;
    public float vitesse;
    public float delay;
    public float tempdegat;

    private int i = 1;
    private bool kawai = false;
    private bool supervirus = false;
    private bool virus = false;
    private bool destruct = false;
    private bool isOnCible1 = false;
    private bool isOnCible2 = false;
    private bool isOnGellule1weak = false;
    private bool isOnGellule1strong = false;
    private bool isOnGellule2weak = false;
    private bool isOnGellule2strong = false;
    private float cooldowndegat = 0.0f;
    private bool finish = false;


    // Start is called before the first frame update
    void Start()
    {
        
        if (Random.Range(1, 101) <= probakawai)
        {
            kawai = true;
            virus = false;
            supervirus = false;
        }
        else if (Random.Range(1, 101) <= probasuper)
        {
            gameObject.tag = "Supervirus";
            life = life * 2;
            ennemis.GetComponent<SpriteRenderer>().sprite = img3;
            kawai = false;
            virus = false;
            supervirus = true;
        }
        else
        {
            gameObject.tag = "Virus";
            virus = true;
            kawai = false;
            supervirus = false;
        }

        if (random_color && virus)
        {

            i = Random.Range(1, 3);
            if (i == 1)
            {
                ennemis.GetComponent<SpriteRenderer>().sprite = img1;
            }
            else if (i == 2)
            {
                ennemis.GetComponent<SpriteRenderer>().sprite = img2;
            }
            else
            {
                ennemis.GetComponent<SpriteRenderer>().sprite = img1;
            }
        }
        if (random_color && kawai)
        {
            gameObject.tag = "Kawai";
            i = Random.Range(1, 3);
            life = 1;
            if (i == 1)
            {
                ennemis.GetComponent<SpriteRenderer>().sprite = img4;
            }
            else if (i == 2)
            {
                ennemis.GetComponent<SpriteRenderer>().sprite = img5;
            }
            else
            {
                ennemis.GetComponent<SpriteRenderer>().sprite = img4;
            }
        }
        
        if (randomcoordonate)
        {
            ennemis.GetComponent<Transform>().position = new Vector3 (Random.Range(1.0f,9.0f),7.0f,0.0f);
        }
        if (randomvitesse)
        {
            ennemis.GetComponent<Rigidbody2D>().velocity = -transform.up * (vitesse + (vitesse * (Random.Range(-10.0f, 10.0f) / 100)));
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cible1")
        {
            isOnCible1 = true;
        }
        if (collision.gameObject.tag == "Cible2")
        {
            isOnCible2 = true;
        }
        
        if (collision.gameObject.tag == "Weapon1")
        {
            isOnGellule1weak = true;
        }
        if (collision.gameObject.tag == "SuperWeapon1")
        {
            isOnGellule1strong = true;
        }
        
        if (collision.gameObject.tag == "Weapon2")
        {
            isOnGellule2weak = true;
        }
        if (collision.gameObject.tag == "SuperWeapon2")
        {
            isOnGellule2strong = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cible1")
        {
            isOnCible1 = false;
        }
        if (collision.gameObject.tag == "Cible2")
        {
            isOnCible2 = false;
        }
        
        if (collision.gameObject.tag == "Weapon1")
        {
            isOnGellule1weak = false;
        }
        if (collision.gameObject.tag == "SuperWeapon1")
        {
            isOnGellule1strong = false;
        }
        
        if (collision.gameObject.tag == "Weapon2")
        {
            isOnGellule2weak = false;
        }
        if (collision.gameObject.tag == "SuperWeapon2")
        {
            isOnGellule2strong = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        delay = delay - 1 * Time.deltaTime;
        if (delay <= 0 | destruct | finish)
        {

            Destroy(gameObject);
        }
        if (isOnCible1 && isOnGellule1weak && cooldowndegat <= 0)
        {
            life = life - 1;
            cooldowndegat = tempdegat;
        }
        else if (isOnCible2 && isOnGellule2weak && cooldowndegat <= 0)
        {
            life = life - 1;
            cooldowndegat = tempdegat;
        }
        else if (isOnCible1 && isOnGellule1strong && cooldowndegat <= 0)
        {
            life = life - 3;
            cooldowndegat = tempdegat;
        }
        else if (isOnCible2 && isOnGellule2strong && cooldowndegat <= 0)
        {
            life = life - 3;
            cooldowndegat = tempdegat;
        }

        if (life <= 0)
        {
            destruct = true;
        }
        if (cooldowndegat > 0)
        {
            cooldowndegat = cooldowndegat - 1 * Time.deltaTime;
        }
        if(ennemis.gameObject.transform.position.y <= -3.0f)
        {
            finish = true;
        }
    }
}
