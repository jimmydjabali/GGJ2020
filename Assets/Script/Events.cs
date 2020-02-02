using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public float minEventTime;
    public float maxEventTime;

    public Transform fireObject;

    public int fireState = 0;

    private List<Vector3> fireEventPositions = new List<Vector3>();
    private List<Vector3> dropEventPositions = new List<Vector3>();

    private List<int> currentFireEvents = new List<int>();
    private List<int> currentDropEvents = new List<int>();
    private List<int> currentElectricEvents = new List<int>();
    private List<int> currentAirEvents = new List<int>();

    // Start is called before the first frame update
    void Start()
    {
        fireEventPositions.Add(new Vector3(-3.44f, 1.59f, 1.0f));
        fireEventPositions.Add(new Vector3(-2.94f, -0.32f, 1.0f));
        fireEventPositions.Add(new Vector3(2.65f, -2.07f, 1.0f));
        fireEventPositions.Add(new Vector3(3.46f, 1.07f, 1.0f));

        dropEventPositions.Add(new Vector3(-0.92f, -3.8f, 1.0f));
        dropEventPositions.Add(new Vector3(0.93f, -3.8f, 1.0f));
        dropEventPositions.Add(new Vector3(0.0f, -4.73f, 1.0f));

        callEvent("FireEvent");
    }
    
    public void DeleteEvent(Vector3 position)
    {
        currentFireEvents.Remove(fireEventPositions.IndexOf(position));
        fireState -= 1;
    }
    
    void callEvent(string functionName)
    {
        float time = Random.Range(minEventTime, maxEventTime);
        Invoke(functionName, time);
    }

    int pickRandomPosition(List<Vector3> positions, List<int> currentEvents)
    {
        int randomPosition = 0;
        do {
            randomPosition = Random.Range(0, positions.Count);
        } while (currentFireEvents.Contains(randomPosition));
        currentEvents.Add(randomPosition);
        return randomPosition;
    }

    void FireEvent()
    {
        callEvent("FireEvent");
        Debug.Log(fireEventPositions.Count);
        if (currentFireEvents.Count >= fireEventPositions.Count) return;
        int randomPosition = pickRandomPosition(fireEventPositions, currentFireEvents);
        Transform fire = Instantiate(fireObject, transform);
        fire.localPosition = fireEventPositions[randomPosition];
        fire.gameObject.SetActive(true);
        fireState = currentFireEvents.Count;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
