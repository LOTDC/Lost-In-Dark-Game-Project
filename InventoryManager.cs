using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();
    public Transform ItemContent;
    public GameObject InventoryItem;

    private void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        try
        {
            foreach (Transform item in ItemContent)
            {
                Destroy(item.gameObject);
            }

            foreach (var item in Items)
            {
                GameObject obj = Instantiate(InventoryItem, ItemContent);
                var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
                var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

                if (itemName != null)
                {
                    itemName.text = item.itemName;
                }
                else
                {
                    Debug.LogError("itemName is null. Make sure you have assigned the Text component to the itemName variable.");
                }

                itemIcon.sprite = item.icon;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("An error occurred: " + e.Message);
        }
    }
}