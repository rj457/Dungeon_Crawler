using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq; 

public class playercollider : MonoBehaviour
{
    public List<GameObject> listgameobjects;
    //three heart
    public GameObject heart;
    public GameObject heart1;
    public GameObject heart2;
    private bool damageProtection = false; 
 
    void Start()
    {
        listgameobjects = new List<GameObject>();
        Fillheart(); 
    }
    public void Fillheart()
    {
        listgameobjects.Clear();  
        listgameobjects.Add(heart);
        listgameobjects.Add(heart1);
        listgameobjects.Add(heart2);
    }
    void Killheart()
    {
        listgameobjects.Last().SetActive(false);
        listgameobjects.Remove(listgameobjects.Last());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Allies")
        {
            bool isinfected = collision.gameObject.GetComponent<sheepbehavior>().IsInfected;
            if (isinfected)
            {
                takeDamage();
            }
        }
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
            takeDamage(); 
        }
    }
    void takeDamage()
    {
        if (damageProtection == false)
        {
            damageProtection = true;
            Killheart();
            StartCoroutine(Protection());
        }
    }
    IEnumerator Protection()
    {
        yield return new WaitForSeconds(1.5f);
        damageProtection = false; 
    }
}
