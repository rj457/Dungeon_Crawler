using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollsion : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
