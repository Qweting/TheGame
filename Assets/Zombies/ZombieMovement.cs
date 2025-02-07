using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public float walkSpeed = 2f;  // Normal speed
    public float runSpeed = 4f;   // Faster speed when chasing
    public float straightWalkTime = 4f; // Time before switching to chase mode
    private Transform player;
    private Vector3 initialDirection;
    private bool isChasing = false;
    private float timer = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        initialDirection = transform.forward; // Move forward initially
    }

    void Update()
    {
        if (!isChasing)
        {
            // Move forward for a set duration
            transform.position += initialDirection * walkSpeed * Time.deltaTime;
            timer += Time.deltaTime;

            if (timer >= straightWalkTime)
            {
                isChasing = true; // Start chasing the player
            }
        }
        else
        {
            // Move towards the player after straight movement
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, runSpeed * Time.deltaTime);
        }
    }
}
