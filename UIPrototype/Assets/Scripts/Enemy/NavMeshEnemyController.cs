using UnityEngine;
using System.Collections;

public class NavMeshEnemyController : EnemyController
{
    private NavMeshAgent agent;

    protected override void OnAwake()
    {
        base.OnAwake();
        agent = this.GetComponent<NavMeshAgent>();
    }

    protected override void OnStart()
    {
        base.OnStart();
        agent.stoppingDistance = this.stoppingDistance;
        agent.speed = this.movementSpeed;
    }

    protected override void OnUpdate()
    {
        base.OnUpdate();

        //RotateIfStopped();

        if (canMove)
        { agent.Resume(); }
        else
        { agent.Stop(); }
    }

    protected override void MoveToDestination()
    {
        base.MoveToDestination();
        if (destination != null)
        { agent.destination = destination; }
    }

    protected override void CheckDistance()
    {
        base.CheckDistance();
        this.AtDestination = (agent.remainingDistance <= (agent.stoppingDistance + 0.1f));
    }

    protected virtual void RotateIfStopped()
    {
        if (agent.pathStatus == NavMeshPathStatus.PathComplete)
        {
            this.LookAtDestination();
        }
    }
}
