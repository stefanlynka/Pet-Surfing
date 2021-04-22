using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugValueChanger : MonoBehaviour
{
    public DirectionUD direction;
    public static float value = 1.2f;
    public float increment = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// OnMouseDown is called when the user has pressed the mouse button while
    /// over the GUIElement or Collider.
    /// </summary>
    void OnMouseDown()
    {
        if (direction == DirectionUD.Up){
            value += increment;
        }
        else {
            value -= increment;
        }
    }

}

public enum DirectionUD{
    Up,
    Down
}