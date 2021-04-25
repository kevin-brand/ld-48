using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasicMovement : MonoBehaviour
{

    public float Speed;
    public int Dir;
    public LayerMask BounceOff;

    private Rigidbody2D rb;
    private RaycastHit2D _hit;

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
        _hit = Physics2D.Linecast(gameObject.transform.position + new Vector3(Dir * 0.37f, 0, 0), gameObject.transform.position + new Vector3(Dir * .5f, 0, 0), BounceOff);
        Debug.DrawLine(gameObject.transform.position + new Vector3(Dir * 0.37f, 0, 0), gameObject.transform.position + new Vector3(Dir * .5f, 0, 0), Color.red, 1);
        if (_hit.collider != null)
        {            
            Dir *= -1;
        }
        rb.velocity = new Vector2(Dir * Speed, rb.velocity.y);
        transform.localScale = new Vector2(Dir * .7f, .7f);
    }
}
