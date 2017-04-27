using UnityEngine;
using System.Collections;

public class GoronKing : NPC
{
    public PlaceholderPanel linkIsKidnapped;

    public override void ExitDialogue()
    {
        linkIsKidnapped.ShowPlaceholderPanel();
        base.ExitDialogue();
    }
}
