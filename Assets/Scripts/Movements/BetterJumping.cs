using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BetterJumping : MonoBehaviour
{
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    Rigidbody2D rb;

    private bool isJumpPressed;

    public Movement movement;

    void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (movement.dir.y < -0.5f && movement.hyperJump.enabled && rb.velocity.y > 7)
        {
            Debug.Log("bnrfhjnk");
            return;
        }
        else 
        {
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !isJumpPressed)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
    }

    public void PressedJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.performed;
    }

}
