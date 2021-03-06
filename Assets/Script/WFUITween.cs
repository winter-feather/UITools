﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WinterFeather;

public class WFUITween : SingleManager<WFUITween>
{
    //$----------------------------------------------
    Dictionary<RectTransform, Vector3> moveDic;
    Dictionary<RectTransform, Vector2> sizeDic;
    Dictionary<RectTransform, Quaternion> rotDic;
    Dictionary<Graphic, Color> colorDic;
    //$----------------------------------------------
    List<RectTransform> moveRemoveList;
    List<RectTransform> sizeRemoveList;
    List<RectTransform> rotRemoveList;
    List<Graphic> colorRemoveList;
    private new void Awake()
    {
        base.Awake();
        Init();
    }

    void Init()
    {
        //$----------------------------------------------
        moveDic = new Dictionary<RectTransform, Vector3>();
        sizeDic = new Dictionary<RectTransform, Vector2>();
        rotDic = new Dictionary<RectTransform, Quaternion>();
        colorDic = new Dictionary<Graphic, Color>();
        //$----------------------------------------------
        moveRemoveList = new List<RectTransform>();
        sizeRemoveList = new List<RectTransform>();
        rotRemoveList = new List<RectTransform>();
        colorRemoveList = new List<Graphic>();
    }

    void Update()
    {
        //$----------------------------------------------
        foreach (var item in moveDic)
            MoveUpdate(item.Key, item.Value);
        foreach (var item in sizeDic)
            SizeUpdate(item.Key, item.Value);
        foreach (var item in rotDic)
            RotUpdate(item.Key, item.Value);
        foreach (var item in colorDic)
            ColorUpdate(item.Key, item.Value);
        AllListRemove();
    }


    void MoveUpdate(RectTransform t, Vector3 v)
    {
        if ((t.anchoredPosition3D - v).sqrMagnitude < 0.01f)
        {
            t.anchoredPosition3D = v;
            SignLogoutMove(t);
            return;
        }
        t.anchoredPosition3D = Vector3.Lerp(t.anchoredPosition3D, v, 5 * Time.deltaTime);
    }

    void SizeUpdate(RectTransform t, Vector2 v)
    {
        if ((t.sizeDelta - v).sqrMagnitude < 2f)
        {
            t.sizeDelta = v;
            SignLogoutSize(t);
            return;
        }
        t.sizeDelta = Vector3.Lerp(t.sizeDelta, v, 8 * Time.deltaTime);
    }

    void RotUpdate(RectTransform t, Quaternion q)
    {
        if (Quaternion.Angle(t.rotation,q)<2)
        {
            t.rotation = q;
            SignLogoutRot(t);
            return;
        }
        t.rotation = Quaternion.Lerp(t.rotation, q, 5 * Time.deltaTime);
    }

    void ColorUpdate(Graphic i, Color c) {
        if (Vector4.Distance(i.color,c)<0.01f) 
        {
            i.color = c;
            SignLogoutImageColor(i);
            return;
        }
        i.color = Color.Lerp(i.color, c, 50 * Time.deltaTime);
    }
    //-----------------------------------------------------------------------------
    public void LoginMove(RectTransform t, Vector3 v)
    {
        moveDic[t] = v;
    }
    public void LoginSize(RectTransform t, Vector3 v)
    {
        sizeDic[t] = v;
    }
    public void LoginRot(RectTransform t, Quaternion q)
    {
        rotDic[t] = q;
    }

    public void LoginColor(Graphic i, Color c) {
        colorDic[i] = c;
    }

    //$----------------------------------------------
    public void SignLogoutMove(RectTransform t)
    {
        moveRemoveList.Add(t);
    }
    public void SignLogoutSize(RectTransform t)
    {
        sizeRemoveList.Add(t);
    }
    public void SignLogoutRot(RectTransform t)
    {
        rotRemoveList.Add(t);
    }
    public void SignLogoutImageColor(Graphic i) {
        colorRemoveList.Add(i);
    }
    public void AllListRemove()
    {
        //$----------------------------------------------
        for (int i = 0; i < sizeRemoveList.Count; i++)
        {
            sizeDic.Remove(sizeRemoveList[i]);
        }
        sizeRemoveList.Clear();
        for (int i = 0; i < moveRemoveList.Count; i++)
        {
            moveDic.Remove(moveRemoveList[i]);
        }
        moveRemoveList.Clear();
        for (int i = 0; i < rotRemoveList.Count; i++)
        {
            rotDic.Remove(rotRemoveList[i]);
        }
        rotRemoveList.Clear();
        for (int i = 0; i < colorRemoveList.Count; i++)
        {
            colorDic.Remove(colorRemoveList[i]);
        }
        colorRemoveList.Clear();
    }
}
