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

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(0, 0, 10f) * Time.deltaTime; //move the Power up panels towards the player
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            if (health <= 0)
            {
                GenerateBulletMultiplayer();
                SetEffect();
                Destroy(gameObject);
            }
            else
                health -= 1;
        }

    }

    //generate a random number between 0 and 10, this number is used for the fire rate multiplayer
    private void GenerateBulletMultiplayer()
    {
        float tmp = Random.Range(2f, 10f);
        bulletMultiplayer = tmp;
    }

    //return the fire rate multiplayer
    public float GetBulletMultiplayer()
    {
        return bulletMultiplayer;
    }

    //set the fire rate multiplayer
    public void SetEffect()
    {
        Bullet bullet = GameObject.Find("Bullet").GetComponent<Bullet>();
        bullet.SetFireRate(GetBulletMultiplayer());
    }
}
