using UnityEngine;
using System.Collections;


namespace UnitySampleAssets.Characters.ThirdPerson
{
    public class LoadInformation : MonoBehaviour
    {

        // Use this for initialization
        public static void LoadAllinformation()
        {
            GameInformation.PlayerName = PlayerPrefs.GetString("PLAYERNAME");
            GameInformation.PlayerLevel = PlayerPrefs.GetInt("Level");
            GameInformation.PlayerHealth = PlayerPrefs.GetInt("Health");
            GameInformation.PlayerMagic = PlayerPrefs.GetInt("Magic");

            Debug.Log("Load all information!");
        }
    }
}
