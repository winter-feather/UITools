using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class WFSlider : MonoBehaviour
{
    public RectTransform fillBackGround, fillArea;
    WFButton handle;
    public float minValue = 0;
    public float maxValue = 1;
    public bool wholeNumber;

    float sliderLength;
    float handelPos;
    public float value;
    float distance =1;
    public WFSliderUnityEvent onValueChange;
    public SliderOrientation orientation;


    private void Awake()
    {
        Handle = GetComponentInChildren<WFButton>();
        sliderLength = fillBackGround.sizeDelta.x;
        Handle.onPress.AddListener(DragHandle);
        Handle.onPointerDown.AddListener(RecordMousePos);
        RefrushDistance();
        InitOrientation();

    }

    void InitOrientation() {
        switch (orientation)
        {
            case SliderOrientation.up:
                transform.rotation = Quaternion.Euler(0, 0, 90);
                break;
            case SliderOrientation.down:
                transform.rotation = Quaternion.Euler(0, 0, 270);
                break;
            case SliderOrientation.right:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case SliderOrientation.left:
                transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            default:
                break;
        }

    }

    public void RefrushDistance() {
        distance = MaxValue - MinValue;
    }
  

    Vector3 startOffset;
    void RecordMousePos(WFButton button)
    {
        startOffset = Input.mousePosition - button.rectT.anchoredPosition3D;
    }

    Vector3 totalOffset = Vector3.zero;

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

    void DragHandle(WFButton button)
    {
        totalOffset = Input.mousePosition - startOffset;
        switch (orientation)
        {
            case SliderOrientation.up:
                totalOffset.y = Mathf.Clamp(totalOffset.y, 0, sliderLength);
                totalOffset.x = 0;
                SetHandlePos(totalOffset.y / sliderLength * distance);
                break;
            case SliderOrientation.down:
                totalOffset.y = Mathf.Clamp(totalOffset.y,  -sliderLength,0);
                totalOffset.x = 0;
                SetHandlePos(-totalOffset.y / sliderLength * distance);
                break;
            case SliderOrientation.right:
                totalOffset.x = Mathf.Clamp(totalOffset.x, 0, sliderLength);
                totalOffset.y = 0;
                SetHandlePos(totalOffset.x / sliderLength * distance);
                break;
            case SliderOrientation.left:
                totalOffset.x = Mathf.Clamp(totalOffset.x, -sliderLength, 0);
                totalOffset.y = 0;
                SetHandlePos(-totalOffset.x / sliderLength * distance);
                break;
            default:
                break;
        }

    
    }

    void SetHandlePos(float pos) {


        handelPos = pos;
        if (wholeNumber)
        {
            handelPos = Mathf.RoundToInt(handelPos);
        }
        totalOffset.x = handelPos / distance * sliderLength;
        if (orientation == SliderOrientation.left || orientation == SliderOrientation.right)
        {
           
        }
        else
        {
            totalOffset.y = 0;// handelPos / distance * sliderLength;
        }
        Handle.rectT.anchoredPosition3D = totalOffset;
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

}

public enum SliderOrientation {
    up,down,right,left
}


[Serializable]
public class WFSliderUnityEvent:UnityEvent<WFSlider> {}