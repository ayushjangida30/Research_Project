using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutlineManager : MonoBehaviour
{

    private Dictionary<int, OutlineController> dict_outline = new Dictionary<int, OutlineController>();

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateDict", 1);
    }

    private void CreateDict()   {
        foreach (Transform eachChild in transform) {
            dict_outline.Add(Int32.Parse(eachChild.name),eachChild.gameObject.GetComponent<OutlineController>());
        }
        // ChangeScale();
    }

    public void SetVisibleOutline(List<int> list)  {
        foreach(KeyValuePair<int, OutlineController> pair in dict_outline)   {
            pair.Value.VisibleOutline(list);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
