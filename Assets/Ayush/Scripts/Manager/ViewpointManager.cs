using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ViewpointManager : MonoBehaviour
{
    public BarManager barManager;

    private Dictionary<string, ViewpointController> viewpoint_dict = new Dictionary<string, ViewpointController>();
    private Dictionary<string, List<int>> visiblePolygons_dict = new Dictionary<string, List<int>>();
    private Dictionary<string, List<int>> invisiblePolygons_dict = new Dictionary<string, List<int>>();
    private Dictionary<string, bool> viewpointSelected_dict = new Dictionary<string, bool>();

    private Dictionary<string, Vector3> dict_pos = new Dictionary<string, Vector3>();
    private Dictionary<string, float> distance_dict = new Dictionary<string, float>();
    private Dictionary<string, float> distance_normal_dict = new Dictionary<string, float>();

    private List<int> polygon_visible_list = new List<int>();
    private List<int> polygon_invisible_list = new List<int>();

    public Camera cam_2d;
    
    void Start()
    {
        Invoke("CreateDict", 0.8f);
    }

    private void CreateDict()   {
        foreach (Transform eachChild in transform) {
            viewpoint_dict.Add(eachChild.name,eachChild.gameObject.GetComponent<ViewpointController>());
            Vector3 pos = eachChild.transform.position;
            Vector3 newPos = SnapTo3DTerrainHeightmap(pos);
            polygon_visible_list = CalculateVisiblePolygons(barManager.GetPolygonPosDict(), newPos);
            polygon_invisible_list = CalculateInvisiblePolygons(barManager.GetPolygonPosDict(), polygon_visible_list);
            visiblePolygons_dict.Add(eachChild.name, polygon_visible_list);
            invisiblePolygons_dict.Add(eachChild.name, polygon_invisible_list);

            Vector3 position = eachChild.transform.position;
            Vector3 newPos_ = SnapTo2DTerrainHeightmap(position);
            dict_pos.Add(eachChild.name, newPos_);
        }

        NormalizeDist();
    }

    private void NormalizeDist()    {
        foreach(KeyValuePair<string, Vector3> viewpoint in dict_pos) {
            float distance = Vector3.Distance(cam_2d.transform.position, viewpoint.Value);
            if(distance_dict.ContainsKey(viewpoint.Key))  {
                // if(polygon.Key == 1033) print("Polygon Key: " + polygon.Key + " Dist: " + distance);
                distance_dict[viewpoint.Key] = distance;
            }else{
                distance_dict.Add(viewpoint.Key, distance);
            }
        }

        float min = float.MaxValue;
        float max = float.MinValue;

        foreach(KeyValuePair<string, float> distance in distance_dict) {
            float d = distance.Value;
            if(d < min) {
                min = d;
            }
            if(d > max) {
                max = d;
            }
        }

        foreach(KeyValuePair<string, float> distance in distance_dict) {
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
        foreach(KeyValuePair<string, Vector3> viewpoint in dict_pos) {
            float distance = Vector3.Distance(camPos, viewpoint.Value);
            if(distance_dict.ContainsKey(viewpoint.Key))  {
                // if(viewpoint.Key == 1033) print("Polygon Key: " + polygon.Key + " Dist: " + distance);
                distance_dict[viewpoint.Key] = distance;
            }else{
                distance_dict.Add(viewpoint.Key, distance);
            }
        }

        float min = float.MaxValue;
        float max = float.MinValue;

        foreach(KeyValuePair<string, float> distance in distance_dict) {
            float d = distance.Value;
            if(d < min) {
                min = d;
            }
            if(d > max) {
                max = d;
            }
        }

        foreach(KeyValuePair<string, float> distance in distance_dict) {
            float normal = (distance.Value - min) / (max - min);
            if(normal == 0) normal = 0.01f;
            if(distance_normal_dict.ContainsKey(distance.Key))  {
                distance_normal_dict[distance.Key] = normal;
            }else{
                distance_normal_dict.Add(distance.Key, normal);
            }
        }

    }

    public void TransformCapsule() {
        // NormalizeDist();
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.SetTransformCapsule(distance_normal_dict);
        }
    }

    public void SetSelectedViewpointColor_Visible(string id)  {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.SelectedViewpoint_Visible(id);
        }
    }

    public void SetSelectedViewpointColor_Invisible(string id)  {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.SelectedViewpoint_Invisible(id);
        }
    }

    public void SetDeselectedViewpointColor(string id)  {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.DeselectedViewpoint(id);
        }
    }

    public Dictionary<string, List<int>> GetVisiblePolygons()    {
        return visiblePolygons_dict;
    }

    public Dictionary<string, List<int>> GetInvisiblePolygons() {
        return invisiblePolygons_dict;
    }

    public Dictionary<string, bool> GetViewPointSelectedDict()  {
        return viewpointSelected_dict;
    }

    private List<int> CalculateVisiblePolygons(Dictionary<int, Vector3> dict, Vector3 viewpointPos)    {
        List<int> list = new List<int>();

        foreach(KeyValuePair<int, Vector3> d in dict)   {
            int id = d.Key;
            Vector3 pos = d.Value;

            float distance = Vector3.Distance(viewpointPos, pos);
            RaycastHit hit;
            LayerMask layerMask = LayerMask.GetMask("3D_Terrain");

            if(Physics.Raycast(viewpointPos, (pos - viewpointPos), out hit, Mathf.Infinity, layerMask)) {
                if(hit.distance >= distance) {
                    list.Add(id);
                    // print("Visible: " + id);
                }
            }
        }

        return list;
    }

    private List<int> CalculateVisiblePolygons(Dictionary<int, Vector3> dict, Vector3 viewpointPos, int barId, string name)    {
        List<int> list = new List<int>();

        foreach(KeyValuePair<int, Vector3> d in dict)   {
            int id = d.Key;
            Vector3 pos = d.Value;

            float distance = Vector3.Distance(viewpointPos, pos);
            RaycastHit hit;
            LayerMask layerMask = LayerMask.GetMask("3D_Terrain");

            if(Physics.Raycast(viewpointPos, (pos - viewpointPos), out hit, Mathf.Infinity, layerMask)) {
                if(hit.distance >= distance) {
                    list.Add(id);
                    // print("Visible: " + id);
                }
            }
        }

        if(!list.Contains(barId))   list.Add(barId);

        return list;
    }

    private List<int> CalculateInvisiblePolygons(Dictionary<int, Vector3> dict, List<int> visibleList)    {
        List<int> list = new List<int>();

        foreach(KeyValuePair<int, Vector3> d in dict)   {
            int id = d.Key;
            if(!visibleList.Contains(id))   {
                list.Add(id);
                // print("Invisible: " + id);
            }
        }

        return list;
    }

    public Vector3 SnapTo3DTerrainHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("3D_Terrain");

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            Vector3 hitPosition = hit.point;
            hitPosition = new Vector3(hitPosition.x, hitPosition.y + 50, hitPosition.z);
            return hitPosition;
        }
        else {
            return Vector3.zero;
        }
    }

    public Vector3 SnapTo2DTerrainHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("2D_Terrain");

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            Vector3 hitPosition = hit.point;
            hitPosition = new Vector3(hitPosition.x, hitPosition.y + 50, hitPosition.z);
            return hitPosition;
        }
        else {
            return Vector3.zero;
        }
    }

    public List<string> GetViewpoints() {
        List<string> list = new List<string>();

        foreach(KeyValuePair<string, ViewpointController> i in viewpoint_dict)  {
            list.Add(i.Key);
        }

        return list;
    } 

    public void DisableSelectedViewpoint(string id) {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.DisableViewpoint(id);
        }
    }

    public void ResetAllViewpoints()    {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.ResetViewpoint();
        }
    }

    public void SetViewpointPos(Vector3 pos, string name)   {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.SelectedViewpoint_Position(pos, name);
            Vector3 p = pair.Value.GetPos();
            Vector3 newPos = SnapTo3DTerrainHeightmap(p);
            polygon_visible_list = CalculateVisiblePolygons(barManager.GetPolygonPosDict(), newPos);
            polygon_invisible_list = CalculateInvisiblePolygons(barManager.GetPolygonPosDict(), polygon_visible_list);

            if(visiblePolygons_dict.ContainsKey(pair.Key)) visiblePolygons_dict[pair.Key] = polygon_visible_list;
            if(invisiblePolygons_dict.ContainsKey(pair.Key))   invisiblePolygons_dict[pair.Key] = polygon_invisible_list;
            

            
        }
    }

    public void DisableAllViewpoints()  {
         foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.DisableViewpoint();
        }
    }
}
