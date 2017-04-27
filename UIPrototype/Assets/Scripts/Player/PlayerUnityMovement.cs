using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class PlayerUnityMovement : MonoBehaviour
{
    private PlayerController controller;
    public float movementSpeed = 10f;
    private Vector3 moveTranslation;
    public bool movement2D = false;
    private bool canMove = true;

    void Awake()
    {
        controller = this.GetComponent<PlayerController>();

    }

    void Update()
    {
        if (controller.MovementInput && canMove) { UpdateMovement(); }
    }

    private void UpdateMovement()
    {
        CreateMoveTranslationBasedOnPerspective();
        this.transform.position += moveTranslation;
    }

    private void CreateMoveTranslationBasedOnPerspective()
    {
        if (movement2D) { Set2DMoveTranslation(); }
        else { Set3DMoveTranslation(); }
    }

    private void Set2DMoveTranslation()
    {
        moveTranslation = new Vector3(controller.direction.x, controller.direction.y, 0) * Time.deltaTime * movementSpeed;
    }

    public void Set3DMoveTranslation()
    {
        if (controller.direction.x > 0)
        {
            this.moveTranslation += this.transform.right;
        }
        else if (controller.direction.x < 0)
        {
            this.moveTranslation += -this.transform.right;
        }
        if (controller.direction.y > 0)
        {
            this.moveTranslation += this.transform.forward;
        }
        else if (controller.direction.y < 0)
        {
            this.moveTranslation += -this.transform.forward;
        }

        moveTranslation *= Time.deltaTime * movementSpeed;
    }

    public void ToggleMovement(bool enabled)
    {
        canMove = enabled;
    }
}
