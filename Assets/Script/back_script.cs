using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_script : MonoBehaviour
{
    public Transform back1;
    public Transform back2;
    public Transform back3;
    public Transform back1_s;
    public Transform back2_s;
    public Transform back3_s;

    private bool isPrimaryBack1 = true;

    private float initX = -0.8020847f;
    private float initY = -26.78f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        back1.localPosition += new Vector3(0.0f, 0.01f, 0.0f);
        back2.localPosition += new Vector3(0.0f, 0.02f, 0.0f);
        back3.localPosition += new Vector3(0.0f, 0.03f, 0.0f);

        back1_s.localPosition += new Vector3(0.0f, 0.01f, 0.0f);
        back2_s.localPosition += new Vector3(0.0f, 0.02f, 0.0f);
        back3_s.localPosition += new Vector3(0.0f, 0.03f, 0.0f);

        if (back1.localPosition.y > 16.406018f)
            back1.localPosition = new Vector3(initX, initY, 27.14926f);
        if (back1_s.localPosition.y > 16.406018f)
            back1_s.localPosition = new Vector3(initX, initY, 27.14926f);

        if (back2.localPosition.y > 16.406018f)
            back2.localPosition = new Vector3(initX, initY, 27.14926f);
        if (back2_s.localPosition.y > 16.406018f)
            back2_s.localPosition = new Vector3(initX, initY, 27.14926f);

        if (back3.localPosition.y > 16.406018f)
            back3.localPosition = new Vector3(initX, initY, 27.14926f);
        if (back3_s.localPosition.y > 16.406018f)
            back3_s.localPosition = new Vector3(initX, initY, 27.14926f);
    }
}
