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
    //public Action<WFButton> onPointerEnter, onPointerExit, onPointerDown, onPointerUp, onHighLight;
    public UnityEvent onPointerEnter, onPointerExit, onPointerDown, onPointerUp, onHighLight, onPress;
    public Image image;
    public void Start()
    {
        onHighLight.AddListener(() => { Debug.Log("highLight"); });
        onPress.AddListener(() => { Debug.Log("press"); });
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        isHighLight = true;
        StartCoroutine(HighLightUpdate());
        if (onPointerEnter != null)
            onPointerEnter.Invoke();
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isHighLight = false;
        if (onPointerExit != null)
            onPointerExit.Invoke();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPress = true;
        StartCoroutine(PressUpdate());
        if (onPointerDown != null)
            onPointerDown.Invoke();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        isPress = false;
        if (onPointerUp != null)
            onPointerUp.Invoke();
    }

    IEnumerator HighLightUpdate() {
        while (isHighLight)
        {
            yield return null;
            if (onHighLight != null)
                onHighLight.Invoke();
        }
    }

    IEnumerator PressUpdate() {
        while (isPress)
        {
            yield return null;
            if (onPress != null)
                onPress.Invoke();
        }
    }
}
