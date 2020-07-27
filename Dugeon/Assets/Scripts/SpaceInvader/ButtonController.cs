using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject Drop;
    public countDownTimer timer;
    public GameObject startmenu;
    public TMP_InputField tmp;
    public GameObject Endsresult;
    public bool Onstart=false; 
    //get all the sheep 
    public GameObject Sheep;
    public GameObject sheep1;
    public GameObject sheep2;
    public playercollider playercollider; 
    public battlesystem battlesystem; 
    void startmoving()
    {
        Sheep.GetComponent<sheepbehavior>().speed = 3f;
        sheep1.GetComponent<sheepbehavior>().speed = 3f;
        sheep2.GetComponent<sheepbehavior>().speed = 3f;
    }
    public void stopmoving()
    {
        Sheep.GetComponent<sheepbehavior>().speed = 0f;
        sheep1.GetComponent<sheepbehavior>().speed = 0f;
        sheep2.GetComponent<sheepbehavior>().speed = 0f;
    }
    public void OnStartButton()
    {
        Onstart = true;
        startmenu.SetActive(false);
        timer.startTime = float.Parse(tmp.text);
        Drop.SetActive(true);
        startmoving();
        resetsheep(); 
        timer.Start(); 
    }
    void resetsheep()
    {
        Sheep.GetComponent<SpriteRenderer>().color = Color.white; 
        sheep1.GetComponent<SpriteRenderer>().color = Color.white;
        sheep2.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void OnResetButton()
    {
        Onstart = false; 
        Endsresult.SetActive(false);
        startmenu.SetActive(true);
        battlesystem.infectcount = 0;
        playercollider.Fillheart(); 
    }
}
