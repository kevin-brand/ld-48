using System;
using System.Collections;
using Interfaces;
using Managers;
using UnityEngine;
using Utility;

namespace Enemies
{
    public class EnemyHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private int health = 2;
        [SerializeField] private Color hurtColor = Color.red;
        [SerializeField] private float hitStopDuration = 0.1f;

        private SpriteRenderer _renderer;
        private HitStop _hitStop;

        private bool _stoppingTime = false;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _hitStop = gameObject.AddComponent(typeof(HitStop)) as HitStop;
        }

        public void ReceiveDamage(int damage)
        {
            health -= damage;
            StartCoroutine(FlashRed());
            _hitStop.StopTime(hitStopDuration);
            if (health <= 0 && !_stoppingTime)
                Die();
        }

        private IEnumerator FlashRed()
        {
            _stoppingTime = true;
            _renderer.color = hurtColor; 
            yield return new WaitForSeconds(hitStopDuration);
            _stoppingTime = false;
            _renderer.color = Color.white;
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
