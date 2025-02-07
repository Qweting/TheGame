using UnityEngine;

/*
 * Assign camera to the player and have it follow the player. 
 */
public class CameraController: MonoBehaviour
{
    public Transform player; // Reference to the player
    public Vector3 offset = new Vector3(0, 5, -10); // Camera offset

    void LateUpdate()
    {
        if (player != null)
        {
            // Update the camera's position to follow the player
            transform.position = player.position + offset;
        }
    }
}
