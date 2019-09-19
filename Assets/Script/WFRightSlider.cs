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
    private float minValue;
    private float maxValue;
    float distance =1;
    public WFSliderUnityEvent onValueChange;

    public void SetMinValue(float v) {
        MinValue = v;
        RefrushDistance();
    }

    public void SetMaxValue(float v) {
        MaxValue = v;
        RefrushDistance();
    }
    private void Awake()
    {
        handle = GetComponentInChildren<WFButton>();
        sliderLength = fillBackGround.sizeDelta.x;
        handle.onPress.AddListener(HorzontalDragHandle);
        handle.onPointerDown.AddListener(RecordMousePos);
    }

    void Start()
    {
        SetValue(MinValue);
    }


    public void RefrushDistance() {
        distance = MaxValue - MinValue;
    }
    // Use this for initialization
 

    // Update is called once per frame
    void Update()
    {

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
            targetPos.x = handelPos / distance * sliderLength;
        }
        handle.rectT.anchoredPosition3D = targetPos;
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