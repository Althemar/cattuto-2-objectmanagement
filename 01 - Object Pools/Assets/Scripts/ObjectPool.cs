using UnityEngine;
using System.Collections.Generic;

/*
 * ObjectPool
 * A pool which we can return objects to and get them
 */

public class ObjectPool : MonoBehaviour
{
    private PooledObject prefab;

    // The list of objects in the pool
    private List<PooledObject> availableObjects = new List<PooledObject>();

    // Create a new pool for a prefab
    public static ObjectPool GetPool(PooledObject prefab)
    {
        GameObject obj;
        ObjectPool pool;

        // Only in editor mode
        if (Application.isEditor)
        {
            obj = GameObject.Find(prefab.name + " Pool");
            if (obj)
            {
                pool = obj.GetComponent<ObjectPool>();
                if (pool)
                    return pool;
            }
        }
        obj = new GameObject(prefab.name + " Pool");
        DontDestroyOnLoad(obj);
        pool = obj.AddComponent<ObjectPool>();
        pool.prefab = prefab;
        return pool;
    }

    // Get an object from the pool
    public PooledObject GetObject()
    {
        PooledObject obj;
        int lastAvailableIndex = availableObjects.Count - 1;

        // If there is an available object, it is removed from the pool and activated
        if(lastAvailableIndex >= 0)
        {
            obj = availableObjects[lastAvailableIndex];
            availableObjects.RemoveAt(lastAvailableIndex);
            obj.gameObject.SetActive(true);
        }
        // Else, a new object is created and returned
        else
        {
            obj = Instantiate<PooledObject>(prefab);
            obj.transform.SetParent(transform, false);
            obj.Pool = this;
        }

        return obj;
    }

    // Add an object in the pool
    public void AddObject(PooledObject obj)
    {
        obj.gameObject.SetActive(false);
        availableObjects.Add(obj);

    }
}