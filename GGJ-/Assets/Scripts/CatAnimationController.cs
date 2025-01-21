using UnityEngine;

public class CatAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius = 0.1f;

    private bool isJumping = false; // To track jumping state

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if grounded
        bool grounded = isGrounded();
        float verticalVelocity = rb.linearVelocity.y;

        // Set Animator parameters
        animator.SetBool("IsGrounded", grounded);
        animator.SetFloat("Velocity", verticalVelocity);

        // Trigger animations based on conditions
        if (!grounded)
        {
            if (verticalVelocity > 0 && !isJumping)
            {
                isJumping = true;
                animator.SetTrigger("Jump");
            }
            else if (verticalVelocity < 0)
            {
                animator.SetTrigger("Falling");
            }
        }
        else
        {
            if (isJumping)
            {
                animator.SetTrigger("Landing");
                isJumping = false;
            }
            else
            {
                animator.SetTrigger("Idle");
            }
        }
    }

    bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
}
