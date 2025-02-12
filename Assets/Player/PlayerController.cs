using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Class for controlling player left & right movement
 */
public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public float minX = -10f, maxX = 10f; //max/min bound 
    private Animator animator;

    void Start()
    {
        // Get reference to Animator
        animator = GetComponent<Animator>();

        // Get plane boundaries dynamically
        GameObject plane = GameObject.Find("Surface");
        if (plane != null)
        {
            MeshRenderer renderer = plane.GetComponent<MeshRenderer>();
            float planeWidth = renderer.bounds.size.x;
            Vector3 planeCenter = plane.transform.position;

            // Calculate minX and maxX based on the plane's size
            minX = planeCenter.x - (planeWidth / 2);
            maxX = planeCenter.x + (planeWidth / 2);
        }
        else
        {
            Debug.LogError("Plane not found! Make sure the plane is named 'Plane'.");
        }

    }

    void Update()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.A)) // Move left
        {
            move = new Vector3(-speed * Time.deltaTime, 0, 0);
            // animator.SetTrigger("MoveLeft");
        }
        else if (Input.GetKey(KeyCode.D)) // Move right
        {
            move = new Vector3(speed * Time.deltaTime, 0, 0);
            // animator.SetTrigger("MoveRight");
        }
        else
        {
            // animator.SetTrigger("Idle"); // Reset to Idle if no key is pressed
        }

        transform.position += move;

        // Clamp position within boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minX, maxX),
            transform.position.y,
            transform.position.z
        );
    }

}
