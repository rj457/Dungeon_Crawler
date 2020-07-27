﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollision : MonoBehaviour
{


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Allies")
        {
            Destroy(collision.gameObject);
        }
    }
}
