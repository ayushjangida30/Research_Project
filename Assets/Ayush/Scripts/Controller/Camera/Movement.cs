using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Movement : MonoBehaviour
{
    private float mainSpeed = 20f;
    private float extraSpeed = 20f;
    // private float xRotation = 0f;
    // private float mouseSensitivity = 500f;
    
    private bool something = false;

    private float speed = 2f;

    private float yaw = 0f;
    private float pitch = 0f;

    private float clickDuration = 2;

    public vsc_geojson_reader reader;

    public BarManager barManager;
    public ViewpointManager viewpointManager;
    public LinkManager linkManager;
    public Movement2D movement2d;
    public Movement2D movement2d_3d_2;
    public PolygonManager polygonManager;
    public MainController mainController;
    public ToolTipManager tooltipManager;
    public TooltipViewpointManager tooltipViewpointManager;

    public Camera camera_3d_3d;


    private LayerMask layerMask;

    private bool click = false;

    private List<string> objectSelected;
    // Start is called before the first frame update
    void Start()
    {
        objectSelected = new List<string>();

        Vector3 terrainPos = GetTerrainPos(this.transform.position);
        movement2d.SetPosition(terrainPos, this.transform.position, Vector3.Distance(this.transform.position, terrainPos) / 4.5f, camera_3d_3d);
        movement2d_3d_2.SetPosition(terrainPos, this.transform.position, Vector3.Distance(this.transform.position, terrainPos) / 4.5f, camera_3d_3d);
    }

    // Update is called once per frame
    void Update()
    {
        // Below if for tooltip selection
        if(mainController.task1 || mainController.task2 || mainController.task3 || mainController.task4 || mainController.task5)    {
            RaycastHit hit;
            Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

            if(!linkManager.GetInvisibleStatus())    {
                print(linkManager.GetInvisibleStatus());
                if(this.name == "3D_3D")    layerMask = LayerMask.GetMask("cube_3d_terrain_3d");
                if(this.name == "3D_2D")    layerMask = LayerMask.GetMask("cube_2d_terrain_3d");
                if(this.name == "2D_3D")    layerMask = LayerMask.GetMask("cube_3d_terrain_2d");
                if(this.name == "2D_2D_2")  layerMask = LayerMask.GetMask("cube_2d_terrain_2d_2");
                // layerMask = LayerMask.GetMask("VQC_Mesh");
                
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                    Transform objectHit = hit.transform;
                    int vsc = reader.GetVSC(Int32.Parse(objectHit.gameObject.name));
                    // tooltipManager.SetToolTip(objectHit.gameObject.name, vsc);
                    if(!(mainController.task3_part1 || mainController.task3_part2 || mainController.task4)) {
                        if(Input.GetMouseButtonDown(0)){
                            print(objectHit.gameObject.name);
                            barManager.SetSelectedBarColor(objectHit.gameObject.name);
                            polygonManager.SetSelectedPolygonColor(objectHit.gameObject.name);
                            // polygonManager.SetSelectedPolygon(objectHit.gameObject.name);
                        }

                        if(Input.GetMouseButtonDown(1)){
                            barManager.SetDeselectedBarColor(objectHit.gameObject.name);
                            polygonManager.SetDeselectedPolygonColor(objectHit.gameObject.name);
                        }
                    }
                    
                }else{
                    tooltipManager.HideToolTip();
                }

            }else{
                // print(linkManager.GetInvisibleStatus());
                // layerMask = LayerMask.GetMask("3D_Terrain");

                // if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                //     Transform objectHit = hit.transform;

                //     if(Input.GetMouseButtonDown(0)){
                //         // print(objectHit.gameObject.name + "VQC");
                //         barManager.SetSelectedBarColor(objectHit.gameObject.name);
                //         polygonManager.SetSelectedPolygonColor(objectHit.gameObject.name);
                //         // polygonManager.SetSelectedPolygon(objectHit.gameObject.name);
                //     }

                //     if(Input.GetMouseButtonDown(1)){
                //         barManager.SetDeselectedBarColor(objectHit.gameObject.name);
                //         polygonManager.SetDeselectedPolygonColor(objectHit.gameObject.name);
                //     }
                // }

            }

            if(this.name == "3D_3D")    layerMask = LayerMask.GetMask("capsule_3d_terrain_3d");
            if(this.name == "3D_2D")    layerMask = LayerMask.GetMask("capsule_2d_terrain_3d");
            if(this.name == "2D_3D")    layerMask = LayerMask.GetMask("capsule_3d_terrain_2d");
            if(this.name == "2D_2D_2")  layerMask = LayerMask.GetMask("capsule_2d_terrain_2d_2");
        
            // for viewpoint
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                Transform objectHit = hit.transform;
                // tooltipViewpointManager.SetToolTip(objectHit.gameObject.name);
                if(mainController.task5)    tooltipViewpointManager.SetToolTip(objectHit.gameObject.name);
                // below if for viewpoint selection
                if(!(mainController.task1 || mainController.task2 || mainController.task3_part1))    {    
                    if(Input.GetMouseButtonDown(0)){
                        // print(objectHit.gameObject.name);
                        if(objectSelected.Contains(objectHit.gameObject.name))   {
                            // Debug.Log("Double click");
                            linkManager.SetViewPointSelected_Invisible(objectHit.gameObject.name);
                            objectSelected.Remove(objectHit.gameObject.name);
                        }else{
                            linkManager.SetViewPointSelected_Visible(objectHit.gameObject.name);
                            if(!(mainController.task3_part2 || mainController.task4))  objectSelected.Add(objectHit.gameObject.name);
                        }
                    }

                    if(Input.GetMouseButtonDown(1)){
                        linkManager.SetViewPointDeselected(objectHit.gameObject.name);
                    }
                }
                

            }else{
                tooltipViewpointManager.HideToolTip();
            }
        }
        


        if(Input.GetMouseButtonDown(2)){
            something = true;
        }

        if(Input.GetMouseButtonUp(2)){
            something = false;
        }

    }


    // void FixedUpdate()  {
    //     if(!(mainController.task1 || mainController.task2 || mainController.task3_part1))   {
    //         Vector3 currPos = this.transform.position;

    //         Vector3 displacement = GetBaseInput();
    //         displacement *= mainSpeed;
    //         if(Input.GetKey(KeyCode.LeftShift)) {
    //             Vector3 newDisplacement = displacement * extraSpeed;
    //             transform.Translate(newDisplacement);
    //         }

    //         transform.Translate(displacement);
    //         barManager.TransformCube();
    //         viewpointManager.TransformCapsule();

    //         Vector3 newPos = this.transform.position;
    //         if(newPos != currPos)   {
    //             Vector3 terrainPos = GetTerrainPos(this.transform.position);
    //             float width = this.GetComponent<Camera>().pixelRect.width / 2;
    //             Vector2 screenPos;
    //             Vector3 lowerBoundTerrainPos;
    //             if(this.name == "2D_3D")    {
    //                 // Debug.Log(Input.mousePosition);
    //                 screenPos = new Vector2(this.GetComponent<Camera>().pixelRect.x + this.GetComponent<Camera>().pixelRect.width, this.GetComponent<Camera>().pixelRect.y + this.GetComponent<Camera>().pixelRect.height);
    //                 lowerBoundTerrainPos = GetLowerBoundTerrainPos(this.transform.position, screenPos);
    //                 Debug.Log(lowerBoundTerrainPos);
    //             }
    //             movement2d.SetPosition(terrainPos, this.transform.position, Vector3.Distance(this.transform.position, terrainPos) / 4.5f);
    //             movement2d_3d_2.SetPosition(terrainPos, this.transform.position, Vector3.Distance(this.transform.position, terrainPos) / 4.5f);
    //             movement2d.SetDistance(Vector3.Distance(this.transform.position, terrainPos) / 4.5f);
    //             movement2d_3d_2.SetDistance(Vector3.Distance(this.transform.position, terrainPos) / 4.5f);
    //             // barManager.CalculateNewDist();
    //         }


    //         // if(Input.GetMouseButton(2))
    //         // {
    
    //         //     yaw += speed * Input.GetAxis("Mouse X");
    //         //     pitch -= speed * Input.GetAxis("Mouse Y");

    //         //     this.gameObject.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    //         //     Vector3 terrainPos = GetTerrainPos(this.transform.position);
    //         //     movement2d.SetPosition(terrainPos, this.transform.position, (Vector3.Distance(this.transform.position, this.GetComponent<Movement>().GetTerrainPos(this.gameObject.transform.position)) / 4.5f));
    //         //     movement2d_3d_2.SetPosition(terrainPos, this.transform.position, (Vector3.Distance(this.transform.position, this.GetComponent<Movement>().GetTerrainPos(this.gameObject.transform.position)) / 4.5f));
    //         //     movement2d.SetDistance(Vector3.Distance(this.transform.position, this.GetComponent<Movement>().GetTerrainPos(this.gameObject.transform.position)) / 4.5f);
    //         //     movement2d_3d_2.SetDistance(Vector3.Distance(this.transform.position, this.GetComponent<Movement>().GetTerrainPos(this.gameObject.transform.position)) / 4.5f);
    //         //     if(this.gameObject.transform.eulerAngles.x >= 75)   {
    //         //         barManager.SetShader(true);
    //         //     }else{
    //         //         barManager.SetShader(false);
    //         //     }
                
    //         //     barManager.TransformCube();
    //         //     viewpointManager.TransformCapsule();
    //         // // barManager.CalculateNewDist();
    //         // }

    //         // if(this.gameObject.transform.eulerAngles.x >= 75)   {
    //         //     barManager.SetShader(true);
    //         // }else{
    //         //     barManager.SetShader(false);
    //         // }

    //         // if(Input.GetMouseButton(2))
    //         // {
    //         //     yaw += speed * Input.GetAxis("Mouse X");
    //         //     pitch -= speed * Input.GetAxis("Mouse Y");

    //         //     this.gameObject.transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    //         //     Vector3 terrainPos = GetTerrainPos(this.transform.position);
    //         //     // movement2d.SetPosition(terrainPos, this.transform.position, (Vector3.Distance(this.transform.position, this.GetComponent<Movement>().GetTerrainPos(this.gameObject.transform.position)) / 4.5f));
    //         //     // movement2d_3d_2.SetPosition(terrainPos, this.transform.position, (Vector3.Distance(this.transform.position, this.GetComponent<Movement>().GetTerrainPos(this.gameObject.transform.position)) / 4.5f));
    //         //     // movement2d.SetDistance(Vector3.Distance(this.transform.position, camera_3d_3d.GetComponent<Movement>().GetTerrainPos(camera_3d_3d.gameObject.transform.position)) / 4.5f);
    //         //     // movement2d_3d_2.SetDistance(Vector3.Distance(this.transform.position, camera_3d_3d.GetComponent<Movement>().GetTerrainPos(camera_3d_3d.gameObject.transform.position)) / 4.5f);
    //         //     if(this.gameObject.transform.eulerAngles.x >= 75)   {
    //         //         barManager.SetShader(true);
    //         //     }else{
    //         //         barManager.SetShader(false);
    //         //     }
                
    //         //     barManager.TransformCube();
    //         //     viewpointManager.TransformCapsule();
    //         // // barManager.CalculateNewDist();
    //         // }
    //     }
        
    // }

    public Vector3 GetTerrainPos(Vector3 position) {
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("3D_Terrain");
        if(Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))    {
            return hit.point;
        }
        else{
            return Vector3.zero;
        }
    }

    private Vector3 GetLowerBoundTerrainPos(Vector3 position, Vector2 screenPos)   {
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("2D_Terrain");

        if(Physics.Raycast(this.GetComponent<Camera>().ScreenPointToRay(screenPos), out hit, Mathf.Infinity))    {
            return hit.point;
        }
        else    {
            return Vector3.zero;
        } 
    }


    private Vector3 GetBaseInput() {
        Vector3 velocity = Vector3.zero;

        if(Input.GetKey(KeyCode.D)) {
            velocity += new Vector3(1, 0, 0);
        }
        if(Input.GetKey(KeyCode.A)) {
            velocity -= new Vector3(1, 0, 0);
        }
        if(Input.GetKey(KeyCode.E)) {
            velocity += new Vector3(0, 1, 0);
        }
        if(Input.GetKey(KeyCode.Q)) {
            velocity -= new Vector3(0, 1, 0);
        }
        if(Input.GetKey(KeyCode.W)) {
            velocity += new Vector3(0, 0, 1);
        }
        if(Input.GetKey(KeyCode.S)) {
            velocity -= new Vector3(0, 0, 1);
        }

        return velocity;
    }

    public void SetPosition(Vector3 position, float distance)  {
        Vector3 currTerrainPos = GetTerrainPos(this.transform.position);
        Vector3 displacement = position - currTerrainPos;
        this.transform.position = new Vector3(this.transform.position.x + displacement.x, this.transform.position.y, this.transform.position.z + displacement.z);
        // Vector3 currTerrainPos = GetTerrainPos(this.transform.position);
        // Vector3 currPos = this.transform.position;
        
        // float dispX = displacement.x;
        // float dispZ = displacement.y;

        // this.transform.position = new Vector3((currPos.x + dispX), currPos.y, (currPos.z + dispZ));

        // this.transform.LookAt(position);
        SetDistance(distance);
    }

    public void SetDistance(float distance) {
        Vector3 direction = ((this.transform.position - GetTerrainPos(this.transform.position))).normalized;
        Vector3 endpoint = GetTerrainPos(this.transform.position) + (direction * distance);
        this.transform.position = endpoint;
    }

    private void ResetMovement() {
        objectSelected.Clear();
    }
}
