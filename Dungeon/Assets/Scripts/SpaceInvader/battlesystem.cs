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
    //public countDownTimer timer;
    public GameObject timertext; 
    //public List<bool> sheeplist;
    public GameObject[] sheeps = null;
    private bool Isend = false;
    private int infectionnumber;
    //update shoot inventory 
    public TextMeshProUGUI maskCount;
    public TextMeshProUGUI stainerizerCount;
    public TextMeshProUGUI wallCount;
    //timer and exit button
    public GameObject exitbutton;
    public GameObject timer;
    private List<GameObject> allieslists;

    
    // Start is called before the first frame update
    void Start()
    {
        //checkstartcondition();
        checkiscaught(); 
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
    void checkiscaught()
    {
        if (infectionrecord.isCaught)
        {
            exitbutton.SetActive(false);
            timer.SetActive(true); 
        }
        else
        {
            exitbutton.SetActive(true);
            timer.SetActive(false); 
        }
    }
    void sqawnwolf()
    {
        while (infectionrecord.infectedallies != 0 )
        {
            List<Vector3> sqawnareas = new List<Vector3> {new Vector3(Random.Range(-9.71f,-5.9f),3.91f,10f), new Vector3(Random.Range(-2.18f, 2.12f), 3.91f, 10f),
                new Vector3(Random.Range(5.71f, 9.78f), -5.5f, 10f), new Vector3(Random.Range(-9.71f,-5.9f),-5.5f,10f)};
            int randspots = Random.Range(0, sqawnareas.Count - 1);
            if (sqawnareas[randspots].y == -5.5f)
            {
                GameObject Wolftemp = Instantiate(wolfPrefab, sqawnareas[randspots], Quaternion.Euler(new Vector3(0f, 0f, 180f)));
                GameObject Canvastemp = Wolftemp.transform.Find("Canvas").gameObject; 
                Canvastemp.GetComponent<RectTransform>().Rotate(new Vector3(0f,0f,180f));
            }
            else
            {
                Instantiate(wolfPrefab, sqawnareas[randspots], Quaternion.identity);
            }
            infectionrecord.infectedallies -= 1; 
        }
    }
    void sqawnsheep()
    {
        while (infectionrecord.uninfectedallies != 0)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-11f, 11f), -5.5f, 10f);
            GameObject Wolftemp1 = Instantiate(sheepPrefab, spawnPosition, Quaternion.Euler(new Vector3(0f,0f,180f)));
            GameObject Canvastemp1 = Wolftemp1.transform.Find("Canvas").gameObject;
            Canvastemp1.GetComponent<RectTransform>().Rotate(new Vector3(0f, 0f, 180f));
            infectionrecord.uninfectedallies -= 1; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkhealth();
        updateInventory(); 
        if ((heartcount.listgameobjects.Count == 0 || timer.GetComponent<countDownTimer>().currentTime == 0) && Isend == false)
        {
            infectionrecord.isCaught = false;
            checkmaskcondition(); 
            StartCoroutine(exitencounter());
            Isend = true; 
        }
       
    }
    void updateInventory()
    {
        maskCount.text = infectionrecord.maskcounts.ToString("0");
        stainerizerCount.text = infectionrecord.stainerizercounts.ToString("0");
        wallCount.text = infectionrecord.wallcounts.ToString("0");
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
    }
    public void Onexit()
    {
        checkmaskcondition();
        StartCoroutine(exitencounter()); 
    }
    void checkmaskcondition()
    {
        allieslists = new List<GameObject>(GameObject.FindGameObjectsWithTag("Allies")); 
        foreach (GameObject allies in allieslists)
        {
            if (allies.GetComponent<wolfBehavior>().IsInfected && allies.GetComponent<wolfBehavior>().Isselfmasked == false)
            {
                infectionrecord.Isallalliesmasked = false; 
            }
            else
            {
                infectionrecord.Isallalliesmasked = true; 
            }
        }
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
