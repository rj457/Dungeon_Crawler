using System.Collections;
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
    //// Start is called before the first frame update
    void Start()
    {
        currentTime = startTime; 
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
            startTimer(); 
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
