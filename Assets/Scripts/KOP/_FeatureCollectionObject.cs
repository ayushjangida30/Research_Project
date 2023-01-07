using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.KOP {
    [System.Serializable]
    public class FeatureCollectionObject {
        public string type;
        public string name;
        public List<FeatureObject> features;
    }
}
