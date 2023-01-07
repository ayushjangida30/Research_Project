using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class Viewpoint_FeatureGeometryObject
    {
    public string type;
    public List<float> coordinates;
    }

[System.Serializable]
public class Viewpoint_FeaturePropertiesObject
    {
    public int OBJECTID;
    }

[System.Serializable]
public class Viewpoint_FeatureObject
    {
        public string type;
        public Viewpoint_FeaturePropertiesObject properties;
        public Viewpoint_FeatureGeometryObject geometry;
    }
[System.Serializable]
public class Viewpoint_FeatureCollectionObject
    {
        public string type;
        public string name;
        public List<Viewpoint_FeatureObject> features;
    }

public class viewpoint_geojson : MonoBehaviour
{
    private Dictionary<int, List<float>> viewpoint_dict = new Dictionary<int, List<float>>();

    void Awake()
    {
        var a = Resources.Load<TextAsset>("sample_viewpoints").text;
        Viewpoint_FeatureCollectionObject list = JsonUtility.FromJson<Viewpoint_FeatureCollectionObject>(a);
        List<Viewpoint_FeatureObject> featureList = list.features;
        for(int i = 0; i < featureList.Count; i++)  {
            Viewpoint_FeatureObject fo = featureList[i];
            Viewpoint_FeatureGeometryObject fgo = fo.geometry;
            Viewpoint_FeaturePropertiesObject fpo = fo.properties;

            viewpoint_dict.Add(i + 1,fgo.coordinates);
        }
    }

    public List<float> GetCoordinates(string name) {
        int id = Int32.Parse(name);
        return viewpoint_dict[id];
    }
}
