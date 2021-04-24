using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ExplosionPattern : ScriptableObject
{
    public abstract List<Vector2> GetExplosionPositions(Vector2 point);
}
