using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestorybyLifeTime : MonoBehaviour
{
    public float lifetime;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
