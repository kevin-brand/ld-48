using System.Collections.Generic;
using UnityEngine;

namespace Bombs.ExplosionPatterns
{
    public abstract class ExplosionPattern : ScriptableObject
    {
        public abstract List<Vector2> GetExplosionPositions(Vector2 point);
    }
}
