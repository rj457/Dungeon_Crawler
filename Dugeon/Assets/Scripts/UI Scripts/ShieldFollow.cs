using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldFollow : MonoBehaviour
{
    public Transform followtransform;
    public GameObject player; 

    // Start is called before the first frame update
    void Start()
    {
        followtransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        followtransform.position = player.transform.position;
    }
}
