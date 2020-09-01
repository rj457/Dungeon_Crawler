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
    public Onselectionhover selethover;
    private bool isselecthover; 
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
        isselecthover = selethover.ismouseoverselbox; 
    }
    public void OnMouseEnter()
    {
        if (isselecthover == false)
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
        cursorcontroller.enablenormal();
        cursorInstruction.SetActive(false); 
    }
    public void OnMouseDown()
    {
        if (isselecthover == false)
        {
            loading.SetActive(true);
            isrockclicked = true;
            cursorInstruction.SetActive(false);
            cursorcontroller.enablenormal();
        }
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }

}
