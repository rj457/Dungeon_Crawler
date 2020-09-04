using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro; 

public class totalAlliesFound : MonoBehaviour
{
    private int alliescount;
    public List<GameObject> allies;
    public InventoryObject inventory; 

    void Start()
    {
        allies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Allies"));
        alliescount = allies.Count; 
    }

    void Update()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "Total Uninfected Allies Found: " + inventory.alliesTag.Count + "/" + alliescount; 
    }
}
