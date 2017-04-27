using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Enemy))]
public class EnemyHealthBar : MonoBehaviour
{
    [HideInInspector] public Canvas worldCanvas;
    public GameObject healthBarPrefab;
    public float yOffset = 2;
    public float width = 10.44f;

    private Slider healthBar;
    private Enemy enemy;

    private Vector3 offset;

    void Awake()
    {
        enemy = this.GetComponent<Enemy>();
        worldCanvas = GameObject.Find("WorldCanvas").GetComponent<Canvas>();
        if(worldCanvas == null) { Debug.LogError("World canvas does not exist"); }
    }

    void OnEnable()
    {
        InitializeBar();
    }

    private void InitializeBar()
    {
        GameObject bar = Instantiate(healthBarPrefab, worldCanvas.transform) as GameObject;
        healthBar = bar.GetComponent<Slider>();
        healthBar.GetComponent<RectTransform>().localScale = Vector3.one;
        healthBar.GetComponent<RectTransform>().sizeDelta = new Vector3(width, healthBar.GetComponent<RectTransform>().sizeDelta.y);
        offset = new Vector3(0, yOffset, 0);
    }

    void Update()
    {
        if (enemy.Health > 0 && healthBar != null)
        {
            //Debug.Log("Enemy health - " + enemy.Health + " // " + enemy.name);
            healthBar.value = enemy.Health;
            healthBar.maxValue = enemy.MaxHealth;

            healthBar.gameObject.transform.position = enemy.gameObject.transform.position + offset;
        }
        else
        {
            if (healthBar != null)
            { Destroy(healthBar.gameObject); }
        }
    }

    void OnDisable()
    {
        if (healthBar != null)
        { Destroy(healthBar.gameObject); }
    }
}
