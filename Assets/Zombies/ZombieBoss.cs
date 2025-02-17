using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBoss : MonoBehaviour
{
    private float health = 200; //health of the zombie boss

    public float bulletDamage = 25f; //the damage each bullet does to it 

    private float movementSpeed = 2f; //its movement speed

    private Transform player; //coordinates of the player

    public Transform spawnPoint; //the coordinates for where we spawn the boss

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheBoss();
    }

    private void MoveTheBoss()
    {
        Vector3 direction = new Vector3(player.position.x, player.position.y, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, direction, movementSpeed * Time.deltaTime);
    }

    private void SpawnBoss()
    {
        transform.position = spawnPoint.position;
        Debug.Log("ZombieBoss has spawned");
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bullet"))
            if (health <= 1)
                Destroy(gameObject);
            else
                health -= bulletDamage;
        
    }
    
    
    
}
