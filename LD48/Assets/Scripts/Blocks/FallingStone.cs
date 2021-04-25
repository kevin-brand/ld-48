using System;
using Interfaces;
using UnityEngine;

namespace Blocks
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class FallingStone : Stone
    {
        [SerializeField] private LayerMask killWhileFalling;
        private Rigidbody2D _rigidbody2D;
        private BoxCollider2D _boxCollider2D;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody2D.velocity.y < -1f)
            {
                var size = _boxCollider2D.size;
                Vector2 nextPosition = transform.position - new Vector3(size.x / 2, size.y / 2, 0);
                Collider2D other = Physics2D.OverlapBox(nextPosition, size * 0.95f, 0, killWhileFalling);

                if (other != null)
                {
                    other.transform.localScale = new Vector3(1f, 0.5f, 1f);
                    other.GetComponent<IDamageable>().ReceiveDamage(999);
                }
            } 
        }
    }
}
