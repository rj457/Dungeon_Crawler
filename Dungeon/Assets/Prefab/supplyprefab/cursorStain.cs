using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorStain : MonoBehaviour
{
    private bool isstainclicked;
    public InventoryObject inventory;
    public GameObject loading;
    //cursorcontroller 
    public DragandDrop cursorcontroller;

    void Start()
    {
        //cursorcontroller = GameObject.Find("CursorController").GetComponent<DragandDrop>();
        isstainclicked = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (isstainclicked)
        {
            loading.SetActive(true);
            loading.GetComponent<Slider>().value -= Time.deltaTime;
            if (loading.GetComponent<Slider>().value <= 0)
            {
                Destroy(gameObject);
                //cursorcontroller.enablenormal();
                inventory.stainerizercounts += 8;
                isstainclicked = false;
            }
        }
    }
    //public void OnMouseEnter()
    //{
    //    cursorcontroller.enablechest();
    //}
    //public void OnMouseExit()
    //{
    //    cursorcontroller.enablenormal();
    //}
    //public void OnMouseDown()
    //{
    //    loading.SetActive(true);
    //    isstainclicked = true;
    //}

    //public void OnMouseUp()
    //{
    //    cursorcontroller.enablenormal();
    //}
}
