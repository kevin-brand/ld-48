using Bombs.ExplosionPatterns;
using UnityEngine;

namespace Bombs
{
    [CreateAssetMenu(fileName = "new Bomb Data", menuName = "Data/Bombs/New Bomb Data")]
    public class BombData : ScriptableObject
    {
        public int fuseTime = 3;
        public int damage = 1;
        public ExplosionPattern pattern;
        public LayerMask whatIsAffected;

        public bool isLimited;
        public int numberOfBombs;

        public int timeToDisplayWarningEffectAt = 1;
        public Sprite sprite;
    }
}
