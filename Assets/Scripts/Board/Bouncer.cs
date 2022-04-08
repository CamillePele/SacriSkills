using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bouncer : MonoBehaviour
{
    
    public GameObject player;
    public float bounceForce = 3;

    public float maxBounce = 20f;
    
    public Transform leftPosition;
    public Transform rightPosition;

    public bool leftBouncer= false;
    public bool rightBouncer = false;
    
    public SpriteRenderer Middle;
    public SpriteRenderer Left;
    public SpriteRenderer Right;
    public SpriteRenderer Alone;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rigidbody = other.gameObject.GetComponent<Rigidbody2D>();
            
            if (rigidbody.velocity.y < 0)
                rigidbody.velocity = new Vector2(rigidbody.velocity.x,  Mathf.Min(maxBounce, (rigidbody.velocity.y * bounceForce) * -1));

            other.GetComponent<Movement>().collision.onGround = true;

        }
    }
    
    private void Start()
    {
        leftBouncer = Physics2D.OverlapCircleAll((Vector2)leftPosition.position, 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Bouncer>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        rightBouncer = Physics2D.OverlapCircleAll((Vector2)rightPosition.position, 0.2f)
            .AsEnumerable().Where(x => x.gameObject.GetComponent<Bouncer>() != null && !x.CompareTag("Board")).ToList().Count > 0;

        if (leftBouncer && rightBouncer) Alone.enabled = true;
        else if (leftBouncer) Left.enabled = true;
        else if (rightBouncer) Right.enabled = true;
        else Middle.enabled = true;
        
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawWireSphere( (Vector2)leftPosition.position, 0.2f);
        Gizmos.DrawWireSphere((Vector2)rightPosition.position, 0.2f);
    }
}
