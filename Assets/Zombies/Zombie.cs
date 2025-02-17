using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float health = 49f;
    // public BulletController bullet; //change this later on, create a clas sfor bullet //how do we use this approach? 
    public float bullet = 25;
    private ZombieController zombieController;
    private PowerUpManager _powerUpManager;
    
    // Start is called before the first frame update
    void Start()
    {
        Collider bulletCollider = GetComponent<Collider>(); 
        if(bulletCollider != null)
            bulletCollider.isTrigger = true;
        _powerUpManager = FindObjectOfType<PowerUpManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            //print collision 
            if (health < 25)
            {
                Bullet bulletZombieKills = other.GetComponent<Bullet>(); //increment the number of zombies killed
                //spawn a panel after 100 zombies killed.
                bulletZombieKills.SetZombiesKilled();
                gameObject.SetActive(false);
                if(bulletZombieKills.ZombiesKilled() >= 100)
                {
                    _powerUpManager.GamblePerk();
                    bulletZombieKills.ResetZombieKills();
                }
            }
            else
                health -= bullet;
            
        }
    }
    
    public void SetZombieHealth(float health)
    {
        this.health = health;
    }
    
    
}
