using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public GridLocation LocationOnGrid;
    public Transform[] pawnLocs = new Transform[4];
    private int[] pawnLocsFilled = new int[4];
    [HideInInspector] public bool canMovePawnToThis = false;
    [HideInInspector] public bool currentSpace = false;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        GetGridLocation();
    }

    private void Start()
    {
        pawnLocs[0] = this.transform.GetChild(0).GetChild(0).transform;
        pawnLocs[1] = this.transform.GetChild(0).GetChild(1).transform;
        pawnLocs[2] = this.transform.GetChild(1).GetChild(0).transform;
        pawnLocs[3] = this.transform.GetChild(1).GetChild(1).transform;

        pawnLocsFilled[0] = 0;
        pawnLocsFilled[1] = 0;
        pawnLocsFilled[2] = 0;
        pawnLocsFilled[3] = 0;
    }

    private void Update()
    {
        if (MovePawn.Instance.MovingPawn && canMovePawnToThis) {  this.GetComponent<Button>().enabled = true; }
        else {  this.GetComponent<Button>().enabled = false; }

        if(MovePawn.Instance.MovingPawn == false) { ToggleGridSquareHalo(this, false); }
    }

    public void OnButtonClick()
    {
        if (!currentSpace)
        {
            for (int x = 0; x < pawnLocsFilled.Length; x++)
            {
                if (pawnLocsFilled[x] == 0)
                {
                    MovePawn.Instance.CurrentPawn.transform.position = pawnLocs[x].position;
                    MovePawn.Instance.CurrentPawn.gridLocation = this.LocationOnGrid;
                    pawnLocsFilled[x] = 1;
                    MovePawn.Instance.CurrentPawn.pawnLoc = x;
                    TurnManager.Instance.IncrementTurn();
                    break;
                }
            }
        }

        currentSpace = false;
        canMovePawnToThis = false;
        UpdatePawnLocs();
        MovePawn.Instance.MovingPawn = false;
    }

    private void UpdatePawnLocs()
    {
        for (int x = 0; x < pawnLocs.Length; x++)
        {
            if (System.Array.Find(MovePawn.Instance.pawns, item => item.pawnLoc == x) == null)
            {
                pawnLocsFilled[x] = 0;
            }
        }
    }

    private void GetGridLocation()
    {
        if (this.transform.parent.gameObject.name.Contains("Column ("))
        {
            string s = this.transform.parent.gameObject.name.Substring(8);
            char[] cA = s.ToCharArray();
            string num = cA[0].ToString();
            int columnNum = Converting.ConvertStringToInt(num);
            LocationOnGrid.columnNumber = columnNum;
            LocationOnGrid.gridSpaceNumber = (this.transform.GetSiblingIndex() + 1);
        }
    }
    public static void ToggleGridSquareHalo(GridSquare gridSquare, bool toggle)
    {
        Behaviour halo = (Behaviour)gridSquare.GetComponent("Halo");
        halo.enabled = toggle; // false
    }
}

[System.Serializable]
public class GridLocation
{
    public int columnNumber = 1;
    public int gridSpaceNumber = 1;

    public GridLocation(int column, int gridSpace)
    {
        columnNumber = column;
        gridSpaceNumber = gridSpace;
    }
}
