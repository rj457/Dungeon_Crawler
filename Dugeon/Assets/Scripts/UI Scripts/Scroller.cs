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
    //switch conditions 
    public List<int> switches = new List<int> {1,2,3};
    public int indication; 
  
    private int pointer; 
    // Start is called before the first frame update
    void Start()
    {
        //boxselector.transform.parent = canvas.transform;
        maskplace = new Vector3(425f,470f,0f);
        stainerizerplace = new Vector3(574f,470f,0f);
        wallplace = new Vector3(721f,472f,0f);
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
        if (Input.GetKeyDown(KeyCode.E))
        {
            pointer += 1; 
            if (pointer > 2) { pointer = 0; }
            boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
            indication = switches[pointer];
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            pointer -= 1;
            if (pointer < 0) { pointer = 2; }
            boxselector.GetComponent<RectTransform>().anchoredPosition = selectionplaces[pointer];
            indication = switches[pointer];
        }
    }
}
