using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private float health = 49f;
    // public BulletController bullet; //change this later on, create a clas sfor bullet //how do we use this approach? 
    public float bullet = 25; 
    
    // Start is called before the first frame update
    void Start()
    {
        Collider bulletCollider = GetComponent<Collider>(); 
        if(bulletCollider != null)
            bulletCollider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
        {
            //print collision 
            Debug.Log(("Bullet collision detected"));
            if (health <= 0)
                gameObject.SetActive(false);
            else
                health -= bullet; 
        }
    }
}
