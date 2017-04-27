using UnityEngine;
using System.Collections;
using System.Linq;

public enum EnemyState { Idle, Wandering, WanderingAction, NoticePlayer, ChasePlayer }

public class Enemy : CombatParticipant
{
    public bool canBlock;
    public bool canDodge;
    protected EnemyController controller;
    public SwordAnimator animator;

    //Enemy State
    public EnemyState State
    {
        get { return state; }
        set
        {
            state = value;
            StateChange();
        }
    }
    private EnemyState state;

    protected override void OnAwake()
    {
        controller = this.GetComponentInParent<EnemyController>();
        animator = this.GetComponentInChildren<SwordAnimator>();
        base.OnAwake();
    }

    protected override void OnUpdate()
    {
        //Debug.Log("inFrontOfPlayer " + controller.InFrontOFPlayer);
        if (controller.inRangeOfPlayer && controller.AtDestination) { this.SetTarget(GameObject.FindObjectOfType<Player>()); }
        else { this.SetTarget(null); }

        CombatSequence();

        base.OnUpdate();
    }

    protected virtual void CombatSequence()
    {
        if (this.targetToAttack != null)
        {
            if (this.targetToAttack.CurrentCombatState != CombatState.Attacking)
            {
                this.CurrentCombatState = CombatState.Attacking;
            }
            else
            {
                EnemyBlockOrDodgeChance();
            }
        }
    }

    private void EnemyBlockOrDodgeChance()
    {
        int rnd = Random.Range(0, 3);
        switch (rnd)
        {
            case 0:
                if (canBlock)
                { this.CurrentCombatState = CombatState.Blocking; }
                break;
            case 1:
                if (canDodge)
                { this.CurrentCombatState = CombatState.Dodging; }
                break;
            case 2:
                this.CurrentCombatState = CombatState.Attacking;
                break;
        }
    }

    protected void StateChange()
    {
        switch (State)
        {
            case EnemyState.Idle:
                controller.enabled = true;
                break;
            case EnemyState.Wandering:
                controller.enabled = true;
                break;
            case EnemyState.WanderingAction:
                controller.enabled = false;
                break;
            case EnemyState.NoticePlayer:
                controller.enabled = false;
                break;
            case EnemyState.ChasePlayer:
                controller.enabled = false;
                break;
        }
    }

    protected override void PlayAttackAnimation()
    {

        if (animator != null)
         animator.PlaySwordAttack(); 
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
}
