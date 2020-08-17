using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class wolfBehavior : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D; 
    public float speed;
    private int changedirection = -1;
    public float goesright;
    private Vector3 movement;
    public SpriteRenderer SR;
    public bool IsInfected;
    //attack pattern
    public GameObject virus;
    public float spawnWait;
    public float waveWait;
    //sqawn at random spots 
    public Transform[] sqawnspot;
    Vector3 spawnPosition;
    public GameObject[] virusprefablist;
    private int treatmentcounts = 0; 
    public TextMeshProUGUI UItimer;
    public bool Isselfmasked;
    private int randomness;
    public InventoryObject inventory;
    public GameObject WarningSign;
    //wait initally 
    public float firstwait; 

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>(); 
        goesright = Random.Range(0,2)*2-1;
        firstwait = 3f;
        //pick random number 
        randomness = Random.Range(0,9);
        if (randomness <= 9-(2*inventory.enemyTag.Count-2) && IsInfected == false)
        {
            StartCoroutine(mutationStart()); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        firstwait -= 1 * Time.deltaTime; 
        if (firstwait <= 0) 
        {
            movement = new Vector3(goesright, 0f, 0f);
            Rigidbody2D.velocity = movement * speed;
            Checkinfection();
        }
    }

    void Checkinfection()
    {
        if (SR.color == Color.red && IsInfected == true)
        {
            speed = 1.5f;
            StartAttackpattern();
        }
        else if (SR.color == Color.white && IsInfected == false)
        {
            speed = 3f; 
        }
        if (treatmentcounts == 3)
        {
            SR.color = Color.white;
            IsInfected = false;
            speed = 3f;
            treatmentcounts = 0; 
        }
    }
    void StartAttackpattern()
    {
        waveWait -= 1 * Time.deltaTime;
        if (waveWait <= 0)
        {
            for (int i = 0; i < sqawnspot.Count(); i++)
            {
                spawnPosition = sqawnspot[i].position;
                Instantiate(virusprefablist[i], spawnPosition, Quaternion.identity);

            }
            waveWait = spawnWait;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Allies")
        {
            goesright *= changedirection; 
        }

        if (collision.gameObject.tag == "Allies" && IsInfected && collision.gameObject.GetComponent<wolfBehavior>().Isselfmasked == false)
        {
            SpriteRenderer alliessr = collision.gameObject.GetComponent<SpriteRenderer>();
            alliessr.color = Color.red;
            collision.gameObject.GetComponent<wolfBehavior>().IsInfected = true;
        }
        if (collision.gameObject.tag == "Wall" && Isselfmasked == false && IsInfected == false)
        {
            if (collision.gameObject.GetComponent<lifeTime>() != null)
            {
                int randomtemp = Random.Range(1, collision.gameObject.GetComponent<lifeTime>().percent);
                if (randomtemp <= 10)
                {
                    SR.color = Color.red;
                    IsInfected = true; 
                }
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Mask")
        {
            Destroy(collider.gameObject);
            SR.color = Color.cyan;
            IsInfected = false; 
            UItimer.enabled = true; 
        }
        if (collider.gameObject.tag == "Virus")
        {
            Destroy(collider.gameObject);
            SR.color = Color.red;
            IsInfected = true;
            //treatmentcounts = 0;
        }
        //if (collider.gameObject.tag == "Potion")
        //{
        //    Destroy(collider.gameObject);
        //    treatmentcounts += 1;
        //    //red become dimmer
        //    SR.color = new Color(255f/255f,SR.color.g + 83.3f/250f, SR.color.b + 83.3f / 250f);
        //}
    }
    
    IEnumerator mutationStart()
    {
        yield return new WaitForSeconds(10f);
        //show sign
        GameObject tempsign = Instantiate(WarningSign, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        //stop speed
        tempsign.transform.parent = gameObject.transform; 
        //turn color and infected state 
        yield return new WaitForSeconds(2f);
        Destroy(tempsign);
        SR.color = Color.red;
        IsInfected = true; 
    }
}
