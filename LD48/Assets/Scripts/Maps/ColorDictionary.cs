
using UnityEngine;

[System.Serializable]
public class ColorDictionary
{
    public Color color;
    public GameObject[] possiblePrefabs;
    public GameObject prefab() {
        int r = Random.Range(0, possiblePrefabs.Length);
        return possiblePrefabs[r];
    }
}
