using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public bool canMove = true;

    //Gamepad Stuff
    public Gamepad myGamepad;
    [Header("What Player Is This?")]
    public int playerNumber = 1;
    //Keyboard Input
    [Header("Assign Keyboard Keys")]
    public KeyCode up = KeyCode.W;
    public KeyCode left = KeyCode.A;
    public KeyCode down = KeyCode.S;
    public KeyCode right = KeyCode.D;
    //direction vectors for movement
    [HideInInspector] public Vector2 direction = new Vector2(0, 0);
    [HideInInspector] public Vector2 keyDirection = new Vector2(0, 0);
    //Tests for input
    public bool MovementInput
    {
        get
        {
            //Debug.Log(direction.sqrMagnitude);
            if (direction.magnitude == 0) return false;
            return true;
        }
    }
   
    //Bools
    [Header("Gamepad?")]
    public bool gamepadInput = true;

 
    void Start()
    {
        if (gamepadInput) //this will basically turn it off if there's no gamepad manager -- so nothing breaks
        { gamepadInput = GamepadManager.Instance != null; }

        if (gamepadInput)
        {
            myGamepad = GamepadManager.Instance.GetGamepad(playerNumber);
        }
    }

    void Update()
    {
        if (myGamepad != null) { gamepadInput = myGamepad.IsConnected; }
        if (canMove) { GetInputsAndDirection(); }
    }

    private void GetInputsAndDirection()
    {
        //Resets the directions each frame
        ResetDirection();
        //Sets direction based on input
        RightAndLeft();
        UpAndDown();
        //sets the direction based on the keyDirection and normalizes it
        direction += keyDirection;
    }
  
    private void ResetDirection()
    {
        //Sets them both back to 0
        keyDirection = new Vector2(0, 0);
        direction = new Vector2(0, 0);
    }
    public virtual void RightAndLeft()
    {
        #region Keyboard Input
        if (KeyboardInput.IsHoldingKey(right))
        {
            keyDirection.x += 1;
        }
        if (KeyboardInput.IsHoldingKey(left))
        {
            keyDirection.x += -1;
        }
        #endregion
        #region Gamepad Input
        if (myGamepad != null && gamepadInput)
        {
            if (myGamepad.GetStick_L().X < 0) //GAMEPAD LEFT
            {
                keyDirection.x += -1;
            }
            if (myGamepad.GetStick_L().X > 0) //GAMEPAD RIGHT
            {
                keyDirection.x += 1;
            }
        }
        #endregion
    }
    public virtual void UpAndDown()
    {
        #region Keyboard Input
        if (KeyboardInput.IsHoldingKey(up))
        {
            keyDirection.y += 1;
        }
        if (KeyboardInput.IsHoldingKey(down))
        {
            keyDirection.y = -1;
        }
        #endregion
        #region Gamepad Input
        if (myGamepad != null && gamepadInput)
        {
            if (myGamepad.GetStick_L().Y < 0) //GAMEPAD DOWN
            {
                keyDirection.y += -1;
            }
            if (myGamepad.GetStick_L().Y > 0) //GAMEPAD UP
            {
                keyDirection.y += 1;
            }
        }
        #endregion
    }

}
