using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTime : MonoBehaviour
{
    public int LifeTime;
    public SpriteRenderer SR;
    private int destorycounts; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
        destorycounts = 0;
    }

    void Update()
    {
        if (destorycounts == 10)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Virus")
        {
            Destroy(collider.gameObject); 
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Allies")
        {
            if (collision.gameObject.GetComponent<wolfBehavior>().IsInfected)
            {
                SR.color = new Color(SR.color.r, SR.color.g - 25.5f/255f, SR.color.b - 25.5f / 255f);
                destorycounts += 1; 
            }
        }
    }
}
