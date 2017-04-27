using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerPawns : Pawns
{
    private PlayerInput playerInput;

    protected override void OnAwake()
    {
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        base.OnAwake();
    }

    private void Update()
    {
        if (playerInput.canDoThings)
        {
            this.GetComponent<Button>().enabled = true;
        }
        else
        {
            this.GetComponent<Button>().enabled = false;
        }
    }

    public override void OnButtonClick()
    {
        base.OnButtonClick();
    }

}
