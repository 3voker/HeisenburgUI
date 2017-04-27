using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PawnColors : MonoBehaviour
{
    private Image image;
    public PawnType pawnType;

    private void Awake()
    {
        image = this.GetComponent<Image>();
    }

    private void Start()
    {
        switch (pawnType)
        {
            case PawnType.Ganondorf:
                image.color = TacticalGUIManager.Instance.ganondorfColor;
                break;
            case PawnType.Enemy:
                if (TacticalEnemyTypeManager.fightingGorons)
                {
                    TacticalGUIManager.Instance.EnemyName = "Goron";
                    image.color = TacticalGUIManager.Instance.goronColor;
                }
                else
                {
                    TacticalGUIManager.Instance.EnemyName = "Bandit";
                    image.color = TacticalGUIManager.Instance.banditColor;
                }
                break;
            default:
                break;
        }
    }
}
