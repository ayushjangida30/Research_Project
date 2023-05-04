using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class BarController : MonoBehaviour
{
    public GameObject cubePrefab;

    private GameObject parent_;
    private GameObject cube2d_terrain2d;
    private GameObject cube2d_terrain3d;
    private GameObject cube3d_terrain3d;
    private GameObject cube3d_terrain2d;
    private GameObject cube2d_terrain2d_2;
    private GameObject cube3d_terrain2d_2;


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
    public Camera cam2d3d_2;
    
    private Vector3 camForward;
    public BarManager barManager;
    private MainController mainController;

    private float dist_2d3d;
    private float dist_2d2d;

    private int height;
    private int barValue;
    private float barHeight;


    // private MeshRenderer meshRenderer;

    public Material barMaterial;
    public Material barMaterial_unlit;
    public Material barMaterial_unlit_Ztest_Off;
    private Color seaGreen;
    // public Material barMaterial_unlit;


    public GameObject parentPanel;

    // Start is called before the first frame update
    void Start()
    {
        parent_ = this.gameObject;
        barValue = UnityEngine.Random.Range(0,8);
        mainController = GameObject.Find("GameObject").GetComponent<MainController>();
        barHeight = (140 * reader.GetVSC(Int32.Parse(this.name))) + 50;
        seaGreen = new Color(0.05f, 0.07f, 0.74f, 0.9f);
        // camForward = new Vector3(cam3d2d.transform.position.x, 0, 0);
        createBar();

    }

    

    private void createBar()    {
        cube3d_terrain3d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube3d_terrain2d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2d_terrain2d = Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // cube2d_terrain3d = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2d_terrain3d = Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        cube3d_terrain2d_2 = Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        cube2d_terrain2d_2 = Instantiate(cubePrefab, new Vector3(0, 0, 0), Quaternion.identity);


        cube3DScale = new Vector3(40, barHeight , 40);
        cube2DScale = new Vector3(40, barHeight , 10);


        // newObj = new GameObject():
        // Image img = newObj.AddComponent<Image>();
        // newObj.GetComponent<RectTransform>().SetParent(parentPanel.transform);
        // newObj.SetActive(true);


        Cube3DTerrain2D(cube3d_terrain2d);
        Cube3DTerrain3D(cube3d_terrain3d);
        Cube2DTerrain2D(cube2d_terrain2d);
        Cube2DTerrain2D_2(cube2d_terrain2d_2);
        Cube2DTerrain3D(cube2d_terrain3d);
        Cube3DTerrain2D_2(cube3d_terrain2d_2);
    }

    // void Update()   {
    //     if(cam3d2d.gameObject.transform.eulerAngles.x >= 75)    {
    //         print("BarController: if reached");
    //         cube2d_terrain3d.GetComponent<Renderer>().material = barMaterial_unlit_Ztest_Off;
    //     }else   {
    //         print("BarController: else reached");
    //         cube2d_terrain3d.GetComponent<Renderer>().material = barMaterial_unlit;
    //     }
    // }

   

    private void Cube3DTerrain2D(GameObject cube)  {
        cube.gameObject.layer = 13;
        SetObject(cube, 3, 2);
        
        TransformCube(cube);
    }

    private void Cube2DTerrain2D(GameObject cube)  {
        SetObject(cube, 2, 2);
        cube.gameObject.tag = "2D_Cube_2D_Terrain";
        cube.gameObject.layer = 15;

        cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y + 100, cube.transform.position.z);

        cube.transform.Rotate(90, 0, 0);
    }

    private void Cube2DTerrain2D_2(GameObject cube)  {
        cube.gameObject.tag = "2D_Cube_2D_Terrain_2";
        cube.gameObject.layer = 21;
        cube.transform.LookAt(cube.transform.position + cam2d2d_2.transform.rotation * Vector3.back, cam2d2d_2.transform.rotation * Vector3.up);
        dist_2d2d = Vector3.Distance(cam2d2d_2.transform.position, cube.transform.position);
        // SetScaleChange(cube, dist_2d2d);
        SetObject(cube, 2, 2);
        // SetPivotChange(cube);
        // cube.transform.LookAt(cam.transform);

        // TransformCube2D(cube);
    }

    private void Cube2DTerrain3D(GameObject cube)  {
        cube.gameObject.tag = "2D_Cube_3D_Terrain";
        cube.gameObject.layer = 16;
        cube.transform.LookAt(cube.transform.position + cam3d2d.transform.rotation * Vector3.back, cam3d2d.transform.rotation * Vector3.up);
        dist_2d3d = Vector3.Distance(cam3d2d.transform.position, cube.transform.position);
        // SetScaleChange(cube, dist_2d3d);
        SetObject(cube, 2, 3);


        // TransformCube(cube);
    }

    private void Cube3DTerrain3D(GameObject cube)  {
        cube.gameObject.layer = 12;
        SetObject(cube, 3, 3);

        TransformCube(cube);
    }

    private void Cube3DTerrain2D_2(GameObject cube) {
        cube.gameObject.tag = "3D_Cube_2D_Terrain_2";
        cube.gameObject.layer = 23;
        SetObject(cube, 3, 2);
        cube.transform.Rotate(0, 45, 0);
        // cube.gameObject.transform.localRotation = Quaternion.Euler(45,45,0);
        // TransformCube(cube);
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

    // private void SetPivotChange(GameObject gameObject)  {
    //     MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
    //     Vector3 objSize = meshFilter.sharedMesh.bounds.size;
    //     Vector3 objScale = gameObject.transform.localScale;
    //     float objHeight = (objSize.y * objScale.y) / 2;
    //     gameObject.transform.position = new Vector3(gameObject.transform.position.x,  + gameObject.transform.position.y + objHeight, gameObject.transform.position.z);
    // }

    // private void SetScaleChange(GameObject gameObject, float dist, float normal)  {
    //     // float scale = dist * 0.0002f + normal * (1 - normal);
    //     // float scale = Mathf.Tan(0.3054f) * dist * 0.0007f;
    //     float scale = 1 + normal + (dist * 0.00007f);
    //     Vector3 scaleChange = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y*scale, gameObject.transform.localScale.z);
    //     gameObject.transform.localScale = scaleChange;
    // }

    private void SetScaleChange(GameObject gameObject, float dist)  {
        float scale = dist * 0.0003f;
        // float scale = Mathf.Tan(0.3054f) * dist * 0.0007f;
        gameObject.transform.localScale = cube2DScale;
        Vector3 scaleChange = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y+scale, gameObject.transform.localScale.z);
        gameObject.transform.localScale = scaleChange;
    }

    private void TransformCube(GameObject cube)   {

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Vector3 objSize = meshFilter.sharedMesh.bounds.size;
        Vector3 objScale = cube.transform.localScale;
        float objHeight = (objSize.y * objScale.y) / 2;
        cube.transform.position = new Vector3(transform.position.x, cube.transform.position.y + objHeight, transform.position.z);
        if(this.tag == "3D_Cube_2D_Terrain_2")  cube.transform.Rotate(0, 45, 0);
    }

    private void TransformCube2D(GameObject cube, float scale)   {
        // float scale = normal_dict[Int32.Parse(cube.gameObject.name)];
        // print();
        // cube.transform.localScale = cube2DScale;
        Vector3 scaleChange= new Vector3(cube.transform.localScale.x + (scale * 50), barHeight, cube.transform.localScale.z);
        // if(scale < 0.5) {
        //     scaleChange = new Vector3(cube.transform.localScale.x - (scale*40), cube.transform.localScale.y - (scale*30), cube.transform.localScale.z);
        // }else{
        //     scaleChange = new Vector3(cube.transform.localScale.x + (scale*40), cube.transform.localScale.y + (scale*30), cube.transform.localScale.z);
        // }
        cube.transform.localScale = scaleChange;

        MeshFilter meshFilter = GetComponent<MeshFilter>();
        Vector3 objSize = meshFilter.sharedMesh.bounds.size;
        Vector3 objScale = cube.transform.localScale;
        float objHeight = (objSize.z * objScale.z) / 2;
        cube.transform.position = new Vector3(transform.position.x, cube.transform.position.y, transform.position.z + objHeight);
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


    public void SetTransform(Dictionary<int, float> dict)   {
        // LookAtFunction(cube2d_terrain3d, cam3d2d, 3, normal_dict[Int32.Parse(this.name)]);
        // LookAtFunction(cube2d_terrain2d_2, cam2d2d_2, 2, normal_dict[Int32.Parse(this.name)]);

        LookAtFunction(cube2d_terrain3d, cam3d2d, 3);
        LookAtFunction(cube2d_terrain2d_2, cam2d2d_2, 2);
        LookAtFunction(cube2d_terrain2d, cam2d2d, 2);
        LookAtFunction(cube3d_terrain2d_2, cam3d2d, 2);
        // LookAtFunction(cube3d_terrain2d_2, cam2d2d_2, 2, normal_dict[Int32.Parse(this.name)]);
        // TransformCube(cube3d_terrain2d_2);
        float scale = 30 / GetWidth(Int32.Parse(name));

        if(name == "1033") {
            print("Width:" + GetWidth(1033));
            print("SCale:" + scale);
            print("LocalScale:" + cube2d_terrain2d_2.transform.localScale);
        }

        TransformCube2D(cube2d_terrain3d, dict[Int32.Parse(name)]);
        TransformCube2D(cube2d_terrain2d_2, dict[Int32.Parse(name)]);
        // TransformCube(cube3d_terrain2d_2);
        // TransformCube2D(cube2d_terrain2d, normal_dict);

        if(name == "1033") {
            print("Width:" + GetWidth(1033));
            print("LocalScale:" + cube2d_terrain2d_2.transform.localScale);
        }

        // RotateCube(cube3d_terrain2d_2);
    }

    private void RotateCube(GameObject cube)    {
        cube.transform.Rotate(0, cam3d2d.gameObject.transform.rotation.eulerAngles.y + 45, 0);

    }

    // public void SetTransform(float scale)   {
    //     LookAtFunction(cube2d_terrain3d, cam3d2d, 3);
    //     LookAtFunction(cube2d_terrain2d_2, cam2d2d_2, 2);

    //     TransformCube2D(cube2d_terrain3d, scale);
    //     TransformCube2D(cube2d_terrain2d_2, scale);
    // }

    public void AdjustCube(int id, float height)    {
        if(id == Int32.Parse(this.name))    {
            barHeight = height;
            cube3d_terrain2d_2.transform.parent = parent_.transform;
            cube3d_terrain2d_2.name = parent_.name;
            cube3d_terrain2d_2.transform.position = parent_.transform.position;
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            cube3d_terrain2d_2.transform.localScale = new Vector3(40, height, 40);
            cube3d_terrain2d_2.transform.position = SnapTo2DTerrainHeightmap(gameObject.transform.position);
            cube3d_terrain2d_2.transform.localRotation = Quaternion.Euler(0, 45, 0);

            // cube2d_terrain2d.transform.parent = parent_.transform;
            // cube2d_terrain2d.name = parent_.name;
            // cube2d_terrain2d.transform.position = parent_.transform.position;
            // cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            cube2d_terrain2d.transform.localScale = new Vector3(40, height, 40);
            // cube2d_terrain2d.transform.position = SnapTo2DTerrainHeightmap(gameObject.transform.position);
            cube2d_terrain2d.transform.localRotation = Quaternion.Euler(45, 0, 0);
        }
    }

    public void AdjustCube(int id, float height, int zero)    {
        if(id == Int32.Parse(this.name))    {
            barHeight = height;
            cube3d_terrain2d_2.transform.parent = parent_.transform;
            cube3d_terrain2d_2.name = parent_.name;
            cube3d_terrain2d_2.transform.position = parent_.transform.position;
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            cube3d_terrain2d_2.transform.localScale = new Vector3(40, height, 40);
            cube3d_terrain2d_2.transform.position = SnapTo2DTerrainHeightmap(gameObject.transform.position);
            cube3d_terrain2d_2.transform.localRotation = Quaternion.Euler(0, 45, 0);


            cube2d_terrain2d.transform.localScale = new Vector3(40, height, 40);
            cube2d_terrain2d.transform.localRotation = Quaternion.Euler(45, 0, 0);
            // cube2d_terrain2d.transform.Rotate(-180, 0, 0);
        }
    }

    private void LookAtFunction(GameObject gameObject, Camera cam, int terrainType)  {
        float angle = cam.transform.rotation.eulerAngles.y;
        if(gameObject.tag == "3D_Cube_2D_Terrain_2")    {
            if(cam.transform.rotation.eulerAngles.y != angle)   {
                print("Camera angle is: " + cam.transform.rotation.eulerAngles.y);
                gameObject.transform.Rotate(0, cam.transform.rotation.eulerAngles.y + 45, 0);
            }
            // Vector3 targetPos = new Vector3(cam2d3d_2.gameObject.transform.position.x, gameObject.transform.position.y, cam2d3d_2.gameObject.transform.position.z);
            // gameObject.transform.LookAt(targetPos);
            // gameObject.transform.Rotate(0, cam.transform.rotation.eulerAngles.y + 45, 0);
        }else if(gameObject.tag == "2D_Cube_2D_Terrain")  {
            gameObject.transform.LookAt(gameObject.transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.up);
        }else{
            gameObject.transform.LookAt(gameObject.transform.position + cam.transform.rotation * Vector3.back, cam.transform.rotation * Vector3.up);
            gameObject.transform.localScale = cube2DScale;
            float distance = Vector3.Distance(cam.transform.position, gameObject.transform.position);
            // SetScaleChange(gameObject, distance, normal);

            if(terrainType == 2)    {
                gameObject.transform.position = SnapTo2DTerrainHeightmap(gameObject.transform.position);
            }else{
                gameObject.transform.position = SnapTo3DTerrainHeightmap(gameObject.transform.position);
            }
        }

    }

    public void BarInvisible()  {
        cube2d_terrain2d.SetActive(false);
        cube3d_terrain2d.SetActive(false);
        cube3d_terrain3d.SetActive(false);
        cube2d_terrain3d.SetActive(false);
        cube2d_terrain2d_2.SetActive(false);
        cube3d_terrain2d_2.SetActive(false);
    }

    public void SelectedBar(int value) {
        // if(cube)
        if(value == 1)  {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);

        }else if(value == 2)    {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            
        }else if(value == 3)    {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
        }
        else{
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
        }
    }


    public void SelectedBar(int value, List<int> highlightList) {
        // if(cube)
        if(value == 1)  {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);

        }else if(value == 2)    {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            
        }
        else{
            if(highlightList.Contains(Int32.Parse(this.name)))  {
                cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
                cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
                cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
                cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);
                cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);
                cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);

                cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
                cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
                cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
                cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
                cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
                cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            }else   {
                cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
                cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
                cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white); 
                cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
                cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", Color.white);

                cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
                cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
                cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
                cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
                cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
                cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f);
            }

        }
    }



    public void SelectedBarHighlight(int id)    {
        if(Int32.Parse(this.name) == id)    {
            cube2d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", seaGreen); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetColor("_Color", seaGreen);

            cube2d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain2d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube3d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
            cube2d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
            cube3d_terrain2d_2.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f);
        }
    }


    public void VisiblePolygon(List<int> list, List<int> visible)  {
        if(visible.Contains(Int32.Parse(this.name)))    {
             print("Reaching Visible Polygon: " + list.Count);
            if(list.Count == 0) {
                cube2d_terrain2d.SetActive(true);
                cube3d_terrain2d.SetActive(true);
                cube3d_terrain3d.SetActive(true);
                cube2d_terrain3d.SetActive(true);
                cube2d_terrain2d_2.SetActive(true);
                cube3d_terrain2d_2.SetActive(true);
            }else{
                if(list.Contains(Int32.Parse(parent_.name)))    {
                    cube2d_terrain2d.SetActive(true);
                    cube3d_terrain2d.SetActive(true);
                    cube3d_terrain3d.SetActive(true);
                    cube2d_terrain3d.SetActive(true);
                    cube2d_terrain2d_2.SetActive(true);
                    cube3d_terrain2d_2.SetActive(true);
                }else{
                    cube2d_terrain2d.SetActive(false);
                    cube3d_terrain2d.SetActive(false);
                    cube3d_terrain3d.SetActive(false);
                    cube2d_terrain3d.SetActive(false);
                    cube2d_terrain2d_2.SetActive(false);
                    cube3d_terrain2d_2.SetActive(false);
                }
            }
        }else{
            cube2d_terrain2d.SetActive(false);
            cube3d_terrain2d.SetActive(false);
            cube3d_terrain3d.SetActive(false);
            cube2d_terrain3d.SetActive(false);
            cube2d_terrain2d_2.SetActive(false);
            cube3d_terrain2d_2.SetActive(false);
        } 
    }

    public void VisiblePolygon(List<int> list)  {
             print("Reaching Visible Polygon: " + list.Count);
            if(list.Count == 0) {
                cube2d_terrain2d.SetActive(true);
                cube3d_terrain2d.SetActive(true);
                cube3d_terrain3d.SetActive(true);
                cube2d_terrain3d.SetActive(true);
                cube2d_terrain2d_2.SetActive(true);
                cube3d_terrain2d_2.SetActive(true);
            }else{
                if(list.Contains(Int32.Parse(parent_.name)))    {
                    cube2d_terrain2d.SetActive(true);
                    cube3d_terrain2d.SetActive(true);
                    cube3d_terrain3d.SetActive(true);
                    cube2d_terrain3d.SetActive(true);
                    cube2d_terrain2d_2.SetActive(true);
                    cube3d_terrain2d_2.SetActive(true);
                }else{
                    cube2d_terrain2d.SetActive(false);
                    cube3d_terrain2d.SetActive(false);
                    cube3d_terrain3d.SetActive(false);
                    cube2d_terrain3d.SetActive(false);
                    cube2d_terrain2d_2.SetActive(false);
                    cube3d_terrain2d_2.SetActive(false);
                }
            }
    }


    public void VisiblePolygonHeight(int id, float h)   {

        if(Int32.Parse(this.name) == id)    {
            barHeight = h;
            // cube2d_terrain2d.transform.localScale = new Vector3(40, 30, h);
            cube3d_terrain2d.transform.localScale = new Vector3(40, h, 40);
            cube3d_terrain3d.transform.localScale = new Vector3(40, h, 40);
            cube2d_terrain3d.transform.localScale = new Vector3(40, h, 10);
            cube2d_terrain2d_2.transform.localScale = new Vector3(40, h, 10);
            // cube3d_terrain2d_2.transform.localScale = new Vector3(40, h, 40);

            cube3d_terrain3d.transform.position = SnapTo3DTerrainHeightmap(cube3d_terrain3d.transform.position);
            cube3d_terrain2d.transform.position = SnapTo2DTerrainHeightmap(cube3d_terrain2d.transform.position);
            cube2d_terrain3d.transform.position = SnapTo3DTerrainHeightmap(cube2d_terrain3d.transform.position);
            // cube2d_terrain2d.transform.position = SnapTo2DTerrainHeightmap(cube2d_terrain2d.transform.position);
            cube2d_terrain2d_2.transform.position = SnapTo2DTerrainHeightmap(cube2d_terrain2d.transform.position);
            // cube3d_terrain2d_2.transform.position = SnapTo2DTerrainHeightmap(cube3d_terrain2d_2.transform.position);

            TransformCube(cube3d_terrain2d);
            TransformCube(cube3d_terrain3d);
            // TransformCube(cube3d_terrain2d_2);
            TransformCube2D(cube2d_terrain2d_2);
            TransformCube2D(cube2d_terrain3d);
            // TransformCube2D(cube2d_terrain2d);

            print("Height: " + h + " cube2d scale: " + cube2d_terrain3d.transform.localScale.y);
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

    public void ResetBars() {

        cube3d_terrain3d.transform.localScale = cube3DScale;
        cube2d_terrain3d.transform.localScale = cube2DScale;
        cube3d_terrain2d.transform.localScale = cube3DScale;
        cube2d_terrain2d_2.transform.localScale = cube2DScale;
        cube3d_terrain2d_2.transform.localScale = cube3DScale;
        cube2d_terrain2d.transform.localScale = cube2DScale;

        barHeight =(140 * reader.GetVSC(Int32.Parse(this.name))) + 50;
        // Cube3DTerrain2D(cube3d_terrain2d);
        // Cube3DTerrain3D(cube3d_terrain3d);
        // Cube2DTerrain2D(cube2d_terrain2d);
        // Cube2DTerrain2D_2(cube2d_terrain2d_2);
        // Cube2DTerrain3D(cube2d_terrain3d);
        // Cube3DTerrain2D_2(cube3d_terrain2d_2);
    }

    public float GetHeight(int id)    {
        if(Int32.Parse(this.name) == id)    {
            return barHeight;
        }

        return 0;
    }

    public float GetWidth(int id)   {
        if(Int32.Parse(this.name) == id)    {
            Vector3 leftWorld = transform.localToWorldMatrix * new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 rightWorld = transform.localToWorldMatrix * new Vector3(-0.5f, 0.5f, 0.5f);
        // print("World Left : " + leftWorld);
        // print("World Right : " + rightWorld);
            Vector3 leftScreen = cam3d2d.WorldToScreenPoint(leftWorld);
            Vector3 rightScreen = cam3d2d.WorldToScreenPoint(rightWorld);
        // print("Screen Left : " + leftScreen);
        // print("Screen Right : " + rightScreen);
            float width = Vector3.Distance(leftScreen, rightScreen);
        // print("Width : " + width);
            return width;
        }

        return 0;
    }

    public void SetWidth(int id, float scale)   {

    }

    public void SetBarShader(bool b, int value) {
        if(b == true)   {
            cube2d_terrain3d.GetComponent<Renderer>().material = barMaterial_unlit_Ztest_Off;
        }else{
            cube2d_terrain3d.GetComponent<Renderer>().material = barMaterial_unlit;;  
        }

        if(value == 1)  {
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.red); 

            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.9f); 
        }else{
            cube2d_terrain3d.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
 
            cube2d_terrain3d.GetComponent<Renderer>().material.SetFloat("_Alpha", 0.7f); 
        }
    }

    public float BarPositionHeight()    {
        Vector3 position = SnapTo3DTerrainHeightmap(parent_.transform.position);
        return position.y;
    }

    // public int GetBarValue()    {
    //     return barValue;
    // }
}
