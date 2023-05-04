using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewpointController : MonoBehaviour
{  
    private GameObject parent_;
    public Material barMaterial;

    GameObject capsule_3d_terrain_3d;
    GameObject capsule_3d_terrain_2d;
    GameObject capsule_2d_terrain_3d;
    GameObject capsule_2d_terrain_2d;
    GameObject capsule_2d_terrain_2d_2;
    GameObject capsule_3d_terrain_2d_2;

    private Vector3 capsule2DScale = new Vector3(200, 200, 1);

    public Camera cam3d2d;
    public Camera cam2d2d_2;

    private Color red = new Color(0.98f, 0.2f, 0.2f, 0.9f);
    private Color green = new Color(0.01f, 0.65f, 0.03f, 0.9f);
    private Color grey = new Color(0.05f, 0.05f, 0.05f, 1);

    // Start is called before the first frame update
    void Start()
    {
        // this.transform.position = new Vector3(Random.Range(-600, 5100), 0, Random.Range(-8000, 1600));
         parent_ = this.gameObject;

         capsule_3d_terrain_3d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_3d_terrain_2d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_2d_terrain_3d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_2d_terrain_2d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_2d_terrain_2d_2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_3d_terrain_2d_2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);

         Capsule3DTerrain3D(capsule_3d_terrain_3d);
         Capsule3DTerrain2D(capsule_3d_terrain_2d);
         Capsule2DTerrain3D(capsule_2d_terrain_3d);
         Capsule2DTerrain2D(capsule_2d_terrain_2d);
         Capsule2DTerrain2D_2(capsule_2d_terrain_2d_2);
         Capsule3DTerrain2D_2(capsule_3d_terrain_2d_2);
    }

    private void Capsule3DTerrain2D_2(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(200, 200 , 200);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.GetComponent<Renderer>().material.SetColor("_Color", grey); 
        capsule.transform.position = SnapTo2DTerrainHeightmap(capsule.transform.position);
        capsule.transform.Rotate(0, 0, 0);

        capsule.gameObject.layer = 24;
    }

    private void Capsule3DTerrain3D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(200, 200, 200);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.GetComponent<Renderer>().material.SetColor("_Color", grey);
        capsule.transform.position = SnapTo3DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 17;
    }

    private void Capsule3DTerrain2D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(200, 200 , 200);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.GetComponent<Renderer>().material.SetColor("_Color", grey);
        capsule.transform.position = SnapTo2DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 18;
    }

    private void Capsule2DTerrain3D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(200, 200 , 1);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.GetComponent<Renderer>().material.SetColor("_Color", grey);
        capsule.transform.position = SnapTo3DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 19;

        capsule.transform.LookAt(capsule.transform.position + cam3d2d.transform.rotation * Vector3.back, cam3d2d.transform.rotation * Vector3.up);
    }

     private void Capsule2DTerrain2D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(200, 1 , 200);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.GetComponent<Renderer>().material.SetColor("_Color", grey);
        capsule.transform.position = SnapTo2DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 20;
    }

     private void Capsule2DTerrain2D_2(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(200, 200 , 1);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.GetComponent<Renderer>().material.SetColor("_Color", grey);
        capsule.transform.position = SnapTo2DTerrainHeightmap(capsule.transform.position);
        capsule.transform.LookAt(capsule.transform.position + cam2d2d_2.transform.rotation * Vector3.back, cam2d2d_2.transform.rotation * Vector3.up);


        capsule.gameObject.layer = 22;
    }


    public Vector3 SnapTo3DTerrainHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("3D_Terrain");

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }

    public Vector3 SnapTo2DTerrainHeightmap(Vector3 position) {
        Vector3 referencePosition = position;
        referencePosition += Vector3.up * 10000;

        RaycastHit hit;

        LayerMask layerMask = LayerMask.GetMask("2D_Terrain");

        if(Physics.Raycast(referencePosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) {
            return hit.point;
        }
        else {
            return Vector3.zero;
        }
    }

    public void SetTransformCapsule(Dictionary<string, float> dict)   {
        capsule_2d_terrain_3d.transform.LookAt(capsule_2d_terrain_3d.transform.position + cam3d2d.transform.rotation * Vector3.back, cam3d2d.transform.rotation * Vector3.up);
        capsule_2d_terrain_2d_2.transform.LookAt(capsule_2d_terrain_2d_2.transform.position + cam2d2d_2.transform.rotation * Vector3.back, cam2d2d_2.transform.rotation * Vector3.up);

        // TransformCapsule2D(capsule_2d_terrain_2d_2, dict[name]);
        // TransformCapsule2D(capsule_2d_terrain_3d, dict[name]);
    }

    private void TransformCapsule2D(GameObject capsule, float scale)   {
        // float scale = normal_dict[Int32.Parse(cube.gameObject.name)];
        // print();
        capsule.transform.localScale = capsule2DScale;
        Vector3 scaleChange= new Vector3(capsule.transform.localScale.x + (scale * 50), capsule.transform.localScale.y, capsule.transform.localScale.z);
        // if(scale < 0.5) {
        //     scaleChange = new Vector3(cube.transform.localScale.x - (scale*40), cube.transform.localScale.y - (scale*30), cube.transform.localScale.z);
        // }else{
        //     scaleChange = new Vector3(cube.transform.localScale.x + (scale*40), cube.transform.localScale.y + (scale*30), cube.transform.localScale.z);
        // }
        capsule.transform.localScale = scaleChange;

        // MeshFilter meshFilter = GetComponent<MeshFilter>();
        // Vector3 objSize = meshFilter.sharedMesh.bounds.size;
        // Vector3 objScale = cube.transform.localScale;
        // float objHeight = (objSize.z * objScale.z) / 2;
        // capsule.transform.position = new Vector3(transform.position.x, cube.transform.position.y, transform.position.z);
    }

    public void SelectedViewpoint_Visible(string id)    {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", red); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", red);
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", red);
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", red);
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", red);
        if(capsule_3d_terrain_2d_2.name == id) capsule_3d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", red);
    }

    public void SelectedViewpoint_Invisible(string id)    {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", green); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", green);
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", green);
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", green);
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", green);
        if(capsule_3d_terrain_2d_2.name == id) capsule_3d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", green);
    }

    public void DeselectedViewpoint(string id)  {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", grey); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", grey);
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", grey);
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", grey);
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", grey);
        if(capsule_3d_terrain_2d_2.name == id) capsule_3d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", grey);
    }

    public void DisableViewpoint(string id) {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.gameObject.SetActive(false); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.gameObject.SetActive(false); 
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.gameObject.SetActive(false); 
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.gameObject.SetActive(false); 
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.gameObject.SetActive(false); 
        if(capsule_3d_terrain_2d_2.name == id) capsule_3d_terrain_2d_2.gameObject.SetActive(false);
    }

    public void ResetViewpoint()    {
        capsule_3d_terrain_3d.gameObject.SetActive(true);
        capsule_3d_terrain_2d.gameObject.SetActive(true);
        capsule_2d_terrain_3d.gameObject.SetActive(true);
        capsule_2d_terrain_2d_2.gameObject.SetActive(true);
        capsule_2d_terrain_2d.gameObject.SetActive(true);
        capsule_3d_terrain_2d_2.gameObject.SetActive(true);
    }

    public void SelectedViewpoint_Position(Vector3 pos, string name)    {
        if(parent_.name == name)    {
            parent_.transform.position = pos;
            Capsule3DTerrain3D(capsule_3d_terrain_3d);
            Capsule3DTerrain2D(capsule_3d_terrain_2d);
            Capsule2DTerrain3D(capsule_2d_terrain_3d);
            Capsule2DTerrain2D(capsule_2d_terrain_2d);
            Capsule2DTerrain2D_2(capsule_2d_terrain_2d_2);
            Capsule3DTerrain2D_2(capsule_3d_terrain_2d_2);
        }
        
    }

    public Vector3 GetPos()    {
        return parent_.transform.position;
    }

    public void DisableViewpoint()  {
        capsule_3d_terrain_3d.gameObject.SetActive(false);
        capsule_3d_terrain_2d.gameObject.SetActive(false);
        capsule_2d_terrain_3d.gameObject.SetActive(false);
        capsule_2d_terrain_2d_2.gameObject.SetActive(false);
        capsule_2d_terrain_2d.gameObject.SetActive(false);
        capsule_3d_terrain_2d_2.gameObject.SetActive(false);
    }
}
