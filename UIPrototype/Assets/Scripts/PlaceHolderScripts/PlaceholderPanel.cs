using UnityEngine;
using System.Collections;

public class PlaceholderPanel : MonoBehaviour
{
    public GameObject panel;

    void Awake()
    {
        panel.SetActive(false);
    }
    public void ShowPlaceholderPanel()
    {
        StartCoroutine(ShowPlaceholder());
    }

    IEnumerator ShowPlaceholder()
    {
        panel.SetActive(true);
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
    }
}
