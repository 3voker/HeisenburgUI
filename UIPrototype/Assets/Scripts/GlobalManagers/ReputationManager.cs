using UnityEngine;
using System.Collections;

public class ReputationManager : MonoBehaviour
{
    private static ReputationManager singleton; // Singleton instance   
    public static ReputationManager Instance
    {
        get
        {
            if (singleton == null)
            {
                Debug.LogError("[ReputationManager]: Instance does not exist!");
                return null;
            }

            return singleton;
        }
    }

    public float Reputation { get; private set; }

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
        Reputation = 50;
    }

    public void IncreaseReputation(float amount)
    {
        Reputation += amount;
    }

    public void DecreaseReputation(float amount)
    {
        Reputation -= amount;
    }
}
