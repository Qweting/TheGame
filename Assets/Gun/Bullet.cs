using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float fireRate = 10f;
    public Transform firePoint; //this is the anchor from which the bullet will be fired
    public float bulletSpeed = 10f;
    
    private float nextFireTime = 0f;
    
    
    void Update()
    {
        if(Time.time >= nextFireTime)
        { 
            Fire();
            nextFireTime = Time.time + (1f / fireRate);
        }
    }
    
    private void Fire()
    {
        GameObject bullet = BulletPool.SharedInstance.GetPoolObject();
        if(bullet != null)
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            bullet.SetActive(true);
            
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if(rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("BulletDestroyTrigger"))
            gameObject.SetActive(false);
    }
    
    
    
}