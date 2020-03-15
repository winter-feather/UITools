using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class WFToggle : MonoBehaviour,IPointerDownHandler,IPointerUpHandler{
    [SerializeField]
    private bool isOn;
    public Image image;
    public Sprite onSprite, offSprite;
    public UnityEvent onTurnOn, onTurnOff;
    public bool IsOn
    {
        get
        {
            return isOn;
        }

        set
        {
            isOn = value;
            if (isOn)
            {
                SetOn();
            }
            else {
                SetOff();
            }

        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetOn() {
        if (image!=null)
        {
            image.sprite = onSprite;
        }
        if (onTurnOn!=null)
        {
            onTurnOn.Invoke();
        }
    }

    void SetOff() {
        if (image != null)
        {
            image.sprite = offSprite;
        }
        if (onTurnOff!=null)
        {
            onTurnOff.Invoke();
        }
    }   

    public void OnPointerDown(PointerEventData eventData)
    {
        IsOn = !isOn;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

    }
}
