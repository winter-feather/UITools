using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class WFRightSlider : MonoBehaviour
{
    WFButton handle;
    float sliderLength;

    float handelPos;
    public float value;
    public RectTransform fillBackGround, fillArea;
    public bool wholeNumber;
    private float minValue = 0;
    private float maxValue = 1;
    float distance =1;
    public WFSliderUnityEvent onValueChange;


    private void Awake()
    {
        Handle = GetComponentInChildren<WFButton>();
        sliderLength = fillBackGround.sizeDelta.x;
        Handle.onPress.AddListener(HorzontalDragHandle);
        Handle.onPointerDown.AddListener(RecordMousePos);
    }


    public void RefrushDistance() {
        distance = MaxValue - MinValue;
    }
  

    Vector3 startMousePos;
    void RecordMousePos(WFButton button)
    {
        startMousePos = Input.mousePosition - button.rectT.anchoredPosition3D;
    }

    Vector3 targetPos = Vector3.zero;

    public float MinValue
    {
        get
        {
            return minValue;
        }

        set
        {
            minValue = value;
            RefrushDistance();
        }
    }

    public float MaxValue
    {
        get
        {
            return maxValue;
        }

        set
        {
            maxValue = value;
            RefrushDistance();
        }
    }

    public WFButton Handle
    {
        get
        {
            if (handle == null)
            {
                Handle = GetComponentInChildren<WFButton>();
            }
            return handle;
        }
        set
        {
            handle = value;
        }
    }

    void HorzontalDragHandle(WFButton button)
    {
        targetPos = Input.mousePosition - startMousePos;
        targetPos.x = Mathf.Clamp(targetPos.x, 0, sliderLength);
        targetPos.y = 0;
        SetHandlePos(targetPos.x / sliderLength * distance);
    }

    void SetHandlePos(float pos) {
        handelPos = pos;
        if (wholeNumber)
        {
            handelPos = Mathf.RoundToInt(handelPos);
        }
        targetPos.x = handelPos / distance * sliderLength;
        Handle.rectT.anchoredPosition3D = targetPos;
        Vector2 fillsize = fillArea.sizeDelta;
        fillsize.x = sliderLength * handelPos / distance;
        fillArea.sizeDelta = fillsize;

        value = MinValue + handelPos;

        if (onValueChange!=null)
        {
            onValueChange.Invoke(this);
        }
    }

    public void SetValue(float value)
    {
        if (value>=MinValue && value<=MaxValue)
        {
            SetHandlePos(value - MinValue);
        }
    }
    void VerticalHandle() { }

}

[Serializable]
public class WFSliderUnityEvent:UnityEvent<WFRightSlider> {}