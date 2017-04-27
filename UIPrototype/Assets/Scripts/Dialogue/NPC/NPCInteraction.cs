using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour {

    //Autumn additions
    private PlayerController controller;
    public KeyCode kbInteractButton;
    public GamepadButtons gbInteractButton;

    [SerializeField]
    float maxDistanceToActivate = 4;
    [SerializeField]
    LayerMask layerToCheckForInteractables;
    [SerializeField]
    Text lookAtObjectText;
   

    IActivateable lookedAtNPC;
    GameObject lookedAtNPCObject;

    void Awake()
    {
        controller = this.GetComponent<PlayerController>();
    }

    void Update()
    {
        CheckForLookedAtObjects();
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(kbInteractButton) || (controller.gamepadInput && controller.myGamepad.GetButtonDown(gbInteractButton)))
        {
            if (lookedAtNPC != null)
            {
                lookedAtNPC.DoActivate();
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
            
            lookedAtNPC = raycastHit.transform.gameObject.GetComponent<IActivateable>();
            lookedAtNPCObject = raycastHit.transform.gameObject;
            if(lookedAtNPCObject.GetComponent<NPC>() != null)
            {
                lookedAtNPCObject.transform.GetChild(0).gameObject.SetActive(true); //indicator showing you can talk to NPC
            }

        }
        else
        {
            if (lookedAtNPCObject != null && lookedAtNPCObject.GetComponent<NPC>() != null) { lookedAtNPCObject.transform.GetChild(0).gameObject.SetActive(false); } //indicator showing you can talk to NPC
            lookedAtNPC = null;
            lookedAtNPCObject = null;
            
        }
    }
}
