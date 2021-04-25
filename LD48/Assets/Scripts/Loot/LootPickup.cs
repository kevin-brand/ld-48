using System;
using UnityEngine;

namespace Loot
{
    public class LootPickup : MonoBehaviour
    {
        [SerializeField] private int value;
        [SerializeField] private float timeUntilDespawn = 10f;
        
        private void Update()
        {
            timeUntilDespawn -= Time.deltaTime;
            
            if (timeUntilDespawn <= 0)
                Despawn();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.CompareTag("Player"))
                return;
            
            if (ScoreManager.Instance != null)
            {
                ScoreManager.Instance.AddLootScore(value);
            }

            Despawn();
        }

        private void Despawn()
        {
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
