using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;

    float horizontalInput;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float jumpPower = 16f;
    bool isFacingRight = true;

    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.2f;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float wallCheckDistance = 0.1f;
    [SerializeField] LayerMask wallLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        bool isTouchingWall = Physics2D.Raycast(transform.position, isFacingRight ? Vector2.right : Vector2.left, wallCheckDistance, wallLayer);

        // Prevent sticking to wall mid-air
        if (!isGrounded && isTouchingWall && Mathf.Abs(horizontalInput) > 0f)
        {
            rb.velocity = new Vector2(0f, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            animator.SetBool("isJumping", true);
        }

        if (isGrounded && rb.velocity.y <= 0.1f)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void FlipSprite()
    {
        if ((isFacingRight && horizontalInput < 0f) || (!isFacingRight && horizontalInput > 0f))
        {
            isFacingRight = !isFacingRight;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }
}
