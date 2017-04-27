using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour
{
    public bool canDoThings = true;
    public PlayerPawns[] playerPawns;

    private void Awake()
    {
        playerPawns = GameObject.FindObjectsOfType<PlayerPawns>();
    }

    void Update ()
    {
        if (canDoThings)
        {

        }
	}

    private void EnablePlayerInput()
    {
        if (TurnManager.Instance.CurrentTurn == Turn.Player)
        {
            canDoThings = true;
        }
        else
        {
            canDoThings = false;
        }
    }

    #region Event Subscription
    private void OnEnable()
    {
        TurnManager manager = GameObject.FindObjectOfType<TurnManager>();
        manager.OnTurnCountChanged += EnablePlayerInput;
    }

    private void OnDisable()
    {
        TurnManager.Instance.OnTurnCountChanged -= EnablePlayerInput;
    }
    #endregion
}
