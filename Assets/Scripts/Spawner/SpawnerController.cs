using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject spawnEnemy;
    float spawnTime;
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }


    void Update()
    {

    }
    IEnumerator SpawnSystem()
    {
        while (true)
        {
            spawnTime = Random.Range(1, 5);
            yield return new WaitForSeconds(spawnTime);
            SpawnObject();
        }


    }
    void SpawnObject()
    {
        GameObject temp = Instantiate(spawnEnemy);
        temp.transform.position = spawnPoint.position;
    }
}
