using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Inspector variables
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f; //TODO
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private BoxCollider2D ceilingCheck; //TODO not sure if I need both of these?
    [SerializeField] private LayerMask groundLayer;

    //Cached references
    private Rigidbody2D rb;
    private Animator anim;

    //Status checks
    private bool isJumping;

    //Player animation
    private int speedParamID;
    private int jumpParamID;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        jumpParamID = Animator.StringToHash("isJumping");
        speedParamID = Animator.StringToHash("runSpeed");
    }

    private void Update()
    {
        Run();
        Jump();
        FlipSprite();
        ClimbLadder();
        Die();

        anim.SetFloat(speedParamID, Mathf.Abs(rb.velocity.x));
        anim.SetBool(jumpParamID, isJumping);
    }

    private void Run()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 playerVelocity = new Vector2(horizontalInput * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;
    }

    private void Jump()
    {
        if (!groundCheck.IsTouchingLayers(groundLayer))
        {
            isJumping = true;
            return;
        }
        else if(Input.GetButtonDown("Jump"))
        {
            Vector2 jumpVelocity = new Vector2(0f, jumpSpeed);
            rb.velocity += jumpVelocity;
        }
        else
        {
            isJumping = false;
        }

    }

    private void ClimbLadder()
    {
    }

    private void Die()
    {
    }

    private void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), transform.localScale.y);
        }
    }
}
