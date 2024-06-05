using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    [SerializeField] private List<Image> inventoryImages = new List<Image>();

    void Start()
    {
        UpdateInventoryUI();
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventoryImages.Count; i++)
        {
            int row = i / 4; 
            int column = i % 4; 
            if (inventory.inventoryGrid[row, column].Count > 0)
            {
                GameObject itemObject = inventory.inventoryGrid[row, column].top.Value.ItemObject;
                Sprite itemSprite = itemObject.GetComponent<SpriteRenderer>().sprite; 
                inventoryImages[i].sprite = itemSprite;
                inventoryImages[i].enabled = true; 
            }
            else
            {
                inventoryImages[i].enabled = false;
            }
        }
    }
}