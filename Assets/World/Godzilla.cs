using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This class is responsible for destroy the objects that are not visible for the 
//player, thus its called Godzilla. 
//All objects that enter the DestroySection are destroyed. 
public class Godzilla : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 56.31
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Destroy"))
            Destroy(gameObject);
    }
}
