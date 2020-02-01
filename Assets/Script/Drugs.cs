using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drugs : MonoBehaviour
{
    public GameObject gellule;
    public float speed;

    public float delay;
   

    // Start is called before the first frame update
    void Start()
    {
        gellule.GetComponent<Rigidbody2D>().velocity = transform.up * 20;
    }

    // Update is called once per frame
    void Update()
    {
        delay = delay - 1*Time.deltaTime;
        if (delay <= 0)
        {
            Destroy(gameObject);
        }


    }
}
