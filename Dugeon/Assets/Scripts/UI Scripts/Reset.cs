using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shield;
    public recordplayer recordplayer;
    public AIPath allies;
    public AIPath allies1;
    public VectorValue alliesoriginal;
    public Transform alliesposition;
    public Transform allies1position;
    public GameObject winend;
    public GameObject winend1; 

    public void OnResetButton()
    {
        recordplayer.IsShield = false;
        shield.SetActive(true);
        recordplayer.playerhealth = 100;
        recordplayer.IsFollow = false;
        allies.enabled = false;
        allies1.enabled = false;
        winend.SetActive(false);
        winend1.SetActive(false); 
        resetalliesposition(); 
    }
    void resetalliesposition()
    {
        alliesposition.position = alliesoriginal.alliesinitialvalue;
        allies1position.position = alliesoriginal.allies1initialvalue; 
    }
    public void OnQuitButton()
    {
        Application.Quit(); 
    }
}
