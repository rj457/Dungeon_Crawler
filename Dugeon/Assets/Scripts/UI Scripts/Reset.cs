using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shield;
    public recordplayer recordplayer;
    public GameObject allies;
    public GameObject allies1;
    public GameObject winend;
    public GameObject Player; 
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
        resetInventory();
        resetPlayerPosition();
        SceneManager.LoadScene(1);
    }
  
    public void OnQuitButton()
    {
        Application.Quit(); 
    }
    public void OnCloseButton()
    {
        winend.SetActive(false);
    }
    void resetallies()
    {
        allies.SetActive(true);
        allies1.SetActive(true);
        infectionrecord.alliesisfollow = false;
        infectionrecord.allies1isfollow = false;
        infectionrecord.infectedallies = 0;
        infectionrecord.uninfectedallies = 2; 
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
    void resetInventory()
    {
        infectionrecord.rockcounts = 0;
        infectionrecord.maskcounts = 0;
        infectionrecord.stainerizercounts = 0;
        infectionrecord.wallcounts = 0;
        infectionrecord.masktimer = 30f; 
    }
    void resetPlayerPosition()
    {
        Player.transform.position = new Vector3(-1.27f, -1.88f, 0f);
        infectionrecord.initialvalue = new Vector3(-1.27f, -1.88f, 0f);
    }
}
