using UnityEngine;
using System.Collections;


public class NPC : MonoBehaviour, IActivateable
{
    //Autumn Script additions
    private PlayerController controller;
    private PlayerUnityMovement movement;
    private NPCDialogueGUI dialogueGUIFiller;
    private CharacterLoader characterLoader;

    GameObject dialogueCanvas;
    [SerializeField] GameObject mainUICanvas;

    private PlayerCameras cameras;

    [SerializeField] float speed;
    Vector3 newPosition;

    void Start()
    {
        controller = GameObject.FindObjectOfType<PlayerController>();
        movement = GameObject.FindObjectOfType<PlayerUnityMovement>();
        characterLoader = this.GetComponent<CharacterLoader>();
        dialogueGUIFiller = GameObject.FindObjectOfType<NPCDialogueGUI>();
        dialogueCanvas = dialogueGUIFiller.transform.GetChild(0).gameObject;

        cameras = GameObject.FindObjectOfType<PlayerCameras>();

        dialogueCanvas.SetActive(false);
    }

    public virtual void DoActivate()
    {
        //Autumn addition
        //Debug.Log(characterLoader);
        dialogueGUIFiller.PopulateGUI(characterLoader);
        if(controller == null) { controller = GameObject.FindObjectOfType<PlayerController>(); }
        controller.enabled = false; //stop player from moving in dialogue
        movement.enabled = false;
        mainUICanvas.SetActive(false);
        cameras.ShowNPCCamera();
        dialogueCanvas.SetActive(true);
        //Debug.Log("Player is talking to the NPC.");

        //ZoomIn();
    }


    public virtual void ExitDialogue()
    {
        movement.enabled = true;
        mainUICanvas.SetActive(true);
        dialogueCanvas.SetActive(false);
        cameras.ShowMainCamera();
        controller.enabled = true; //return player movement
    }

    public void ZoomOut()
    {
        float step = speed * Time.deltaTime;
        //Move back to player after finishing dialogue
        //Vector3.zero; 

    }

    private void ZoomIn()
    {
        newPosition.x = gameObject.transform.position.x;
        newPosition.y = gameObject.transform.position.y + 1f;
        newPosition.z = gameObject.transform.position.z + 2f;

        float step = speed * Time.deltaTime;
    }

}
