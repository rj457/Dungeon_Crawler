using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cursorMask : MonoBehaviour
{
    private bool ismaskclicked;
    public InventoryObject inventory;
    public GameObject loading; 
    //cursorcontroller 
    public DragandDrop cursorcontroller;

    void Start()
    {
        //cursorcontroller = GameObject.Find("CursorController").GetComponent<DragandDrop>();
        ismaskclicked = true; 
    }

    // Update is called once per frame
    void Update()
    {
        if (ismaskclicked)
        {
            loading.SetActive(true);
            loading.GetComponent<Slider>().value -= Time.deltaTime;
            if (loading.GetComponent<Slider>().value <= 0)
            {
                Destroy(gameObject);
                //cursorcontroller.enablenormal();
                inventory.maskcounts += 10;
                ismaskclicked = false;
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
    //    ismaskclicked = true;
    //}

    //public void OnMouseUp()
    //{
    //    cursorcontroller.enablenormal();
    //}
}
