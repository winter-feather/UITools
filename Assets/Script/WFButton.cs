using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WFButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler {
    public int id;
    public bool isHighLight;
    public Action<WFButton> onPointerEnter, onPointerExit, onPointerDown, onPointerUp, onHighLight;
    public Image image;
    public bool isHighLightCheck;

    public void Start()
    {
        if (isHighLightCheck)
        {
            StartCoroutine(HighLightUpdate());
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHighLight = true;
        if (onPointerEnter != null)
            onPointerEnter.Invoke(this);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHighLight = false;
        if (onPointerExit != null)
            onPointerExit.Invoke(this);
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (onPointerDown != null)
            onPointerDown.Invoke(this);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (onPointerUp != null)
            onPointerUp.Invoke(this);
    }

    IEnumerator HighLightUpdate() {
        while (isHighLightCheck)
        {
            yield return null;
            if (onHighLight != null)
                onHighLight.Invoke(this);
        }
    }   
}
