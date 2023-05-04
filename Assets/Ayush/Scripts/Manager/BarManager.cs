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
    private Dictionary<int, int> dict_barValue = new Dictionary<int, int>();
    private Dictionary<int, float> dict_barPosHeight = new Dictionary<int, float>();
    private List<int> dict_id = new List<int>();
    private Dictionary<int, float> dict_pixel = new Dictionary<int, float>();
    public List<int> highlight = new List<int>();


    private List<int> barVisible_dense = new List<int>();
    private List<int> barVisible_medium = new List<int>();
    private List<int> barVisible_sparse = new List<int>();
    private int dense = 0;
    private int medium = 0;
    private int sparse = 0;

    private int bar_selected_count = 0;
    private int bar_selected_yellow_count = 0;
    private int task4_count = 0;

    public Camera cam_2d;

    private float minDist, maxDist;
    private int minId, maxId;

    private float scale = 0f;

    //private GameObject[] gameObjects;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("CreateDict", 0.5f);
    }

    private void CreateDict()   {
        foreach (Transform eachChild in transform) {
            dict_bar.Add(Int32.Parse(eachChild.name),eachChild.gameObject.GetComponent<BarController>());
            dict_id.Add(Int32.Parse(eachChild.name));
            dict_barSelected.Add(Int32.Parse(eachChild.name), 0);
            dict_barPosHeight.Add(Int32.Parse(eachChild.name), eachChild.gameObject.GetComponent<BarController>().BarPositionHeight());

            Vector3 position = eachChild.transform.position;
            Vector3 newPos = SnapTo2DTerrainHeightmap(position);
            dict_pos.Add(Int32.Parse(eachChild.name), newPos);
        }

        dense = (int) (dict_bar.Count * 0.75);
        medium = (int) (dict_bar.Count * 0.5);
        sparse = (int) (dict_bar.Count * 0.25);

        CreateList(dense, barVisible_dense);
        CreateList(medium, barVisible_medium);
        CreateList(sparse, barVisible_sparse);

        // foreach(KeyValuePair<int, BarController> bar in dict_bar) {
        //     int key = bar.Key;
        //     dict_barValue.Add(key, bar.Value.GetBarValue());
        // }    


        NormalizeDist();
        // ChangeScale();
    }

    private void NormalizeDist()    {

        // foreach(KeyValuePair<int, BarController> bar in dict_bar)   {
        //     int key = bar.Key;

        //     // print("Pixel: " + bar.Value.GetWidth(key) + " Key: " + key);

        //     scale = 20 / bar.Value.GetWidth(key);
        //     bar.Value.SetTransform(scale);

        //     // print("Pixel: " + bar.Value.GetWidth(key) + " Key: " + key + "_");
        // }

        // scale = width_const / width;
        // object.size.x *= scale;

        foreach(KeyValuePair<int, Vector3> polygon in dict_pos) {
            float distance = Vector3.Distance(cam_2d.transform.position, polygon.Value);
            if(distance_dict.ContainsKey(polygon.Key))  {
                if(polygon.Key == 1033) print("Polygon Key: " + polygon.Key + " Dist: " + distance);
                distance_dict[polygon.Key] = distance;
            }else{
                distance_dict.Add(polygon.Key, distance);
            }
        }

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
            if(normal == 0) normal = 0.01f;
            if(distance_normal_dict.ContainsKey(distance.Key))  {
                distance_normal_dict[distance.Key] = normal;
            }else{
                distance_normal_dict.Add(distance.Key, normal);
            }
        }

    }

    private void NormalizeDist(Vector3 camPos)    {

        // foreach(KeyValuePair<int, BarController> bar in dict_bar)   {
        //     int key = bar.Key;

        //     // print("Pixel: " + bar.Value.GetWidth(key) + " Key: " + key);

        //     scale = 1 / bar.Value.GetWidth(key);
        //     bar.Value.SetTransform(scale);

        //     // print("Pixel: " + bar.Value.GetWidth(key) + " Key: " + key + "_");
        // }

        foreach(KeyValuePair<int, Vector3> polygon in dict_pos) {
            float distance = Vector3.Distance(camPos, polygon.Value);
            if(distance_dict.ContainsKey(polygon.Key))  {
                if(polygon.Key == 1033) print("Polygon Key: " + polygon.Key + " Dist: " + distance);
                distance_dict[polygon.Key] = distance;
            }else{
                distance_dict.Add(polygon.Key, distance);
            }
        }

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
            if(normal == 0) normal = 0.01f;
            if(distance_normal_dict.ContainsKey(distance.Key))  {
                distance_normal_dict[distance.Key] = normal;
            }else{
                distance_normal_dict.Add(distance.Key, normal);
            }
        }

    }

    public void TransformCube() {
        NormalizeDist();
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SetTransform(distance_normal_dict);
        }
    }

    public void TransformCube(Vector3 camPosition) {
        NormalizeDist();
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SetTransform(distance_normal_dict);
        }
    }

    public void AdjustCubes(int id, float height)   {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.AdjustCube(id, height);
        }
    }

    public void AdjustCubes(int id, float height, int zero)   {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.AdjustCube(id, height, zero);
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
        if(mainController.task1)    {
            ResetBarSelected();
            dict_barSelected[Int32.Parse(id)] = 1;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key]);
            }
        }else if(mainController.task2)    {
            if(task4_count <= 1)    {
                if(dict_barSelected[Int32.Parse(id)] == 0)  {
                    dict_barSelected[Int32.Parse(id)] = 1;
                    foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                        pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                    }
                    task4_count++;
                }
            }
        
        else if(mainController.complexTask3) {}
        }else if(mainController.complexTask2){
            dict_barSelected[Int32.Parse(id)] = 1;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key], highlight);                         
            }
            bar_selected_count++;
        }else if(mainController.complexTask1)   {
            if(dict_barSelected[Int32.Parse(id)] == 1)  {
                if(bar_selected_yellow_count <= 1)  {
                    dict_barSelected[Int32.Parse(id)] = 2;
                    print("Bar value: " + dict_barSelected[Int32.Parse(id)]);
                    foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                        pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                    }
                    bar_selected_yellow_count++;
                }
            }

            else if(dict_barSelected[Int32.Parse(id)] == 2)  {
                bar_selected_yellow_count--;
                dict_barSelected[Int32.Parse(id)] = 1;
                foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                    pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                }
            }
            else{
                if(bar_selected_count < 5)  {
                    dict_barSelected[Int32.Parse(id)] = 1;
                    foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                        pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                    }
                    bar_selected_count++;
                }
            }
        }
        else{
            if(dict_barSelected[Int32.Parse(id)] == 1)  {
                dict_barSelected[Int32.Parse(id)] = 2;
                print("Bar value: " + dict_barSelected[Int32.Parse(id)]);
                foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                    pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                }
            }
            else if(dict_barSelected[Int32.Parse(id)] == 2)  {
                dict_barSelected[Int32.Parse(id)] = 1;
                foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                    pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                }
            }
            else{
                dict_barSelected[Int32.Parse(id)] = 1;
                foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                    pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                }
            }
        }
    }

    public void SetSelectedBarColor(int id) {
        dict_barSelected[id] = 1;
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SelectedBar(dict_barSelected[pair.Key]);
        }
    }

    public void SetSelectedBarHighlightColor(List<int> highlightList)    {
        highlight = highlightList;

        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            if(highlight.Contains(pair.Key))    pair.Value.SelectedBarHighlight(pair.Key);
        }
    }

    public void SetBarColor(int id) {
        dict_barSelected[id] = 1;
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SelectedBar(dict_barSelected[pair.Key]);
        }
    }

    public void SetDeselectedBarColor(string id)  {
        if(mainController.task2)    {
            if(dict_barSelected[Int32.Parse(id)] == 1)  {
                dict_barSelected[Int32.Parse(id)] = 0;
                foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                    pair.Value.SelectedBar(dict_barSelected[pair.Key]);
                }
                task4_count--;
            }
        }else if(mainController.complexTask2)   {
            if(dict_barSelected[Int32.Parse(id)] == 2)  bar_selected_yellow_count--;
            bar_selected_count--;
            dict_barSelected[Int32.Parse(id)] = 0;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key], highlight);
            }
        }else{
            if(dict_barSelected[Int32.Parse(id)] == 2)  bar_selected_yellow_count--;
            bar_selected_count--;
            dict_barSelected[Int32.Parse(id)] = 0;
            foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
                pair.Value.SelectedBar(dict_barSelected[pair.Key]);
            }
        }
    }

    public void SetVisiblePolygons(List<int> list)  {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            if(mainController.task3_part2 || mainController.task4)  {
                print("BarVisible Sparse contains 503: " + barVisible_sparse.Contains(503));
                pair.Value.VisiblePolygon(list, barVisible_sparse);
            }
            else                            pair.Value.VisiblePolygon(list);
            // pair.Value.VisiblePolygon(list);
        }
    }

    public void SetVisiblePolygonsHeight(int id, float height)  {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.VisiblePolygonHeight(id, height);
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

    public Vector3 SnapTo2DTerrainHeightmap(Vector3 position) {
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

        highlight.Clear();
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

    public List<int> GetBarSelected()   {
        List<int> list = new List<int>();

        foreach(KeyValuePair<int, int> pair in dict_barSelected)    {
            int key = pair.Key;
            int value = pair.Value;

            if(value == 1)  list.Add(key);
        }

        return list;
    }

    public List<int> GetAllBars()   {
        return dict_id;
    }

    public void Blink(int id)   {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.BlinkBar(id);
        }
    }

    public float GetCube2DTerrain3DDict()   {
        return minDist;
    }

    public Dictionary<int, int> GetBarSelectedDict()    {
        return dict_barSelected;
    }

    public int GetBarFinalSeleced() {
        return bar_selected_yellow_count;
    }

    public void ResetAllBars() {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.ResetBars();
        }
        task4_count = 0;
        bar_selected_count = 0;
        bar_selected_yellow_count = 0;
    }

    public Vector3 GetBarPos(int id){
        return dict_pos[id];
    }

    public float GetBarHeight(int id) {
        float height = 0;
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            float h = pair.Value.GetHeight(id);
            if(h != 0)  height = h;
        }

        return height;
    }

    public void SetShader(bool b)   {
        foreach(KeyValuePair<int, BarController> pair in dict_bar)   {
            pair.Value.SetBarShader(b, dict_barSelected[pair.Key]);
        }
    }

    public void CreateList(int size, List<int> list)    {
        int count = 0;
        while(count <= size)    {
            int index = UnityEngine.Random.Range(0, dict_bar.Count - 1);
            if(!list.Contains(dict_id[index])) {
                list.Add(dict_id[index]);
                count++;
            }                      
        }
    }

    public int GetBarSelectedDictCount()   {
        int count = 0;
        foreach(KeyValuePair<int, int> bar in dict_barSelected) {
            if(bar.Value == 1)  count++;
        }

        return count;
    }

    public float GetBarPosHeight(int id)    {
        return dict_barPosHeight[id];
    }

    public void addDictDense(int id)    {
        if(!barVisible_dense.Contains(id))  barVisible_dense.Add(id);
    }

    public void RemoveDictDense(int id) {
        if(barVisible_dense.Contains(id))       barVisible_dense.Remove(id);
    }

    public void addDictMedium(int id)    {
        if(!barVisible_medium.Contains(id))  barVisible_medium.Add(id);
    }

    public void RemoveDictMedium(int id) {
        if(barVisible_medium.Contains(id))       barVisible_medium.Remove(id);
    }

    public void addDictSparse(int id)    {
        if(!barVisible_sparse.Contains(id))  barVisible_sparse.Add(id);
    }

    public void RemoveDictSparse(int id) {
        if(barVisible_sparse.Contains(id))       barVisible_sparse.Remove(id);
    }

    public List<int> GetBarVisibleSparse()  {
        return barVisible_sparse;
    }

    public List<int> GetBarVisibleMedium()  {
        return barVisible_medium;
    }

    public List<int> GetBarVisibleDense()  {
        return barVisible_dense;
    }

    // public int ReturnBarValue(int id)  {
    //     return dict_barValue[id];
    // }
}
