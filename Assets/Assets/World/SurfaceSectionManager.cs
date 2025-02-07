using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class is used for moving the surface.
 */
public class SurfaceSectionManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(0, 0, 10) * Time.deltaTime;
    }
}
