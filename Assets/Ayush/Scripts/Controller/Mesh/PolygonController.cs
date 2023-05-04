using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PolygonController : MonoBehaviour
{
    public vsc_geojson_reader reader;
    private List<int> num_val;
    private List<string> str_val;

    private Color blue = new Color(0.01f, 1f, 0.92f, 0.4f);
    private Color orange = new Color(0.82f, 0.43f, 0.08f, 0.4f);

    private MainController mainController;

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

        mainController = GameObject.Find("GameObject").GetComponent<MainController>();

    }

    private Color ChangeColor(string s)   {
        if(s == "PR")   return orange;
        else            return blue;
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
                if(mainController.task1 || mainController.task2) this.gameObject.SetActive(false);
                else                                            this.gameObject.SetActive(true);
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
