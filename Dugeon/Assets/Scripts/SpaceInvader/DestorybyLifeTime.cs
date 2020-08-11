using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorybyLifeTime : MonoBehaviour
{
    public float lifetime;
    public Transform[] targetlists;
    private Vector3 target;
    private Transform temp;
    public float speed;
    private Vector3 moveVector = Vector3.zero;
    private Vector3 direction;
    private float rad;
    private float deg; 

    void Start()
    {
        Destroy(gameObject, lifetime);
        
        temp = targetlists[Random.Range(0, targetlists.Length)];
        target = new Vector3(temp.position.x, temp.position.y, temp.position.z);
        moveVector = (target - transform.position).normalized * speed;
        rad = Mathf.Tan((target.x - transform.position.x) / (target.y - transform.position.y));
        deg = Mathf.Rad2Deg * rad;
        transform.Rotate(0f, 0f, deg);
    }

    void Update()
    {
        //start move 
        //transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        transform.position += moveVector * Time.deltaTime;
        //constantly rotating 
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Ground")
        {
            moveVector = (target - transform.position).normalized * 0f; 
        }
    }

}
