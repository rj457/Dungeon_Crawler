using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickBarrel : MonoBehaviour
{
    public GameObject player;
    public Transform transform;
    public CapsuleCollider2D CC; 

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        CC = GetComponent<CapsuleCollider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("k"))
        {
            transform.parent = null;
            CC.enabled = true; 
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("CollisionStay"); //&& Input.GetKey("j")
        if (collision.gameObject.tag == "Player" && Input.GetKey("j"))
        {
            CC.enabled = false; 
            transform.parent = player.transform; 
        }
    }
}
