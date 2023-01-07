using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.MKRF {
    [System.Serializable]
    public class FeaturePropertiesObject {
        [SerializeField] private int OBJECTID = 0;
        public int objectId {
            get {
                return OBJECTID;
            }
        }

        [SerializeField] private int FID_VQO_Polygons_Eliminate1 = 0;
        public int polygonId {
            get {
                return FID_VQO_Polygons_Eliminate1;
            }
        }

        [SerializeField] private string EVC = "";
        public int evc {
            get {
                switch(EVC) {
                    case "Preserved":
                        return 0;
                    
                    case "Retained":
                        return 1;

                    case "Partially Retained":
                        return 2;

                    case "Modified":
                        return 3;
                    
                    case "Maximally Modified":
                        return 4;
                    
                    case "Excessively Modified":
                        return 5;
                    
                    default:
                        return -1;
                }
            }
        }

        [SerializeField] private int VAC_Final = 0;
        public int vac {
            get {
                return VAC_Final;
            }
        }

        [SerializeField] private int BR_Final = 0;
        public int br {
            get {
                return BR_Final;
            }
        }

        [SerializeField] private int VC_Final = 0;
        public int vc {
            get {
                return VC_Final;
            }
        }

        [SerializeField] private int VR_Final = 0;
        public int vr {
            get {
                return VR_Final;
            }
        }

        [SerializeField] private int VSC = 0;
        public int vsc {
            get {
                return VSC;
            }
        }

        [SerializeField] private int VSC_Final = 0;
        public int vscFinal {
            get {
                return VSC_Final;
            }
        }

        [SerializeField] private string VQC = "";
        public string vqc {
            get {
                return VQC;
            }
        }

        [SerializeField] private string VQC_Harvest = "";
        public int vqcFinal {
            get {
                switch(VQC_Harvest) {
                    case "0":
                        return 0;
                    
                    case "0-1.5":
                        return 1;
                    
                    case "1.6-7":
                        return 2;
                    
                    case "7.1-18":
                        return 3;
                    
                    case "18.1-30":
                        return 4;
                    
                    case "30.1":
                        return 5;
                    
                    default:
                        return -1;
                }
            }
        }

        [SerializeField] private int Visibility = 0;
        public int visibility {
            get {
                return Visibility;
            }
        }

        [SerializeField] private float GEOMETRY_Length = 0f;
        public float geometryLength {
            get {
                return GEOMETRY_Length;
            }
        }

        [SerializeField] private float GEOMETRY_Area = 0f;
        public float geometryArea {
            get {
                return GEOMETRY_Area;
            }
        }
    }
}
