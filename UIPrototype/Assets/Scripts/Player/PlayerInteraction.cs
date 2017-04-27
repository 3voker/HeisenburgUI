using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] GameObject linkObject;

    private Transform deployLocation;
    private bool linkDeployed;
    private PlayerController pController;

	void Start ()
    {
        deployLocation = transform.FindChild("DeployLocation");
        pController = GetComponent<PlayerController>();
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Interactable>() && Input.GetKeyDown(KeyCode.J) && linkDeployed == false)
        {
            Debug.Log("Detecting");
            DeployLink(other.GetComponent<Interactable>().collectablePosition);
            linkDeployed = true;
            pController.canMove = false;
        }
    }

    private void DeployLink(Vector3 linkTarget)
    {
        GameObject newLink = Instantiate(linkObject, deployLocation.position, deployLocation.rotation, deployLocation) as GameObject;
        newLink.GetComponent<Link>().SetLinkTarget(linkTarget, transform.position, this);
    }

    public void ReceiveItem()
    {
        pController.canMove = true;
    }
}
