using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    public Collision collision;
    public Rigidbody2D rb;
    public PlayerInput playerInput;
    public Transform playerVisual;
    public Player player;

    [Header("Stats")]
    public float speed = 5;
    public float slideSpeed = 5;
    [Range(1, 15)]
    public float jumpForce = 5;
    public float wallJumpLerp = 10;
    public float wallClimbSpeed = 2;
    
    [Header("Boolean")]
    public bool isClimbing;
    public bool wallGrab;
    public bool canMove;
    public bool wallJumped;
    public bool isDashing;

    [Header("Skills")] 
    public Jetpack jetpack;
    public MultipleJump multipleJump;
    public Glide glide;
    public MoonGravity moonGravity;
    public HyperJump hyperJump;
    public WallClimb wallClimb;
    public Crouch crouch;
    public GrapplingGun grapplingGun;

    public bool stopJumpPressed;
    public bool startJumpPressed;
    public bool isJumpPressed;
    public Vector2 dir = new Vector2();
    
    public int side;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collision>();
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        if (player.dead)
        {
            dir = Vector2.zero;
            return;
        }

        Move();

        //Active Jump
        if (startJumpPressed && (collision.onGround || wallGrab) && !jetpack.enabled)
        {
            if (collision.onWall && !collision.onGround)
            {
                WallJump();
            }
            
            else if (hyperJump.enabled && dir.y < -0.5f) hyperJump.JumpHyper();
            
            else Jump(jumpForce, Vector2.up, false);
        } else if (startJumpPressed && multipleJump.enabled && !jetpack.enabled)
        {
            multipleJump.Jump();
        }
        
        //Wall slide
        if (collision.onWall && !collision.onGround && dir.x != 0)
        {
            WallSlide();
            wallGrab = true;
        }
        else
        {
            wallGrab = false;
            wallClimb.active = false;
        }

        if (collision.onGround && !isDashing)
        {
            wallJumped = false;
        }

        if (dir.x > 0) side = 1;
        if (dir.x < 0) side = -1;

        if (startJumpPressed) startJumpPressed = false;
    }
    

    public void Move()
    {
        if (wallGrab)
        {
            return;
        }
        else if (canMove)
        {
            if (!moonGravity.enabled || (moonGravity.enabled && collision.onGround))
            {
                if (!wallJumped)
                {
                    if (crouch.active) rb.velocity = (new Vector2(dir.x * speed / crouch.speedMultiplier, rb.velocity.y));
 
                    else rb.velocity = (new Vector2(dir.x * speed, rb.velocity.y));

                    Flip(side);
                }
                else
                {
                    rb.velocity = Vector2.Lerp(rb.velocity, new Vector2(dir.x * speed, rb.velocity.y),
                        wallJumpLerp * Time.deltaTime);
                }
            }
            else
            {
                rb.velocity = (new Vector2(dir.x * speed/moonGravity.directionApplier, rb.velocity.y));
            }
        }
    }
    

    public void HorizontalMove(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        dir.x = value;
    }

    public void VerticalMove(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();

        dir.y = value;
    }
    
    public void Jump(float force, Vector2 dir, bool wall)
    {
        if (true)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity += dir * force;
        }
    }
    
    void WallJump()
    {
        /*
        if ((side == 1 && collision.onRightWall) || side == -1 && !collision.onRightWall)
        {
            side *= -1;
            Flip(side);
        }*/
        side *= -1;
        Flip(side);
        
        wallJumped = true;

        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(.4f));

        Vector2 wallDir = collision.onRightWall ? Vector2.left : Vector2.right;

        Jump(jumpForce, (Vector2.up / 1.5f + wallDir / 1.5f), true);

        
    }
    
    public IEnumerator DisableMovement(float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }
    
    void Flip(int _side)
    {
        playerVisual.localScale = new Vector3(_side, 1, 1);
    }

    void WallSlide()
    {
        if (canMove)
        {
            bool pushingWall = (rb.velocity.x > 0 && collision.onRightWall) ||
                               (rb.velocity.x < 0 && collision.onLeftWall);
            float push = pushingWall ? 0 : rb.velocity.x;
            if (wallClimb.enabled)
            {
                wallClimb.active = true;
                rb.velocity = new Vector2(push, dir.y * wallClimbSpeed);
                
                if (!collision.onWall) Jump(jumpForce, Vector2.up, false);
            }
            else
            {
                rb.velocity = new Vector2(push, -slideSpeed);
            }
        }
    }
    
    public void PressedJump(InputAction.CallbackContext context)
    {
        isJumpPressed = context.performed;
        if (context.started) startJumpPressed = true;
        if (context.canceled) stopJumpPressed = true;
    }
}
