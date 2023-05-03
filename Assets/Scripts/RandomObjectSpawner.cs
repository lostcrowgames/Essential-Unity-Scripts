using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectSpawner : MonoBehaviour
{
    public GameObject[] coinPrefabs;
    public GameObject heartPrefab;
    public int minCoins;
    public int maxCoins;
    public float coinSpawnRadius;
    public float heartSpawnRadius;
    public float coinForceMultiplier;
    public float heartForceMultiplier;
    [Range(0, 1)] public float coinSpawnProbability = 0.5f;
    private Transform coinHolderTransform;

    private void Awake()
    {
        coinHolderTransform = GameObject.Find("CoinHolder").transform;
    }

    public void SpawnRandomObjects()
    {
        Debug.Log("Spawning random objects");
        // Choose between spawning coins or a heart (50% chance each)
        if (Random.value < coinSpawnProbability)
        {
            SpawnCoins();
        }
        else
        {
            SpawnHeart();
        }
    }

    private void SpawnCoins()
    {
        int numCoins = Random.Range(minCoins, maxCoins + 1);

        for (int i = 0; i < numCoins; i++)
        {
            // Select a random coin prefab
            GameObject randomCoinPrefab = coinPrefabs[Random.Range(0, coinPrefabs.Length)];

            GameObject coin = Instantiate(randomCoinPrefab, transform.position, Quaternion.identity, coinHolderTransform);
            Rigidbody coinRb = coin.GetComponent<Rigidbody>();

            Vector3 randomDirection = Random.insideUnitSphere * coinSpawnRadius;
            randomDirection.y = Mathf.Abs(randomDirection.y); // Make sure the coins fly upwards

            coinRb.AddForce(randomDirection * coinForceMultiplier, ForceMode.Impulse);
        }
    }

    private void SpawnHeart()
    {
        GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
        Rigidbody heartRb = heart.GetComponent<Rigidbody>();

        Vector3 randomDirection = Random.insideUnitSphere * heartSpawnRadius;
        randomDirection.y = Mathf.Abs(randomDirection.y); // Make sure the heart flies upwards

        heartRb.AddForce(randomDirection * heartForceMultiplier, ForceMode.Impulse);
    }
}
