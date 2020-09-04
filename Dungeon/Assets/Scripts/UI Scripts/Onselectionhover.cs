using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; 

public class Onselectionhover : MonoBehaviour
{
    public InventoryObject inventory;
    public CursorRock cursorRock;

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            inventory.ismouseonselectbox = true;
        }
        else
        {
            inventory.ismouseonselectbox = false;
        }
    }

    //public void OnMouseOver()
    //{
       
    //}
    //public void OnMouseExit()
    //{

    //}
}
