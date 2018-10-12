using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    private float money;
    public Text scoreText;
    public Text decreaseText;

    // Use this for initialization
    public void Start () {
        money = 1f;
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        decreaseText = GameObject.Find("Fade").GetComponent<Text>();
        decreaseText.enabled = false;
        Invoke("Increase", 0.05f);
    }
	
	public void Update()
    {
        scoreText.text = money.ToString("$#,##0");
        scoreText.text.Replace(',', '.');
    }

    public void minScore(float number)
    {
        money = money - number;

        decreaseText.text = number.ToString("-$#,##0");
        decreaseText.text.Replace(',', '.');

        if (money < 0)
        {
            money = 0;

            SceneManager.LoadScene("Menu");

        }

        decreaseText.enabled = true;
    }

    public void Increase()
    {
        if(money > 0)
        {
            money = money + 11f;
        }

        Invoke("Increase", 0.05f);
    }
}
