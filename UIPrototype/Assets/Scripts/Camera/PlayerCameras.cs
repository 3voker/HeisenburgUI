using UnityEngine;
using System.Collections;

public class PlayerCameras : MonoBehaviour
{
    public Camera main;
    public Camera npc;

    public void ShowMainCamera()
    {
        main.gameObject.SetActive(true);
        npc.gameObject.SetActive(false);
    }

    public void ShowNPCCamera()
    {
        main.gameObject.SetActive(false);
        npc.gameObject.SetActive(true);
    }
}
