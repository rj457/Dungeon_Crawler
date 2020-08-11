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
        //RectTransform = GetComponent<RectTransform>(); 
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,moveVertical, 0.0f);
        Rigidbody2D.velocity = movement * speed;

        //Rigidbody2D.position = new Vector3
        //(
        //    Mathf.Clamp(Rigidbody2D.position.x, boundary.xMin, boundary.xMax),
        //    Mathf.Clamp(Rigidbody2D.position.y, boundary.yMin, boundary.yMax),
        //    0.0f
        //);
        //Vector3 pos = RectTransform.position;
        //pos.x = Mathf.Clamp(pos.x,boundary.xMin,boundary.xMax);
        //pos.y = Mathf.Clamp(pos.y, boundary.yMin, boundary.yMax);
        //RectTransform.position = pos; 
    }
}


