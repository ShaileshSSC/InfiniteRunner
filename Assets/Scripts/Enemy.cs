using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Manager
{
    public float speed;

	void Start ()
    {
        speed = Random.Range(6f, 7f);
	}


    protected override void Update()
    {
        transform.Translate(Vector3.forward * -speed * Time.deltaTime);
    }

}
