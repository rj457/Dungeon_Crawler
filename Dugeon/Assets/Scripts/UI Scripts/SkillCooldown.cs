using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SkillCooldown : MonoBehaviour
{
    public InventoryObject infectionrecord; 

    // Start is called before the first frame update
    void Start()
    {
        if (infectionrecord.IsskillCooldown)
        {
            gameObject.GetComponent<Image>().fillAmount = infectionrecord.skillfillamount; 
        }
        else
        {
            gameObject.GetComponent<Image>().fillAmount = 0; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (infectionrecord.IsskillCooldown)
        {
            infectionrecord.skillfillamount -= 1 / infectionrecord.skillcooldown * Time.deltaTime;
            gameObject.GetComponent<Image>().fillAmount = infectionrecord.skillfillamount;
            if (infectionrecord.skillfillamount <= 0)
            {
                gameObject.GetComponent<Image>().fillAmount = 0;
                infectionrecord.skillfillamount = 0; 
                infectionrecord.IsskillCooldown = false;
            }
        }
    }
}
