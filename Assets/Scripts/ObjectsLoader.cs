using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectsLoader : MonoBehaviour
{

    List<GameObject> chunks = new List<GameObject>();
    List<GameObject> enemys = new List<GameObject>();


    public GameObject enemy;
    public GameObject chunk;
    public GameObject player;


    public GameObject playerLine;

    public float chunkPosZ = 0;
    public float playerLinePos;

    public int time;

    private int index;
    private int enemyIndex;

    private void Start()
    {
        enemyIndex = -1;
        index = -1;
        playerLinePos = 25.0f;
        playerLine = GameObject.Find("PlayerLine");
        chunk = Resources.Load("Prefabs/Chunk") as GameObject;
        enemy = Resources.Load("Prefabs/NewEnemyChunk") as GameObject;
    }

    private T[] ShuffleArray<T>(T[] array)
    {
        System.Random r = new System.Random();
        for (int i = array.Length; i > 0; i--)
        {
            int j = r.Next(i);
            T k = array[j];
            array[j] = array[i - 1];
            array[i - 1] = k;
        }

        return array;
    }

    public void spawnEnemy()
    {
        float[] floatArray = new float[] { -2.35f, -1.33f, -0.26f, 0.66f, 1.64f, 2.65f };
        floatArray = ShuffleArray(floatArray);

        var instEnemy = Instantiate(enemy, new Vector3(0f,0f,0f), Quaternion.identity);

        for (int i = 0; i < 3; i++)
        {
            var enemyChild = instEnemy.transform.GetChild(i);
            enemyChild.name = "Enemy" + i;
            enemyChild.transform.localPosition = new Vector3(floatArray[i], 0.5f, player.transform.position.z + 50f);
        }

        enemys.Add(instEnemy);

    }


    public void SpawnBuildings()
    {

        player = GameObject.Find("Truck(Clone)");

        Vector3 chunkPos = new Vector3(0f,0f,chunkPosZ);

        var instChunk = Instantiate(chunk, chunkPos, Quaternion.identity);

        instChunk.name = "Chunk" + chunks.Count;

        for (int i = 0; i < 10; i++)
        {
            var building1 = chunk.transform.GetChild(i);
            float randompos = Random.Range(19f, -6f);
            building1.transform.localPosition = new Vector3(building1.transform.localPosition.x, randompos, building1.transform.localPosition.z);
        }

        chunks.Add(instChunk);


        chunkPosZ = chunkPosZ + 50f;

    }

    public void CheckPos()
    {
        time = time + 1;

        if (player.transform.position.z > playerLine.transform.position.z)
        {
            playerLinePos = playerLinePos + 50.0f;
            playerLine.transform.position = new Vector3(playerLine.transform.position.x, playerLine.transform.position.y, playerLinePos);
            SpawnBuildings();
            RemoveChunk();
        }

        if(time > 40)
        {
            spawnEnemy();

            RemoveEnemy();

            time = 0;
        }

        
    }

    void RemoveChunk()
    {
        index++;
        Destroy(chunks[index], 1f);
    }

    void RemoveEnemy()
    {
        enemyIndex++;
        Destroy(enemys[enemyIndex], 4f);
    }
}
