using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mosterHover : MonoBehaviour
{
    public InventoryObject infectionrecord;
    public DragandDrop cursorcontroller;
    public bool monsterclicked = false;
    public GameObject web;
    public InventoryObject monsterclickedpos; 

    void Update()
    {
        if (monsterclicked)
        {
            Instantiate(web, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y + 3f, GameObject.Find("Player").transform.position.z), Quaternion.identity);
            monsterclicked = false; 
        }
    }

    // Start is called before the first frame update
    public void OnMouseEnter()
    {
        cursorcontroller.enableaim();
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
    }
    public void OnMouseDown()
    {
        monsterclicked = true;
        monsterclickedpos.monsterclickedpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }
}
