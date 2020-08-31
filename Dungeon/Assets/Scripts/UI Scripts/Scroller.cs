using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public GameObject boxselector;
    public Vector3 maskplace;
    public Vector3 stainerizerplace;
    public Vector3 wallplace;
    public List<Vector3> selectionplaces;
    //selectionbox locations
    public RectTransform Maskbox;
    public RectTransform sanitizerbox;
    public RectTransform Wallbox; 
    //switch conditions 
    public List<int> switches = new List<int> {1,2,3};
    public int indication; 
  
    private int pointer; 
    // Start is called before the first frame update
    void Start()
    {
        //boxselector.transform.parent = canvas.transform;
        maskplace = Maskbox.anchoredPosition; 
        stainerizerplace = sanitizerbox.anchoredPosition;
        wallplace = Wallbox.anchoredPosition;
        initalplaced(); 
    }
    void initalplaced()
    {
        boxselector.GetComponent<RectTransform>().anchoredPosition = maskplace; 
        selectionplaces = new List<Vector3> { maskplace, stainerizerplace, wallplace };
        indication = switches[0];
        pointer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            pointer = 0; 
            boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
            indication = switches[pointer];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            pointer = 1;
            boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
            indication = switches[pointer];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            pointer = 2;
            boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
            indication = switches[pointer];
        }
    }
}

//Referrence Codes 
//Using Scrolling right and left by key E and Q:
//if (Input.GetKeyDown(KeyCode.E))
        //{
        //    pointer += 1; 
        //    if (pointer > 2) { pointer = 0; }
        //    boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
        //    indication = switches[pointer];
        //}
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    pointer -= 1;
        //    if (pointer< 0) { pointer = 2; }
        //    boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
        //    indication = switches[pointer];
        //}