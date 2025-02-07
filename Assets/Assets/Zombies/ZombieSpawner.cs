using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Assign in the Inspector
    public Transform[] spawnPoints;  // Assign spawn locations in Inspector
    public float spawnRate = 1f;     // Time between spawns
    public int batchSize = 10;       // Number of zombies per batch
    public float activationDelay = 20f; // Delay before zombies start moving

    void Start()
    {
        StartCoroutine(SpawnBatches());
    }

    IEnumerator SpawnBatches()
    {
        // Initial spawn
        for (int i = 0; i < batchSize; i++)
        {
            SpawnObject();
            yield return new WaitForSeconds(2f); // Delay between each zombie spawn
        }

        // Subsequent spawns with activation delay
        while (true)
        {
            yield return new WaitForSeconds(activationDelay); // Delay before next batch
            for (int i = 0; i < batchSize; i++)
            {
                SpawnObject();
                yield return new WaitForSeconds(2f); // Delay between each zombie spawn
            }
        }
    }

    void SpawnObject()
    {
        if (spawnPoints.Length == 0 || objectToSpawn == null) return;

        Transform randomSpawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
        GameObject zombie = Instantiate(objectToSpawn, randomSpawn.position, randomSpawn.rotation);
        zombie.SetActive(true); // Deactivate the zombie initially
        StartCoroutine(ActivateZombie(zombie));
    }

    IEnumerator ActivateZombie(GameObject zombie)
    {
        yield return new WaitForSeconds(activationDelay); // Wait before activating the zombie
        zombie.SetActive(true);
    }
}
