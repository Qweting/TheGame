using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    /*
     * this class handles the bullet velcoity. 
     */
    public float velocity = 10f;
    public GameObject bulletPrefab; 
    
    void Start()
    {
    }
    
    
    // Update is called once per frame
    void Update()
    {
        bulletPrefab.transform.forward = transform.forward * velocity;
    }
}
