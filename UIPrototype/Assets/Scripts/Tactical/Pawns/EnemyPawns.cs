using UnityEngine;
using System.Collections;

public class EnemyPawns : Pawns
{
    private void Update()
    {
        
    }

    public void MovePawn()
    {
        StartCoroutine(TakeTurn());
    }

    private int ChooseRandomGridSquare()
    {
        int rnd = 0;
        rnd = Random.Range(0, this.adjacentGridSquares.Count);

        return rnd;
    }

    IEnumerator TakeTurn()
    {
        yield return new WaitForSeconds(1f);
        this.OnButtonClick();
        yield return new WaitForSeconds(0.5f);
        int random = ChooseRandomGridSquare();
        yield return new WaitForSeconds(1f);
        //Debug.Log(adjacentGridSquares[random].transform.parent.name + " // " + adjacentGridSquares[random].name);
        adjacentGridSquares[random].OnButtonClick();
    }
}
