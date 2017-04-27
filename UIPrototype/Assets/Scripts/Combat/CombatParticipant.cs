using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CombatState { Nothing, Attacking, Blocking, Dodging, UsingItem, Dead }

public class CombatParticipant : MonoBehaviour
{
    [SerializeField] private CombatState combatState;
    public CombatState CurrentCombatState
    {
        get { return combatState; }
        set
        {
            previousState = combatState;
            combatState = value;
            CombatStateChanged();
        }
    }
    private CombatState previousState;

    [SerializeField] protected float health = 5;
    [SerializeField] protected float attackDamage = 5;
    [Tooltip("If there's a weapon, attack speed should be half the animation time")]
    [SerializeField] protected float attackSpeed = 0.4f;
    [SerializeField] protected float blockSturdiness = 5;
    public float MaxHealth { get; private set; }

    protected float attackTimer;
    private int blockHitTimes;

    [SerializeField] private CombatParticipant target;
    protected CombatParticipant targetToAttack { get { return target; } }
    public List<CombatParticipant> targetsAttackingThis = new List<CombatParticipant>();

    [HideInInspector]
    public bool canAttack;

    public bool hasWeapon;

    #region Public Accessors
    public CombatParticipant Target { get { return target; } }
    public float Health { get { return health; } }
    #endregion

    #region Unity Functions
    void Awake()
    {
        OnAwake();
    }
    void Start()
    {
        OnStart();
    }
    void Update()
    {
        OnUpdate();
    }
    #endregion

    #region Animations
    protected virtual void PlayAttackAnimation()
    {

    }
    protected virtual void PlayBlockAnimation()
    {

    }

    protected virtual void PlayUnBlockAnimation()
    {

    }

    protected virtual void PlayCombatNothingAnimation()
    {

    }
    #endregion

    private bool dying;

    protected void CombatStateChanged()
    {
        if (previousState != CombatState.Blocking && combatState == CombatState.Blocking)
        {
            PlayBlockAnimation();
        }
        else if (previousState == CombatState.Blocking && combatState != CombatState.Blocking)
        {
            PlayUnBlockAnimation();
        }
        else if(combatState == CombatState.Nothing)
        {
            PlayCombatNothingAnimation();
        }
    }

    protected virtual void OnAwake()
    {
        MaxHealth = health;
    }

    protected virtual void OnStart()
    {

    }

    protected virtual void OnUpdate()
    {
        AttackOnCooldown();
        CheckForDeath();
    }

    private void AttackOnCooldown()
    {
        if (CurrentCombatState == CombatState.Attacking)
        {
            if (this.attackTimer >= 0 && this.attackTimer <= 0.01f)   {    PlayAttackAnimation();  }

            this.attackTimer += Time.deltaTime;
            if (this.attackTimer > this.attackSpeed)
            {
                if (hasWeapon) { canAttack = !canAttack; }
                this.attackTimer = 0;
                if (!hasWeapon)  {  this.Attack();  }
            }
        }
    }

    protected virtual void BeingAttacked(CombatParticipant attackedBy)
    {
        if(CurrentCombatState == CombatState.Blocking)
        {
            Block(attackedBy);
        }
        else if (CurrentCombatState == CombatState.Dodging)
        {
            Dodge();
        }
    }

    public virtual void Attack()
    {
        //do the attack thing
        this.DealDamage(attackDamage);
        if (this.target != null)
        { this.target.BeingAttacked(this); }
    }

    public virtual void Block(CombatParticipant attackedBy)
    {
        //check sturdiness
        if (blockHitTimes > blockSturdiness)
        {
            //break block - no damage recovery
        }
        else
        {
            blockHitTimes++;
            //normal blocking - maybe cut damage
            health += attackedBy.attackDamage - (attackedBy.attackDamage / 4);
        }
    }

    public virtual void Dodge()
    {
        //do the dodge thing
        Debug.Log("Dodged");
    }

    protected void CheckForDeath()
    {
        if (health <= 0 && !dying)
        {
            this.combatState = CombatState.Dead;
            StartCoroutine(DeathDelay());
        }
    }
    public virtual void Death()
    {
        this.gameObject.SetActive(false);
    }


    public virtual void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
    }

    public virtual void RecoverHealth(float recoveryAmount)
    {
        health += recoveryAmount;
    }

    public virtual void DealDamage(float amount)
    {
        if (targetToAttack != null)
        { targetToAttack.TakeDamage(amount); }
    }

    public void SetTarget(CombatParticipant newTarget)
    {
        if(newTarget != target)
        {
            if (target != null)  { target.targetsAttackingThis.Remove(this); }

            if (newTarget != null)
            {
                target = newTarget;
                newTarget.targetsAttackingThis.Add(this);
            }
        }
    }


    IEnumerator DeathDelay()
    {
        dying = true;
        yield return new WaitForSeconds(1f);
        Death();
    }
}
