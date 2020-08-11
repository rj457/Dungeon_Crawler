using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverLeft : MonoBehaviour
{
    public float lifetime;
    private Vector3 movment;
    public Rigidbody2D RD;
    public float speed;
    private float goesleft;
    private float goesdown;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        goesleft = -0.5f;
        goesdown = -0.5f;
       
    }

    // Update is called once per frame
    void Update()
    {
        flyleft();
    }
    void flyleft()
    {
        movment = new Vector3(goesleft, goesdown, 0f);
        RD.velocity = movment * speed; 
    }

    void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Wall")
        {
            trundirection(); 
        }
        if (collision.gameObject.tag == "Ground")
        {
            turnup();
        }
    }
    void trundirection()
    {
        goesleft *= -1;
        //rotate 
        transform.Rotate(0f, 0f, 90f);
    }
    void turnup()
    {
        goesdown *= -1;
        transform.Rotate(0f, 0f, 90f);
    }
}
