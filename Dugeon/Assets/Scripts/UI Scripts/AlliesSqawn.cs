using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AlliesSqawn : MonoBehaviour
{
    public InventoryObject infectionrecord;
    public GameObject allies;
    public GameObject allies1;
    public InventoryObject encountername;
    private GameObject enemy; 
    // Start is called before the first frame update
    void Start()
    {
        checkalliessqawn();
        checkenemysqawn(); 
    }

    void checkalliessqawn()
    {
        if (infectionrecord.alliesisfollow)
        {
            allies.SetActive(false);
        }
        else
        {
            allies.SetActive(true);
        }
        if (infectionrecord.allies1isfollow)
        {
            allies1.SetActive(false); 
        }
        else
        {
            allies1.SetActive(true); 
        }
    }

    void checkenemysqawn()
    {
        if (encountername.enemyTag != null)
        {
            foreach (string tag in encountername.enemyTag)
            {
                enemy = GameObject.FindGameObjectWithTag(tag);
                if (enemy != null)
                {
                    enemy.SetActive(false);
                }
            }
        }
        else if (encountername.enemyTag == null)
        {
            return; 
        }
    }

}
