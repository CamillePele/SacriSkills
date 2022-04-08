using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HyperJump : Skill
{
    private Movement movement;
    public float jumpForce;

    public float multiplier = 0.2f;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    public void JumpHyper()
    {
        movement.Jump(jumpForce * movement.hyperJump.jumpForce, Vector2.up, false);
        activeTime += multiplier;
    }
}
