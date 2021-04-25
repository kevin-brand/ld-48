using System;
using Bombs;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class HurtTrigger : MonoBehaviour
    {
        [SerializeField] private int damage = 2;
        //[SerializeField] private int layerIndex = 9;
        //[SerializeField] private int[] ignoreLayerIndices;
        [SerializeField] public bool canDetonateBombs;
        
        /*private void Start()
        {
            for (int i = 0; i < ignoreLayerIndices.Length; i++)
            {
                Physics2D.IgnoreLayerCollision(layerIndex, ignoreLayerIndices[i], true);
            }
        }*/

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<Bomb>() != null && !canDetonateBombs)
                return;
            
            if (other.CompareTag("Player") && other.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().ReceiveDamage(damage);
            }
        }
    }
}
