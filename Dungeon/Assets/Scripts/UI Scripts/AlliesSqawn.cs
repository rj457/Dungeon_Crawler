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
    private GameObject barrel; 
    // Start is called before the first frame update
    void Start()
    {
        checkalliessqawn();
        checkenemysqawn();
        checkbarrelsqawn();
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
    void checkbarrelsqawn()
    {
        if (infectionrecord.barrelstag != null)
        {
            foreach (string barreltag in infectionrecord.barrelstag)
            {
                barrel = GameObject.Find(barreltag);
                if (barrel != null)
                {
                    barrel.SetActive(false);
                }
                else
                {
                    return; 
                }
            }
        }
        else if (infectionrecord.barrelstag == null)
        {
            return; 
        }
    }

}
