using UnityEngine; 
using Unity; 

public class GunController : MonoBehaviour
{
    public float fireRate = 2f;
    public float nextFireTime = 0f;

    void Fire()
    {
        GameObject bullet = ObjectPool.SharedInstance.GetPoolObject(); 
        if (bullet != null)
        {
            bullet.transform.position = new Vector3(-0.5f, 0, 0); 
            bullet.SetActive(true);
        }
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + (1f / fireRate); 
        }
    }
    
    
    public void SetFireRate(float newFireRate)
    {
        fireRate = newFireRate; 
    }
    
}