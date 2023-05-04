using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDistance : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     RaycastHit hit;
    //     LayerMask layerMask = LayerMask.GetMask("2D_Terrain");
    //     Vector3 posDown = new Vector3();
    //     Vector3 posForward = new Vector3();

    //     if (Physics.Raycast(transform.position, new Vector3(0, -1, 0), out hit, Mathf.Infinity, layerMask))
    //     {
    //        posDown = hit.point;
    //     }

    //     if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
    //     {
    //        posForward = hit.point;
    //     }

    //     print("Orthographic distance:" + (posForward.z - posDown.z));    
    // }
}
