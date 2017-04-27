using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerDataManager : MonoBehaviour
{
    #region Singleton
    private static PlayerDataManager singleton; // Singleton instance   
    public static PlayerDataManager Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[PlayerDataManager]: Instance does not exist!");
                return null;
            }

            return singleton;
        }
    }
    private void DeclareSingleton()
    {
        // Found a duplicate instance of this class, destroy it!
        if (singleton != null && singleton != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            // Create singleton instance
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion

    private Player player;

    public float Health = 0;
    

    void Awake()
    {
        DeclareSingleton();
        SceneManager.sceneLoaded += RunOnEachLevelLoad;
    }

    public void RunOnEachLevelLoad(Scene scene, LoadSceneMode sceneMode)
    {
        if(scene.ToString() != "MainMenu")
        {
            player = GameObject.FindObjectOfType<Player>();

            if (Health != 0) { player.SetHealth(Health); }
            else { Health = player.Health; }
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= RunOnEachLevelLoad;
    }
}
