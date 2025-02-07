using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBodyDetection : MonoBehaviour
{
    void Start()
    {
        Collider bulletCollider = GetComponent<Collider>();
        if (bulletCollider != null)
        {
            bulletCollider.isTrigger = true;  // Ensure it's a trigger
        }
    }

    // This method is called when the zombie's collider enters a trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")) // Check if the object is tagged as "bullet"
        {
            // Print "bullet hit" when a bullet hits the zombie
            Debug.Log("Bullet hit");

            // Optional: You can add damage logic here (e.g., subtract health)
            // For now, we’ll just destroy the zombie when hit
            Destroy(gameObject);  // Destroy the zombie on bullet hit
        }
    }
}
