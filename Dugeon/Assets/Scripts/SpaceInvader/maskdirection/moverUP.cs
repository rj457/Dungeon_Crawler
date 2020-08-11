using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverUP : MonoBehaviour
{
    public float lifetime;
    public Rigidbody2D RD;
    public float speed;
    private Vector3 movementVector = Vector3.zero;
    private GameObject player;
    private Vector2 Direction; 
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
        player = GameObject.Find("Player");
        movementVector = (player.GetComponent<shootTowards>().clickedposition - transform.position).normalized * speed; 
        Direction = new Vector2(player.GetComponent<shootTowards>().clickedposition.x - transform.position.x, player.GetComponent<shootTowards>().clickedposition.y - transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += movementVector * Time.deltaTime;
        transform.up = Direction; 
    }

}
