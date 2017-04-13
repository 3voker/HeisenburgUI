using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class NPC : MonoBehaviour, IActivateable
{
    [SerializeField]
    GameObject dialogueCanvas;
    [SerializeField]
    GameObject mainUICanvas;

    [SerializeField]
    Camera camera;
    [SerializeField]
    Camera mainCamera;
    [SerializeField]
    float speed;
    Vector3 newPosition;
    Vector3 startingPosition;
    void Start()
    {
        dialogueCanvas.SetActive(false);
        startingPosition = camera.transform.position;
        //dialogueCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }
    public void DoActivate()
    {
        mainUICanvas.SetActive(false);
        mainCamera.gameObject.SetActive(false);
        camera.gameObject.SetActive(true);
        dialogueCanvas.SetActive(true);
        Debug.Log("Player is talking to the NPC.");
        //dialoguePanel.gameObject.SetActive(true);
        //Send to Dialogue Camera View.
        ZoomIn();
       
        // transform.forward;
        // public Transform target;
       
    }

    public void ZoomOut()
    {
        float step = speed * Time.deltaTime;
        mainUICanvas.SetActive(true);
        dialogueCanvas.SetActive(false);
        camera.gameObject.SetActive(false);
        mainCamera.gameObject.SetActive(true);
        //Move back to player after finishing dialogue
        //Vector3.zero; 
        camera.transform.position = startingPosition;//Vector3.MoveTowards(transform.position, startingPosition, step);
    
}

    private void ZoomIn()
    {
        newPosition.x = gameObject.transform.position.x;
        newPosition.y = gameObject.transform.position.y + 1f;
        newPosition.z = gameObject.transform.position.z + 2f;

        float step = speed * Time.deltaTime;
        camera.transform.position = newPosition;//Vector3.MoveTowards(transform.position, newPosition, step);
    }

}

