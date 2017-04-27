using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerJumpingController : MonoBehaviour
{
    public KeyCode jumpButton;
    public GamepadButtons gamePadKey;

    public bool grounded = true;
    public float jumpPower = 190;
    private bool hasJumped = false;

    private PlayerController controller;
    private Rigidbody rigidbody;

    void Awake()
    {
        controller = this.GetComponent<PlayerController>();
        rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool pressedGamepadJumpKey = controller.myGamepad != null && controller.gamepadInput 
            && controller.myGamepad.GetButton(gamePadKey);

        if (!grounded && rigidbody.velocity.y == 0)
        {
            grounded = true;
        }
        if ((KeyboardInput.IsHoldingKey(jumpButton) || pressedGamepadJumpKey) && grounded == true)
        {
            hasJumped = true;
        }
    }

    void FixedUpdate()
    {
        if (hasJumped)
        {
            rigidbody.AddForce(transform.up * jumpPower);
            grounded = false;
            hasJumped = false;
        }
    }
}
