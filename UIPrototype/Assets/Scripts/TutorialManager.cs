using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialManager : MonoBehaviour
{

    [SerializeField] GameObject GoronEmissary;
    [SerializeField] GameObject tutorialPanel;
    [SerializeField] Toggle attackedToggle;
    [SerializeField] Toggle blockedToggle;
    [HideInInspector] public bool hasAttacked;
    [HideInInspector] public bool hasBlocked;

    private WorldStateManager worldManager;

	void Start ()
    {
        GoronEmissary.GetComponent<MeshRenderer>().enabled = false;
        worldManager = GameObject.Find("WorldStateManager").GetComponent<WorldStateManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasAttacked = true;
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            hasBlocked = true;
        }

        if (hasAttacked == true)
        {
            attackedToggle.isOn = true;
        }

        if (hasBlocked == true)
        {
            blockedToggle.isOn = true;
        }

        if (hasAttacked && hasBlocked)
        {
            worldManager.MoveToNextState(GoronEmissary);
            tutorialPanel.SetActive(false);
            Destroy(this.gameObject);
        }
	}

    public void StartTutorial()
    {
        tutorialPanel.SetActive(true);
    }
}
