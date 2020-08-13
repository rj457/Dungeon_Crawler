using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifeTime : MonoBehaviour
{
    public int LifeTime;
    public SpriteRenderer SR;
    public Animator animator; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, LifeTime);
    }

    void Update()
    {
        if (SR.color == Color.red)
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
        if (collider.gameObject.tag == "Potion")
        {
            SR.color = new Color(SR.color.r, SR.color.g + 25.5f / 255f, SR.color.b + 25.5f / 255f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Allies")
        {
            if (collision.gameObject.GetComponent<wolfBehavior>().IsInfected)
            {
                SR.color = new Color(SR.color.r, SR.color.g - 25.5f/255f, SR.color.b - 25.5f / 255f);
            }
        }
    }
}
