using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject Truck;
    public float speed;
    public int speedr = 60;

    public CheckCollision checkcollision;


    public void Start()
    {
        Truck = GameObject.Find("Truckobj");
        speed = 6f;
        GameObject obj = GameObject.Find("CheckCollision");
        checkcollision = obj.GetComponent<CheckCollision>();
        //checkcollision = GameObject.Find("Text").GetComponent<CheckCollision>();
    }


    public void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) || (Input.GetKeyUp(KeyCode.LeftArrow))) {
            Truck.transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (transform.position.x > -2.5)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.right * -speed * Time.deltaTime);
                Truck.transform.Rotate(Vector3.up * -speedr * Time.deltaTime, Space.Self);
            }
        }

        if (transform.position.x < 2.5)
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                Truck.transform.Rotate(Vector3.up * speedr * Time.deltaTime, Space.Self);
            }
        }

            transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }


    public void OnTriggerEnter(Collider other)
    {
            //checkcollision.collide = true;
            checkcollision.Crash(other.gameObject,this.gameObject);
    }

}
