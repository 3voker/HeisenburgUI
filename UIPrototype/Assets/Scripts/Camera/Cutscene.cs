using UnityEngine;
using System.Collections;
using System;

public class Cutscene : MonoBehaviour
{
    public PlaceholderPanel tutorialPlaceholder; //TODO - REMOVE PLACEHOLDER
    private PlayerController controller;
    private TutorialManager tutorialManager;
    [SerializeField] Camera playerCamera;
    [SerializeField] Camera cutsceneCamera;

    void Awake() { controller = GameObject.FindObjectOfType<PlayerController>(); }

	void Start ()
    {
        controller.canMove = false;
        playerCamera.gameObject.SetActive(false);
        cutsceneCamera.gameObject.SetActive(true);
        StartCoroutine(PlayCutscene());
        tutorialManager = GameObject.Find("TutorialManager").GetComponent<TutorialManager>();
    }

    private IEnumerator PlayCutscene()
    {
        yield return new WaitForSeconds(24.9f);
        cutsceneCamera.gameObject.SetActive(false);
        playerCamera.gameObject.SetActive(true);
        controller.canMove = true;
        tutorialManager.StartTutorial();
        //tutorialPlaceholder.ShowPlaceholderPanel();
    }
}
