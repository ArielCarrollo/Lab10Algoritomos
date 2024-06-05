using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public GameObject ItemObject { get; private set; }

    public InventoryItem(GameObject itemObject)
    {
        ItemObject = itemObject;
    }
}

