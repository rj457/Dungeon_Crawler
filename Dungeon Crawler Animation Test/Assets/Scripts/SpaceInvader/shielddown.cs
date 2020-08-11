using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shielddown : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.5f, player.transform.position.z);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Virus")
        {
            Destroy(collision.gameObject);
        }
    }
}
