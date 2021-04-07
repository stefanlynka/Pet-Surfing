using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public float petHeight = 0.0f;
    public BoxCollider2D myCollider;


    // Start is called before the first frame update
    void Start()
    {
        petHeight = myCollider.size.y * transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetBottomPos(){
        return transform.position.y - petHeight/2;
    }
    public void SetHeightFromBottom(float bottomHeight){
        transform.position = new Vector3(transform.position.x, bottomHeight+petHeight/2, transform.position.z);
    }
}
