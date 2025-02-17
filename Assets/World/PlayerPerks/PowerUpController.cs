using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
/*
 * This class is responsible for the power up panels that spawn in the game.
 */

public class PowerUpController : MonoBehaviour
{
    public float health = 10f; //after it gets 10 times with a bullet it gets destroyed
    private float bulletMultiplayer; //how much the fire rate of the player will increase



    void Start()
    {
        GenerateRandomPanelHealth();
        
    }
    
    
    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(0, 0, 5f) * Time.deltaTime; //move the Power up panels towards the player
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (health <= 0)
            {
                GenerateRandomPerk();
                Destroy(gameObject);
            }
            else
                health -= 1;
        }

    }

    //generate a random number between 0 and 10, this number is used for the fire rate multiplayer
    private void BulletPositiveMultiplier()
    {
        float tmp = Random.Range(2f, 6f);
        bulletMultiplayer = tmp;
    }
    
    //opposite of the BulletPositriveMultiplier method
    private void BulletNegativeMultiplier()
    {
        float tmp = Random.Range(0.5f, 1.5f);
        bulletMultiplayer = tmp;
    }

    //zombies take only one bullet to kill
    private void DestroyOnHit()
    {
        
    }

    //return the fire rate multiplayer
    public float GetBulletMultiplayer()
    {
        return bulletMultiplayer;
    }

    //set the fire rate multiplayer
    public void SetEffect(string effect)
    {
        if (effect.Equals("Positive"))
        {
            Bullet bullet = GameObject.Find("Bullet").GetComponent<Bullet>();
            bullet.SetFireRate(GetBulletMultiplayer());
        } 
        
        if (effect.Equals("Negative"))
        {
            Bullet bullet = GameObject.Find("Bullet").GetComponent<Bullet>();
            bullet.SetFireRate(GetBulletMultiplayer());
        }

        if (effect.Equals("WeakenZombies"))
        {
            Zombie zombie = GameObject.Find("Zombie").GetComponent<Zombie>();
            zombie.SetZombieHealth(1);
        }
    }

    //generates a new random perk effect. 
    public void GenerateRandomPerk()
    {
        float random = Random.Range(0f, 100f); //odd of spawning differennt types of perks

        if (random >= 0 && random <= 25)
        {
            BulletPositiveMultiplier();
            SetEffect("Positive");
        } else if (random > 25 && random <= 50)
        {
            BulletNegativeMultiplier();
            SetEffect("Negative");
        } else if (random > 50 && random <= 65)
        {
            SetEffect("WeakenZombies");
        }

    }


    public void GenerateRandomPanelHealth()
    {
        float random = Random.Range(40f, 100f);
        health = random;
        
        Debug.Log("Panel health bar is at:" + random);
    }
    
    
    
}
