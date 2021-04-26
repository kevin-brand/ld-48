using UnityEngine;

namespace Enemies
{
    public class EnemyJumpMovement : EnemyBasicMovement
    {
        [SerializeField] private float jumpHeight = 5;
        private RaycastHit2D _hit, _hit2, _grounded;
        
        protected override void Awake()
        {
            base.Awake();
        }
        
        protected override void Start()
        { 
            base.Start();
        }

        // Update is called once per frame
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }

        protected override void Move(Vector3 position)
        {
            _hit = Physics2D.Linecast(position + new Vector3(Dir * 0.37f, 0, 0), position + new Vector3(Dir * .7f, 0, 0), bounceOff);
            _hit2 = Physics2D.Linecast(position + new Vector3(Dir * 0.37f, 1, 0), position + new Vector3(Dir * .71f, 1, 0), bounceOff);
            _grounded = Physics2D.Linecast(position + new Vector3(0, -0.37f, 0), position + new Vector3(0, -.5f, 0), bounceOff); 

            if (_hit.collider != null)
            {
                if ((_grounded.collider != null) && (_hit2.collider == null))
                {
                    //jump
                    Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, jumpHeight);
                } 
                else if (_grounded.collider != null)
                {
                    Dir *= -1;
                }
            }
            Rigidbody2D.velocity = new Vector2(Dir * speed, Rigidbody2D.velocity.y);
            transform.localScale = new Vector2(Dir * transform.localScale.x, transform.localScale.y);
        }
    }
}
