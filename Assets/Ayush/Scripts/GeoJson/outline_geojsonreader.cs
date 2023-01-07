using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OutLine_FeaturePropertiesObject
    {
    public int OBJECTID;
    public string EVC;
    public int VAC_Final;
    public int VC_Final;
    public int VR_Final;
    public int BR_Final;
    public int VSC;
    public int VSC_Final;
    public string VQC;
    }
[System.Serializable]
public class Outline_FeatureObject
    {
        public string type;
        public OutLine_FeaturePropertiesObject properties;
    }
[System.Serializable]
public class OutLine_FeatureCollectionObject
    {
        public string type;
        public string name;
        public List<Outline_FeatureObject> features;
    }

[System.Serializable]
public class outline_geojsonreader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
