using Interfaces;
using UnityEngine;

namespace Blocks
{
    public abstract class DestructibleBlock : MonoBehaviour, IDamageable
    {
        protected int Health = 2;
        public void ReceiveDamage(int damage)
        {
            Health -= Mathf.Abs(damage);
            
            if (Health <= 0)
                Die();
        }

        protected abstract void Die();
    }
}