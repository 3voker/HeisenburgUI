using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum PawnType { Ganondorf, Enemy }

public class TacticalGUIManager : MonoBehaviour
{
    [Header("Text")]
    public Text turnCount;
    public Text ganondorfArmy;
    public Text enemyArmy;

    [Header("Colors")]
    public Color ganondorfColor;
    public Color banditColor;
    public Color goronColor;

    public string EnemyName { get; set; }

    private PlayerInput playerInput;
    private EnemyAI enemyAI;

    public int armyScale = 20;

    #region Singleton
    private static TacticalGUIManager singleton; // Singleton instance   
    public static TacticalGUIManager Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[TacticalGUIManager]: Instance does not exist!");
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

    private void Awake()
    {
        DeclareSingleton();
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        enemyAI = GameObject.FindObjectOfType<EnemyAI>();
    }

    void Update()
    {
        if (TurnManager.Instance != null)
        { turnCount.text = "Turn #" + TurnManager.Instance.RealTurnCount; }

        ganondorfArmy.text = "Ganondorf Army: " + playerInput.playerPawns.Length * armyScale;
        enemyArmy.text = EnemyName + " Army: " + enemyAI.enemyPawns.Length * armyScale;
    }
}
