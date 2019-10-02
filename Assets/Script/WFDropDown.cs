using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;

public class WFDropDown : MonoBehaviour
{
    public WFMaskMenu mask;
    public WFButton mainButton;
    public Text mainDisplayText;
    RectTransform nodeContainer;

    public GameObject nodeGOPre;
    public float nodeHight;

    public List<string> textsforStart;
    public List<string> texts;
    public bool isOn;
    public int seletID;

    public WFDropDownEvent onSetOn, onSetOff;
    public WFButtonUnityEvent onAddNode;
    public WFDropDownEvent onSetID;

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
    }

    public void SetOff()
    {
        if (onSetOff != null)
        {
            onSetOff.Invoke(this);
        }
    }

    public void SetID(int id)
    {
        seletID = id;
        mainDisplayText.text = texts[seletID];
        OnSetID.Invoke(this);
    }

    public void Init()
    {
        mainButton.onPointerDown.AddListener((a) =>
        {
            IsOn = true;
            mask.IsOn = true;
        });

        WFButton b = mask.gameObject.AddComponent<WFButton>();
        b.onPointerExit = new WFButtonUnityEvent();
        b.onPointerExit.AddListener((a) =>
        {
            IsOn = false;
            mask.IsOn = false;
        });

        float high = mainButton.rectT.sizeDelta.y;
        float width = mainButton.rectT.sizeDelta.x;
        mask.onSize = new Vector2(width, high);
        mask.offSize = new Vector2(width, high);

        nodeContainer = mask.content;
        VerticalLayoutGroup verticalLayoutGroup = nodeContainer.gameObject.AddComponent<VerticalLayoutGroup>();
        verticalLayoutGroup.childForceExpandHeight = false;
        verticalLayoutGroup.childControlHeight = false;

        if (nodeGOPre == null)
        {
            nodeGOPre = mainButton.gameObject;
        }
        nodeHight = nodeGOPre.GetComponent<RectTransform>().sizeDelta.y;

        texts = new List<string>();

        if (textsforStart!=null)
        {
            for (int i = 0; i < textsforStart.Count; i++)
            {
                AddNode(textsforStart[i]);
            }
            SetID(0);
        }
       

        IsOn = false;
        mask.IsOn = false;
        
    }

    void AddNode(string text)
    {
        GameObject node = Instantiate<GameObject>(nodeGOPre, nodeContainer);
        node.GetComponentInChildren<Text>().text = text;
        WFButton button = node.GetComponent<WFButton>();
        button.id = texts.Count;
        texts.Add(text);
        button.onPointerDown.RemoveAllListeners();
        button.onPointerDown.AddListener((a) => { SetID(button.id); });
        mask.onSize.y += nodeHight;
        OnAddNode(button);
    }

    void OnAddNode(WFButton button)
    {
        if (onAddNode != null)
        {
            onAddNode.Invoke(button);
        }
    }

    void Start()
    {
        Init();
    }

}

[Serializable]
public class WFDropDownEvent : UnityEvent<WFDropDown> { }

public class DropDownNode : MonoBehaviour
{

}