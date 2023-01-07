using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FeaturePropertiesObject
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
public class FeatureObject
    {
        public string type;
        public FeaturePropertiesObject properties;
    }
[System.Serializable]
public class FeatureCollectionObject
    {
        public string type;
        public string name;
        public List<FeatureObject> features;
    }

[System.Serializable]
public class vsc_geojson_reader : MonoBehaviour
{
    private Dictionary<int, List<int>> dictionary_num = new Dictionary<int, List<int>>();
    private Dictionary<int, List<string>> dictionary_string = new Dictionary<int, List<string>>();

    private Dictionary<int, List<float>> dict = new Dictionary<int, List<float>>();

    public centroid_reader cr;


    // Start is called before the first frame update
    void Awake()
    {
        var a = Resources.Load<TextAsset>("VSC_Heatmap_text").text;
        FeatureCollectionObject list = JsonUtility.FromJson<FeatureCollectionObject>(a);
        List<FeatureObject> featureList = list.features;
        for(int i = 0; i < featureList.Count; i++)  {
            FeatureObject fo = featureList[i];
            FeaturePropertiesObject fpo = fo.properties;
            List<int> elements = new List<int>();
            List<string> str_list = new List<string>();

            elements.Add(fpo.VAC_Final);
            elements.Add(fpo.VC_Final);
            elements.Add(fpo.VR_Final);
            elements.Add(fpo.BR_Final);
            elements.Add(fpo.VSC);
            elements.Add(fpo.VSC_Final);

            str_list.Add(fpo.VQC);
            str_list.Add(fpo.EVC);

            dictionary_num.Add(fpo.OBJECTID, elements);
            dictionary_string.Add(fpo.OBJECTID, str_list);
        }
        
    }

    void Start()    {
        GameObject mkrfPositionsObject = Resources.Load("Data/MKRF_Position", typeof(GameObject)) as GameObject;

        // foreach(Transform positionObject in mkrfPositionsObject.transform) {
        //     int id = int.Parse(positionObject.name);
        //     Vector3 position = SnapToTerrainHeightmap(positionObject.position);

        //     dict.Add(id, position);
        // }

        // dict = cr.GetDict();
        // List<Vector3> vector3_list = new List<Vector3>();
        // for(int i = 1; i <= dict.Count; i++) {
        //     List<float> l = dict[i];
        //     Vector3 coord = new Vector3(l[0], l[1], 0);
        //     vector3_list.Add(coord);
        // }

        // for(int i = 0; i < vector3_list.Count; i++) {
        //     Debug.Log("Vector3: " + vector3_list[i]);
        // }

    }

    // public Vector3 SnapToTerrainHeightmap(Vector3 position) {
    //     Vector3 referencePosition = position;
    //     referencePosition += Vector3.up * 10000;

    //     RaycastHit hit;

    //     LayerMask layerMask = LayerMask.GetMask("3D_Terrain");

    //     if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
    //         return hit.point;
    //     }
    //     else {
    //         return Vector3.zero;
    //     }
    // }

    // public Vector3 GetBarPos(int id)    {
    //     return dict[id];
    // }

    public List<int> GetNumDict(int id) {
        return dictionary_num[id];
    }

    public List<string> GetStrDict(int id)  {
        return dictionary_string[id];
    }

    public int GetVSC(int id)   {
        List<int> list = dictionary_num[id];
        return list[4];
    }
}
