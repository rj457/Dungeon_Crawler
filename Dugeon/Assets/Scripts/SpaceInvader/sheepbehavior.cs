using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class sheepbehavior : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D; 
    public float speed;
    private int changedirection = -1;
    public float goesright;
    private Vector3 movement;
    public SpriteRenderer SR;
    public bool IsInfected;
    //attack pattern
    //public GameObject virus;
    //public int virusCount;
    //public float startWait;
    //public float spawnWait;
    //public float waveWait;
    //sqawn at random spots 
    //public Transform[] sqawnspot;
    //private int randomspot;
    //Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>(); 
        goesright = Random.Range(0,2)*2-1;
     
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(goesright, 0f, 0f);
        Rigidbody2D.velocity = movement * speed;
        Checkinfection();
        
    }

    void Checkinfection()
    {
        if (SR.color == Color.red)
        {
            IsInfected = true;
            speed = 1.5f;
            //StartAttackpattern();
        }
        else
        {
            IsInfected = false;
            speed = 3f; 
        }
    }
    //void StartAttackpattern()
    //{
    //    waveWait -= 1 * Time.deltaTime;
    //    if (waveWait <= 0)
    //    {
    //        for (int i = 0; i < sqawnspot.Count(); i++)
    //        {
    //            //generatespot();
    //            spawnPosition = sqawnspot[i].position;
    //            Instantiate(virus, spawnPosition, Quaternion.identity);

    //        }
    //        waveWait = spawnWait;
    //    }
    //}
    //void generatespot()
    //{
    //    randomspot = Random.Range(0, sqawnspot.Length); 
    //}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Allies")
        {
            goesright *= changedirection; 
        }
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
            SR.color = Color.red; 
        }
        if (collision.gameObject.tag == "Allies" && IsInfected)
        {
            SpriteRenderer alliessr = collision.gameObject.GetComponent<SpriteRenderer>();
            alliessr.color = Color.red; 
        }
        if (collision.gameObject.tag == "Potion")
        {
            Destroy(collision.gameObject);
            SR.color = Color.white;
        }
    }


}
