using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RayCastMethod : MonoBehaviour
{

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
    public Camera camera_3d_2d;
    public Camera camera_2d_3d;
    public Camera camera_2d_2d_2;

    private LayerMask layerMask;
    private List<string> objectSelected;

    private float speed = 2f;
    private float mainSpeed = 20f;
    private float extraSpeed = 20f;

    // private float yaw = 0f;
    // private float pitch = 0f;

    void Start()
    {
        objectSelected = new List<string>();
        mainController.yaw = camera_3d_3d.transform.rotation.eulerAngles.y;
        mainController.pitch = camera_3d_3d.transform.rotation.eulerAngles.x;
    }

    public void ResetMovement() {
        objectSelected.Clear();
    }

    private Vector3 GetTerrainPos(Vector3 position) {
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("3D_Terrain");
        if(Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))    {
            return hit.point;
        }
        else{
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

    public void RaycastObject(Vector3 mousePos)  {

        if(this.name == "3D_3D" || this.name == "3D_2D" || this.name == "2D_3D" || this.name == "2D_2D_2")    {
            if(Input.GetMouseButton(2))
            {
            if(!(mainController.task1 || mainController.task2))   {
                mainController.yaw += speed * Input.GetAxis("Mouse X");
                mainController.pitch -= speed * Input.GetAxis("Mouse Y");

                camera_3d_3d.gameObject.transform.eulerAngles = new Vector3(mainController.pitch, mainController.yaw, 0f);
                camera_3d_2d.gameObject.transform.eulerAngles = new Vector3(mainController.pitch, mainController.yaw, 0f);
                camera_2d_3d.gameObject.transform.eulerAngles = new Vector3(mainController.pitch, mainController.yaw, 0f);
                camera_2d_2d_2.gameObject.transform.eulerAngles = new Vector3(mainController.pitch, mainController.yaw, 0f);
                Vector3 terrainPos = GetTerrainPos(this.transform.position);
                movement2d.SetPosition(terrainPos, this.transform.position, (Vector3.Distance(this.transform.position, camera_3d_3d.GetComponent<Movement>().GetTerrainPos(camera_3d_3d.gameObject.transform.position)) / 4.5f), camera_3d_3d);
                movement2d_3d_2.SetPosition(terrainPos, this.transform.position, (Vector3.Distance(this.transform.position, camera_3d_3d.GetComponent<Movement>().GetTerrainPos(camera_3d_3d.gameObject.transform.position)) / 4.5f), camera_3d_3d);
                // movement2d.SetDistance(Vector3.Distance(this.transform.position, camera_3d_3d.GetComponent<Movement>().GetTerrainPos(camera_3d_3d.gameObject.transform.position)) / 4.5f);
                // movement2d_3d_2.SetDistance(Vector3.Distance(this.transform.position, camera_3d_3d.GetComponent<Movement>().GetTerrainPos(camera_3d_3d.gameObject.transform.position)) / 4.5f);
                if(this.gameObject.transform.eulerAngles.x >= 75)   {
                    barManager.SetShader(true);
                }else{
                    barManager.SetShader(false);
                }
                
                barManager.TransformCube();
                viewpointManager.TransformCapsule();
            }
            // barManager.CalculateNewDist();
            }

            if(!(mainController.task1 || mainController.task2))   {
               Vector3 currPos = this.transform.position;

                Vector3 displacement = GetBaseInput();
                displacement *= mainSpeed;
                if(Input.GetKey(KeyCode.LeftShift)) {
                    Vector3 newDisplacement = displacement * extraSpeed;
                    camera_3d_3d.gameObject.transform.Translate(displacement);
                    camera_3d_2d.gameObject.transform.Translate(displacement);
                    camera_2d_3d.gameObject.transform.Translate(displacement);
                    camera_2d_2d_2.gameObject.transform.Translate(displacement);
                }

                camera_3d_3d.gameObject.transform.Translate(displacement);
                camera_3d_2d.gameObject.transform.Translate(displacement);
                camera_2d_3d.gameObject.transform.Translate(displacement);
                camera_2d_2d_2.gameObject.transform.Translate(displacement);
                // transform.Translate(displacement);
                barManager.TransformCube();
                viewpointManager.TransformCapsule();

                Vector3 newPos = this.transform.position;
                if(newPos != currPos)   {
                    Vector3 terrainPos = GetTerrainPos(this.transform.position);
                    float width = this.GetComponent<Camera>().pixelRect.width / 2;
                    Vector2 screenPos;
                    Vector3 lowerBoundTerrainPos;
                    if(this.name == "2D_3D")    {
                        // Debug.Log(Input.mousePosition);
                        screenPos = new Vector2(this.GetComponent<Camera>().pixelRect.x + this.GetComponent<Camera>().pixelRect.width, this.GetComponent<Camera>().pixelRect.y + this.GetComponent<Camera>().pixelRect.height);
                        lowerBoundTerrainPos = GetLowerBoundTerrainPos(this.transform.position, screenPos);
                        Debug.Log(lowerBoundTerrainPos);
                    }
                    movement2d.SetPosition(terrainPos, this.transform.position, Vector3.Distance(this.transform.position, terrainPos) / 4.5f, camera_3d_3d);
                    movement2d_3d_2.SetPosition(terrainPos, this.transform.position, Vector3.Distance(this.transform.position, terrainPos) / 4.5f, camera_3d_3d);
                    movement2d.SetDistance(Vector3.Distance(this.transform.position, terrainPos) / 4.5f);
                    movement2d_3d_2.SetDistance(Vector3.Distance(this.transform.position, terrainPos) / 4.5f);
                // barManager.CalculateNewDist();
            }
            }

        }

        if(this.name == "2D_2D" || this.name == "2D_3D_2")  {
            movement2d.CameraMovement();
            movement2d_3d_2.CameraMovement();
        }


        RaycastHit hit;
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(mousePos);

        if(!linkManager.GetInvisibleStatus())   {
            if(this.name == "3D_3D")    layerMask = LayerMask.GetMask("cube_3d_terrain_3d");
            if(this.name == "3D_2D")    layerMask = LayerMask.GetMask("cube_2d_terrain_3d");
            if(this.name == "2D_3D")    layerMask = LayerMask.GetMask("cube_3d_terrain_2d");
            if(this.name == "2D_2D_2")  layerMask = LayerMask.GetMask("cube_2d_terrain_2d_2");
            if(this.name == "2D_2D")    layerMask = LayerMask.GetMask("cube_2d_terrain_2d");
            if(this.name == "2D_3D_2")  layerMask = LayerMask.GetMask("cube_3d_terrain_2d_2");
            // layerMask = LayerMask.GetMask("VQC_Mesh");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                Transform objectHit = hit.transform;
                int vsc = reader.GetVSC(Int32.Parse(objectHit.gameObject.name));
                tooltipManager.SetToolTip(objectHit.gameObject.name, reader.GetVSC(Int32.Parse(objectHit.gameObject.name)), Input.mousePosition);
                print("Code reaching here RayCast method");
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
            }else{
            tooltipManager.HideToolTip();
            }
        }else{
            if(this.name == "2D_3D" || this.name == "2D_2D" || this.name == "2D_2D_2"|| this.name == "2D_3D_2")    {
                layerMask = LayerMask.GetMask("2D_Terrain");

                Vector3 position = new Vector3(0, 0, 0);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))   {
                    position = hit.point;
                    position = new Vector3(position.x, position.y + 10000, position.z);
                    LayerMask layerMask_ = LayerMask.GetMask("VQC_Mesh");
                    if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, layerMask_))   {
                        Transform objectHit = hit.transform;
                        int vsc = reader.GetVSC(Int32.Parse(objectHit.gameObject.name));
                        tooltipManager.SetToolTip(objectHit.gameObject.name,  reader.GetVSC(Int32.Parse(objectHit.gameObject.name)), Input.mousePosition);
                        if(Input.GetMouseButtonDown(0)) {
                            barManager.SetSelectedBarColor(objectHit.gameObject.name);
                            polygonManager.SetSelectedPolygonColor(objectHit.gameObject.name);  
                        }
                        if(Input.GetMouseButtonDown(1)){
                            barManager.SetDeselectedBarColor(objectHit.gameObject.name);
                            polygonManager.SetDeselectedPolygonColor(objectHit.gameObject.name);
                        }
                    }else{
                        tooltipManager.HideToolTip();
                    }
                }
            }

            else if(this.name == "3D_3D" || this.name == "3D_2D")    {
                layerMask = LayerMask.GetMask("3D_Terrain");

                Vector3 position = new Vector3(0, 0, 0);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))   {
                    position = hit.point;
                    position = new Vector3(position.x, position.y + 10000, position.z);
                    LayerMask layerMask_ = LayerMask.GetMask("VQC_Mesh");
                    if (Physics.Raycast(position, Vector3.down, out hit, Mathf.Infinity, layerMask_))   {
                        Transform objectHit = hit.transform;
                        int vsc = reader.GetVSC(Int32.Parse(objectHit.gameObject.name));
                        tooltipManager.SetToolTip(objectHit.gameObject.name,  reader.GetVSC(Int32.Parse(objectHit.gameObject.name)), Input.mousePosition);
                        if(Input.GetMouseButtonDown(0)) {
                            barManager.SetSelectedBarColor(objectHit.gameObject.name);
                            polygonManager.SetSelectedPolygonColor(objectHit.gameObject.name);  
                        }
                        if(Input.GetMouseButtonDown(1)){
                            barManager.SetDeselectedBarColor(objectHit.gameObject.name);
                            polygonManager.SetDeselectedPolygonColor(objectHit.gameObject.name);
                        }
                    }else{
                        tooltipManager.HideToolTip();
                    }
                }
            }

        }

        if(this.name == "3D_3D")    layerMask = LayerMask.GetMask("capsule_3d_terrain_3d");
        if(this.name == "3D_2D")    layerMask = LayerMask.GetMask("capsule_2d_terrain_3d");
        if(this.name == "2D_3D")    layerMask = LayerMask.GetMask("capsule_3d_terrain_2d");
        if(this.name == "2D_2D_2")  layerMask = LayerMask.GetMask("capsule_2d_terrain_2d_2");
        if(this.name == "2D_3D_2")  layerMask = LayerMask.GetMask("capsule_3d_terrain_2d_2");
        if(this.name == "2D_2D")    layerMask = LayerMask.GetMask("capsule_2d_terrain_2d");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            Transform objectHit = hit.transform;
            // tooltipManager.SetToolTip(objectHit.gameObject.name);
            tooltipViewpointManager.SetToolTip(objectHit.gameObject.name, Input.mousePosition);

            if(Input.GetMouseButtonDown(0)){
                print(objectHit.gameObject.name);
                if(objectSelected.Contains(objectHit.gameObject.name))   {
                    Debug.Log("Double click");
                    linkManager.SetViewPointSelected_Invisible(objectHit.gameObject.name);
                    objectSelected.Remove(objectHit.gameObject.name);
                }else{
                    linkManager.SetViewPointSelected_Visible(objectHit.gameObject.name);
                    // if((!mainController.complexTask3))  objectSelected.Add(objectHit.gameObject.name);
                }
            }

            if(Input.GetMouseButtonDown(1)){
                linkManager.SetViewPointDeselected(objectHit.gameObject.name);
            }

            
        }else{
            tooltipViewpointManager.HideToolTip();
        }
    }
}
