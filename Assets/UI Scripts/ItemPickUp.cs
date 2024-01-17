using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{

    public InventoryManager Inventory_Manager;
    public Item[] itemsToPickup;



    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Apple"))
        {
            for (int i = 0; i < itemsToPickup.Length; i++)
            {
                FindObjectOfType<InventoryManager>().AddItem(itemsToPickup[i]);
            }
            Destroy(other.gameObject);
        }
        
        

    }

    //public void PickupItem(int id)
    //{
    //    Inventory_Manager.AddItem(itemsToPickup[id]);
    //    Debug.Log("Added to inven");

    //}

}
