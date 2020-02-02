using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public float minEventTime = 1.0f;
    public float maxEventTime = 3.0f;

    public Transform fireObject;

    private Vector3[] eventsPositions = {
        new Vector3(2.26f, -1.05f, 1.0f),
        new Vector3(-2.19f, -1.09f, 1.0f),
        new Vector3(-2.19f, -2.09f, 1.0f),
        new Vector3(-3.19f, -1.09f, 1.0f)
    };

    private List<int> currentEvents = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        callEvent("FireEvent");
    }
    
    void callEvent(string functionName)
    {
        Invoke(functionName, Random.Range(minEventTime, maxEventTime));
    }

    int pickRandomPosition()
    {
        int randomPosition = 0;
        do
        {
            randomPosition = Random.Range(0, eventsPositions.Length);
        } while (currentEvents.Contains(randomPosition));
        currentEvents.Add(randomPosition);
        return randomPosition;
    }

    void FireEvent()
    {
        int randomPosition = pickRandomPosition();
        Debug.Log(randomPosition);
        Transform fire = Instantiate(fireObject, transform);
        fire.localPosition = eventsPositions[randomPosition];
        fire.gameObject.SetActive(true);
        //callEvent("FireEvent");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
