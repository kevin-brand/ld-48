using System;
using Interfaces;
using UnityEngine;

namespace Enemies
{
    public class HurtTrigger : MonoBehaviour
    {
        [SerializeField] private int damage = 2;
        [SerializeField] private int layerIndex = 9;
        [SerializeField] private int[] ignoreLayerIndices;

        private void Start()
        {
            for (int i = 0; i < ignoreLayerIndices.Length; i++)
            {
                Physics2D.IgnoreLayerCollision(layerIndex, ignoreLayerIndices[i], true);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("Something entered hurt box: " + other.name);
            if (other.GetComponent<IDamageable>() != null)
            {
                other.GetComponent<IDamageable>().ReceiveDamage(damage);
            }
        }
    }
}
