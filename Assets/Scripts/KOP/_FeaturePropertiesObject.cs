using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.KOP {
    [System.Serializable]
    public class FeaturePropertiesObject {
        [SerializeField] private int OBJECTID = 0;
        public int objectId {
            get {
                return OBJECTID;
            }
        }

        [SerializeField] private int OFFSETA = 0;
        public int offsetA {
            get {
                return OFFSETA;
            }
        }

        [SerializeField] private int OFFSETB = 0;
        public int offsetB {
            get {
                return OFFSETB;
            }
        }

        [SerializeField] private int IMPORTANCE = 0;
        public int importance {
            get {
                return IMPORTANCE;
            }
        }
    }
}
