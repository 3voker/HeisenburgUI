using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlaceHolderContainer : MonoBehaviour, IActivateable
{
    [SerializeField]
    GameObject placeHolderPanel;

    public void DoActivate()
    {
        placeHolderPanel.SetActive(true);
    }

    // Use this for initialization
    void Start ()
    {
        placeHolderPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ClosePlaceHolder()
    {
        placeHolderPanel.SetActive(false);
    }
    public void ToGoronLevel()
    {
        SceneManager.LoadScene("Goron Level");
    }

    public void MainMenuTeleport()
    {
        SceneManager.LoadScene(0);
    }
}
