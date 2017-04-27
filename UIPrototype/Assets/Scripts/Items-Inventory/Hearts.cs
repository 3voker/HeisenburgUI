using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {   
        if(collider.GetComponent<Player>() != null)
        {
            //heart does a thing
            Destroy(this.gameObject, 1f);
        }   
    }
}
