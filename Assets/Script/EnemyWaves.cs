using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject virus;

    private float time = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        spawnMob();
    }

    void popMob()
    {
        Instantiate(virus);
    }

    void spawnMob()
    {
        time = Random.Range(3.5f, 7.0f);
        Invoke("popMob", time);
        Invoke("spawnMob", 2.0f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
