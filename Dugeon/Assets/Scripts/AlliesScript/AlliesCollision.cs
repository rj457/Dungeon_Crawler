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
    bool safenet = true; 
    bool istouchPlayer = false;
    public bool Isinfected;
    public InventoryObject infectionrecord;
 
    void Update()
    {

        if (istouchPlayer && Input.GetKeyDown(KeyCode.N) && safenet)
        {
            StartCoroutine(dialogStart());
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            istouchPlayer = true;
            //update infection to object 
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
        safenet = false; 
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
}
