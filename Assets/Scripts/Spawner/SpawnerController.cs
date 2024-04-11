using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] enemy;
    float spawnTime;
    void Start()
    {
        StartCoroutine(SpawnSystem());
    }
    IEnumerator SpawnSystem()
    {
        while (true)
        {
            if (gameObject.name!="fly_enemy")
                SpawnObject();

            spawnTime = Random.Range(1, 5);
            yield return new WaitForSeconds(spawnTime);
            SpawnObject();
        }
    }
    void SpawnObject()
    {
        int randomIndex=Random.Range(0, enemy.Length);

        GameObject temp = Instantiate(enemy[randomIndex]);
        temp.transform.position = spawnPoint.position;
    }
}
