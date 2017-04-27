using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class MovePawn : MonoBehaviour
{
    #region Singleton
    private static MovePawn singleton; // Singleton instance   
    public static MovePawn Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[MovePawn]: Instance does not exist!");
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

    public Pawns[] pawns; 
    public GridSquare[] gridSquares;

    public Pawns CurrentPawn;
    public bool MovingPawn;

    private int maxColumnNumber = 0;
    private int maxGridSpaceNumber = 0;

    void Awake()
    {
        DeclareSingleton();
        gridSquares = GameObject.FindObjectsOfType<GridSquare>();
        pawns = GameObject.FindObjectsOfType<Pawns>();
    }

    private void Start()
    {
        FindMaxNums();
    }

    public List<GridSquare> HighlightAdjacentGridSquares()
    {
        List<GridSquare> squares = new List<GridSquare>();

        if (MovingPawn)
        {
            int prevColumn = CurrentPawn.gridLocation.columnNumber - 1;
            int prevGridNum = CurrentPawn.gridLocation.gridSpaceNumber - 1;

            int nextColum = CurrentPawn.gridLocation.columnNumber + 1;

            int nextGridNum = CurrentPawn.gridLocation.gridSpaceNumber + 1;

            int currentColumnNumber = CurrentPawn.gridLocation.columnNumber;
            int currentGridNumber = CurrentPawn.gridLocation.gridSpaceNumber;

            //TODO : ADD DIAGONAL SPACES

            GridSquare gS1 = System.Array.Find(gridSquares, item => item.LocationOnGrid.columnNumber == nextColum && item.LocationOnGrid.gridSpaceNumber == currentGridNumber);
            if (gS1 != null) { gS1.canMovePawnToThis = true; squares.Add(gS1); /*Debug.Log("GS1 : " + gS1.transform.parent.name + " // " + gS1.name);*/ }

            GridSquare gS2 = System.Array.Find(gridSquares, item => item.LocationOnGrid.columnNumber == currentColumnNumber && item.LocationOnGrid.gridSpaceNumber == nextGridNum);
            if (gS2 != null) { gS2.canMovePawnToThis = true; squares.Add(gS2); /*Debug.Log("GS2 : " + gS2.transform.parent.name + " // " + gS2.name);*/ }

            GridSquare gS3 = System.Array.Find(gridSquares, item => item.LocationOnGrid.columnNumber == currentColumnNumber && item.LocationOnGrid.gridSpaceNumber == prevGridNum);
            if (gS3 != null) { gS3.canMovePawnToThis = true; squares.Add(gS3); /*Debug.Log("GS3 : " + gS3.transform.parent.name + " // " + gS3.name);*/ }

            GridSquare gS4 = System.Array.Find(gridSquares, item => item.LocationOnGrid.columnNumber == prevColumn && item.LocationOnGrid.gridSpaceNumber == currentGridNumber);
            if (gS4 != null) { gS4.canMovePawnToThis = true; squares.Add(gS4); /*Debug.Log("GS4 : " + gS4.transform.parent.name + " // " + gS4.name);*/ }


            GridSquare cur = System.Array.Find(gridSquares, item => item.LocationOnGrid.columnNumber == currentColumnNumber && item.LocationOnGrid.gridSpaceNumber == currentGridNumber);
            cur.canMovePawnToThis = true;
            cur.currentSpace = true;

            if (gS1 != null) { GridSquare.ToggleGridSquareHalo(gS1, true); }
            if (gS2 != null) { GridSquare.ToggleGridSquareHalo(gS2, true); }
            if (gS3 != null) { GridSquare.ToggleGridSquareHalo(gS3, true); }
            if (gS4 != null) { GridSquare.ToggleGridSquareHalo(gS4, true); }
            GridSquare.ToggleGridSquareHalo(cur, true);
        }

        return squares;
    }

    private void FindMaxNums()
    {
        maxColumnNumber = gridSquares.Max(item => item.LocationOnGrid.columnNumber);
        maxGridSpaceNumber = gridSquares.Max(item => item.LocationOnGrid.gridSpaceNumber);
    }


}
