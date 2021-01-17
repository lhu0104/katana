using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputImage : MonoBehaviour, IPointerDownHandler
{
    public bool left;
    public void OnPointerDown(PointerEventData e)
    {
        if(left)
        {
            InputManager.Instance.OnInputLeft();
        }
        else
        {
            InputManager.Instance.OnInputRight();
            
        }
    }
}