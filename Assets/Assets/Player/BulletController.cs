using UnityEngine;

public class BulletController : MonoBehaviour
{
    private float boundaryZ; // Store the end of the plane
    public int damage = 25; 

    void Start()
    {
        
        GameObject plane = GameObject.Find("Surface"); // Make sure your plane is named "Surface"
        if (plane != null) 
        {
            float planeLength = plane.transform.localScale.z * 10f; // Unity's default Plane is 10x10 units
            boundaryZ = plane.transform.position.z + (planeLength / 2); // Get the end of the plane
        }
        
    }

    void Update()
    {
        // Destroy the bullet if it moves past the end of the plane
        if (transform.position.z >= boundaryZ)
        {
            Destroy(gameObject);
        }
    }
}
