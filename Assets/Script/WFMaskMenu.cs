using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WFMaskMenu : MonoBehaviour {
    bool isOn;
    public bool isMaskScale, isContentMove;
    public Vector3 onPos, offPos;
    public Vector2 onSize, offSize;
    Vector3 targetSize, targetPos;
    public RectTransform mask, content;
    public Image iamge;
    public bool IsOn
    {
        get
        {
            return isOn;
        }

        set
        {
            isOn = value;

            if (isContentMove)
            {
                if (isOn)
                    targetPos = onPos;
                else
                    targetPos = offPos;
                WFUITween.Instance.LoginMove(content, targetPos);
            }
            if (isMaskScale)
            {
                if (isOn)
                    targetSize = onSize;
                else
                    targetSize = offSize;
                WFUITween.Instance.LoginSize(mask, targetSize);
            }
        }
    }

    private void Awake()
    {
       // iamge = GetComponent<Image>();
    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
   
}


