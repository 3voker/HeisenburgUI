using UnityEngine;
using System.Collections;

public enum Turn { Player, Enemy }

public class TurnManager : MonoBehaviour
{
    #region Singleton
    private static TurnManager singleton; // Singleton instance   
    public static TurnManager Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[TurnManager]: Instance does not exist!");
                return null;
            }

            return singleton;
        }
    }
    private void DeclareSingleton()
    {
        // Found a duplicate instance of this class, destroy it!
        if (singleton != null && singleton != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Create singleton instance
            singleton = this;
        }
    }
    #endregion

    private int turnCount
    {
        get { return tC; }
        set
        {
            tC = value;
            OnTurnCountChanged();
        }
    }

    public int RealTurnCount = 1;
    public Turn CurrentTurn;

    public delegate void TurnCountIsChanged();
    public event TurnCountIsChanged OnTurnCountChanged;

    private void Awake()
    {
        DeclareSingleton();
        CurrentTurn = Turn.Player;
    }

    void Start ()
    {
	
	}
	

	void Update ()
    {

	}

    public void IncrementTurn()
    {
        turnCount++;
    }

    private void OnTurnCountChange()
    {
        ChangeTurn();
        CheckRealTurnCountIncrementation();
    }

    private void ChangeTurn()
    {
        if (turnCount % 2 == 0)
        {
            CurrentTurn = Turn.Player;
        }
        else
        {
            CurrentTurn = Turn.Enemy;
        }
    }

    private void CheckRealTurnCountIncrementation()
    {
        if (turnCount % 3 == 0)
        {
            RealTurnCount++;
        }
    }

    #region Event Subscription
    private void OnEnable()
    {
        OnTurnCountChanged += OnTurnCountChange;
    }

    private void OnDisable()
    {
        OnTurnCountChanged -= OnTurnCountChange;
    }
    #endregion

    #region Private Property Variables
    private int tC;
    #endregion

}
