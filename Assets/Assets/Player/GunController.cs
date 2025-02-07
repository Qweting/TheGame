using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign the bullet prefab in Inspector
    public Transform firePoint; // The position where bullets spawn
    public float bulletSpeed = 10f; 
    public float fireRate = 0f; // Default fire rate (bullets per second)

    private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            rb.velocity = transform.forward * bulletSpeed; // Shoots forward
        }



        Destroy(bullet, 300f); // Destroy the bullet after 2 seconds
    }
    // Function to change fire rate dynamically
    public void SetFireRate(float newRate)
    {
        fireRate = Mathf.Clamp(newRate, 0.1f, 10f); // Prevents extreme values
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + (1f / fireRate); // Dynamic fire rate
        }
    }
}
