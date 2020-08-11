using UnityEngine;
using UnityEngine.UI;

public class CursorRock : MonoBehaviour
{
    public GameObject loading;
    private bool isrockclicked;
    public InventoryObject inventory;
    //cursorcontroller 
    public DragandDrop cursorcontroller;

    void Update()
    {
        if (isrockclicked)
        {
            loading.GetComponent<Slider>().value -= Time.deltaTime;
            if (loading.GetComponent<Slider>().value <= 0)
            {
                Destroy(gameObject);
                cursorcontroller.enablenormal();
                inventory.rockcounts += 10;
                isrockclicked = false;
            }
        }
    }
    public void OnMouseEnter()
    {
        cursorcontroller.enableaxe(); 
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal(); 
    }
    public void OnMouseDown()
    {
        loading.SetActive(true);
        isrockclicked = true;
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }

}
