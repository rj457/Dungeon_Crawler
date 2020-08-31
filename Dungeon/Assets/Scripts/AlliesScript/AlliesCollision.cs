using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;

public class AlliesCollision : MonoBehaviour
{
    //rescure dialog 
    public GameObject rescueDialog;
    public TextMeshProUGUI textpro;
    string firstSentence = "Player:\n I am here to rescue you.";
    string secondSentence = "Player:\n Come to my universe and stay for now. It is safe.";
    bool alliesclicked = false;
    bool safnet = true; 
    
    public bool Isinfected;
    public InventoryObject infectionrecord;
    public DragandDrop cursorcontroller; 
 
    void Update()
    {

        if (alliesclicked && safnet)
        {
            StartCoroutine(dialogStart());
            updateinfection(); 
        }
        
    }
 
    void updateinfection()
    {
        if (Isinfected)
        {
            infectionrecord.infectedallies += 1;
        }
        else
        {
            infectionrecord.uninfectedallies += 1; 
        }
    }
    IEnumerator dialogStart()
    {
        safnet = false; 
        //open dialog
        rescueDialog.SetActive(true);
        textpro.text = firstSentence;
        //wait for author to see what's saying 
        yield return new WaitForSeconds(3f);
        textpro.text = secondSentence;
        yield return new WaitForSeconds(3f);
        rescueDialog.SetActive(false);
        //update following status
        updateSqawn();
        //distroy object 
        gameObject.SetActive(false);

    }
    void updateSqawn()
    {
        if (gameObject.name == "allies")
        {
            infectionrecord.alliesisfollow = true; 
        }
        else if (gameObject.name == "allies(1)")
        {
            infectionrecord.allies1isfollow = true; 
        }
    }
    public void OnMouseEnter()
    {
        cursorcontroller.enablechat();
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
    }
    public void OnMouseDown()
    {
        alliesclicked = true;
        cursorcontroller.enablenormal();
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }
}
