using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenClose : MonoBehaviour
{
    [SerializeField] GameObject MainInventory;
    [SerializeField] KeyCode[] toggle;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            MainInventory.SetActive(true);
            UnityEngine.Cursor.visible = true;
            UnityEngine.Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            MainInventory.SetActive(false);
            UnityEngine.Cursor.visible = false;
            Time.timeScale = 1;
        }


    }
}
