using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFMaskMenu : MonoBehaviour {
    bool isOn;
    public Vector3 onPos, offPos;
    public Vector3 onSize, offSize;
    Vector3 targetSize, targetPos;
    public WFMaskMenuSta sta;
    public RectTransform mask, content;
    public bool isContentMoving;
    public bool isMaskScaling;
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
                if (!isContentMoving)
                {
                    StartCoroutine(ContentMove());
                }
            }
            else
            {
                if (isOn)
                    targetSize = onSize;
                else
                    targetSize = offSize;
                if (!isMaskScaling)
                {
                    StartCoroutine(MaskScale());
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MaskScale() {
        while (true)
        {
            yield return null;
        }
    }

    IEnumerator ContentMove() {
        while (true)
        {
            yield return null;
        }
    }
}


public enum WFMaskMenuSta {
    MaskScale,
    ContentMove
}