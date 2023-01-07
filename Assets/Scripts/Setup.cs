using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setup : MonoBehaviour {
    private void Start() {

    }

    private void Update() {

    }

    private void Awake() {
        Screen.SetResolution(1366, 768, true);

        GlobalProperties.Instance.CameraController = Camera.main.gameObject.GetComponent<CameraController>();
        GlobalProperties.Instance.InputController = Camera.main.gameObject.GetComponent<InputController>();
        GlobalProperties.Instance.FilterController = Camera.main.gameObject.GetComponent<FilterController>();

        GameObject kopPositionsObject = Resources.Load("Data/KOP_Position", typeof(GameObject)) as GameObject;

        if(GlobalProperties.Instance.KOPPositions == null) {
            GlobalProperties.Instance.KOPPositions = new Dictionary<int, Vector3>();
        }

        foreach(Transform positionObject in kopPositionsObject.transform) {
            int id = int.Parse(positionObject.name);
            Vector3 position = GlobalMethods.Instance.SnapToTerrainHeightmap(positionObject.position);

            GlobalProperties.Instance.KOPPositions.Add(id, position);
        }

        JL.KOP.FeatureCollectionObject kopFeatureCollectionObject = JsonUtility.FromJson<JL.KOP.FeatureCollectionObject>(Resources.Load<TextAsset>("Data/KOP_FeatureCollection").text);

        if(GlobalProperties.Instance.KOPFeatureProperties == null) {
            GlobalProperties.Instance.KOPFeatureProperties = new Dictionary<int, JL.KOP.FeaturePropertiesObject>();
        }

        foreach(JL.KOP.FeatureObject featureObject in kopFeatureCollectionObject.features) {
            GlobalProperties.Instance.KOPFeatureProperties.Add(featureObject.properties.objectId, featureObject.properties);
        }

        GameObject mkrfPositionsObject = Resources.Load("Data/MKRF_Position", typeof(GameObject)) as GameObject;

        if(GlobalProperties.Instance.MKRFPositions == null) {
            GlobalProperties.Instance.MKRFPositions = new Dictionary<int, Vector3>();
        }

        foreach(Transform positionObject in mkrfPositionsObject.transform) {
            int id = int.Parse(positionObject.name);
            Vector3 position = GlobalMethods.Instance.SnapToTerrainHeightmap(positionObject.position);

            GlobalProperties.Instance.MKRFPositions.Add(id, position);
        }

        JL.MKRF.FeatureCollectionObject mkrfFeatureCollectionObject = JsonUtility.FromJson<JL.MKRF.FeatureCollectionObject>(Resources.Load<TextAsset>("Data/MKRF_FeatureCollection").text);

        if(GlobalProperties.Instance.MKRFFeatureProperties == null) {
            GlobalProperties.Instance.MKRFFeatureProperties = new Dictionary<int, JL.MKRF.FeaturePropertiesObject>();
        }

        foreach(JL.MKRF.FeatureObject featureObject in mkrfFeatureCollectionObject.features) {
            GlobalProperties.Instance.MKRFFeatureProperties.Add(featureObject.properties.objectId, featureObject.properties);
        }

        GlobalProperties.Instance.KOPManager = GameObject.Find("/KOP").GetComponent<JL.KOP.Manager>();

        GlobalProperties.Instance.PolygonManager = GameObject.Find("/MKRF/Polygons").GetComponent<JL.MKRF.Polygon.Manager>();
        GlobalProperties.Instance.LineManager = GameObject.Find("/MKRF/Lines").GetComponent<JL.MKRF.Line.Manager>();

        GlobalProperties.Instance.BarManager = GameObject.Find("/Components/Bars").GetComponent<JL.Component.Bar.Manager>();
        GlobalProperties.Instance.LinkManager = GameObject.Find("/Components/Links").GetComponent<JL.Component.Link.Manager>();

        GlobalProperties.Instance.TooltipController = GameObject.Find("/UI/Tooltips/Tooltip").GetComponent<JL.UI.Tooltip.Controller>();

        Invoke("VisibilityAnalysis", 1f);
    }

    private void VisibilityAnalysis() {
        print("Visibility Analysis Started");

        Transform viewpoints = GameObject.Find("/KOP").transform;
        Transform polygons = GameObject.Find("/MKRF/Polygons").transform;
        Transform colliders = GameObject.Find("/MKRF/Colliders").transform;

        LayerMask layerMask = LayerMask.GetMask("Terrain");

        Dictionary<int, int> totalCount = new Dictionary<int, int>();
        Dictionary<int, int> visibleCount = new Dictionary<int, int>();

        foreach(Transform viewpoint in viewpoints) {
            int viewpointId = int.Parse(viewpoint.name);

            foreach(Transform polygon in polygons) {
                int polygonId = int.Parse(polygon.name);

                int key = (viewpointId * 10000) + polygonId;

                totalCount.Add(key, 0);
                visibleCount.Add(key, 0);
            }
        }

        foreach(Transform collider in colliders) {
            Renderer renderer = collider.GetComponent<Renderer>();

            Vector3 boundsCenter = renderer.bounds.center;
            Vector3 boundsExtents = renderer.bounds.extents;

            Vector3 tempPosition = collider.position;
            tempPosition.y = tempPosition.y - (boundsCenter.y + boundsExtents.y - colliders.position.y);

            collider.position = tempPosition;
        }

        foreach(Transform polygon in polygons) {
            int polygonId = int.Parse(polygon.name);

            Renderer renderer = polygon.GetComponent<Renderer>();
            Bounds bounds = renderer.bounds;

            Vector3 boundsCenter = bounds.center;
            Vector3 boundsExtents = bounds.extents;

            boundsCenter.y = 0;
            boundsExtents.y = 0;

            Vector3 boundsMax = boundsCenter + boundsExtents;
            Vector3 boundsMin = boundsCenter - boundsExtents;

            float boundsLeft = Mathf.Ceil(boundsMin.x);
            float boundsRight = Mathf.Floor(boundsMax.x);
            float boundsBack = Mathf.Ceil(boundsMin.z);
            float boundsForward = Mathf.Floor(boundsMax.z);

            Vector3 tempPosition = polygon.position;
            tempPosition.y = tempPosition.y - boundsCenter.y;

            polygon.position = tempPosition;

            foreach(Transform collider in colliders) {
                int colliderId = int.Parse(collider.name);

                if(colliderId == polygonId) {
                    collider.gameObject.SetActive(true);
                }
                else {
                    collider.gameObject.SetActive(false);
                }
            }

            for(int i = 0; i <= GlobalProperties.Instance.VisibilityAnalysisSampleRate; i++) {
                for(int j = 0; j <= GlobalProperties.Instance.VisibilityAnalysisSampleRate; j++) {
                    float xPosition = boundsLeft + (i * ((boundsRight - boundsLeft) / (GlobalProperties.Instance.VisibilityAnalysisSampleRate - 1)));
                    float zPosition = boundsBack + (j * ((boundsForward - boundsBack) / (GlobalProperties.Instance.VisibilityAnalysisSampleRate - 1)));

                    Vector3 rawPosition = new Vector3(xPosition, 0, zPosition);

                    int id_ = GlobalMethods.Instance.GetMKRFPointSimple(rawPosition);

                    if(id_ == polygonId) {
                        Vector3 processedPosition = GlobalMethods.Instance.SnapToTerrainHeightmap(rawPosition);

                        foreach(Transform viewpoint in viewpoints) {
                            int viewpointId = int.Parse(viewpoint.name);

                            int key = (viewpointId * 10000) + polygonId;

                            Vector3 origin = GlobalProperties.Instance.KOPPositions[viewpointId] + (Vector3.up * GlobalProperties.Instance.ViewerHeight);
                            Vector3 destination = processedPosition;
                            Vector3 direction = destination - origin;

                            RaycastHit hit;

                            if(Physics.Raycast(origin, direction, out hit, Mathf.Infinity, layerMask)) {
                                if(Vector3.Distance(hit.point, destination) < 1f) {
                                    visibleCount[key]++;
                                }
                            }

                            totalCount[key]++;
                        }
                    }
                }
            }
        }

        if(GlobalProperties.Instance.Visibility == null) {
            GlobalProperties.Instance.Visibility = new Dictionary<int, float>();
        }

        foreach(Transform viewpoint in viewpoints) {
            int viewpointId = int.Parse(viewpoint.name);

            foreach(Transform polygon in polygons) {
                int polygonId = int.Parse(polygon.name);

                int key = (viewpointId * 10000) + polygonId;

                if(totalCount[key] == 0) {
                    totalCount[key] = 1;
                }

                GlobalProperties.Instance.Visibility.Add(key, (1.0f * visibleCount[key] / totalCount[key]));
            }
        }

        print("Visibility Analysis Completed");
    }
}
