using UnityEngine;
using System.Collections;

public class PlayerSingleton : MonoBehaviour
{
    private static PlayerSingleton singleton; // Singleton instance   
    public static PlayerSingleton Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[PlayerSingleton]: Instance does not exist!");
                return null;
            }

            return singleton;
        }
    }
    void Awake()
    {
        #region Singleton
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
        #endregion
    }
}
