using UnityEngine;
using System.Collections;
using System;

public class Link : MonoBehaviour
{

    [HideInInspector] public bool hasItem;
    private Vector3 pointToMove;
    private Vector3 playerLocation;
    private float speed = 5;

    private PlayerInteraction pInteraction;
	
    public void SetLinkTarget(Vector3 itemLocation, Vector3 ganonLocation, PlayerInteraction temp)
    {
        pointToMove = itemLocation;
        playerLocation = ganonLocation;
        pInteraction = temp;
    }

	private void Update ()
    {
        MoveLink();
	}

    private void MoveLink()
    {
        if (pointToMove == null)
        {
            //Wait for further instructions, Link!
        }
        else
        {
            if (hasItem == false)
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, pointToMove, step);
            }
            else
            {
                float step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, pointToMove, step);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Item>())
        {
            Destroy(collision.gameObject);
            hasItem = true;
            pointToMove = playerLocation;
        }
        else if (collision.gameObject.GetComponent<Player>() && hasItem == true)
        {
            Destroy(gameObject);
            pInteraction.ReceiveItem();
        }
    }
}
