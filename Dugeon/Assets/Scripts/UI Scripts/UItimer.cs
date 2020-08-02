using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UItimer : MonoBehaviour
{
    public GameObject infectedsheep;
    public float waittime;
    public GameObject heloprefab;
    private bool ismaskon = false;
    GameObject heloclone; 
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (infectedsheep.GetComponent<SpriteRenderer>().color == Color.cyan)
        {
            if (ismaskon == false)
            {
                heloclone = Instantiate(heloprefab, infectedsheep.transform.position, Quaternion.identity);
                ismaskon = true; 
            }
            starttimer(); 
        }
        else if (infectedsheep.GetComponent<SpriteRenderer>().color == Color.red)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
    void starttimer()
    {
        waittime -= 1 * Time.deltaTime;
        gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        gameObject.GetComponent<TextMeshProUGUI>().text = waittime.ToString("0");
        if (waittime <= 0)
        {
            infectedsheep.GetComponent<SpriteRenderer>().color = Color.white;
            infectedsheep.GetComponent<wolfBehavior>().IsInfected = false;
            Destroy(heloclone);
            ismaskon = false; 
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        }
    }
}
