using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDown : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D RD;
    public int lifetime;
    void Start()
    {
        Destroy(gameObject, lifetime);
        RD = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0f, -1f, 0.0f);
        RD.velocity = movement * Speed;
    }
}
