using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;

public class Jetpack : Skill
{
    private Movement movement;
    public float horizontalForce = 1;

    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (movement.isJumpPressed && !movement.collision.onGround)
        {
            movement.rb.AddForce(Vector2.up * horizontalForce, ForceMode2D.Impulse);
            active = true;
        }
        if (!movement.isJumpPressed && active) active = false;
    }

    public void PressedJump(InputAction.CallbackContext context)
    {
        if (enabled)
        {
            if (context.started && (movement.collision.onGround || movement.wallGrab))
            {
                movement.Jump(movement.jumpForce, Vector2.up, false);
            }
        }
    }

}
