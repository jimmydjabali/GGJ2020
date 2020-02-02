using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vie : MonoBehaviour
{
    public GameObject vie1, vie2, vie3, vie4, vie5, vie6;
    public int vierestante = 6;
    public bool gameover = false;

    private int compteur = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Virus")
        {
            compteur = compteur + 1;
        }
        if (collision.tag == "Supervirus")
        {
            compteur = compteur + 2;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (compteur > 0)
        {

            vierestante = vierestante - compteur;
            compteur = 0;
        }
        if (vierestante >= 6)
        {
            vie6.SetActive(true);
            vie5.SetActive(true);
            vie4.SetActive(true);
            vie3.SetActive(true);
            vie2.SetActive(true);
            vie1.SetActive(true);

        }
        else if (vierestante >= 5)
        {
            vie6.SetActive(false);
            vie5.SetActive(true);
            vie4.SetActive(true);
            vie3.SetActive(true);
            vie2.SetActive(true);
            vie1.SetActive(true);
        }
        else if (vierestante >= 4)
        {
            vie6.SetActive(false);
            vie5.SetActive(false);
            vie4.SetActive(true);
            vie3.SetActive(true);
            vie2.SetActive(true);
            vie1.SetActive(true);
        }
        else if (vierestante >= 3)
        {
            vie6.SetActive(false);
            vie5.SetActive(false);
            vie4.SetActive(false);
            vie3.SetActive(true);
            vie2.SetActive(true);
            vie1.SetActive(true);
        }
        else if (vierestante >= 2)
        {
            vie6.SetActive(false);
            vie5.SetActive(false);
            vie4.SetActive(false);
            vie3.SetActive(false);
            vie2.SetActive(true);
            vie1.SetActive(true);
        }
        else if (vierestante >= 1)
        {
            vie6.SetActive(false);
            vie5.SetActive(false);
            vie4.SetActive(false);
            vie3.SetActive(false);
            vie2.SetActive(false);
            vie1.SetActive(true);
        }
        else
        {
            vie6.SetActive(false);
            vie5.SetActive(false);
            vie4.SetActive(false);
            vie3.SetActive(false);
            vie2.SetActive(false);
            vie1.SetActive(false);
            gameover = true;

        }
    }
}
