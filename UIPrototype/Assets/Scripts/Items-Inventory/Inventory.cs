using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public float rotationSpeed = -60.0F;
    public float passiveRotationSpeed = -30.0F;
    public float inventoryMax = 12;

    public KeyCode consumeButton;
    public List<Item> Items = new List<Item>();
    public GameObject InvWheel;

    private float circleRadius = 1.5f;
    bool isInvOpen = false;
    private bool increasedSize = false;

    // Use this for initialization
    void Start()
    {
        InvWheel.SetActive(false);
        RefreshItems();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && isInvOpen == false)
        {
            OpenInventory();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isInvOpen == true)
        {
            CloseInventory();
        }

        if (isInvOpen == true)
        {
            InventoryOrbit();
        }
    }

    public void AddItem(Item item)
    {
        if (isInvOpen) { CloseInventory(); OpenInventory(); }

        if (Items.Count <= inventoryMax)
        {
            Items.Add(item);
            //Debug.Log("ItemCount " + Items.Count);
        }
        else
        {
            //Debug.Log("Cannot carry item");
        }
    }

    public void RefreshItems()
    {
        Vector3 center = InvWheel.transform.position;
        for (int i = 0; i < Items.Count; i++)
        {
            int angle = i * 80;
            Vector3 pos = RandomCircle(center, circleRadius, angle);
            Quaternion rot = Quaternion.Euler(0, -158f, 0);
            Items[i].transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
            Items[i].transform.position = pos;
            Items[i].transform.rotation = rot;
        }
    }

    private Vector3 RandomCircle(Vector3 center, float radius, int angle)
    {
        float ang = angle;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        pos.z = center.z;
        return pos;
    }

    void OpenInventory()
    {
        InvWheel.SetActive(true);
        isInvOpen = true;
        RefreshItems();
    }

    void CloseInventory()
    {
        InvWheel.SetActive(false);
        isInvOpen = false;
    }

    void InventoryOrbit()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            InvWheel.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            InvWheel.transform.Rotate(0, 0, -rotationSpeed * Time.deltaTime);
        }

        else
        {
            InvWheel.transform.Rotate(0, 0, passiveRotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Item>() != null)
        {
            Item item = col.GetComponent<Item>();
            HighlightItem(item, true);
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.GetComponent<Item>() != null)
        {
            Item item = col.GetComponent<Item>();
            HighlightItem(item, false);
        }
    }

    private void HighlightItem(Item item, bool highlight)
    {
        item.isSelectedInInventory = highlight;
        Behaviour halo = (Behaviour)item.gameObject.GetComponent("Halo");
        halo.enabled = highlight;
    }

}
