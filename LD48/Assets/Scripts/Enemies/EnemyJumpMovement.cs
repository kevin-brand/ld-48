using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpMovement : MonoBehaviour
{

    public float Speed;
    public float JumpHeight;
    public int Dir;
    public LayerMask BounceOff;

    private Rigidbody2D rb;
    private RaycastHit2D _hit, _hit2, _grounded;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    { 
        Physics2D.IgnoreLayerCollision(9, 9, true);
    }

    private void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _hit = Physics2D.Linecast(gameObject.transform.position + new Vector3(Dir * 0.37f, 0, 0), gameObject.transform.position + new Vector3(Dir * .7f, 0, 0), BounceOff);
        _hit2 = Physics2D.Linecast(gameObject.transform.position + new Vector3(Dir * 0.37f, 1, 0), gameObject.transform.position + new Vector3(Dir * .71f, 1, 0), BounceOff);
        _grounded = Physics2D.Linecast(gameObject.transform.position + new Vector3(0, -0.37f, 0), gameObject.transform.position + new Vector3(0, -.5f, 0), BounceOff); 
        Debug.DrawLine(gameObject.transform.position + new Vector3(Dir * 0.37f, 0, 0), gameObject.transform.position + new Vector3(Dir * .5f, 0, 0), Color.red, 1);
        Debug.DrawLine(gameObject.transform.position + new Vector3(Dir * 0.37f, 1, 0), gameObject.transform.position + new Vector3(Dir * .55f, 1, 0), Color.red, 1);
        Debug.DrawLine(gameObject.transform.position + new Vector3(0, -0.37f, 0), gameObject.transform.position + new Vector3(0, -.5f, 0), Color.red, 0);
        if (_hit.collider != null)
        {
            if ((_grounded.collider != null) && (_hit2.collider == null))
            {
                //jump
                rb.velocity = new Vector2(rb.velocity.x, JumpHeight);
            } 
            else if (_grounded.collider != null)
            {
                Dir *= -1;
            }
        }
        rb.velocity = new Vector2(Dir * Speed, rb.velocity.y);
        transform.localScale = new Vector2(Dir * .7f, .7f);
    }
}
