using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireRate = 1f;
    public Transform firePoint; // This is the anchor from which the bullet will be fired
    public float bulletSpeed = 10f;
    private int zombiesKilled = 0;
    private float damage = 10f; 
    

    private Coroutine fireCoroutine;

    

    void Update()
    {
        if(fireCoroutine == null)
            fireCoroutine = StartCoroutine(FireCoroutine());
    }

    // This coroutine is called every 1/fireRate seconds
    IEnumerator FireCoroutine()
    { 
        Fire();
        yield return new WaitForSeconds(1f / fireRate);
        fireCoroutine = null;
    }

    // This method is called when the player presses the fire button
    private void Fire()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPoolObject();
        if (bullet != null)
        {
            
            bullet.transform.position = firePoint.position;
            bullet.SetActive(true);

            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
                rb.velocity = firePoint.forward * bulletSpeed;
        }
    }

    //Trigger to destroy the bullet when it hits the wall
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BulletDestroyTrigger"))
        {
            gameObject.SetActive(false);
        }
    }

    // This method is called by the PowerUpController to change the fire rate
    public void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate;
        Fire(); // Restart firing with the new rate
    }

    // This method is called by the PowerUpController to get the current fire rate
    public float GetFireRate()
    {
        return fireRate;
    }


    public int ZombiesKilled()
    {
        return zombiesKilled;
    }

    public void SetZombiesKilled()
    {
        zombiesKilled += 1; 
    }

    public void ResetZombieKills()
    {
        zombiesKilled = 0; 
    }
    
    public void SetDamage(float newDamage)
    {
        damage = newDamage;
    }
    
    public float GetDamage()
    {
        return damage;
    }
    
}