using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class WFHighLighter : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler {
    bool isHightlight;
    public Image image;
    //public Color highlightColor, normalColor;
    public UnityEvent onHighLightOn, onHighLightOff;
    public WFHightLightEvent onHighLighting;

    public bool IsHightlight
    {
        get
        {
            return isHightlight;
        }

        set
        {
            isHightlight = value;
            if (isHightlight)
            {
                OnHightlightOn();

            }
            else
            {
                OnHightlightOff();
            }
        }
    }

    public void OnHightlightOn() {

        //if (image!=null)
        //{
        //    image.color = highlightColor;
        //}
        if (onHighLightOn != null)
        {
            onHighLightOn.Invoke();
        }
    }

    public void OnHightlightOff() {
        //if (image != null)
        //{
        //    image.color = normalColor;
        //}
        if (onHighLightOff != null)
        {
            onHighLightOff.Invoke();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        IsHightlight = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        IsHightlight = false;
    }


    IEnumerator HighLightUpdate()
    {
        while (isHightlight)
        {
            yield return null;
            if (onHighLighting != null)
                onHighLighting.Invoke(this);
        }
    }
   
}
