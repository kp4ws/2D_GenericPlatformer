using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Properties")]
    [SerializeField] private float speed = 8f;
    [SerializeField] private float crouchSpeed = 3f;
    [SerializeField] private float coyoteDuration = 0.5f; // How long player can jump after falling
    [SerializeField] private float maxFallSpeed = -25f;

    [Header("Jump Properties")]
    [SerializeField] private float jumpForce = 6.3f;
    [SerializeField] private float crouchJumpBoost = 2.5f;
    [SerializeField] private float hangingJumpForce = 15f;
    [SerializeField] private float jumpHoldForce = 1.9f;
    [SerializeField] private float jumpHoldDuration = 0.1f;

    [Header("Environment Check Properties")]
    [SerializeField] private float footOffset = 0.4f;
    [SerializeField] private float eyeHeight = 1.5f;
    [SerializeField] private float reachOffset = 0.7f;
    [SerializeField] private float headClearance = .5f;      //Space needed above the player's head
    [SerializeField] private float groundDistance = .2f;      //Distance player is considered to be on the ground
    [SerializeField] private float grabDistance = .4f;        //The reach distance for wall grabs
    [SerializeField] private LayerMask groundLayer;			//Layer of the ground

    [Header("Status Flags")]
    [SerializeField] private bool isOnGround;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool isHanging;
    [SerializeField] private bool isCrouching;
    [SerializeField] private bool isHeadBlocked;

    //Cached References
    private PlayerInput input;
    private BoxCollider2D boxCollidder;
    private Rigidbody2D rigidBody;


    //TODO rename these and whatnot
    float jumpTime;                         //Variable to hold jump duration
    float coyoteTime;                       //Variable to hold coyote duration
    float playerHeight;                     //Height of the player

    float originalXScale;                   //Original scale on X axis
    int direction = 1;                      //Direction player is facing

    Vector2 colliderStandSize;              //Size of the standing collider
    Vector2 colliderStandOffset;            //Offset of the standing collider
    Vector2 colliderCrouchSize;             //Size of the crouching collider
    Vector2 colliderCrouchOffset;           //Offset of the crouching collider

    const float smallAmount = .05f;			//A small amount used for hanging position

    private void Start()
    {

    }

    
}
