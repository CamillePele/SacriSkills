using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Dash : Skill
{
    private Movement movement;
    public UnityEvent dashEvent;
    public float dashForce = 50;

    public bool canDash = false;
    public bool hasDash = false;

    public float multiplier;

    private void Start()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        if (!canDash && movement.collision.onGround && !hasDash) canDash = true;

    }

    public void PressDash(InputAction.CallbackContext context)
    {
        if (context.started && canDash)
        {
            movement.rb.velocity = Vector2.zero;
            movement.rb.velocity += movement.dir * dashForce;

            StopCoroutine(movement.DisableMovement(0));
            StartCoroutine(movement.DisableMovement(.4f));

            canDash = false;
            StartCoroutine(DisableDash((.1f)));
            dashEvent.Invoke();

            activeTime += multiplier;
        }
    }
    
    public IEnumerator DisableDash(float time)
    {
        hasDash = true;
        yield return new WaitForSeconds(time);
        hasDash = false;
    }
    
    
    
}
