using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalProperties : Singleton<GlobalProperties> {
    public CameraController CameraController;
    public InputController InputController;
    public FilterController FilterController;
    public SliderController SliderController;
    public Experiment Experiment;
    

    public Dictionary<int, Vector3> KOPPositions;
    public Dictionary<int, JL.KOP.FeaturePropertiesObject> KOPFeatureProperties;

    public Dictionary<int, Vector3> MKRFPositions;
    public Dictionary<int, JL.MKRF.FeaturePropertiesObject> MKRFFeatureProperties;

    public Dictionary<int, float> Visibility;

    public JL.KOP.Manager KOPManager;


    public JL.MKRF.Polygon.Manager PolygonManager;
    public JL.MKRF.Line.Manager LineManager;

    public JL.Component.Bar.Manager BarManager;
    public JL.Component.Link.Manager LinkManager;

    public JL.UI.Tooltip.Controller TooltipController;

    public float ViewerHeight = 2f;
    public int VisibilityAnalysisSampleRate = 3;

    public float MouseShortActionDelay = 0.01f;
    public float MouseLongActionDelay = 1f;

    public float CameraTeleportTime = 1.5f;

    public int TooltipCharacterWrapLimit = 80;

    // Decide progamatically?
    public Vector3 BaseTerrain = new Vector3(0, 1200, 0);

    public List<Vector3> KOPScale = new List<Vector3>() {
        1f * Vector3.one,
        1.3f * Vector3.one,
        1.6f * Vector3.one
    };

    public Vector3 KOPPointPositionOffset = new Vector3(0, 50, 0);
    public Quaternion KOPPointRotationOffset = Quaternion.identity;
    public Vector3 KOPPointScaleOffset = Vector3.one;

    public Color KOPPointColor = Color.white;
    public float KOPPointAlpha = 1f;

    public Color KOPPointColorAlternative1 = Color.green;
    public float KOPPointAlphaAlternative1 = 1f;

    public Color KOPPointColorAlternative2 = Color.red;
    public float KOPPointAlphaAlternative2 = 1f;

    public Color KOPPointOutlineColor = Color.black;
    public float KOPPointOutlineWidth = 1f;

    public Color KOPPointOutlineColorAlternative = Color.black;
    public float KOPPointOutlineWidthAlternative = 3f;



    public Vector3 MKRFPolygonPositionOffset = Vector3.zero;
    public Quaternion MKRFPolygonRotationOffset = Quaternion.identity;
    public Vector3 MKRFPolygonScaleOffset = Vector3.one;

    public List<Color> MKRFPolygonColor = new List<Color> {
        new Color(145f / 255, 191f / 255, 219f / 255, 1f),
        new Color(255f / 255, 255f / 255, 191f / 255, 1f),
        new Color(252f / 255, 141f / 255, 89f / 255, 1f)
    };

    public List<float> MKRFPolygonAlpha = new List<float> {
        0.3f,
        0.3f,
        0.3f
    };



    public Vector3 MKRFLinePositionOffset = Vector3.zero;
    public Quaternion MKRFLineRotationOffset = Quaternion.identity;
    public Vector3 MKRFLineScaleOffset = Vector3.one;

    public Color MKRFLineColor = Color.black;
    public float MKRFLineAlpha = 1f;

    public Color MKRFLineColorAlternative = Color.white;
    public float MKRFLineAlphaAlternative = 1f;

    public Color MKRFLineColorAlternative1 = Color.green;
    public float MKRFLineAlphaAlternative1 = 1f;

    public Color MKRFLineColorAlternative2 = Color.red;
    public float MKRFLineAlphaAlternative2 = 1f;



    public Vector3 BarPositionOffset = new Vector3(0, 100, 0);
    public Quaternion BarRotationOffset = Quaternion.identity;
    public Vector3 BarScaleOffset = Vector3.one;

    public List<Color> BarColor = new List<Color>() {
        new Color(145f / 255, 191f / 255, 219f / 255, 1f),
        new Color(255f / 255, 255f / 255, 191f / 255, 1f),
        new Color(252f / 255, 141f / 255, 89f / 255, 1f)
    };

    public List<float> BarAlpha = new List<float>() {
        0.3f,
        0.3f,
        0.3f
    };

    public List<Color> BarColorPalette = new List<Color>() {
        new Color(0.745f, 0.682f, 0.831f, 1f),
        new Color(0.992f, 0.753f, 0.525f, 1f),
        new Color(1f, 1f, 0.6f, 1f),
        new Color(0.498f, 0.788f, 0.498f, 1f)
    };

    public List<float> BarAlphaPalette = new List<float>() {
        0.3f,
        0.3f,
        0.3f,
        0.3f
    };

    public Color BarOutlineColor = Color.black;
    public float BarOutlineWidth = 1f;

    public Color BarOutlineColorAlternative = Color.white;
    public float BarOutlineWidthAlternative = 3f;



    public Vector3 LinkPositionOffset = new Vector3(0, 50, 0);
    public Quaternion LinkRotationOffset = Quaternion.identity;
    public Vector3 LinkScaleOffset = Vector3.one;

    public List<float> LinkDashLength = new List<float>() {
        200f,
        200f,
        0f
    };

    public List<float> LinkSpaceLength = new List<float>() {
        200f,
        100f,
        0f
    };

    public List<Color> LinkColor = new List<Color>() {
        new Color(116f / 255, 196f / 255, 118f / 255, 1f),
        new Color(49f / 255, 163f / 255, 84f / 255, 1f),
        new Color(0f / 255, 109f / 255, 44f / 255, 1f)
    };

    public List<float> LinkAlpha = new List<float>() {
        1f,
        1f,
        1f
    };

    public Color LinkOutlineColor = Color.black;
    public float LinkOutlineWidth = 1f;

    public Color LinkOutlineColorAlternative = Color.white;
    public float LinkOutlineWidthAlternative = 3f;
}
