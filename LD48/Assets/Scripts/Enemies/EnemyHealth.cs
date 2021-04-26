using System;
using System.Collections;
using Interfaces;
using Managers;
using UnityEngine;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 2;
        [SerializeField] private Color hurtColor = Color.red;

        private SpriteRenderer _renderer;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        public void ReceiveDamage(int damage)
        {
            health -= damage;
            StartCoroutine(FlashRed());
            if (health <= 0)
                Die();
        }

        private IEnumerator FlashRed()
        {
            _renderer.color = hurtColor; 
            yield return new WaitForSeconds(0.1f);
            _renderer.color = Color.white;
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
