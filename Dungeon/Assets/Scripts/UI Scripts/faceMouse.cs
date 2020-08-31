using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceMouse : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        mouseface();
    }
    void mouseface()
    {
        Vector3 MousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(MousPosition.x - transform.position.x, MousPosition.y - transform.position.y);
        transform.up = direction; 
    }
}
