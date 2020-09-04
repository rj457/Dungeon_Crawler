using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mosterHover : MonoBehaviour
{
    public InventoryObject infectionrecord;
    public DragandDrop cursorcontroller;
    public bool monsterclicked = false;
    public GameObject web;
    public InventoryObject monsterclickedpos;
    public GameObject enemyinstruction;
    public GameObject skillcooldown; 

    void Update()
    {
        if (monsterclicked && infectionrecord.IsskillCooldown == false)
        {
            infectionrecord.IsskillCooldown = true;
            infectionrecord.skillfillamount = 1;
            Instantiate(web, new Vector3(GameObject.Find("Player").transform.position.x, GameObject.Find("Player").transform.position.y + 3f, GameObject.Find("Player").transform.position.z), Quaternion.identity);
            monsterclicked = false;
            
        }
    }

    // Start is called before the first frame update
    public void OnMouseEnter()
    {
        if (monsterclickedpos.ismouseonselectbox == false)
        {
            cursorcontroller.enableaim();
            enemyinstruction.SetActive(true);
        }
        else
        {
            return; 
        }
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
        enemyinstruction.SetActive(false); 
    }
    public void OnMouseDown()
    {
        if (monsterclickedpos.ismouseonselectbox == false)
        {
            monsterclicked = true;
            monsterclickedpos.monsterclickedpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            enemyinstruction.SetActive(false);
            cursorcontroller.enablenormal();
        }
        else
        {
            return;
        }
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
        monsterclicked = false; 
    }
}
