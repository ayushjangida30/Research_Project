using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class BarController : MonoBehaviour
{
    private GameObject parent_;
    private GameObject cube2d_terrain2d;
    private GameObject cube2d_terrain3d;
    private GameObject cube3d_terrain3d;
    private GameObject cube3d_terrain2d;
    private GameObject cube2d_terrain2d_2;

    private GameObject newObj;

    public vsc_geojson_reader reader;
    public centroid_reader c_reader;
    
    private Vector3 vector_coord;
    private Vector3 pos;

    private Vector3 cube3DScale;
    private Vector3 cube2DScale;

    private GameObject[] terrain_3d;
    private GameObject[] terrain_2d;


    public Camera cam2d2d;
    public Camera cam3d2d;
    public Camera cam2d2d_2;
    
    private Vector3 camForward;
    public BarManager barManager;

    private float dist_2d3d;
    private float dist_2d2d;


    // private MeshRenderer meshRenderer;

    public Material barMaterial;
    public Material barMaterial_unlit;
    // public Material barMaterial_unlit;


    public GameObject parentPanel;

    // Start is called before the first frame update
    void Start()
    {
        parent_ = this.gameObject;
        // camForward = new Vector3(cam3d2d.transform.position.x, 0, 0);
        createBar();

    }

    private void createBar()    {
        cube3d_terrain3d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3d_terrain2d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2d_terrain2d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2d_terrain3d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2d_terrain2d_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);

        cube3DScale = new Vector3(40, 100 + (150 * reader.GetVSC(Int32.Parse(this.name))) , 40);
        cube2DScale = new Vector3(40, 100 + (150 * reader.GetVSC(Int32.Parse(this.name))) , 10);


        // newObj = new GameObject():
        // Image img = newObj.AddComponent<Image>();
        // newObj.GetComponent<RectTransform>().SetParent(parentPanel.transform);
        // newObj.SetActive(true);


        Cube3DTerrain2D(cube3d_terrain2d);
        Cube3DTerrain3D(cube3d_terrain3d);
        Cube2DTerrain2D(cube2d_terrain2d);
        Cube2DTerrain2D_2(cube2d_terrain2d_2);
        Cube2DTerrain3D(cube2d_terrain3d);
    }

   

    private void Cube3DTerrain2D(GameObject cube)  {
        cube.gameObject.layer = 13;
        SetObject(cube, 3, 2);

        TransformCube(cube);
    }

    private void Cube2DTerrain2D(GameObject cube)  {
        SetObject(cube, 2, 2);
        cube.transform.localScale = new Vector3(40, 1f, 100 + (100 * reader.GetVSC(Int32.Parse(this.name))));
        cube.gameObject.tag = "2D_Cube_2D_Terrain";
        cube.gameObject.layer = 15;

        TransformCube2D(cube);
    }

    private void Cube2DTerrain2D_2(GameObject cube)  {
        cube.gameObject.tag = "2D_Cube_2D_Terrain";
        cube.gameObject.layer = 21;
        cube.transform.LookAt(cube.transform.position + cam2d2d_2.transform.rotation * Vector3.back, cam2d2d_2.transform.rotation * Vector3.up);
        dist_2d2d = Vector3.Distance(cam2d2d_2.transform.position, cube.transform.position);
        SetScaleChange(cube, dist_2d2d);
        SetObject(cube, 2, 2);
        // cube.transform.LookAt(cam.transform);

        TransformCube2D(cube);
    }

    private void Cube2DTerrain3D(GameObject cube)  {
        cube.gameObject.tag = "2D_Cube_3D_Terrain";
        cube.gameObject.layer = 16;
        cube.transform.LookAt(cube.transform.position + cam3d2d.transform.rotation * Vector3.back, cam3d2d.transform.rotation * Vector3.up);
        dist_2d3d = Vector3.Distance(cam3d2d.transform.position, cube.transform.position);
        SetScaleChange(cube, dist_2d3d);
        SetObject(cube, 2, 3);

        TransformCube(cube);
    }

    private void Cube3DTerrain3D(GameObject cube)  {
        cube.gameObject.layer = 12;
        SetObject(cube, 3, 3);

        TransformCube(cube);
    }

    private void SetObject(GameObject gameObject, int dimType, int terrainType) {
        gameObject.transform.parent = parent_.transform;
        gameObject.name = parent_.name;
        gameObject.transform.position = parent_.transform.position;
        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

        //Dimensional IF
        if(dimType == 3)   {
            gameObject.transform.localScale = cube3DScale;
            gameObject.GetComponent<Renderer>().material = barMaterial;
        }else{
            gameObject.transform.localScale = cube2DScale;
            gameObject.GetComponent<Renderer>().material = barMaterial_unlit;
        }

        //Terrain IF
        if(terrainType == 2)    {
            gameObject.transform.position = SnapTo2DTerrainHeightmap(gameObject.transform.position);
        }else{
            gameObject.transform.position = SnapTo3DTerrainHeightmap(gameObject.transform.position);
        }

        gameObject.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
    }

    private void SetScaleChange(GameObject gameObject, float dist, float normal)  {
        // float scale = dist * 0.0002f + normal * (1 - normal);
        // float scale = Mathf.Tan(0.3054f) * dist * 0.0007f;
        float scale = 1 + normal + (dist * 0.00007f);
        Vector3 scaleChange = new Vector3(gameObject.transform.localScale.x*scale, gameObject.transform.localScale.y*scale, gameObject.transform.localScale.z);
        gameObject.transform.localScale = scaleChange;
    }

    private void SetScaleChange(GameObject gameObject, float dist)  {
        float scale = dist * 0.0003f;
        // float scale = Mathf.Tan(0.3054f) * dist * 0.0007f;
        Vector3 scaleChange = new Vector3(gameObject.transform.localScale.x*scale, gameObject.transform.localScale.y*scale, gameObject.transform.localScale.z);
        gameObject.transform.localScale = scaleChange;
    }

    private void TransformCube(GameObject cube)   {

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Vector3 objSize = meshFilter.sharedMesh.bounds.size;
        Vector3 objScale = cube.transform.localScale;
        float objHeight = (objSize.y * objScale.y) / 2;
        cube.transform.position = new Vector3(transform.position.x, cube.transform.position.y + objHeight, transform.position.z);
    }

    private void TransformCube2D(GameObject cube)   {

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Vector3 objSize = meshFilter.sharedMesh.bounds.size;
        Vector3 objScale = cube.transform.localScale;
        float objHeight = (objSize.z * objScale.z) / 2;
        cube.transform.position = new Vector3(transform.position.x, cube.transform.position.y, transform.position.z + objHeight);
    }


    private Vector3 SnapTo3DTerrainHeightmap(Vector3 position) {
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


    public void SetTransform(Dictionary<int, float> normal_dict)   {
        LookAtFunction(cube2d_terrain3d, cam3d2d, 3, normal_dict[Int32.Parse(this.name)]);
        LookAtFunction(cube2d_terrain2d_2, cam2d2d_2, 2, normal_dict[Int32.Parse(this.name)]);
    }

    private void LookAtFunction(GameObject gameObject, Camera cam, int terrainType, float normal)  {
        gameObject.transform.LookAt(gameObject.transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.up);
        gameObject.transform.localScale = cube2DScale;
        float distance = Vector3.Distance(cam.transform.position, gameObject.transform.position);
        SetScaleChange(gameObject, distance, normal);

        if(terrainType == 2)    {
            gameObject.transform.position = SnapTo2DTerrainHeightmap(gameObject.transform.position);
        }else{
            gameObject.transform.position = SnapTo3DTerrainHeightmap(gameObject.transform.position);
        }

    }

    public void BarInvisible()  {
        cube2d_terrain2d.SetActive(false);
        cube3d_terrain2d.SetActive(false);
        cube3d_terrain3d.SetActive(false);
        cube2d_terrain3d.SetActive(false);
        cube2d_terrain2d_2.SetActive(false);
    }

    public void SelectedBar(int value) {
        // if(cube)
        if(value == 1)  {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);

        }else{
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
        }
    }

    public void VisiblePolygon(List<int> list)  {
        if(list.Count == 0) {
            cube2d_terrain2d.SetActive(true);
            cube3d_terrain2d.SetActive(true);
            cube3d_terrain3d.SetActive(true);
            cube2d_terrain3d.SetActive(true);
            cube2d_terrain2d_2.SetActive(true);
        }else{
            if(list.Contains(Int32.Parse(parent_.name)))    {
            cube2d_terrain2d.SetActive(true);
            cube3d_terrain2d.SetActive(true);
            cube3d_terrain3d.SetActive(true);
            cube2d_terrain3d.SetActive(true);
            cube2d_terrain2d_2.SetActive(true);

            // cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            // cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            // cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            // cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            // cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            }else{
            cube2d_terrain2d.SetActive(false);
            cube3d_terrain2d.SetActive(false);
            cube3d_terrain3d.SetActive(false);
            cube2d_terrain3d.SetActive(false);
            cube2d_terrain2d_2.SetActive(false);
            }
        }
        
    }

    public void BlinkBar(int id)    {
        string cubeId = id.ToString();
        if(cube3d_terrain3d.name == cubeId)   {
            print("Reached blink file");
            Example();
        }
    }

    IEnumerator Example()   {
        cube3d_terrain3d.SetActive(false);
        yield return new WaitForSeconds(1);
        cube3d_terrain3d.SetActive(true);
        yield return new WaitForSeconds(1);
        cube3d_terrain3d.SetActive(false);
    }

    public Vector3 GetPosition()    {
        return parent_.transform.position;
    }
}
