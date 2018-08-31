using UnityEngine;

/*
 * FloatRange
 * Generate random floats within two floats
 */

[System.Serializable]
public struct FloatRange
{
    public float min;
    public float max;

    // Generate a random float within min and max
    public float RandomInRange
    {
        get{
            return Random.Range(min, max);
        }
    }
}
