using UnityEngine;
using System.Collections;

public class Interactable : MonoBehaviour
{
    public Vector3 collectablePosition;

    private void Start()
    {
        collectablePosition = transform.FindChild("Item").position;
    }


}
