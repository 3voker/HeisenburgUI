using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image healthBarImage;
    private float curHealth = 1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            curHealth -= .1f;
            ChangeHealthBar(curHealth);
        }
    }

    public void ChangeHealthBar(float myHealth)
    {
        healthBarImage.transform.localScale = new Vector3(myHealth, healthBarImage.transform.localScale.y, healthBarImage.transform.localScale.z);   
    }
}
