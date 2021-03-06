﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public InventoryObject infectionrecord;
    public TextMeshProUGUI timer;
    public float startTime;
    public float currentTime;
    public GameObject lossalliessign;
    public TextMeshProUGUI rockcounts;
    //other three resources counts; 
    public TextMeshProUGUI maskcounts;
    public TextMeshProUGUI stainerizercounts;
    public TextMeshProUGUI wallcounts;
    //guidence sign
    public GameObject timetick;
    public GameObject LostWarning;
    public GameObject warningSolution; 

    //// Start is called before the first frame update
    void Start()
    {
        if (infectionrecord.Isallalliesmasked)
        {
            currentTime = startTime;
        }
        else
        {
            currentTime = infectionrecord.masktimer; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        //constantly check infection balance
        checkinfectionbalance();
        updateinventory(); 
    }
    void updateinventory()
    {
        rockcounts.text = infectionrecord.rockcounts.ToString("0");
        maskcounts.text = infectionrecord.maskcounts.ToString("0");
        stainerizercounts.text = infectionrecord.stainerizercounts.ToString("0");
        wallcounts.text = infectionrecord.wallcounts.ToString("0");
        if (infectionrecord.rockcounts == 0)
        {
            Destroy(GameObject.Find("RockSprite(Clone)")); 
        }
    }
    void checkinfectionbalance()
    {
        if (infectionrecord.infectedallies > 0 && infectionrecord.uninfectedallies > 0)
        {
            //start timer
            timetick.SetActive(true);
            LostWarning.SetActive(true);
            warningSolution.SetActive(true);
            startTimer(); 
        }
        else
        {
            timetick.SetActive(false);
            LostWarning.SetActive(false);
            warningSolution.SetActive(false);
        }
    }
    void startTimer()
    {
        currentTime -= 1 * Time.deltaTime;
        timer.text = currentTime.ToString("0"); 
        if (currentTime <= 0)
        {
            StartCoroutine(showsign()); 
            infectionrecord.uninfectedallies -= 1;
            infectionrecord.infectedallies += 1;
            currentTime = startTime;
        }
    }

    IEnumerator showsign()
    {
        lossalliessign.SetActive(true);
        yield return new WaitForSeconds(3f);
        lossalliessign.SetActive(false); 
    }
}
