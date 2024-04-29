using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionFollower : MonoBehaviour
{

    // Update is called once per frame
    public Transform TargetTransform;
    public Vector3 Offset;

    void Update()
    {
        transform.position = TargetTransform.position + Offset;
    }
}
