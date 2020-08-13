using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UItimer : MonoBehaviour
{
    public GameObject infectedsheep;
    public float waittime;
    private float resettime; 
    public GameObject heloprefab;
    private bool ismaskon = false;
    GameObject heloclone;

    void Start()
    {
        resettime = waittime; 
    }

    // Update is called once per frame
    void Update()
    {
        if (infectedsheep.GetComponent<SpriteRenderer>().color == Color.cyan)
        {
            infectedsheep.GetComponent<wolfBehavior>().IsInfected = false;
            infectedsheep.GetComponent<wolfBehavior>().Isselfmasked = true; 
            if (ismaskon == false)
            {
                heloclone = Instantiate(heloprefab, infectedsheep.transform.position, Quaternion.identity);
                heloclone.transform.parent = infectedsheep.transform; 
                ismaskon = true; 
            }
            starttimer();
        }
        else if (infectedsheep.GetComponent<SpriteRenderer>().color == Color.red)
        {
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;

            infectedsheep.GetComponent<wolfBehavior>().Isselfmasked = false;
            infectedsheep.GetComponent<wolfBehavior>().IsInfected = true; 
            if (heloclone != null)
            {
                Destroy(heloclone);
            }
        }
    }
    void starttimer()
    {
        waittime -= 1 * Time.deltaTime;
        gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        gameObject.GetComponent<TextMeshProUGUI>().text = waittime.ToString("0");
        if (waittime <= 0)
        {
            Destroy(heloclone);
            ismaskon = false; 
            gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
            infectedsheep.GetComponent<SpriteRenderer>().color = Color.red;
            waittime = resettime; 
        }
    }
}
