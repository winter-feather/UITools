using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WFButtonModule : MonoBehaviour
{
    public WFButton button;
    public Sprite downSprite, upSprite, pressSprite, enterSprite, exitSprite, highLightSprite;
    public Color downColor, upColor, pressColor, enterColor, exitColor, highLightColor;
    // Use this for initialization

    public void Down() {
        button.image.sprite = downSprite;
    }

    
}
