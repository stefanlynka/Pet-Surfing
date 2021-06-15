using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    //public DirectionLR direction = DirectionLR.Left;

    public float speed = 0.1f;
    public float windowRange = 20.0f;
    float leftEdge {
        get {
            return transform.localPosition.x - windowRange;
        }
    }
    float rightEdge {
        get {
            return transform.localPosition.x + windowRange;
        }
    }
    protected List<ScrollObject> objects = new List<ScrollObject>();


    // Start is called before the first frame update
    void Start()
    {
        AddChildren();
        
    }
    void AddChildren(){
        
        for(int i =0 ; i < transform.childCount; i++){
            GameObject child = transform.GetChild(i).gameObject;
            if (child.TryGetComponent(out SpriteRenderer childRender)){
                var newObj = new ScrollObject(childRender);
                objects.Add(newObj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach(ScrollObject item in objects){
            if(item.rightPoint < leftEdge){
                RepositionObject(item);
            }
        }
        foreach(ScrollObject item in objects){
            Vector3 oldPos = item.renderer.transform.localPosition;
            item.renderer.transform.localPosition = new Vector3(item.renderer.transform.localPosition.x - speed, oldPos.y, oldPos.z);
        }
    }
    protected virtual void RepositionObject(ScrollObject item){
        Vector3 oldPos = item.renderer.transform.localPosition;
        item.renderer.transform.localPosition = new Vector3(rightEdge+item.radius, oldPos.y, oldPos.z);
    }
    /*
    void OnDrawGizmos(){
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, new Vector3(windowRange, 10,10));
    }
    */
}
public class ScrollObject{
    public SpriteRenderer renderer;
    public float radius {
        get {
            return renderer.bounds.extents.x;
        }
    }
    public float rightPoint {
        get {
            return renderer.transform.localPosition.x + renderer.bounds.extents.x;
        }
    }
    public ScrollObject(SpriteRenderer spriteRenderer){
        renderer = spriteRenderer;
    }
}
public enum DirectionLR {
    Left,
    Right
}
