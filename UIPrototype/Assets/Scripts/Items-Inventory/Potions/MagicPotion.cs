using UnityEngine;
using System.Collections;

public class MagicPotion : Item
{
    private Player player;

    protected override void OnStart()
    {
        player = FindObjectOfType<Player>();
        base.OnStart();
    }

    public override void Use()
    {
        Debug.Log("MAGIC RECOVERY?!!?!?!?!?!?!?!?!");
        base.Use();
    }
}