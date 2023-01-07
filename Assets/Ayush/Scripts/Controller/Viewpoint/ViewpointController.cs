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


    public Camera cam3d2d;
    public Camera cam2d2d_2;

    // Start is called before the first frame update
    void Start()
    {
         parent_ = this.gameObject;

         capsule_3d_terrain_3d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_3d_terrain_2d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_2d_terrain_3d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_2d_terrain_2d = GameObject.CreatePrimitive(PrimitiveType.Capsule);
         capsule_2d_terrain_2d_2 = GameObject.CreatePrimitive(PrimitiveType.Capsule);

         Capsule3DTerrain3D(capsule_3d_terrain_3d);
         Capsule3DTerrain2D(capsule_3d_terrain_2d);
         Capsule2DTerrain3D(capsule_2d_terrain_3d);
         Capsule2DTerrain2D(capsule_2d_terrain_2d);
         Capsule2DTerrain2D_2(capsule_2d_terrain_2d_2);
    }

    private void Capsule3DTerrain3D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(100, 100 , 100);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.transform.position = SnapTo3DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 17;
    }

    private void Capsule3DTerrain2D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(100, 100 , 100);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.transform.position = SnapTo2DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 18;
    }

    private void Capsule2DTerrain3D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(100, 100 , 1);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.transform.position = SnapTo3DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 19;

        capsule.transform.LookAt(capsule.transform.position + cam3d2d.transform.rotation * Vector3.back, cam3d2d.transform.rotation * Vector3.up);
    }

     private void Capsule2DTerrain2D(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(100, 1 , 100);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
        capsule.transform.position = SnapTo2DTerrainHeightmap(capsule.transform.position);

        capsule.gameObject.layer = 20;
    }

     private void Capsule2DTerrain2D_2(GameObject capsule) {
        capsule.transform.parent = parent_.transform;
        capsule.name = parent_.name;
        capsule.transform.position = parent_.transform.position;
        capsule.transform.localScale = new Vector3(100, 100 , 1);

        capsule.GetComponent<Renderer>().material = barMaterial;
        capsule.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.5f);
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

    public void SetTransformCapsule()   {
        capsule_2d_terrain_3d.transform.LookAt(capsule_2d_terrain_3d.transform.position + cam3d2d.transform.rotation * Vector3.back, cam3d2d.transform.rotation * Vector3.up);
        capsule_2d_terrain_2d_2.transform.LookAt(capsule_2d_terrain_2d_2.transform.position + cam2d2d_2.transform.rotation * Vector3.back, cam2d2d_2.transform.rotation * Vector3.up);
    }

    public void SelectedViewpoint_Visible(string id)    {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
    }

    public void SelectedViewpoint_Invisible(string id)    {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", Color.blue); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    public void DeselectedViewpoint(string id)  {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    public void DisableViewpoint(string id) {
        if(capsule_3d_terrain_3d.name == id) capsule_3d_terrain_3d.gameObject.SetActive(false); 
        if(capsule_3d_terrain_2d.name == id) capsule_3d_terrain_2d.gameObject.SetActive(false); 
        if(capsule_2d_terrain_3d.name == id) capsule_2d_terrain_3d.gameObject.SetActive(false); 
        if(capsule_2d_terrain_2d_2.name == id) capsule_2d_terrain_2d_2.gameObject.SetActive(false); 
        if(capsule_2d_terrain_2d.name == id) capsule_2d_terrain_2d.gameObject.SetActive(false); 
    }
}
