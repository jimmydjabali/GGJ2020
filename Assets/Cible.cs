using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cible : MonoBehaviour
{
    public float delay;

    private bool destruct = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.tag == "Cible1" && (other.gameObject.tag == "SuperWeapon1" || other.gameObject.tag == "Weapon1"))
        {
            destruct = true;
        }
        if (gameObject.tag == "Cible2" && (other.gameObject.tag == "SuperWeapon2" || other.gameObject.tag == "Weapon2"))
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
