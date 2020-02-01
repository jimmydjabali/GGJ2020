using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    Vector3 currentEulerAngles;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float yAxis = Input.GetAxis("Player Yaxis");
        float xAxis = Input.GetAxis("Player Xaxis");

        float angle = Mathf.Atan2(xAxis, yAxis) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 180.0f));
    }

    public void setMoving(bool isMoving)
    {

    }
}
