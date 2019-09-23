using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class WFButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler,IPointerExitHandler {
    public int id;
    public bool isHighLight, isPress;
    public WFButtonUnityEvent onPointerEnter, onPointerExit, onPointerDown, onPointerUp, onHighLight, onPress;
    public Image image;
    public RectTransform rectT;
    public void Awake()
    {
        rectT = GetComponent<RectTransform>();
        image = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHighLight = true;
        StartCoroutine(HighLightUpdate());
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
        isPress = true;
        StartCoroutine(PressUpdate());
        if (onPointerDown != null)
            onPointerDown.Invoke(this);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
        if (onPointerUp != null)
            onPointerUp.Invoke(this);
    }

    IEnumerator HighLightUpdate() {
        while (isHighLight)
        {
            yield return null;
            if (onHighLight != null)
                onHighLight.Invoke(this);
        }
    }

    IEnumerator PressUpdate() {
        while (isPress)
        {
            yield return null;
            if (onPress != null)
                onPress.Invoke(this);
        }
    }
}

[Serializable]
public class WFButtonUnityEvent : UnityEvent<WFButton> { }
