using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    public Lights lightScript;

    public GameObject chunk;

    public GameObject playerinst;
    public GameObject roadInsts;
    public GameObject kamera;
    public GameObject Text;


    public Player playerScript;
    public ObjectsLoader chunkScript;
    public Score score;

    private void Start()
    {
        lightScript = GameObject.Find("LightManager").GetComponent<Lights>();
        chunk = GameObject.Find("ObjectsLoader");
        //Text = GameObject.Find("Text");
        var player = Resources.Load("Prefabs/Truck") as GameObject;
        playerinst = Instantiate(player, new Vector3(0, 0.5f, -2f), Quaternion.identity);
        chunkScript = chunk.GetComponent<ObjectsLoader>();
        playerScript = playerinst.GetComponent<Player>();

        kamera.transform.parent = playerinst.transform;

        //score = Text.GetComponent<Score>();

        chunkScript.SpawnBuildings();
        chunkScript.SpawnBuildings();
        chunkScript.spawnEnemy();

    }
	
	protected virtual void Update ()
    {
        playerScript.CheckInput();
        chunkScript.CheckPos();
        lightScript.FlickLights(0.2f);
        //score.addScore();
        kamera.transform.position = new Vector3(0f, kamera.transform.position.y, kamera.transform.position.z);
        kamera.transform.eulerAngles = new Vector3(11.825f, 0, 0);
    }
}
