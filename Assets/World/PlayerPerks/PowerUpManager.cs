using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    //powerup movement speed
    public Transform[] spawnPoints; // Assign spawn points in the Inspector
    public float spawnDelay = 5f; // Time before first spawn

    public GameObject rightWall; 
    public GameObject leftWall;

    private float spawnChance = 10f; // 10% chance to spawn a power-up

    public void GamblePerk()
    {
        float random = Random.Range(0f, 100f); //this is the odds of spawning a new power up panel
        
        
        //if the random number is less than 10, spawn a power up panel
        if ( random < spawnChance)
        {
            //16:20
            SpawnPowerup();
        }
    }
    

    void SpawnPowerup()
    {
        //since power up perks are rare (maybe) we can afford to instantiate them at runtime instead of using object pooling (ITHINK)
        //spawn the walls
        Instantiate(rightWall, spawnPoints[0].position, Quaternion.identity);
        Instantiate(leftWall, spawnPoints[0].position, Quaternion.identity);
        
        //activate the walls so that the update gets called and they can move.
        leftWall.SetActive(true);
        rightWall.SetActive(true);

    }
}
