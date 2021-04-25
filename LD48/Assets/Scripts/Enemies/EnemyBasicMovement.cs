using UnityEngine;

namespace Enemies
{
    public class EnemyBasicMovement : MonoBehaviour
    {

        public float speed;
        public LayerMask bounceOff;

        protected int Dir = 1;
        protected Rigidbody2D Rigidbody2D;
        protected RaycastHit2D Hit;
        protected Transform Transform;

        protected virtual void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Transform = GetComponent<Transform>();
        }

        protected virtual void Start()
        {
            Physics2D.IgnoreLayerCollision(9, 9, true);
            Physics2D.IgnoreLayerCollision(9, 8, true);
        }
    
        protected virtual void FixedUpdate()
        {
            var position = Transform.position;
            Move(position);
        }

        protected virtual void Move(Vector3 position)
        {
            Hit = Physics2D.Linecast(position + new Vector3(Dir * 0.37f, 0, 0), position + new Vector3(Dir * .5f, 0, 0), bounceOff);
            if (Hit.collider != null)
            {            
                Dir *= -1;
            }
            Rigidbody2D.velocity = new Vector2(Dir * speed, Rigidbody2D.velocity.y);
            transform.localScale = new Vector2(Dir * .7f, .7f);
        }
    }
}
