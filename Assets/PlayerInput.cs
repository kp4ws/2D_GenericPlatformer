using UnityEngine;

[DefaultExecutionOrder(-100)]//read up on this
public class PlayerInput : MonoBehaviour
{
    private float horizontalInput;
    private bool jumpHeld;
    private bool jumpPressed;
    private bool crouchHeld;
    private bool crouchPressed;

    private bool readyToClear; //Keeps input in sync

    private void Update()
    {
        ClearInput();

        //if (GameManager.IsGameOver()) TODO
         //   return;

        ProcessInputs();
        horizontalInput = Mathf.Clamp(horizontalInput, -1f, 1f);
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
        jumpPressed = false;
        jumpHeld = false;
        crouchPressed = false;
        crouchHeld = false;

        readyToClear = false;
    }

    private void ProcessInputs()
    {
        horizontalInput += Input.GetAxis("Horizontal"); //TODO change to updated input manager

        jumpPressed = jumpPressed || Input.GetButtonDown("Jump");
        jumpHeld = jumpHeld || Input.GetButtonDown("Crouch");

        crouchPressed = crouchPressed || Input.GetButtonDown("Crouch");
        crouchHeld = crouchHeld || Input.GetButton("Crouch");
    }
}