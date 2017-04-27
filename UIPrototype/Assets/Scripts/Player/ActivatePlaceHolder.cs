using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivatePlaceHolder : MonoBehaviour
{
    private PlayerController controller;
    public KeyCode kbInteractButton;
    public GamepadButtons gbInteractButton;

    [SerializeField]
    float maxDistanceToActivate = 4;
    [SerializeField]
    LayerMask layerToCheckForInteractables;

    Text lookAtObjectText;

    IActivateable lookedAtNPC;
    GameObject lookedAtNPCObject;

    void Awake()
    {
        controller = this.GetComponent<PlayerController>();
    }

    void Start()
    {

    }

    void Update()
    {
        if(lookAtObjectText == null) { lookAtObjectText = GameObject.Find("FeedbackText").GetComponent<Text>();  }

        CheckForLookedAtObjects();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(kbInteractButton) || (controller.gamepadInput && controller.myGamepad.GetButtonDown(gbInteractButton)))
        {
            if (lookedAtNPC != null)
            {
                lookedAtNPC.DoActivate();
                Debug.Log("ASFHKEFHWKF");
            }
        }
    }
    void CheckForLookedAtObjects()
    {
        Vector3 endPoint = (transform.forward * maxDistanceToActivate) + transform.position;
        Debug.DrawLine(transform.position, endPoint, Color.red);

        RaycastHit raycastHit;
        if (Physics.Raycast(transform.position, transform.forward,
            out raycastHit, maxDistanceToActivate, layerToCheckForInteractables))
        {
            //Debug.Log(raycastHit.transform.gameObject.name);
            lookAtObjectText.gameObject.SetActive(true);
            lookedAtNPC = raycastHit.transform.gameObject.GetComponent<IActivateable>();
            lookedAtNPCObject = raycastHit.transform.gameObject;
            lookAtObjectText.text = "Activate " + raycastHit.transform.gameObject.name + " with 'Q'";
        }
        else
        {
            lookAtObjectText.gameObject.SetActive(false);
        }
      
    }
}
