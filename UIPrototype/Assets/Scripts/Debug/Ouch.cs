using UnityEngine;
using System.Collections;

public class Ouch : MonoBehaviour
{
	public float injuryAmount = 4;
	private Player player;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<Player> ();
		player.TakeDamage (injuryAmount);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
