using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject obj;
    public MyOwnStack<InventoryItem>[,] inventoryGrid = new MyOwnStack<InventoryItem>[3, 4];

    void Awake()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                inventoryGrid[i, j] = new MyOwnStack<InventoryItem>();
            }
        }
    }

    public void AddItem(GameObject itemObject)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (inventoryGrid[i, j].Count == 0)
                {
                    inventoryGrid[i, j].Push(new InventoryItem(itemObject));
                    FindObjectOfType<InventoryUI>().UpdateInventoryUI();
                    return;
                }
            }
        }
    }

    public void RemoveItem(GameObject itemObject)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if (inventoryGrid[i, j].Count > 0 && inventoryGrid[i, j].top.Value.ItemObject == itemObject)
                {
                    inventoryGrid[i, j].Pop();
                }
            }
        }
        FindObjectOfType<InventoryUI>().UpdateInventoryUI();
    }
    public void AgregarObjetoAlInventario()
    {
        GameObject objetoDePrueba = obj;
        FindObjectOfType<Inventory>().AddItem(objetoDePrueba);
    }
    public void QuitarObjetoDelInventario()
    {
        GameObject objetoDePrueba = obj;
        FindObjectOfType<Inventory>().RemoveItem(objetoDePrueba);
    }
}


