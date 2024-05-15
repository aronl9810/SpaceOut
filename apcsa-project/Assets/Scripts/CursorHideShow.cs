using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHideShow : MonoBehaviour
{
    // Start is called before the first frame update
    bool isLocked = true;
    void Start()
    {
        
    }

    public void SetCursorLock(bool isLocked){
        this.isLocked = isLocked;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isLocked);
        Screen.lockCursor = isLocked;
        Cursor.visible = !isLocked;
        if(Input.GetKeyDown(KeyCode.Escape)){
            SetCursorLock(!isLocked);
        }
    }
}
