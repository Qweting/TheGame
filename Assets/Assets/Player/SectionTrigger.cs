using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is responsible for creating new road tiles.
 * With the CreateSection box collider, we detect if a "Trigger"
 * box collider has entered the...box collider. 
 */
public class SectionTrigger : MonoBehaviour
{
    public GameObject roadSection;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(roadSection, new Vector3(0, 0, (float)(112.62)), Quaternion.identity);
        }
    }
}

