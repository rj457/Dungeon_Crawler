using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorWall : MonoBehaviour
{
    private bool isWallclicked;
    public InventoryObject inventory;
    public GameObject loading;
    //cursorcontroller 
    public DragandDrop cursorcontroller;

    void Start()
    {
        cursorcontroller = GameObject.Find("CursorController").GetComponent<DragandDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWallclicked)
        {
            loading.GetComponent<Slider>().value -= Time.deltaTime;
            if (loading.GetComponent<Slider>().value <= 0)
            {
                Destroy(gameObject);
                cursorcontroller.enablenormal();
                inventory.wallcounts += 1;
                isWallclicked = false;
            }
        }
    }
    public void OnMouseEnter()
    {
        cursorcontroller.enablechest();
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
    }
    public void OnMouseDown()
    {
        loading.SetActive(true);
        isWallclicked = true;
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }
}
