using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public Light lightblue;
    public Light lightred;

    public int time;

    public float speed;

    public bool reverse;

    private void Start()
    {
        time = 0;
        reverse = false;
        speed = 0.1f;
        lightblue = GameObject.Find("blue").GetComponent<Light>();
        lightred = GameObject.Find("red").GetComponent<Light>();
        lightblue.intensity = 0f;
        lightred.intensity = 0f;
    }

    void OnMouseDown()
    {
        if(gameObject.name == "Start")
        {
            SceneManager.LoadScene("Game");
        }
        if (gameObject.name == "Quit")
        {
            print("quit");
        }
        if (gameObject.name == "Controls")
        {
            print("controls");
        }
    }

    private void OnMouseOver()
    {
        if (transform.localScale.x < 1f)
        {
            transform.localScale += new Vector3(0.02f, 0.02f, 0f);
        }
    }

    public void Update()
    {
        if (reverse)
        {
            time = time - 1;
            lightred.intensity -= speed;
            lightblue.intensity += speed;
        }
        if(!reverse)
        {
            time = time + 1;
            lightred.intensity += speed;
            lightblue.intensity -= speed;
        }
        if (time > 10)
        {
            reverse = true;
        }
        if (time < 0)
        {
            reverse = false;
        }
        if (transform.localScale.x > 0.94f)
        {
           transform.localScale -= new Vector3(0.01F, 0.01f, 0);
        }
    }
}
