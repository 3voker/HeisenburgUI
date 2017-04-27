using UnityEngine;
using System.Collections;


namespace UnitySampleAssets.Characters.ThirdPerson
{
    public class SaveInformation : MonoBehaviour
    {

        // Use this for initialization
        public static void SaveAllInformation()
        {
            PlayerPrefs.SetInt("PLAYERLEVEL", GameInformation.PlayerLevel);
            PlayerPrefs.SetString("PLAYERNAME", GameInformation.PlayerName);
            PlayerPrefs.SetInt("PlayerHealth", GameInformation.PlayerHealth);
            PlayerPrefs.SetInt("PlayerMagic", GameInformation.PlayerMagic);

            Debug.Log("Saved All Information!!");

        }
     
    }
}
