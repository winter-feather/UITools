using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFMaskMenu : MonoBehaviour {
    public bool isOn;
    public Vector3 onPos, offPos;
    public Vector2 onSize, offSize;
    Vector3 targetSize, targetPos;
    public WFMaskMenuSta sta;
    public RectTransform mask, content;
    public bool IsOn
    {
        get
        {
            return isOn;
        }

        set
        {
            isOn = value;
            if (sta == WFMaskMenuSta.ContentMove)
            {
                if (isOn)
                    targetPos = onPos;
                else
                    targetPos = offPos;
                WFUITween.Instance.LoginMove(content, targetPos);
            }
            else
            {
                if (isOn)
                    targetSize = onSize;
                else
                    targetSize = offSize;
                WFUITween.Instance.LoginSize(mask, targetSize);

            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            IsOn = true;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            IsOn = false;
        }
    }
}


public enum WFMaskMenuSta {
    MaskScale,
    ContentMove
}