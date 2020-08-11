using Pathfinding.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movermiddle : MonoBehaviour
{
    public float lifetime;
    private Vector3 movment;
    public Rigidbody2D RD;
    public float speed;
    private float goesdown;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        goesdown = -0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        flydown();
    }
    void flydown()
    {
        movment = new Vector3(0f, goesdown, 0f);
        RD.velocity = movment * speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            turnup();
        }
    }
    void turnup()
    {
        goesdown *= -1;
    }

}
