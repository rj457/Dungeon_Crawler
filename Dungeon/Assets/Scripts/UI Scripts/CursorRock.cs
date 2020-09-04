using UnityEngine;
using UnityEngine.UI;

public class CursorRock : MonoBehaviour
{
    public GameObject loading;
    private bool isrockclicked;
    public InventoryObject inventory;
    //cursorcontroller 
    public DragandDrop cursorcontroller;
    public GameObject cursorInstruction;
    public bool isRockenter; 
    void Update()
    {
        if (isrockclicked)
        {
            loading.GetComponent<Slider>().value -= Time.deltaTime;
            if (loading.GetComponent<Slider>().value <= 0)
            {
                Destroy(gameObject);
                cursorcontroller.enablenormal();
                inventory.rockcounts += 4;
                isrockclicked = false;
            }
        }
    }
    public void OnMouseEnter()
    {
        isRockenter = true; 
        if (inventory.ismouseonselectbox == false)
        {
            cursorcontroller.enableaxe();
            cursorInstruction.SetActive(true);
        }
        else
        {
            cursorcontroller.enablenormal();
            cursorInstruction.SetActive(false);
        }
    }
    public void OnMouseExit()
    {
        isRockenter = false; 
        cursorcontroller.enablenormal();
        cursorInstruction.SetActive(false); 
    }
    public void OnMouseDown()
    {
        if (inventory.ismouseonselectbox == false)
        {
            loading.SetActive(true);
            isrockclicked = true;
            cursorInstruction.SetActive(false);
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
    }

}
