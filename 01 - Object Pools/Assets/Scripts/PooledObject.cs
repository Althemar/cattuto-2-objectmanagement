using UnityEngine;

/*
 * PooledObject
 * An object that can be pooled and get from a pool
 */

public class PooledObject : MonoBehaviour
{
    // The pool where the object is pooled
    public ObjectPool Pool { get; set; }

    [System.NonSerialized]
    private ObjectPool poolInstanceForPrefab;

    // Return the object to the pool
    public void ReturnToPool()
    {
        if (Pool)
            Pool.AddObject(this);
        else
            Destroy(gameObject);
    }

    // Get an instance of the object from the linked pool
    public T GetPooledInstance<T>() where T : PooledObject
    {
        // If no pool is associated to the object, we get a new pool
        if (!poolInstanceForPrefab)
            poolInstanceForPrefab = ObjectPool.GetPool(this);
        return (T)poolInstanceForPrefab.GetObject();
    }
}