using UnityEngine;
using System.Collections;

public class WorldCanvasHack : MonoBehaviour
{
    private Canvas canvas;

    private void Start()
    {
        canvas = this.GetComponent<Canvas>();
    }

    void Update ()
    {
	    if(canvas.worldCamera == null)
        {
            canvas.worldCamera = Camera.main;
        }
	}
}
