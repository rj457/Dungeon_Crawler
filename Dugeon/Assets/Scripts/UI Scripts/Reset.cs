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
    public GameObject allies;
    public GameObject allies1;
    public GameObject winend;
    
    public InventoryObject infectionrecord;
    //enemy object 
    public List<GameObject> enemylists;

    public void OnResetButton()
    {
        recordplayer.IsShield = false;
        shield.SetActive(true);
        recordplayer.playerhealth = 100;
        recordplayer.IsFollow = false;
        winend.SetActive(false);
       
        resetallies();
        restartenemy();
        clearenemyencounterlist(); 
    }
  
    public void OnQuitButton()
    {
        Application.Quit(); 
    }
    void resetallies()
    {
        allies.SetActive(true);
        allies1.SetActive(true);
        infectionrecord.alliesisfollow = false;
        infectionrecord.allies1isfollow = false;
        infectionrecord.infectedallies = 0;
        infectionrecord.uninfectedallies = 0; 
    }
    void restartenemy()
    {
        foreach (GameObject enemy in enemylists)
        {
            if (enemy.activeSelf == false)
            {
                enemy.SetActive(true); 
            }
        }
    }
    void clearenemyencounterlist()
    {
        infectionrecord.enemyTag.Clear(); 
    }
}
