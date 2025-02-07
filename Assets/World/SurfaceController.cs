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
        //move the surface
        transform.position -= new Vector3(0, 0, 10) * Time.deltaTime;
        //check if the z coordinate of the prefab is less than 57 (ie check if the surface is behind the playuer) 
        //if so we call on Notify, in Notify we use object pooling. Oh yeah, also set the active state to false. 
        if (transform.position.z <= -57.5)
        {
            gameObject.SetActive(false);
            ObjectPool.SharedInstance.Notify(gameObject);

        }
    }
}
