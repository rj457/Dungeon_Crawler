using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    //cursor types
    private GameObject defaultcursor;
    private GameObject axecursor;
    private GameObject aimcursor;
    private GameObject chestcursor; 
    public List<GameObject> cursortypes; 

    private bool isenterrock;
    Vector2 cursorPos; 

    void Start()
    {
        
        Cursor.visible = false;
        defaultcursor = cursortypes[0];
        axecursor = cursortypes[1];
        aimcursor = cursortypes[2];
        chestcursor = cursortypes[3];
    }

    void Update()
    {
        cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        foreach (GameObject cursor in cursortypes)
        {
            if (cursor != null) 
            {
                cursor.transform.position = cursorPos; 
            }
        }
    }
    public void enablenormal()
    {
        axecursor.SetActive(false);
        defaultcursor.SetActive(true);
        aimcursor.SetActive(false);
        chestcursor.SetActive(false);
    }
    public void enableaxe()
    {
        axecursor.SetActive(true);
        defaultcursor.SetActive(false);
        aimcursor.SetActive(false);
        chestcursor.SetActive(false);
    }
    public void enableaim()
    {
        axecursor.SetActive(false);
        defaultcursor.SetActive(false);
        aimcursor.SetActive(true);
        chestcursor.SetActive(false);
    }
    public void enablechest()
    {
        chestcursor.SetActive(true);
        axecursor.SetActive(false);
        defaultcursor.SetActive(false);
        aimcursor.SetActive(false);
    }

}
