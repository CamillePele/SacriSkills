using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MultipleJump : Skill
{
    private Movement movement;
    public UnityEvent multijumpEvent;

    public float multiplier = 0.4f;

    [SerializeField]
    public int jumpAmount = 2;
    
    //Nombre de jumps effectué
    public int jumpCount;
    
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    public void Update()
    {
        if (movement.collision.onGround)
        {
            jumpCount = 0;
        }
    }

    public void Jump()
    {
        if (jumpCount < jumpAmount-1)
        {
            multijumpEvent.Invoke();
            movement.Jump(movement.jumpForce, Vector2.up, false);
            jumpCount++;
            activeTime += multiplier;
        }
    }
}
