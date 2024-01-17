using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Inventoryslot[] inventorySlots;
    public GameObject InventoryItemPrefab;
    public int maxStackedItems = 4;
    //-1 means no item will be selected when the player starts
    int selectedSlot = -1;

    private void Start()
    {
        //At start first item in slot is selected
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        // uses number keys to go through items in inventory only if number is between range
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 8)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
    }


    void ChangeSelectedSlot(int newValue)
        //if statement makes it so when player changes selected slot the previous item doesnt stay selected
    {   if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }
        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }
    public bool AddItem(Item item)
    {
        for (int i = 0; i <inventorySlots.Length; i++) 
        { 
            Inventoryslot slot = inventorySlots[i];
            {
                InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                if (itemInSlot != null &&
                    itemInSlot.item == item &&
                    itemInSlot.count < maxStackedItems)
                    itemInSlot.item.stackable = false;
                {
                    itemInSlot.count++;
                    itemInSlot.RefreshCount();
                    return true;
                }
            }
        }

        //Find any empty slot using for loop
        for (int i= 0; i < inventorySlots.Length; i++)
        {
            Inventoryslot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, Inventoryslot slot)
    {
        GameObject newItemGo = Instantiate(InventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
}
