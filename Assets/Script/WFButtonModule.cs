using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WFButtonModule : MonoBehaviour
{
    public Image image;
    public Text text;

    public List<Sprite> sprites;
    public List<Color> colors;
    // Use this for initialization

    public void ChangeSprite(int id) {
        image.sprite = sprites[id];
    }

    public void ChangeColor(int id) {
        image.color = colors[id];
    }

    public void ChangeText(string text) {
       this.text.text = text;
    }

    public void ChangeTextColor(int id) {
        text.color = colors[id];
    }
}
