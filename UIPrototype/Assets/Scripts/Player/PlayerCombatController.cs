using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Player))]
public class PlayerCombatController : MonoBehaviour
{
    private Player player;
    private PlayerController playerController;
    [Header("Keyboard Keys")]
    public KeyCode attackKBKey;
    public KeyCode blockKBKey;
    [Header("Gamepad Keys")]
    public GamepadButtons attackGPKey;
    public GamepadButtons blockGPKey;

    void Awake()
    {
        player = this.GetComponent<Player>();
        playerController = this.GetComponent<PlayerController>();
    }

    void Update()
    {
        AttackCheck();
        BlockCheck();
    }

    private void AttackCheck()
    {
        if (KeyboardInput.IsHoldingKey(attackKBKey) || (playerController.gamepadInput && playerController.myGamepad.GetButton(attackGPKey)))
        {
            player.CurrentCombatState = CombatState.Attacking;
        }
        else if (player.CurrentCombatState != CombatState.Blocking)
        {
            player.CurrentCombatState = CombatState.Nothing;
        }
    }

    private void BlockCheck()
    {
        if (KeyboardInput.IsHoldingKey(blockKBKey) ||
             (playerController.gamepadInput && playerController.myGamepad.GetButton(blockGPKey)))
        {
            player.CurrentCombatState = CombatState.Blocking;
        }
        else if (player.CurrentCombatState != CombatState.Attacking)
        {
            player.CurrentCombatState = CombatState.Nothing;
        }
    }
}
