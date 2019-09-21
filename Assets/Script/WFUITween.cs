using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFUITween : SingleManager<WFUITween> {
    Dictionary<RectTransform, Vector3> moveDic;
    Dictionary<RectTransform, Vector3> scaleDic;
    Dictionary<RectTransform, Quaternion> rotDic;

    private new void Awake()
    {
        base.Awake();
        Init();
    }

    void Init() {
        moveDic = new Dictionary<RectTransform, Vector3>();
        scaleDic = new Dictionary<RectTransform, Vector3>();
        rotDic = new Dictionary<RectTransform, Quaternion>();
    }
   
	
	// Update is called once per frame
	void Update () {
        foreach (var item in moveDic)
            MoveUpdate(item.Key, item.Value);
        foreach (var item in scaleDic)
            ScaleUpdate(item.Key, item.Value);
        foreach (var item in rotDic)
            RotUpdate(item.Key, item.Value);
    }


    void MoveUpdate(RectTransform t, Vector3 v)
    {
        if ((t.transform.position - v).sqrMagnitude < 0.01f)
        {
            t.transform.position = v;
            LogoutMove(t);
            return;
        }
        t.transform.position = Vector3.Lerp(t.transform.position, v, 0.05f);
    }

    void ScaleUpdate(RectTransform t, Vector3 v) {

    }

    void RotUpdate(RectTransform t, Quaternion q) {

    }

    public void LoginMove(RectTransform t, Vector3 v)
    {
        moveDic[t] = v;
    }

    public void LogoutMove(RectTransform t)
    {
        moveDic.Remove(t);
    }

    public void LoginScale(RectTransform t, Vector3 v) {
        scaleDic[t] = v;
    }

    public void LogoutScale(RectTransform t)
    {
        scaleDic.Remove(t);
    }

    public void LoginRot(RectTransform t, Quaternion q) {
        rotDic[t] = q;
    }

    public void LogoutRot(RectTransform t) {
        rotDic.Remove(t);
    }
}
