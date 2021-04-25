using UnityEngine;

namespace Maps
{
    [CreateAssetMenu(fileName = "new Color Dictionary", menuName = "Data/Maps/Color Dictionary")]
    public class ColorDictionaryData : ScriptableObject
    {
        public ColorMapping[] mappings;
    }
}
