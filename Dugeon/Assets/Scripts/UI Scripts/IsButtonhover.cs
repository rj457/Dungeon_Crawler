using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IsButtonhover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool isexitbuttonhover;

    public void OnPointerEnter(PointerEventData eventData)
    {
        isexitbuttonhover = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isexitbuttonhover = false; 
    }
}
