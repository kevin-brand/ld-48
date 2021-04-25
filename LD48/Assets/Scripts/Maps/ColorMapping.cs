
using UnityEngine;

namespace Maps
{
    [System.Serializable]
    public class ColorMapping
    {
        public Color color;
        public GameObject[] possiblePrefabs;
        public GameObject GetRandomPrefab() {
            int r = Random.Range(0, possiblePrefabs.Length);
            return possiblePrefabs[r];
        }
    }
}
