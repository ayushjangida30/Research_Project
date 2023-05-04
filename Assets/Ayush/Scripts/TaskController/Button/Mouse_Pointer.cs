using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mouse_Pointer : MonoBehaviour
{
    public Image mouse_pointer;
    

    public void UpdatePosition(Vector3 pos) {
        mouse_pointer.transform.position = pos;
    }

    
}
