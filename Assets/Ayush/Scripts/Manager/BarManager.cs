using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BarManager : MonoBehaviour
{
    public BarController barController;
    public MainController mainController;
    private Dictionary<int, BarController> dict_bar = new Dictionary<int, BarController>();
    private Dictionary<int, Vector3> dict_pos = new Dictionary<int, Vector3>();
    private Dictionary<int, float> distance_dict = new Dictionary<int, float>();
    private Dictionary<int, float> distance_normal_dict = new Dictionary<int, float>();
    private Dictionary<int, int> dict_barSelected = new Dictionary<int, int>();
    private int task4_count = 0;

    public Camera cam_2d;

    private float minDist, maxDist;
    private int minId, maxId;

    //private GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateDict", 0.5f);
    }

    private void CreateDict()   {
        foreach (Transform eachChild in transform) {
            dict_bar.Add(Int32.Parse(eachChild.name),eachChild.gameObject.GetComponent<BarController>());
            dict_barSelected.Add(Int32.Parse(eachChild.name), 0);

            Vector3 position = eachChild.transform.position;
            Vector3 newPos = SnapTo3DTerrainHeightmap(position);
            dict_pos.Add(Int32.Parse(eachChild.name), newPos);
        }

        foreach(KeyValuePair<int, Vector3> polygon in dict_pos) {
            float distance = Vector3.Distance(cam_2d.transform.position, polygon.Value);
            distance_dict.Add(polygon.Key, distance);
        }


        NormalizeDist();
        // ChangeScale();
    }

    private void NormalizeDist()    {

        float min = float.MaxValue;
        float max = float.MinValue;

        foreach(KeyValuePair<int, float> distance in distance_dict) {
            float d = distance.Value;
            if(d < min) {
                min = d;
            }
            if(d > max) {
                max = d;
            }
        }

        foreach(KeyValuePair<int, float> distance in distance_dict) {
            float normal = (distance.Value - min) / (max - min);
            if(distance_normal_dict.ContainsKey(distance.Key))  {
                distance_normal_dict[distance.Key] = normal + 0.01f;
            }else{
                distance_normal_dict.Add(distance.Key, normal + 0.01f);
            }
        }

    }

    public void TransformCube() {
        NormalizeDist();
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SetTransform(distance_normal_dict);
        }
    }


    public void MakeBarInvisible()  {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.BarInvisible();
        }
    }

    public Dictionary<int, Vector3> GetPolygonPosDict() {
        return dict_pos;
    }

    public void SetSelectedBarColor(string id)  {
        if(mainController.task2)    {
            ResetBarSelected();
            dict_barSelected[Int32.Parse(id)] = 1;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key]);
            }
        }else if(mainController.task4)    {
            if(task4_count <= 1)    {
                dict_barSelected[Int32.Parse(id)] = 1;
                foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                    pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                }
                task4_count++;
            }
        }else{
            dict_barSelected[Int32.Parse(id)] = 1;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key]);
            }
        }
    }

    public void SetBarColor(int id) {
        dict_barSelected[id] = 1;
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SelectedBar(dict_barSelected[pair.Key]);
        }
    }

    public void SetDeselectedBarColor(string id)  {
        if(mainController.task4)    {
            dict_barSelected[Int32.Parse(id)] = 0;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key]);
            }
            task4_count--;
        }else{
            dict_barSelected[Int32.Parse(id)] = 0;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key]);
            }
        }
    }

    public void SetVisiblePolygons(List<int> list)  {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.VisiblePolygon(list);
        }
    }

    public Dictionary<int, BarController> GetDict() {
        return dict_bar;
    }

    public Vector3 SnapTo3DTerrainHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("3D_Terrain");

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }

    public void ResetBarSelected()  {
        for(int i = 0; i < dict_barSelected.Count; i++) {
            dict_barSelected[i] = 0;
        }
        
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SelectedBar(dict_barSelected[pair.Key]);
        }
    }

    public List<int> GetBarSelected_Task1() {
        // int res = 0;
        // foreach(KeyValuePair<int, int> pair in dict_barSelected)    {
        //     int key = pair.Key;
        //     int value = pair.Value;

        //     if(value == 1)  res = key;
        // }

        // return res;
        List<int> res = new List<int>();
        foreach(KeyValuePair<int, int> pair in dict_barSelected)    {
            int key = pair.Key;
            int value = pair.Value;

            if(value == 1)  res.Add(key);
        }

        return res;
    }

    public int GetBarSelected_Task2()   {
        foreach(KeyValuePair<int, int> pair in dict_barSelected)    {
            int key = pair.Key;
            int value = pair.Value;

            if(value == 1)  return key;
        }
         return 0;
    }

    public void Blink(int id)   {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.BlinkBar(id);
        }
    }

    public float GetCube2DTerrain3DDict()   {
        return minDist;
    }
}
