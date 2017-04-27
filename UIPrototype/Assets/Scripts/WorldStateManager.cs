using UnityEngine;
using System.Collections;

public class WorldStateManager : MonoBehaviour
{

    public enum WorldState { Tutorial, TutorialFinished };

    private WorldState curState;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start ()
    {
        curState = WorldState.Tutorial;
	}

    public void MoveToNextState(GameObject affectedObject)
    {
        switch (curState)
        {
            case WorldState.Tutorial:
                curState = WorldState.TutorialFinished;
                affectedObject.GetComponent<MeshRenderer>().enabled = true;
                break;
            case WorldState.TutorialFinished:
                //Move to next state
                break;
            default:
                break;
        }
    }
}
