using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PolygonController : MonoBehaviour
{
    public vsc_geojson_reader reader;
    private List<int> num_val;
    private List<string> str_val;

    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<MeshRenderer>();

        //Mesh mesh = GetComponent<MeshFilter>().mesh;
        //mesh.RecalculateNormals();

        int id = Int32.Parse(this.name);
        num_val = reader.GetNumDict(id);
        str_val = reader.GetStrDict(id);

        GetComponent<Renderer>().material.SetColor("_Color", ChangeColor(str_val[0]));
        GetComponent<Renderer>().material.SetFloat("_Alpha", 0.4f);

    }

    private Color ChangeColor(string s)   {
        if(s == "PR")   return Color.red;
        else            return Color.green;
    }

    public void VisiblePolygons(List<int> list) {
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

    public void SelectedPolygon(int value)  {
        if(value == 1)  {
            this.gameObject.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
        }
        if(value == 0)  {
            this.gameObject.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.4f);
        }
    }
}
