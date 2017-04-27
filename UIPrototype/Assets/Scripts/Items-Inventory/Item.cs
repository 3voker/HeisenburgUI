using UnityEngine;
using System.Collections;

//We probably want to load items from an XML database? 

public class Item : MonoBehaviour
{
    private Inventory inventory;
    protected string itemName;
    [HideInInspector]
    public bool isSelectedInInventory;

    #region Accessors
    public string ItemName { get { return itemName; } }
    #endregion

    #region Unity Functions
    void Awake() { OnAwake(); }
    void Start() { OnStart(); }
    void Update() { OnUpdate(); }
    #endregion

    protected virtual void OnAwake()
    {

    }

    protected virtual void OnStart() { inventory = GameObject.FindObjectOfType<Inventory>(); }

    protected virtual void OnUpdate()
    {
        if (inventory.Items.Contains(this))
        {
            if (Input.GetKeyDown(inventory.consumeButton) && isSelectedInInventory)
            {
                Use();
            }
        }
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<PlayerController>() != null)
        {
            PickUp();
        }
    }

    public virtual void PickUp()
    {
        inventory.AddItem(this);
        this.transform.parent = inventory.transform.GetChild(0);
        Collider[] colliders = this.GetComponents<Collider>();
        Collider col = System.Array.Find(colliders, item => item.isTrigger == true);
        col.enabled = false;
    }

    public virtual void Use()
    {
        this.gameObject.SetActive(false);
        inventory.Items.Remove(this);
        Destroy(this.gameObject, 2f);
    }
}
