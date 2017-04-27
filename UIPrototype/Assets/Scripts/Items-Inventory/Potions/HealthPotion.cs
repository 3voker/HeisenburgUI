using UnityEngine;
using System.Collections;

public class HealthPotion : Item
{
	private Player player;

    protected override void OnStart()
    {
        player = FindObjectOfType<Player>();
        base.OnStart();
    }
	
    public override void Use()
    {
        if (player.Health < player.MaxHealth)
        {
            player.RecoverHealth(ItemsManager.Instance.healthPotionRecovery);
        }

        base.Use();
    }
}
