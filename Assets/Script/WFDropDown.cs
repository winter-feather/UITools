using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WFDropDown : MonoBehaviour
{
    public WFMaskMenu mask;
    public WFButton mainButton;
    public Text mainDisplayText;
    public Transform nodeContainer;
    public List<string> texts;
    public string defaultText;
    public GameObject nodeGOPre;
    bool isOn;
    public int seletID;
    public WFDropDownEvent onSetOn, onSetOff;
    public WFButtonUnityEvent onAddNode;
    //------------------------------------tempStart
    public Vector2 onSize, offSize;
    public Color onColor, offColor;
    public Color arrowOnColor, arrowOffColor;
    public RectTransform arrow;
    Quaternion onRot, offRot;
    private WFDropDownEvent onSetID;

    //------------------------------------tempEnd

    public bool IsOn
    {
        get
        {
            return isOn;
        }
        set
        {
            isOn = value;
            if (IsOn)
                SetOn();
            else
                SetOff();
        }
    }

    public WFDropDownEvent OnSetID
    {
        get
        {
            if (onSetID == null)
                onSetID = new WFDropDownEvent();
            return onSetID;
        }

        set
        {
            onSetID = value;
        }
    }

    public void SetOn()
    {
        if (onSetOn != null)
        {
            onSetOn.Invoke(this);
        }
        //------------------------------------tempStart
        mainButton.GetComponent<Image>().raycastTarget = false;
        WFUITween.Instance.LoginSize(mask.mask, onSize);
        WFUITween.Instance.LoginRot(arrow, onRot);
        WFUITween.Instance.LoginColor(mask.iamge, onColor);
        WFUITween.Instance.LoginColor(arrow.GetComponent<Image>(), arrowOnColor);
        //------------------------------------tempEnd
    }

    public void SetOff()
    {
        if (onSetOff != null)
        {
            onSetOff.Invoke(this);
        }
        //------------------------------------tempStart
        mainButton.GetComponent<Image>().raycastTarget = true;
        WFUITween.Instance.LoginSize(mask.mask, offSize);
        WFUITween.Instance.LoginRot(arrow, offRot);
        WFUITween.Instance.LoginColor(mask.iamge, offColor);
        WFUITween.Instance.LoginColor(arrow.GetComponent<Image>(), arrowOffColor);
        //------------------------------------tempEnd
    }


    public void SetID(int id) {
        seletID = id;
        mainDisplayText.text = texts[seletID];
        OnSetID.Invoke(this);
        NewUIManager.instance.RefreshCharcterIcon();
    }

    public void Init()
    {
        mainButton.onPointerDown.AddListener((a) => { IsOn = true; });
        WFButton b = mask.gameObject.AddComponent<WFButton>();
        b.onPointerExit = new WFButtonUnityEvent();
        b.onPointerExit.AddListener((a) => { IsOn = false; });

        onSize.y = offSize.y + 5; 
        for (int i = 0; i < texts.Count; i++)
        {
            AddNode(texts[i],i);
        }

        //------------------------------------tempStart
        onRot = Quaternion.Euler(0, 0, 180);
        offRot = Quaternion.identity;
        onColor = Color.white;
        offColor = new Color(1, 1, 1, 0);
        //------------------------------------tempEnd
        SetOff();
    }
    void AddNode(string text,int id) {
      GameObject node = Instantiate<GameObject>(nodeGOPre, nodeContainer);
      node.GetComponentInChildren<Text>().text = text;
      //TODO:use nodeHigh instead 30
      onSize.y += 30;
      WFButton button = node.GetComponent<WFButton>();
      button.id = id;
      OnAddNode(button);
    }

    void OnAddNode(WFButton button) {
        //------------------------------------tempStart
        button.onPointerEnter.AddListener((a) => { WFUITween.Instance.LoginColor(button.GetComponentInChildren<Text>(), new Color(0.5f, 1f,1f, 1)); });
        button.onPointerExit.AddListener((a) => { WFUITween.Instance.LoginColor(button.GetComponentInChildren<Text>(), new Color(1,1, 1, 1)); });
        button.onPointerDown.AddListener((a) => SetID(a.id));
        //------------------------------------tempEnd
        if (onAddNode!=null)
        {
            onAddNode.Invoke(button);
        }
    }

    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class WFDropDownEvent : UnityEvent<WFDropDown> { }

public class DropDownNode : MonoBehaviour {

}