using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    public float spawnTime = 2.0f;
    public float deSpawnTime = 4.0f;
    public GameObject prefabCoin;

    private float seconds = 0f;


    // Update is called once per frame
    void Update()
    {
        seconds += spawnTime;
        StartCoroutine(SpawnCoinsWait(seconds));
    }

    private Vector3 RandomVector()
    {
        float randomX = Random.Range(-8f, 8f);
        float randomZ = Random.Range(-8f, 8f);

        return new Vector3(randomX, transform.position.y, randomZ);


    }

    IEnumerator SpawnCoinsWait(float spawnTime)
    {
        yield return new WaitForSeconds(spawnTime);
        GameObject coin = Instantiate(prefabCoin, RandomVector(), Quaternion.identity);
        coin.transform.parent = gameObject.transform;

        StartCoroutine(DeSpawnWait(deSpawnTime, coin));
    }

    IEnumerator DeSpawnWait(float spawnTime, GameObject coin)
    {
        yield return new WaitForSeconds(spawnTime);
        Destroy(coin);

    }
}
