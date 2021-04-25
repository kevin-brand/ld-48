using System;
using UnityEngine;

namespace Bombs
{
    [Serializable]
    public class BombSlot
    {
        public BombData Bomb { get; private set; }
        public int held;

        public void SetBomb(BombData data)
        {
            Bomb = data;
            held = Bomb.numberOfBombs;
        }
        
        
    }
}