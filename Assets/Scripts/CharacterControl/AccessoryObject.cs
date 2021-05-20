using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryObject : MonoBehaviour
{
    public List<PetAccessoryData> petAccessoryData = new List<PetAccessoryData>();
    public float bobDistance = 0.0f;
    public float bobSpeed = 0.0f;
    public Vector3 startingPos = new Vector3();

    void Awake()
    {
        //transform.localScale = GetGlobalScale(transform, globalScale);
    }
    public void Setup(Pet pet){
        foreach(PetAccessoryData petData in petAccessoryData){
            if (petData.pet == pet){
                transform.localScale = petData.localScale;
                transform.localPosition = petData.offset;
                startingPos = petData.offset;
            }
        }
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
    public Vector3 GetGlobalScale(Transform transform, Vector3 globalScale)
    {
        transform.localScale = Vector3.one;
        return new Vector3 (globalScale.x/transform.lossyScale.x, globalScale.y/transform.lossyScale.y, globalScale.z/transform.lossyScale.z);
    }

    [System.Serializable]
    public struct PetAccessoryData{
        public Pet pet;
        public Vector3 offset;
        public Vector3 localScale;
    }
}
