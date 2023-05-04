using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PolygonManager : MonoBehaviour

{
    public MainController mainController;
    private Dictionary<int, PolygonController> dict_polygon = new Dictionary<int, PolygonController>();
    private Dictionary<int, int> dict_polygonSelected = new Dictionary<int, int>();

    private int task4_count = 0;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateDict", 1);
    }

    private void CreateDict()   {
        foreach (Transform eachChild in transform) {
            dict_polygon.Add(Int32.Parse(eachChild.name),eachChild.gameObject.GetComponent<PolygonController>());
            dict_polygonSelected.Add(Int32.Parse(eachChild.name), 0);
        }
        // ChangeScale();
    }

    public void SetVisiblePolygons(List<int> list)  {
        foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
            pair.Value.VisiblePolygons(list);
        }
    }

    public void SetSelectedPolygonColor(string id)    {
        if(mainController.task1)    {
            ResetPolygonSelected();
            dict_polygonSelected[Int32.Parse(id)] = 1;
            foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
                pair.Value.SelectedPolygon(dict_polygonSelected[pair.Key]);
            }
        }else if(mainController.task2)    {
            if(task4_count <= 1)    {
                dict_polygonSelected[Int32.Parse(id)] = 1;
                foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
                    pair.Value.SelectedPolygon(dict_polygonSelected[pair.Key]);
                }
                task4_count++;
            }
        print(task4_count);
        }else{
           dict_polygonSelected[Int32.Parse(id)] = 1;
            foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
                pair.Value.SelectedPolygon(dict_polygonSelected[pair.Key]);
            } 
        }
    }

    public void SetDeselectedPolygonColor(string id)  {
        if(mainController.task4)    {
            dict_polygonSelected[Int32.Parse(id)] = 0;
            foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
                pair.Value.SelectedPolygon(dict_polygonSelected[pair.Key]);
            }
            task4_count--;
            print(task4_count);
        }else{
            dict_polygonSelected[Int32.Parse(id)] = 0;
            foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
                pair.Value.SelectedPolygon(dict_polygonSelected[pair.Key]);
            }
        }
    }

    public void ResetPolygonSelected()  {
        for(int i = 1; i <= dict_polygonSelected.Count; i++)  {
            dict_polygonSelected[i] = 0;
        }

        foreach(KeyValuePair<int, PolygonController> pair in dict_polygon)   {
            pair.Value.SelectedPolygon(dict_polygonSelected[pair.Key]);
        }
    }
    

    // barManager.SetVisiblePolygons(totalVisiblePolygonsList);

    // Update is called once per frame
    void Update()
    {
        
    }
}
