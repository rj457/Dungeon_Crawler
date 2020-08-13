using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeloCollision : MonoBehaviour
{
    private float host;

    void Start()
    {
        host = GetComponentInParent<wolfBehavior>().goesright;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Allies" || collision.gameObject.tag == "Wall")
        {
            host *= -1; 
        }
    }
}
