using UnityEngine;
using System.Collections;

public abstract class EnemyController : MonoBehaviour
{
    private Player player;

    public bool canMove = true;
    public float stoppingDistance = 0f;
    public float movementSpeed = 5f;
    public bool AtDestination { get; set; }
    public bool inRangeOfPlayer { get; set; }

    [HideInInspector]public Vector3 destination;
    private BoxCollider boxCollider;

    public float wanderingRaidus = 5;
    public float sightRadius = 5;

    #region UnityFunctions
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

    protected virtual void OnAwake()
    {
        #region Set sight raidus size
        BoxCollider[] colliders = this.GetComponents<BoxCollider>();
        if(colliders.Length > 1)
        {
            boxCollider = System.Array.Find(colliders, item => item.isTrigger);
            boxCollider.size = new Vector3(sightRadius, boxCollider.size.y, sightRadius);
        }
        else if (colliders.Length == 1)
        {
            boxCollider = colliders[0];
            boxCollider.size = new Vector3(sightRadius, boxCollider.size.y, sightRadius);
        }
        else
        {
            Debug.LogError("Enemy has no box collider -- can't set trigger size");
        }
        #endregion

        player = GameObject.FindObjectOfType<Player>();
    }

    protected virtual void OnStart()
    {
        destination = RandomDestination();
    }
    
    protected virtual void OnUpdate()
    {
        CheckDistance();

        if(inRangeOfPlayer && player != null) { this.destination = player.gameObject.transform.position; }

        if (canMove)
        {
            Wandering();
            MoveToDestination();
        }
        else
        {
            LookAtDestination();
        }
    }

    protected virtual void MoveToDestination()
    {

    }
    protected virtual void CheckDistance()
    {

    }

    public void LookAtDestination()
    {
        if (destination != null)
            this.transform.LookAt(destination);
    }

    public void ToggleMovement(bool enabled)
    {
        canMove = enabled;
    }

    public void SetStoppingDistance(float dist)
    {
        stoppingDistance = dist;
    }

    protected void Wandering()
    {
        if (!inRangeOfPlayer)
        {
            if (AtDestination)
            {
                destination = RandomDestination();
            }
        }
    }

    protected Vector3 RandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderingRaidus;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderingRaidus, 1);
        Vector3 finalPosition = hit.position;
        return finalPosition;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>() != null)
        {
            inRangeOfPlayer = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        //if (collider.GetComponent<Player>() != null)
        //{
        //    inRangeOfPlayer = false;
        //    this.destination = RandomDestination();
        //}
    }

    void OnDrawGizmos()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawSphere(destination, 1);
    }
}
