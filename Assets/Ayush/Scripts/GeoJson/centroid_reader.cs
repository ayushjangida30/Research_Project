using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Centroid_FeatureGeometryObject
    {
    public string type;
    public List<float> coordinates;
    }

[System.Serializable]
public class Centroid_FeaturePropertiesObject
    {
    public int OBJECTID;
    }

[System.Serializable]
public class Centroid_FeatureObject
    {
        public string type;
        public Centroid_FeaturePropertiesObject properties;
        public Centroid_FeatureGeometryObject geometry;
    }
[System.Serializable]
public class Centroid_FeatureCollectionObject
    {
        public string type;
        public string name;
        public List<Centroid_FeatureObject> features;
    }


public class centroid_reader : MonoBehaviour
{

    private Dictionary<int, List<float>> centroid_dict = new Dictionary<int, List<float>>();
    
    void Awake()
    {
        var a = Resources.Load<TextAsset>("_VSC_Heatmap_json").text;
        Centroid_FeatureCollectionObject list = JsonUtility.FromJson<Centroid_FeatureCollectionObject>(a);
        List<Centroid_FeatureObject> featureList = list.features;
        for(int i = 0; i < featureList.Count; i++)  {
            Centroid_FeatureObject fo = featureList[i];
            Centroid_FeatureGeometryObject fgo = fo.geometry;
            Centroid_FeaturePropertiesObject fpo = fo.properties;
            
            centroid_dict.Add(fpo.OBJECTID,fgo.coordinates);
        }
    }

    public Dictionary<int, List<float>> GetDict()   {
        return centroid_dict;
    }

    public List<float> GetCoordList(int id) {
        return centroid_dict[id];
    }
}
