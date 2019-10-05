using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFUITest : MonoBehaviour {

    public void SliderValue(WFSlider slider)
    {
        Debug.Log(slider.value);
    }

    public void DropDownValue(WFDropDown dropDwon) {
        Debug.Log(dropDwon.seletID);
        Debug.Log(dropDwon.texts[dropDwon.seletID] );
    }
}
