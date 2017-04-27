using UnityEngine;
using System.Collections;

public class ItemsManager : MonoBehaviour
{
    public float healthPotionRecovery;
    public float magicPotionRecovery;


    private static ItemsManager singleton; // Singleton instance   
    public static ItemsManager Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[ItemsManager]: Instance does not exist!");
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
