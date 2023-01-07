using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMethods : Singleton<GlobalMethods> {
    public string GetGameObjectPath(GameObject gameObject) {
        string path = "";

        GameObject gameObject_ = gameObject;
        List<string> pathList = new List<string>();

        while(true) {
            pathList.Add(gameObject_.name);

            if(gameObject_.transform.parent != null) {
                gameObject_ = gameObject_.transform.parent.gameObject;
            }
            else {
                break;
            }
        }

        for(int i = 0; i < pathList.Count; i++) {
            path = path + "/" + pathList[pathList.Count - 1];
            pathList.RemoveAt(pathList.Count - 1);
        }

        return path;
    }

    public string GetGameObjectPath(GameObject gameObject, int level) {
        string path = "";

        GameObject gameObject_ = gameObject;
        List<string> pathList = new List<string>();

        while(true) {
            pathList.Add(gameObject_.name);

            if(gameObject_.transform.parent != null) {
                gameObject_ = gameObject_.transform.parent.gameObject;
            }
            else {
                break;
            }
        }

        for(int i = 0; i < level; i++) {
            path = path + "/" + pathList[pathList.Count - 1];
            pathList.RemoveAt(pathList.Count - 1);
        }

        return path;
    }

    public Vector3 SnapToSceneHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity)) {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }

    public Vector3 SnapToTerrainHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("Terrain");

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }

    public int GetMKRFPointSimple(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition.y = -1;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("MKRF");

        int id = -1;

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            id = int.Parse(hit.transform.name);
        }

        return id;
    }

    public int GetMKRFPointComplex(Vector3 position) {
        Transform polygons = GameObject.Find("/MKRF/Polygons").transform;
        Transform colliders = GameObject.Find("/MKRF/Colliders").transform;

        Vector3 referencePosition = position;
        referencePosition.y = -1;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("MKRF");

        List<int> ids = new List<int>();

        foreach(Transform polygon in polygons) {
            int polygonId = int.Parse(polygon.name);

            Renderer renderer = polygon.GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;

            Vector3 boundsCenter = bounds.center;
            Vector3 boundsExtents = bounds.extents;

            boundsCenter.y = 0;
            boundsExtents.y = 5000;

            if(bounds.Contains(position)) {
                foreach(Transform collider in colliders) {
                    int colliderId = int.Parse(collider.name);

                    if(colliderId == polygonId) {
                        collider.gameObject.SetActive(true);
                    }
                    else {
                        collider.gameObject.SetActive(false);
                    }
                }

                if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
                    ids.Add(int.Parse(hit.transform.name));
                }
            }
        }

        int id = -1;

        float minDistance = float.MaxValue;

        foreach(Transform polygon in polygons) {
            int polygonId = int.Parse(polygon.name);

            if(ids.IndexOf(polygonId) == -1) {
                continue;
            }

            Renderer renderer = polygon.GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;

            Vector3 boundsCenter = bounds.center;
            Vector3 boundsExtents = bounds.extents;

            boundsCenter.y = 0;
            boundsExtents.y = 5000;

            float distance = (referencePosition - boundsCenter).magnitude;
            if(distance < minDistance) {
                id = polygonId;
                
                minDistance = distance;
            }
        }

        return id;
    }

    public Dictionary<int, bool> GetVisibilityByKopId(int id) {
        Dictionary<int, bool> dict = new Dictionary<int, bool>();

        foreach(var item in GlobalProperties.Instance.MKRFPositions) {
            int key = (10000 * id) + item.Key;

            dict.Add(item.Key, (GlobalProperties.Instance.Visibility[key] >= 0.1f));
        }

        return dict;
    }

    public Dictionary<int, bool> GetVisibilityByMkrfId(int id) {
        Dictionary<int, bool> dict = new Dictionary<int, bool>();

        foreach(var item in GlobalProperties.Instance.KOPPositions) {
            int key = (10000 * item.Key) + id;

            dict.Add(item.Key, (GlobalProperties.Instance.Visibility[key] >= 0.1f));
        }

        return dict;
    }

    public Dictionary<int, bool> GetEmptyVisibility(bool value) {
        Dictionary<int, bool> dict = new Dictionary<int, bool>();

        foreach(var item in GlobalProperties.Instance.MKRFPositions) {
            dict.Add(item.Key, value);
        }

        return dict;
    }

    public int GetIdAFromKey(int key) {
        return key / 10000;
    }

    public int GetIdBFromKey(int key) {
        return key % 10000;
    }
}
