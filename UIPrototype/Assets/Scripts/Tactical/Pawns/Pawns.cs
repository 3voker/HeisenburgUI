using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pawns : MonoBehaviour
{
    public GridLocation gridLocation;
    public int pawnLoc = 0;
    protected List<GridSquare> adjacentGridSquares;

    private void Awake()
    {
        OnAwake();
    }

    protected virtual void OnAwake()
    {

    }

    public virtual void OnButtonClick()
    {
        MovePawn.Instance.CurrentPawn = this;
        MovePawn.Instance.MovingPawn = true;
        adjacentGridSquares = MovePawn.Instance.HighlightAdjacentGridSquares();
    }
}
