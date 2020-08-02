using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverUP : MonoBehaviour
{
    public float lifetime;
    private Vector3 movement;
    public Rigidbody2D RD;
    public float speed; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(0f, 1f, 0f);
        RD.velocity = speed * movement; 
    }

}
