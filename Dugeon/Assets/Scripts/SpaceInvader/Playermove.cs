using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
//public class Boundary
//{
//    public float xMin, xMax, yMin, yMax;
//}
public class Playermove : MonoBehaviour
{
    public float speed;
    public Rigidbody2D Rigidbody2D;
    //public Boundary boundary;
    //public RectTransform RectTransform; 

    private void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,moveVertical, 0.0f);
        Rigidbody2D.velocity = movement * speed;
        mouseface();
    }
    void mouseface()
    {
        Vector3 MousPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(MousPosition.x - transform.position.x, MousPosition.y - transform.position.y);
        transform.up = direction;
    }
}


