using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Glide : Skill
{
    private Movement movement;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (active && !movement.collision.onGround)
        {
            Vector2 lastVelocity = movement.rb.velocity;

            movement.rb.velocity = new Vector2(lastVelocity.x, -movement.slideSpeed);
        }
        if (movement.collision.onGround && active) //Meme s'il est sur un mur
        {
            active = false;
        }
    }
    
    public void PressedJump(InputAction.CallbackContext context)
    {
        if (context.started && !movement.collision.onGround) active = true;
        if (context.canceled) active = false;
    }
}
