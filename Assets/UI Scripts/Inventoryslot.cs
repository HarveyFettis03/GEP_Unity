using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Inventoryslot : MonoBehaviour, IDropHandler
{   //For selecting which item you want to use
    public Image image;
    public Color Selectedcolor, notSelectedColor;

    //Select and Deselected will change color depending on what item the player has selected on awake no item will be selected

    public void Awake()
    {
        Deselect();
    }
    public void Select()
    {
        image.color = Selectedcolor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
