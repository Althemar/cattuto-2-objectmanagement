using UnityEngine;

/*
 * StuffSpawner
 * A spawner of Stuff 
 */

public class StuffSpawner : MonoBehaviour
{
    public FloatRange timeBetweenSpawns;
    public FloatRange scale;
    public FloatRange randomVelocity;
    public FloatRange angularVelocity;
    public float velocity;

    // The material that will be assigned to spawned objects
    public Material stuffMaterial;

    // The prefabs that can be created
    public Stuff[] stuffPrefabs;

    private float timeSinceLastSpawn;
    private float currentSpawnDelay;

    private void FixedUpdate()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= currentSpawnDelay)
        {
            timeSinceLastSpawn -= currentSpawnDelay;
            currentSpawnDelay = timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }
    }

    // Spawn a stuff object
    private void SpawnStuff()
    {
        // Get an object from the pool
        Stuff prefab = stuffPrefabs[Random.Range(0, stuffPrefabs.Length)];
        Stuff spawn = prefab.GetPooledInstance<Stuff>();

        spawn.transform.localPosition = transform.position;
        spawn.transform.localScale = Vector3.one * scale.RandomInRange;
        spawn.transform.localRotation = Random.rotation;

        spawn.Body.velocity = transform.up * velocity + Random.onUnitSphere * randomVelocity.RandomInRange;
        spawn.Body.angularVelocity = Random.onUnitSphere * angularVelocity.RandomInRange;

        spawn.SetMaterial(stuffMaterial);
    }
}
