using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPathUpdate : MonoBehaviour
{
    public AstarPath pathfinder;
    private float nextActionTime = 0.0f;
    public float period = 1f;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<AstarPath>();
    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime = Time.time + period;
            // execute block of code here
            AstarPath.active.Scan();
        }
    }


}
