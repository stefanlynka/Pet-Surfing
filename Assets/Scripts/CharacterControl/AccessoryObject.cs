using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryObject : MonoBehaviour
{
    public float bobDistance = 0.0f;
    public float bobSpeed = 0.0f;
    public Vector3 startingPos = new Vector3();

    void Awake()
    {
        startingPos = transform.localPosition;
    }

    public void SetBobPosition(float heightOffset){
        float newHeight = startingPos.y - heightOffset;
        Vector3 newPos = startingPos;
        newPos.y = newHeight;
        transform.localPosition = newPos;
    }
    public void SetJumpOffset(Vector3 jumpOffset){
        transform.localPosition = startingPos + jumpOffset;
    }
}
