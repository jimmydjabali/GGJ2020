using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour
{
    public Sprite A;
    public Sprite B;
    public Sprite X;
    public Sprite Y;
    public Sprite right;
    public Sprite wrong;
    public int qteSize = 5;
    public float time = 1.5f;
    public Player2 player2Obj;

    private List<int> buttonCombination = new List<int>();
    private int currentPosition = 0;
    private bool isQteStarted = false;
    private float remainingTime;

    void FailedQte()
    {
        isQteStarted = false;
        currentPosition = 0;
        GetComponent<SpriteRenderer>().sprite = wrong;
        player2Obj.failedQte();
        Invoke("DisableObj", 2.0f);
    }

    void DisableObj()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isQteStarted) return;

        remainingTime -= Time.deltaTime;
        if (remainingTime < 0)
            FailedQte();

        int newCurrentPostion = currentPosition;

        if (Input.GetButtonDown("A Button"))
        {
            if (buttonCombination[currentPosition] == 0)
                newCurrentPostion += 1;
            else
                FailedQte();
        }
        if (Input.GetButtonDown("B Button"))
        {
            if (buttonCombination[currentPosition] == 1)
                newCurrentPostion += 1;
            else
                FailedQte();
        }
        if (Input.GetButtonDown("X Button"))
        {
            if (buttonCombination[currentPosition] == 2)
                newCurrentPostion += 1;
            else
                FailedQte();
        }
        if (Input.GetButtonDown("Y Button"))
        {
            if (buttonCombination[currentPosition] == 3)
                newCurrentPostion += 1;
            else
                FailedQte();
        }

        if (newCurrentPostion != currentPosition)
        {
            currentPosition = newCurrentPostion;
            remainingTime = time;
            if (buttonCombination[currentPosition] == 0) GetComponent<SpriteRenderer>().sprite = A;
            if (buttonCombination[currentPosition] == 1) GetComponent<SpriteRenderer>().sprite = B;
            if (buttonCombination[currentPosition] == 2) GetComponent<SpriteRenderer>().sprite = X;
            if (buttonCombination[currentPosition] == 3) GetComponent<SpriteRenderer>().sprite = Y;
        }
        
        if (currentPosition > qteSize - 1)
        {
            isQteStarted = false;
            currentPosition = 0;
            GetComponent<SpriteRenderer>().sprite = right;
            player2Obj.successQte();
            Invoke("DisableObj", 2.0f);
        }
    }

    public void startQte()
    {
        int button;
        while (buttonCombination.Count < qteSize)
        {
            do
            {
                button = Random.Range(0, 4);
            } while (buttonCombination.Count > 0 && button == buttonCombination[buttonCombination.Count - 1]);
            buttonCombination.Add(button);
        }
        if (buttonCombination[currentPosition] == 0) GetComponent<SpriteRenderer>().sprite = A;
        if (buttonCombination[currentPosition] == 1) GetComponent<SpriteRenderer>().sprite = B;
        if (buttonCombination[currentPosition] == 2) GetComponent<SpriteRenderer>().sprite = X;
        if (buttonCombination[currentPosition] == 3) GetComponent<SpriteRenderer>().sprite = Y;
        gameObject.SetActive(true);
        isQteStarted = true;
        remainingTime = time;
        CancelInvoke();
    }
}
