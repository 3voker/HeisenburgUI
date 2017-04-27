using UnityEngine;
using System.Collections;

public class GameInformation : MonoBehaviour {

	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
	public static string PlayerName { get; set; }
    public static int PlayerLevel { get; set; }
    public static int PlayerHealth { get; set; }
    public static int PlayerMagic { get; set; }
    
}
