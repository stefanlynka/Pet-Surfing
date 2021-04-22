using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollerStitched : Scroller
{
    
    protected override void RepositionObject(ScrollObject item){
        Vector3 oldPos = item.renderer.transform.position;
        item.renderer.transform.position = new Vector3(FindRightmostPoint()+item.radius, oldPos.y, oldPos.z);
    }
    
    float FindRightmostPoint(){
        float rightMost = Mathf.NegativeInfinity;
        foreach(ScrollObject item in objects){
            rightMost = Mathf.Max(rightMost, item.rightPoint);
        }
        return rightMost;
    }
}
