using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Crosshair : MonoBehaviour
{
    public Image getImage;
    public byte red,green,blue,transparency;
    // Start is called before the first frame update
    void Start(){
        red = 255;
        green = 255;
        blue = 255;
        transparency = 255;
    }
    void Update(){
        getImage.GetComponent<Image>().color = new Color32(red,green,blue,transparency);
    }

    public void hitEnemy(){
        red = 96;
        green = 153;
        blue = 225;
        Invoke("returnBack", 0.1f);
    }

    private void returnBack(){
        red = 255;
        green = 255;
        blue = 255;
    }
}
