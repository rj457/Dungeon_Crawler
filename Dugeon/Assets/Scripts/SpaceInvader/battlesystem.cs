using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class battlesystem : MonoBehaviour
{
    public int infectcount; 
    public playercollider heartcount;
    public GameObject sheep;
    public GameObject sheep1;
    public GameObject sheep2;

    public GameObject Drop;

    public List<bool> sheeplist;
    // Start is called before the first frame update
    void Start()
    {
        infectcount = 0;
    }

    // Update is called once per frame
    void Update()
    { //
        if (heartcount.listgameobjects.Count == 0)
        {
            checkinfectedsheep();
        }
    }
    void checkinfectedsheep()
    {
        sheeplist = new List<bool> { sheep.GetComponent<sheepbehavior>().IsInfected, sheep1.GetComponent<sheepbehavior>().IsInfected, sheep2.GetComponent<sheepbehavior>().IsInfected };
        for (int i = 0; i < sheeplist.Count; i++)
        {
            if (sheeplist[i] == true)
            {
                infectcount += 1; 
            }
        }
    }
}
