using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLeftCast : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D RD;
    
    public int lifetime;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        RD = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //fly 
        Vector3 movement = new Vector3(-1f, 0.0f, 0.0f);
        RD.velocity = movement * Speed;
    }


}
