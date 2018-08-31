using UnityEngine;

/*
 * An object with a rigidbody that can be pooled
 */

[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject
{
    public Rigidbody Body { get; private set; }

    // A stuff can have multiple meshRenderer
    private MeshRenderer[] meshRenderers;

    private void Awake()
    {
        Body = GetComponent<Rigidbody>();
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the stuff enter the trigger, it return to the pool
        if (other.CompareTag("Kill Zone"))
            ReturnToPool();
    }

    public void SetMaterial(Material m)
    {
        for (int i = 0; i < meshRenderers.Length; ++i)
            meshRenderers[i].material = m;
    }

    private void OnLevelWasLoaded()
    {
        ReturnToPool();
    }
}
