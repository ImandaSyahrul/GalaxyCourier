using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IArea<BoxCollider>
{
    public GameObject[] prefabs;
    public PlayerController player;

    private BoxCollider boxCollider;
    private Coroutine Cr_Spawn;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        InitCollider(boxCollider);
        StartSpawn();
    }

    void StartSpawn()
    {
        //Start Coroutine function IeSpawn()
        if (Cr_Spawn == null)
        {
            Cr_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //Stop Coroutine function if its running
        if (Cr_Spawn != null)
        {
            StopCoroutine(Cr_Spawn);
        }
    }

    // Pick a random point on collider
    static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y),
            Random.Range(bounds.min.z, bounds.max.z)
        );
    }

    void SpawnObstacle()
    {
        GameObject newObject = Instantiate(prefabs[0], RandomPointInBounds(GetComponent<BoxCollider2D>().bounds), Quaternion.identity);
    }

    public void InitCollider(BoxCollider col)
    {
        Camera camera = Camera.main;

        if (!camera.orthographic)
        {
            Debug.LogError("Camera isn't orthographic");
            return;
        }

        float aspect = (float)Screen.width / Screen.height;
        float orthoSize = camera.orthographicSize;

        float width = 2.0f * orthoSize * aspect * 2;
        float height = 2.0f * camera.orthographicSize * 2;

        col.size = new Vector3(width, height, 0f);
    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //If player is dead, stop spawnning
            if (player.IsDead)
            {
                StopSpawn();
            }

            //Membuat obstacle
            SpawnObstacle();

            //Menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(0.5f);
        }
    }
}
