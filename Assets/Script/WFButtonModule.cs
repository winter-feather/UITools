using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WFButtonModule : MonoBehaviour
{
    public WFButton button;
    public Sprite downSprite, upSprite, pressSprite, enterSprite, exitSprite, highLightSprite;
    public Color downColor, upColor, pressColor, enterColor, exitColor, highLightColor;
    public List<Sprite> customSprite;
    public List<Color> customColor;
    // Use this for initialization

    public void DownSprite() {
        button.image.sprite = downSprite;
    }

    public void UpSprite() {
        button.image.sprite = upSprite;
    }

    public void PressSprite() {
        button.image.sprite = pressSprite;
    }

    public void EnterSprite() {
        button.image.sprite = enterSprite;
    }

    public void ExiteSprite() {
        button.image.sprite = exitSprite;
    }

    public void HighLightSprite()
    {
        button.image.sprite = highLightSprite;
    }
//-------------------------------------------------------
    public void DownColor()
    {
        button.image.color = downColor;
    }

    public void UpColor()
    {
        button.image.color = upColor;
    }

    public void PressColor()
    {
        button.image.color = pressColor;
    }

    public void EnterColor()
    {
        button.image.color = enterColor;
    }

    public void ExiteColor()
    {
        button.image.color = exitColor;
    }

    public void HighLightColor(WFButton e)
    {
        button.image.color = highLightColor;
    }

//-------------------------------------------------------
    public void ShowColor(int id) {
        button.image.color = customColor[id];
    }

    public void ShowSpreite(int id) {
        button.image.sprite = customSprite[id];
    }


}
