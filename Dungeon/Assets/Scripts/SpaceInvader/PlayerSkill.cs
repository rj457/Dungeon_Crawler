using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject ShieldLeft;
    private Vector3 leftcastposition;
    public GameObject ShieldRight;
    private Vector3 rightcastposition;
    public GameObject Walldown;
    private Vector3 downcastposition;
    public GameObject downHeal;
    private Vector3 upcastposition;
    public GameObject maskUP; 
    private float skillcooldownleft = 11;
    private float skillcooldownright = 11;
    private float skillcooldowndown = 11;
    private float skillcooldownHeal = 11;
    private float skillcooldownmask = 11; 

    // Update is called once per frame
    void Update()
    {
        leftcastposition = new Vector3(transform.position.x - 1,transform.position.y,transform.position.z);
        rightcastposition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        downcastposition = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        upcastposition = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z); 
        FireShield();

    }

    void FireShield()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (skillcooldownleft > 10)
            {
                skillcooldownleft = 0; 
                //show up the object
                Instantiate(ShieldLeft, leftcastposition, Quaternion.identity);
                StartCoroutine(skillcountdownleft());
            }
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (skillcooldownright > 10)
            {
                skillcooldownright = 0;
                Instantiate(ShieldRight, rightcastposition, Quaternion.identity);
                StartCoroutine(skillcountdownright());
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (skillcooldowndown > 10)
            {
                skillcooldowndown = 0;
                Instantiate(Walldown, downcastposition, Quaternion.identity);
                StartCoroutine(skillcountdowndown());
            }
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (skillcooldownHeal > 10)
            {
                skillcooldownHeal = 0;
                Instantiate(downHeal, downcastposition, Quaternion.identity);
                StartCoroutine(skillcountdownHeal()); 
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (skillcooldownmask > 10)
            {
                skillcooldownmask = 0;
                Instantiate(maskUP, upcastposition, Quaternion.identity);
                StartCoroutine(skillcountdownmask());
            }
        }
    }

    IEnumerator skillcountdownleft()
    {
        yield return new WaitForSeconds(2);
        skillcooldownleft = 11; 
    }
    IEnumerator skillcountdownright()
    {
        yield return new WaitForSeconds(2);
        skillcooldownright = 11;
    }
    IEnumerator skillcountdowndown()
    {
        yield return new WaitForSeconds(2);
        skillcooldowndown = 11; 
    }
    IEnumerator skillcountdownHeal()
    {
        yield return new WaitForSeconds(2);
        skillcooldownHeal = 11; 
    }
    IEnumerator skillcountdownmask()
    {
        yield return new WaitForSeconds(2);
        skillcooldownmask = 11;
    }
}
