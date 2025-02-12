using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool SharedInstance;
    public List<GameObject> poolObjects;
    public GameObject objectPool;
    public int amountToPool; 
    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        poolObjects = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(objectPool);
            tmp.SetActive(false);
            poolObjects.Add(tmp);
        }
    }
    
    public GameObject GetPoolObject()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
                return poolObjects[i];
        }

        return null; 
    }
    
    
    public void Notify()
    {
        gameObject.transform.position = gameObject.transform.position;
        gameObject.SetActive(true);
    }

}
