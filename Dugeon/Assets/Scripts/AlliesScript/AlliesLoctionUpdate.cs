using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlliesLoctionUpdate : MonoBehaviour
{
    public VectorValue alliesposition;

    void Start()
    {
        transform.position = alliesposition.allies; 
    }

    // Update is called once per frame
    void Update()
    {
        alliesposition.allies = transform.position; 
    }
}
