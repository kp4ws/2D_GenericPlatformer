using UnityEngine;

[DefaultExecutionOrder(-100)]//read up on this
public class PlayerInput : MonoBehaviour
{
    public float horizontalInput { get; private set; }
    public float runInput { get; private set; }

    public bool jumpHeld { get; private set; }
    public bool jumpPressed { get; private set; }
    public bool crouchHeld { get; private set; }
    public bool crouchPressed { get; private set; }
    public bool runHeld { get; private set; }
    public bool runPressed { get; private set; }

    private bool readyToClear; //Keeps input in sync

    private void Update()
    {
        ClearInput();

        //if (GameManager.IsGameOver()) TODO
         //   return;

        ProcessInputs();
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
        runInput = Mathf.Clamp(runInput, -2f, 2f);
    }

    private void FixedUpdate()
    {
        readyToClear = true;
    }

    private void ClearInput()
    {
        if (!readyToClear)
            return;

        //Clear inputs
        horizontalInput = 0f;
        runInput = 0f;
        jumpPressed = false;
        jumpHeld = false;
        crouchPressed = false;
        crouchHeld = false;
        runPressed = false;
        runHeld = false;

        readyToClear = false;
    }

    private void ProcessInputs()
    {
        horizontalInput += Input.GetAxisRaw("Horizontal"); //TODO change to updated input manager
        runInput += Input.GetAxisRaw("Run");

        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        jumpHeld = jumpHeld || Input.GetButton("Jump");

        crouchPressed = crouchPressed || Input.GetButtonDown("Crouch");
        crouchHeld = crouchHeld || Input.GetButton("Crouch");

        runPressed = runPressed || Input.GetButtonDown("Run");
        runHeld = runHeld || Input.GetButton("Run");
    }
}