using Unity.VisualScripting;
using UnityEngine;
/*
 * This class is responsible for the zombie movement 
 */
public class ZombieMovement : MonoBehaviour
{
    public float walkSpeed = 5f;  // Normal speed
    private Transform player;
    private GameObject playerObject;

    void Awake()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
        else 
            Debug.Log("Player not found.");
    }

    void Update()
    {
        Vector3 direction = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.position = Vector3.MoveTowards(transform.position, direction, Speed() * Time.deltaTime);
    }

    public float Speed()
    {
        float distance = gameObject.transform.position.z - playerObject.transform.position.z; // Distance between zombie and player
        if (distance < 40) // If the player is close, increase speed
            return walkSpeed * 1.5f;
        
        return walkSpeed; // Otherwise, return normal speed
    }
}
