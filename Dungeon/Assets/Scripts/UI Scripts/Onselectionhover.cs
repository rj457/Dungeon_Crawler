using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onselectionhover : MonoBehaviour
{
    public bool ismouseoverselbox;

    public void OnMouseOver()
    {
        ismouseoverselbox = true; 
    }
    public void OnMouseExit()
    {
        ismouseoverselbox = false;
    }
}
