using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class Reset : MonoBehaviour
{
    // Start is called before the first frame update
    public recordplayer recordplayer;
    public GameObject allies;
    public GameObject allies1;
    public GameObject winend;
    public GameObject Player; 
    public InventoryObject infectionrecord;
    //enemy object 
    public List<GameObject> enemylists;
    public GameObject startintro; 

    public void OnResetButton()
    {
        infectionrecord.IsStartIntroopened = false; 
        recordplayer.IsShield = false;
        recordplayer.playerhealth = 100;
        recordplayer.IsFollow = false;
        winend.SetActive(false);
       
        resetallies();
        restartenemy();
        clearenemyencounterlist();
        resetInventory();
        resetPlayerPosition();
        resetskillcooldown(); 
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
    public void OnCloseIntro()
    {
        startintro.SetActive(false);
        Player.GetComponent<Playermovement>().moveSpeed = 15; 
    }
    void resetallies()
    {
        allies.SetActive(true);
        allies1.SetActive(true);
        infectionrecord.infectedallies = 0;
        infectionrecord.uninfectedallies = 1;
        infectionrecord.alliesTag.Clear(); 
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
        infectionrecord.barrelstag.Clear(); 
    }
    void resetInventory()
    {
        infectionrecord.rockcounts = 0;
        infectionrecord.maskcounts = 0;
        infectionrecord.stainerizercounts = 0;
        infectionrecord.wallcounts = 0;
        infectionrecord.playerhealth = 50; 
        infectionrecord.masktimer = 30f;
    }
    void resetPlayerPosition()
    {
        Player.transform.position = new Vector3(-1.27f, -1.88f, 0f);
        infectionrecord.initialvalue = new Vector3(-1.27f, -1.88f, 0f);
    }
    void resetskillcooldown()
    {
        infectionrecord.skillfillamount = 0;
        infectionrecord.IsskillCooldown = false; 
    }
}
