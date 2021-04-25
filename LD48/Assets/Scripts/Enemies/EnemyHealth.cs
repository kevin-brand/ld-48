using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 2;
        public void ReceiveDamage(int damage)
        {
            Debug.Log("I recieved damage!");
            health -= damage;
            
            if (health <= 0)
                Die();
        }

        private void Die()
        {
            Destroy(this.gameObject);
        }
    }
}
