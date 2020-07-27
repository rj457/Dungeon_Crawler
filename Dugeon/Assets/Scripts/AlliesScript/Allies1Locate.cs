using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Allies1Locate : MonoBehaviour
{
    public VectorValue alliesposition; 
    void Start()
    {
        transform.position = alliesposition.allies1;
    }
    void Update()
    {
        alliesposition.allies1 = transform.position; 
    }
}
