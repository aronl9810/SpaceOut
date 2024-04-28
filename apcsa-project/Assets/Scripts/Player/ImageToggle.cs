using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Image getImage;

    public void imageOn(){
        getImage.enabled = false;
    }

    public void imageOff(){
        getImage.enabled = true;
    }

}
