using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : Skill
{
    private Movement movement;
    private BoxCollider2D boxCollider2D;
    
    public float sizeMultiplier = 2;
    public float speedMultiplier = 2;
    public float sensibility;
    
    private void Start()
    {
        movement = GetComponent<Movement>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (!active && movement.dir.y < sensibility)
        {
            boxCollider2D.size = new Vector2(boxCollider2D.size.x, boxCollider2D.size.y / sizeMultiplier);
            boxCollider2D.offset = new Vector2(boxCollider2D.offset.x, boxCollider2D.offset.y / sizeMultiplier);

            active = true;
        }
        else if (active && movement.dir.y >= sensibility)
        {
            RaycastHit2D hit = Physics2D.Raycast((Vector2) transform.position + (movement.collision.bottomOffset - Vector2.down*0.1f), Vector2.up, Mathf.Infinity, movement.collision.groundLayer);
            if (hit.distance >= boxCollider2D.size.x*sizeMultiplier) //a la place se lever
            {
                boxCollider2D.size = new Vector2(boxCollider2D.size.x, boxCollider2D.size.y * sizeMultiplier);
                boxCollider2D.offset = new Vector2(boxCollider2D.offset.x, boxCollider2D.offset.y * sizeMultiplier);

                active = false;
            }
        } else if (active && movement.collision.onGround && movement.dir.x != 0 && movement.rb.velocity.y == 0)
        {
            Debug.Log("jhgvfk");
            movement.rb.AddForce(movement.dir.x * Vector2.right);
            //movement.rb.velocity = (new Vector2(movement.dir.x * movement.speed / speedMultiplier, movement.rb.velocity.y));
        }
    }
}
