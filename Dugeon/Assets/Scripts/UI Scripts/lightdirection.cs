using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightdirection : MonoBehaviour
{
    public Playermovement player; 

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        if (player.IsDown)
        {
            transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        else if (player.IsUp)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (player.IsRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (player.IsLeft)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
    }
}
