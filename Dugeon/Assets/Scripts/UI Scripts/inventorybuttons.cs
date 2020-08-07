using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class inventorybuttons : MonoBehaviour
{
    public GameObject equipSlot;
    public GameObject rockPrefab;
    public TextMeshProUGUI numbercount;
    public InventoryObject inventory; 
    
    public void OnRockClick()
    {
        if (GameObject.Find("RockSprite(Clone)") == null)
        {
            var newrock = Instantiate(rockPrefab, equipSlot.transform.position, Quaternion.identity);
            newrock.transform.parent = equipSlot.transform;
            numbercount.text = inventory.rockcounts.ToString("0");
        }
        else
        {
            return; 
        }
    }
}
