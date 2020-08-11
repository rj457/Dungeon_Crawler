using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class battlesystem : MonoBehaviour
{
    //public int infectcount; 
    public playercollider heartcount;
    //decide how many allies to spawn 
    public InventoryObject infectionrecord; 
    //allies prefab     
    public GameObject sheepPrefab;
    public GameObject wolfPrefab; 
    public Animator transition;
    public countDownTimer timer;
    public GameObject timertext; 
    //public List<bool> sheeplist;
    public GameObject[] sheeps = null;
    private bool Isend = false;
    private int infectionnumber;
    
    // Start is called before the first frame update
    void Start()
    {
        checkstartcondition();
        sqawnsheep();
        sqawnwolf();
        sheeps = GameObject.FindGameObjectsWithTag("Allies");
       
    }
    void checkstartcondition()
    {
        if (infectionrecord.infectedallies == 0)
        {
            StartCoroutine(exitearly()); 
        }
    }

    void sqawnwolf()
    {
        while (infectionrecord.infectedallies != 0 )
        {
            List<Vector3> sqawnareas = new List<Vector3> {new Vector3(Random.Range(-9.71f,-5.9f),3.91f,10f), new Vector3(Random.Range(-2.18f, 2.12f), 3.91f, 10f),
                new Vector3(Random.Range(5.71f, 9.78f), 3.91f, 10f)};
            int randspots = Random.Range(0, sqawnareas.Count - 1);
            Instantiate(wolfPrefab, sqawnareas[randspots], Quaternion.identity);
            infectionrecord.infectedallies -= 1; 
        }
    }
    void sqawnsheep()
    {
        while (infectionrecord.uninfectedallies != 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-11f, 11f), -5.5f, 10f);
            Instantiate(sheepPrefab, spawnPosition, Quaternion.Euler(new Vector3(0f,0f,180f)));
            infectionrecord.uninfectedallies -= 1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkhealth(); 
        if ((heartcount.listgameobjects.Count == 0 || timer.currentTime == 0 || (infectionnumber == 0)) && Isend == false)
        {
            StartCoroutine(exitencounter());
            Isend = true; 
        }
       
    }
    void checkhealth()
    {
        infectionnumber = 0; 
        foreach (GameObject sheep in sheeps)
        {
            if (sheep.GetComponent<wolfBehavior>().IsInfected)
            {
                infectionnumber += 1; 
            }
        }
        
    }
    void updateinfectionrecord()
    {
        foreach (GameObject sheep in sheeps)
        {
            if (sheep.GetComponent<wolfBehavior>().IsInfected)
            {
                infectionrecord.infectedallies += 1; 
            }
            else
            {
                infectionrecord.uninfectedallies += 1; 
            }
        }
        //sheeplist = new List<bool> { sheep.GetComponent<sheepbehavior>().IsInfected, sheep1.GetComponent<sheepbehavior>().IsInfected, sheep2.GetComponent<sheepbehavior>().IsInfected };
        //for (int i = 0; i < sheeplist.Count; i++)
        //{
        //    if (sheeplist[i] == true)
        //    {
        //        infectcount += 1;
        //    }
        //}
    }

    IEnumerator exitearly()
    {
        timertext.SetActive(true);
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(1);
    }
    IEnumerator exitencounter()
    {
        transition.SetTrigger("Start");
        updateinfectionrecord();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
