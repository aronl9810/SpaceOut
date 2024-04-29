using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewBobbing : MonoBehaviour
{
    // Start is called before the first frame update

    public float EffectIntensity;
    public float EffectIntensityX;
    public float EffectSpeed;

    private float initialEffectIntensity;
    private float initialEffectIntensityX;
    private float initialEffectSpeed; 

    private PositionFollower FollowerInstance;
    private Vector3 OriginalOffset;
    private float SinTime;


    void Start()
    {
        initialEffectIntensity = EffectIntensity;
        initialEffectIntensityX = EffectIntensityX;
        initialEffectSpeed = EffectSpeed;
        FollowerInstance = GetComponent<PositionFollower>();
        OriginalOffset = FollowerInstance.Offset;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Vertical"), 0f, Input.GetAxis("Horizontal"));
        if(inputVector.magnitude > 0f){
            SinTime += Time.deltaTime * EffectSpeed;
        } else {
            SinTime = 0f;
        }

        float sinAmountY = -Mathf.Abs(EffectIntensity * Mathf.Sin(SinTime));
        Vector3 sinAmountX = FollowerInstance.transform.right * EffectIntensity * Mathf.Cos(SinTime) * EffectIntensityX;

        FollowerInstance.Offset = new Vector3 {
            x = OriginalOffset.x,
            y = OriginalOffset.y + sinAmountY,
            z = OriginalOffset.z
        };

        FollowerInstance.Offset += sinAmountX; 
    }

    public void spintEffect(){
        EffectIntensity = initialEffectIntensity * 2;
        EffectIntensityX = initialEffectIntensityX + 1;
        EffectSpeed = initialEffectSpeed * 2;
    }

    public void afterSprintEffect(){
        EffectIntensity = initialEffectIntensity;
        EffectIntensityX = initialEffectIntensityX;
        EffectSpeed = initialEffectSpeed;  
    }
}
