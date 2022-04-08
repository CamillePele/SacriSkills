using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonGravity : Skill
{

    public BetterJumping betterJumping;
    public Rigidbody2D rigidbody;
    public float gravity = 0.5f;
    public float directionApplier = 3;
    
    private Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }
    
    private void OnEnable()
    {
        betterJumping.enabled = false;
        rigidbody.gravityScale = gravity;
    }

    private void OnDisable()
    {
        betterJumping.enabled = true;
        rigidbody.gravityScale = 1f;
    }

    private void Update()
    {
        active = !movement.collision.onGround;
    }
}
