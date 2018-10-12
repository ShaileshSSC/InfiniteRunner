using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lights : MonoBehaviour {

    public bool reverse;

    public int time;

    public Light lightblue;
    public Light lightred;

    private void Start()
    {
        time = 0;
        reverse = false;
        lightblue = GameObject.Find("blue").GetComponent<Light>();
        lightred = GameObject.Find("red").GetComponent<Light>();
    }

    // Use this for initialization
    public void FlickLights(float speed)
    {
        if (reverse)
        {
            time = time - 1;
            lightred.intensity -= speed;
            lightblue.intensity += speed;
        }
        if (!reverse)
        {
            time = time + 1;
            lightred.intensity += speed;
            lightblue.intensity -= speed;
        }
        if (time > 5)
        {
            reverse = true;
        }
        if (time < 0)
        {
            reverse = false;
        }
    }
}
