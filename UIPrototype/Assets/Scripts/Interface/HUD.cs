using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    // Use this for initialization
    [SerializeField]
    Sprite[] heartSprites;
    [SerializeField]
    Image heartUI;
    [SerializeField]
    Sprite[] magicSprites;
    [SerializeField]
    Image magicUI;

    Player player;
    private void Start()
    {
        //Make sure player gameObject has tag "Player" toggled on. 
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        //Visual representation of current player health.       
        heartUI.sprite = heartSprites[(int)player.Health];
        magicUI.sprite = magicSprites[(int)player.Magic];
    }
}
