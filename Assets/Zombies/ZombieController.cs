using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform[] spawnPoints; // Array of spawn points
    public int zombieCount = 10; // Number of zombies to spawn
    public float spawnDelay = 0.5f; // Delay between spawns
    public int zombiesAlive; // Number of zombies currently alive
    private Transform player;
    private bool respawn = true; // Flag to control spawning

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnZombies());
        zombiesAlive = zombieCount;
    }

    //spawns zombis at random spawn points
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
            yield return new WaitForSeconds(spawnDelay); //delay the spawn between zombies so they don't spawn into each other
        }

        yield return new WaitForSeconds(5f); // Delay of 10 seconds
        respawn = false; // Allow spawning again
    }

    void Update()
    {
        if (!respawn) //if we are done spawning spawn again
        {
            respawn = true; //dont allow spawning
            StartCoroutine(SpawnZombies());
        }
    }

    
}