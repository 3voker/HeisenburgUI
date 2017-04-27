using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum PlayerState { Idle, Moving, Interacting, TalkToNPC }

[RequireComponent(typeof(PlayerController))]
public class Player : CombatParticipant
{
    public PlayerController controller { get; private set; }
    private SwordAnimator animator;
    private BattleAudioHandler battleAudio;

    public bool canPlaySound { get; set; }

    //----PLAYER MAGIC----//

    [SerializeField] protected float magic = 5;
    public float MaxMagic { get; private set; }
    public float Magic { get { return magic; } }

    public PlayerState State
    {
        get { return state; }
        set
        {
            state = value;
            StateChange();
        }
    }
    private PlayerState state;

    protected override void OnAwake()
    {
        controller = this.GetComponent<PlayerController>();
        animator = this.GetComponentInChildren<SwordAnimator>();
        battleAudio = GetComponent<BattleAudioHandler>();
        State = PlayerState.Idle;
        base.OnAwake();
    }

    protected override void OnStart()
    {
        base.OnStart();
    }

    protected override void OnUpdate()
    {
        //UIConsoleText.SetConsoleText("Player Health: " + this.Health); //DEBUG HEALTH VISIBILIY
        base.OnUpdate();
    }

    public override void Attack()
    {
        //battleAudio.PlayAttackSound();
        base.Attack();
    }

    public override void Block(CombatParticipant attackedBy)
    {
        battleAudio.PlayBlockSound();
        base.Block(attackedBy);
    }

    public override void TakeDamage(float damageAmount)
    {
        if (CurrentCombatState != CombatState.Blocking) { battleAudio.PlayPainSound(); }
        base.TakeDamage(damageAmount);
    }

    public void StateChange()
    {
        switch (State)
        {
            case PlayerState.Idle:
                controller.enabled = true;
                break;
            case PlayerState.Moving:
                controller.enabled = true;
                break;
            case PlayerState.Interacting:
                controller.enabled = false;
                break;
            case PlayerState.TalkToNPC:
                controller.enabled = false;
                break;
        }
    }

    protected override void PlayAttackAnimation()
    {
        if(animator != null)
            animator.PlaySwordAttack();

        battleAudio.PlayAttackSound();
    }

    protected override void PlayBlockAnimation()
    {
        if (animator != null)
            animator.PlaySwordBlock();
    }

    protected override void PlayUnBlockAnimation()
    {
        if (animator != null)
            animator.PlaySwordUnBlock();
    }
    protected override void PlayCombatNothingAnimation()
    {
        if (animator != null)
            animator.PlayNothing();
    }

    public void SetHealth(float healthAmount)
    {
        this.health = healthAmount;
    }
}
