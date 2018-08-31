using UnityEngine;

/*
 * StuffSpawnerRing
 * A ring of StufferSpawner
 */

public class StuffSpawnerRing : MonoBehaviour
{
    public int numberOfSpawners;
    public float radius;
    public float tiltAngle;
    public StuffSpawner spawnerPrefab;
    public Material[] stuffMaterials;

    private void Awake()
    {
        for (int i = 0; i < numberOfSpawners; ++i)
            CreateSpawner(i);
    }

    // Create a new StuffSpawner
    private void CreateSpawner(int index)
    {
        // A rotater that set the orientation of the spawner
        Transform rotater = new GameObject("Rotater").transform;
        rotater.SetParent(transform, false);
        rotater.localRotation = Quaternion.Euler(0f, index * 360f / numberOfSpawners, 0f);

        // Instantiate the spawner
        StuffSpawner spawner = Instantiate<StuffSpawner>(spawnerPrefab);
        spawner.transform.SetParent(rotater, false);
        spawner.transform.localPosition = new Vector3(0f, 0f, radius);
        spawner.transform.localRotation = Quaternion.Euler(tiltAngle, 0f, 0f);

        spawner.stuffMaterial = stuffMaterials[index % stuffMaterials.Length];
    }
}
