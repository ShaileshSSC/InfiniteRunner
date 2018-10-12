using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{

    public Score score;

    public void Start()
    {
        GameObject obj = GameObject.Find("Score");
        score = obj.GetComponent<Score>();
    }

    public void Crash(GameObject otherObject, GameObject fromObject)
    {
        if(otherObject.tag == "Respawn")
        {
            Destroy(otherObject, 0f);
        }
        if (otherObject.gameObject.name == "Enemy0")
        {
            score.minScore(1600);
            
        }
        if (otherObject.gameObject.name == "Enemy1")
        {
            score.minScore(2400);
            
        }
        if (otherObject.gameObject.name == "Enemy2")
        {
            score.minScore(45000);
            
        }
    }
	
}
