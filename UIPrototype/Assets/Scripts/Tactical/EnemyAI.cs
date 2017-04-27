using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector] public bool canDoThings;
    [HideInInspector] public EnemyPawns[] enemyPawns;

    private void Start()
    {
        enemyPawns = GameObject.FindObjectsOfType<EnemyPawns>();
    }

    void Update ()
    {
	    
	}

    private void DecideTurn()
    {
        int rnd = Random.Range(0, enemyPawns.Length);
        enemyPawns[rnd].MovePawn();
    }

    private void EnableEnemyTurn()
    {
        if (TurnManager.Instance.CurrentTurn == Turn.Enemy)
        {
            canDoThings = true;
            DecideTurn();
        }
        else
        {
            canDoThings = false;
        }
    }

    #region Event Subscription
    private void OnEnable()
    {
        TurnManager manager = GameObject.FindObjectOfType<TurnManager>();
        manager.OnTurnCountChanged += EnableEnemyTurn;
    }

    private void OnDisable()
    {
        TurnManager.Instance.OnTurnCountChanged -= EnableEnemyTurn;
    }
    #endregion
}
