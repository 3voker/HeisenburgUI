using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCInteraction : MonoBehaviour {
    [SerializeField]
    float maxDistanceToActivate = 4;
    [SerializeField]
    LayerMask layerToCheckForInteractables;
    [SerializeField]
    Text lookAtObjectText;

    IActivateable lookedAtNPC;

    void Update()
    {
        CheckForLookedAtObjects();
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
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
            Debug.Log(raycastHit.transform.gameObject.name);

            lookedAtNPC = raycastHit.transform.gameObject.GetComponent<IActivateable>();
        }
        else
        {
            lookedAtNPC = null;
        }
    }
}
