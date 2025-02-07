using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool SharedInstance;
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

    public void Notify(GameObject gameObject)
    {
        gameObject.transform.position = new Vector3(0, 0, 110.55f); 
        gameObject.SetActive(true);
    }
    
    
}
