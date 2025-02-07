using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    //powerup movement speed
    public GameObject powerupPrefab; // Assign this in the Inspector
    public Transform[] spawnPoints; // Assign spawn points in the Inspector
    public float spawnDelay = 5f; // Time before first spawn

    void Start()
    {
        // Spawn power-up after 5 seconds
        Invoke("SpawnPowerup", spawnDelay);
    }

    void SpawnPowerup()
    {
        if (spawnPoints.Length == 0) return;

        // Select a random spawn point
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Instantiate the power-up at the spawn point
        Instantiate(powerupPrefab, spawnPoint.position, Quaternion.identity);
    }
}
