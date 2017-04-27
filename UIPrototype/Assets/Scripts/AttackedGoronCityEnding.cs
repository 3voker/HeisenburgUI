using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AttackedGoronCityEnding : MonoBehaviour
{
    public GameObject endPanel;
    private Link link;

    void Start()
    {
        endPanel.SetActive(false);
    }

    void Update()
    {
        link = GameObject.FindObjectOfType<Link>();
        if (link != null) { Debug.Log(link.hasItem); }
        if (link != null && link.hasItem)
        {
            endPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
