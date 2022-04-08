using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : Skill
{
    private Movement movement;
    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (active)
        {
            //Debug.Log(movement.collision.leftHit.distance);
            //Debug.Log(movement.collision.leftHit.distance >= movement.collision.max-0.3f);
            if (movement.collision.leftHit.distance >= movement.collision.max-0.3f || movement.collision.rightHit.distance >= movement.collision.max-0.3f)
            {
                movement.rb.velocity = new Vector2(0, 1);
                movement.rb.velocity *= Vector2.up * movement.jumpForce;
            }
        }
    }
}
