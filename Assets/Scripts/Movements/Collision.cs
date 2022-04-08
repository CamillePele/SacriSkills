using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    [Header("Layers")]
    public LayerMask groundLayer;
    public Movement movement;

    [Space]

    public bool onGround;
    public bool onWall;
    public bool onRightWall;
    public bool onLeftWall;
    public int wallSide;
    

    [Space]

    [Header("Collision")]

    public float collisionRadius = 0.25f;
    public float max, min;
    public Vector2 bottomOffset;
    public float rightOffset, leftOffset;
    private Color debugCollisionColor = Color.red;

    public RaycastHit2D rightHit;
    public RaycastHit2D leftHit;
    //private Animator animator;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Physics2D.queriesHitTriggers = false;
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);

        //animator.SetBool("Ground", onGround);


        rightHit = Physics2D.Raycast(new Vector2(transform.position.x + rightOffset, transform.position.y + max),
            Vector2.down, max - min, groundLayer);
        onRightWall = rightHit.collider != null && !rightHit.transform.CompareTag("Platform");;

        
        leftHit = Physics2D.Raycast(new Vector2(transform.position.x + leftOffset, transform.position.y + max),
            Vector2.down, max - min, groundLayer);
        onLeftWall = leftHit.collider != null && !leftHit.transform.CompareTag("Platform");

        onWall = onLeftWall || onRightWall;
        


        wallSide = onRightWall ? -1 : 1;

        if (movement.crouch.active)
        {
            onLeftWall = false;
            onRightWall = false;
            onWall = false;
        }
    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position  + bottomOffset, collisionRadius);

        Gizmos.DrawLine(new Vector2(transform.position.x + leftOffset, transform.position.y + max), new Vector2(transform.position.x + leftOffset, transform.position.y + min));
        
        
        Gizmos.DrawLine(new Vector2(transform.position.x + rightOffset, transform.position.y + max), new Vector2(transform.position.x + rightOffset, transform.position.y + min));

    }
}