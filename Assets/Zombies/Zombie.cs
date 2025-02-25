using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float health = 29f;
    // public BulletController bullet; //change this later on, create a clas sfor bullet //how do we use this approach? 
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
            Bullet bullet = other.GetComponent<Bullet>(); //increment the number of zombies killed
            //print collision 
            if (health < 25)
            {
                ZombieScoreManager.instance.AddScore(2);
                RoundScoreManager.instance.AddZombieKilled();
                //spawn a panel after 100 zombies killed.
                bullet.SetZombiesKilled();
                gameObject.SetActive(false);
                if(bullet.ZombiesKilled() >= 30  ) //after 30 zombies kills spawn perks
                {
                    _powerUpManager.GamblePerk();
                    bullet.ResetZombieKills();
                }
            }
            else
                health -= bullet.GetDamage();
            
            other.gameObject.SetActive(false);
        }
    }
    
    public void SetZombieHealth(float health)
    {
        this.health = health;
    }
    
    public float getZombieHealth()
    {
        return health;
    }
    
    
}
