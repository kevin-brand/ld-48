using System.Collections.Generic;
using UnityEngine;

namespace Bombs.ExplosionPatterns
{
    [CreateAssetMenu(fileName = "new Directional Pattern", menuName = "Data/Bombs/Directional Pattern")]
    public class DirectionalPattern : ExplosionPattern
    {
        public Vector2[] directions;
        public int range = 2;
        public override List<Vector2> GetExplosionPositions(Vector2 point)
        {
            List<Vector2> explosionPositions = new List<Vector2>();
            explosionPositions.Add(point);
            foreach (var direction in directions)
            {
                for (int i = 1; i <= range; i++)
                {
                    Vector2 pos = point + i * direction;
                    explosionPositions.Add(pos);
                }
            }

            return explosionPositions;
        }
    }
}
