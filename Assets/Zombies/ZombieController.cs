using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public int zombieCount = 10; // Number of zombies to spawn
    public float spawnDelay = 0.5f; // Delay between spawns
    private int zombiesAlive; // Number of zombies currently alive
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnZombies());
        zombiesAlive = zombieCount;
    }

    IEnumerator SpawnZombies()
    {
        for (int i = 0; i < zombieCount; i++)
        {
            GameObject zombie = ZombieObjectPool.SharedInstance.GetPoolObject();
            if (zombie != null)
            {
                zombie.transform.position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                zombie.gameObject.SetActive(true);
                zombiesAlive += 1; // Increment the number of zombies alive
                Debug.Log("Successfully spawned zombie at " + zombie.transform.position);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    //this doesn't work.
    void Update()
    {
        if (zombiesAlive == 0 || zombiesAlive < zombieCount || IsZombieCloseToPlayer())
        {
            // StartCoroutine(SpawnZombies());
            
        }
    }

    private bool IsZombieCloseToPlayer()
    {
        foreach (GameObject zombie in ZombieObjectPool.SharedInstance.poolObjects)
        {
            if (zombie.activeInHierarchy)
            {
                float distance = Vector3.Distance(zombie.transform.position, player.position);
                if (distance < 100)
                {
                    return true;
                }
            }
        }
        return false;
    }
}