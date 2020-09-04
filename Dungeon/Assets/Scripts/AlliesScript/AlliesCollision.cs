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
    string secondSentence = "Player:\n Stay in my pocket universe for now.";
    string thirdSentence = "Player:\n We’ll all get out of here together.";
    bool alliesclicked = false;
    bool safnet = true; 
    
    public bool Isinfected;
    public InventoryObject infectionrecord;
    public DragandDrop cursorcontroller;

    public Onselectionhover selethover;
    private bool isselecthover;

    void Update()
    {

        if (alliesclicked && safnet)
        {
            StartCoroutine(dialogStart());
            updateinfection();
            addAllyTagtoInventory();
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
    void addAllyTagtoInventory()
    {
        infectionrecord.alliesTag.Add(gameObject.name);
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
        textpro.text = thirdSentence;
        yield return new WaitForSeconds(3f); 
        rescueDialog.SetActive(false);
        //distroy object 
        gameObject.SetActive(false);

    }
    public void OnMouseEnter()
    {
        if (infectionrecord.ismouseonselectbox == false)
        {
            cursorcontroller.enablechat();
        }
        else
        {
            cursorcontroller.enablenormal();
        }
    }
    public void OnMouseExit()
    {
        cursorcontroller.enablenormal();
    }
    public void OnMouseDown()
    {
        if (infectionrecord.ismouseonselectbox == false)
        {
            alliesclicked = true;
            cursorcontroller.enablenormal();
        }
        else
        {
            return; 
        }
       
    }

    public void OnMouseUp()
    {
        cursorcontroller.enablenormal();
    }
}
