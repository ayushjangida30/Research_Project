using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OutlineController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.8f);
        this.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
    }

    public void VisibleOutline(List<int> list) {
        // foreach(int i in list)  {
        //     print("Number: " + i);
        // }
        if(list.Count == 0) {
            this.gameObject.SetActive(true);
            // GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        }else{
            if(list.Contains(Int32.Parse(this.name)))   {
                this.gameObject.SetActive(true);
            // GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
            }else{
                this.gameObject.SetActive(false);
            // GetComponent<Renderer>().material.SetFloat("_Alpha", 0f);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
