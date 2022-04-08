    using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float fastFallSpeed;
    private bool isJumping;
    private bool isGrounded;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Transform groundCheckerLeft;
    public Transform groundCheckerRight;
    public Animator animator;

    public void Jump()
    {
        if (isGrounded)
            isJumping = true;
    }
    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundCheckerLeft.position, groundCheckerRight.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        float verticalMovement = rb.velocity.y;
        if (Input.GetAxis("Vertical") < 0f && !isGrounded && rb.velocity.y < 0)
        {
            verticalMovement = Input.GetAxis("Vertical") * fastFallSpeed * Time.deltaTime;
        }

        MovePlayer(horizontalMovement, verticalMovement);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", rb.velocity.x);
    }

    void MovePlayer(float _horizontalMovement, float _verticalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, _verticalMovement);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }
}
