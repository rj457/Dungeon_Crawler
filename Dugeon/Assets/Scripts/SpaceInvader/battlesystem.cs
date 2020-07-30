using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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
    public Animator transition;
    public countDownTimer timer; 
    public List<bool> sheeplist;
    public GameObject[] sheeps = null;
    private bool Isend = false; 
    // Start is called before the first frame update
    void Start()
    {
        sqawnsheep(); 
    }

    void sqawnsheep()
    {
        //if (infectionrecord.uninfectedallies > 0)
        //{
        while (infectionrecord.uninfectedallies != 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-11f, 11f), -5.5f, 10f);
            Instantiate(sheepPrefab, spawnPosition, Quaternion.identity);
            infectionrecord.uninfectedallies -= 1; 
        }
        //}
    }

    // Update is called once per frame
    void Update()
    { 
        if ((heartcount.listgameobjects.Count == 0 || timer.currentTime == 0) && Isend == false)
        {
            StartCoroutine(exitencounter());
            Isend = true; 
        }
       
    }
    void updateinfectionrecord()
    {
        sheeps = GameObject.FindGameObjectsWithTag("Allies");
        foreach (GameObject sheep in sheeps)
        {
            if (sheep.GetComponent<sheepbehavior>().IsInfected)
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


    IEnumerator exitencounter()
    {
        transition.SetTrigger("Start");
        updateinfectionrecord();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
