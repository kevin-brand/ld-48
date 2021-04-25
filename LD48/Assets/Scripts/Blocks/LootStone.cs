using System;
using UnityEngine;

namespace Blocks
{
    public class LootStone : DestructibleBlock
    {
        [SerializeField] private GameObject drop;
        [SerializeField] private int dropAmount = 1;

        protected override void Die()
        {
            if (drop != null)
            {
                for (int i = 0; i < dropAmount; i++)
                {
                    Instantiate(drop, transform.position, Quaternion.identity);
                }
            }

            Destroy(this.gameObject);
        }
    }
}
