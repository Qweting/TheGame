using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieObjectPool : MonoBehaviour
{
    public static ZombieObjectPool SharedInstance;
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
    
    void Update()
    {
        
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
    
    
}
