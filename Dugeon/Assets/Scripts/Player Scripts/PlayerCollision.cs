﻿using UnityEngine;
using System.Collections;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.SceneManagement;
using Pathfinding;
using TMPro;

public class PlayerCollision : MonoBehaviour
{
    public GameObject helo;
    public HealthBar healthBar;
    //health
    public int maxHealth = 100;
    public int currentHealth;
    //time
    public float period = 2f;
    //bool logic pravite 
    private bool IsInRangeWithCM = false;
    private bool IsNOTFirstTime = true;
    //get caveman diolog stages; 
    public GameObject firstdialog;
    public GameObject seconddialog;
    //get animator 
    public Animator transition;
    //player location before enter battle
    public VectorValue playerstorage;
    public recordplayer recordplayer; 
    //public recordplayer recordplayer; 
    public Playermovement playermovement;
    public Animator anim;
    public GameObject Shield;
    //grab player battle result
    public BattleResult BattleResult;
    public GameObject winend; // with 
    public GameObject winend1; //without
    //inventory
    private bool Isopen = false;
    public GameObject inventory; 

    //update per fame
    void Update()
    {
        checkCM();
        checkshield();
        //update health in runtime; 
        checkhealth();
        checkinventory();
    }

    void checkinventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Isopen == false)
            {
                inventory.SetActive(true);
                Isopen = true;
            }
            else
            {
                inventory.SetActive(false);
                Isopen = false;
            }
        }
    }
    void checkhealth()
    {
        healthBar.SetHealth(recordplayer.playerhealth);
    }


    //functions calls caveman speaking
    void checkCM()
    {
        if (Input.GetKeyDown(KeyCode.N) && IsInRangeWithCM && IsNOTFirstTime)
        {
            firstdialog.SetActive(false);
            seconddialog.SetActive(true);
            IsNOTFirstTime = false; 
        }
    }

    void checkshield()
    {
        if (recordplayer.IsShield == true)
        {
            helo.SetActive(true);
        }
        else
        {
            helo.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Shield")
        {
            recordplayer.IsShield = true;
            Shield.SetActive(false); 
            helo.SetActive(true);
            
        }

        if (collider.gameObject.tag == "Potion")
        {
            Destroy(collider.gameObject);
            if ((recordplayer.playerhealth += 20) >= 100)
            {
                recordplayer.playerhealth = 100; 
            }
            else
            {
                recordplayer.playerhealth += 20; 
            }
        }

        if (collider.gameObject.tag == "CaveMan")
        {
            IsInRangeWithCM = true;
        }

        if (collider.gameObject.tag == "Enemies")
        {
            playerstorage.Isbattle = true;
            playermovement.moveSpeed = 0;
            anim.enabled = false;
            //which enemy encounter 
            BattleResult.enemyTag = collider.gameObject.transform.parent.tag; 
            //recored last check point
            playerstorage.initialvalue.x = transform.position.x - 1;
            playerstorage.initialvalue.y = transform.position.y;
            playerstorage.initialvalue.z = transform.position.z;
            StartCoroutine(PlayerEngage());
        }

        if(collider.gameObject.tag == "Door")
        {
            if (recordplayer.IsFollow)
            {
                winend.SetActive(true);
                winend1.SetActive(false);
            }
            else
            {
                winend1.SetActive(true);
                winend.SetActive(false); 
            }
        }
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{

    //}

    IEnumerator PlayerEngage()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }
}
