using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput input;
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;

    private Rigidbody2D rb;
    private Animator anim;

    private BoxCollider2D groundCheck;
    private BoxCollider2D ceilingCheck; //TODO not sure if I need both of these?


    void Start()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
        Jump();
        FlipSprite();
        ClimbLadder();
        Die();
    }

    private void Run()
    {
        Vector2 playerVelocity = new Vector2(input.horizontalInput * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        anim.SetFloat("runSpeed", Mathf.Abs(rb.velocity.x)); //TODO set String to hash
    }

    private void Jump()
    {
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
