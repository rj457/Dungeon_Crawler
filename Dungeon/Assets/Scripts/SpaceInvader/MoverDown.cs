using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverDown : MonoBehaviour
{
    public float Speed;
    public Rigidbody2D RD;
    public int lifetime;

    private Vector3 movementVector = Vector3.zero;
    private GameObject player;
    private Vector2 Direction;
    void Start()
    {
        Destroy(gameObject, lifetime);
        player = GameObject.Find("Player");
        movementVector = (player.GetComponent<shootTowards>().clickedposition - transform.position).normalized * Speed;
        Direction = new Vector2(player.GetComponent<shootTowards>().clickedposition.x - transform.position.x, player.GetComponent<shootTowards>().clickedposition.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime;
        transform.up = Direction;
    }
}
