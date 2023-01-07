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

    private List<int> polygon_visible_list = new List<int>();
    private List<int> polygon_invisible_list = new List<int>();
    
    void Start()
    {
        Invoke("CreateDict", 0.7f);
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

    public void TransformCapsule() {
        foreach(KeyValuePair<string, ViewpointController> pair in viewpoint_dict)   {
            pair.Value.SetTransformCapsule();
        }
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
}
