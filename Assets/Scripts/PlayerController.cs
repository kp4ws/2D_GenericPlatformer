using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]//TODO Add box collider to this? 
public class PlayerController : MonoBehaviour
{
    //Inspector variables
    [SerializeField] private BoxCollider2D groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //Player values
    [SerializeField] private float runSpeed = 5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float climbSpeed = 5f;
    [SerializeField] private Vector2 hurtRecoil = new Vector2(5f,5f);

    //Status checks
    private bool isJumping;

    //Player animation
    private int speedParamID;
    private int jumpParamID;

    //Cached references
    private Rigidbody2D rb;
    private BoxCollider2D bodyCollider;
    private Animator anim;


    /*******
     * 
     * TODO:
     * -Add Raycasts for status checks, collision detection, etc
     * 
     * 
     */



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bodyCollider = GetComponent<BoxCollider2D>();
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
            //isJumping = true;
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
        if(bodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemy", "Hazards")))
        {
            GetComponent<Animator>().SetTrigger("hurt");
            hurtRecoil.x *= -transform.localScale.x;
            rb.AddForce(hurtRecoil, ForceMode2D.Impulse); //TODO
        }
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
