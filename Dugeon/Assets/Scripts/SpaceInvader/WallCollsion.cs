using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollsion : MonoBehaviour
{
    public GameObject Wall;
    private GameObject player;
    private Vector3 spawnposition;

    void Start()
    {
        player = GameObject.Find("Player");
        spawnposition = player.GetComponent<shootTowards>().clickedposition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Walltrigger")
        {
            Instantiate(Wall, spawnposition, Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
        }
    }
}
