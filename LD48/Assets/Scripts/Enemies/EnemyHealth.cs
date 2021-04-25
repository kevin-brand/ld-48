using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 2;
        public void ReceiveDamage(int damage)
        {
            health -= damage;
            
            if (health <= 0)
                Die();
        }

        private void Die()
        {
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddEnemyScore(1);
            }
            Destroy(this.gameObject);
        }
    }
}
