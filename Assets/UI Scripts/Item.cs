using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{


    [Header("Only Gameplay")]
    public ToolboxItemFilterType type;
    public InputActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);
    public TileBase tile;

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;
}
    public enum ItemType
    {
        fruit,
        Tool,
        
    }

    public enum ActionType
    {
        dig,
        Mine,
        eat
    }

