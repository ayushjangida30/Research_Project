using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Movement2D : MonoBehaviour
{
    
    public Movement movement3d3d;
    public Movement movement3d2d;
    public Movement movement2d3d;
    public Movement movement2d2d;

    private bool something = false;

    private float speed = 2f;
    private float mainSpeed = 20f;
    private float extraSpeed = 20f;
    private float orthographicSize = 1150;

    private float yaw = 0f;
    private float pitch = 0f;

    private float clickDuration = 2;

    public vsc_geojson_reader reader;

    public BarManager barManager;
    public ViewpointManager viewpointManager;
    public LinkManager linkManager;
    public Movement2D movement2d;
    public PolygonManager polygonManager;
    public MainController mainController;
    public ToolTipManager tooltipManager;
    public TooltipViewpointManager tooltipViewpointManager;
    private float height = 10f;
    private float width = 10f;
    private float angle = 0f;


    private LayerMask layerMask;

    private bool click = false;

    private List<string> objectSelected;

    public Image indicator;
    public Canvas canvas;
    private RectTransform canvasRect;
    // Start is called before the first frame update
    void Start()
    {
        objectSelected = new List<string>();
        this.orthographicSize = 100;
        canvasRect = canvas.GetComponent<RectTransform>();
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
                if(this.name == "2D_2D")  layerMask = LayerMask.GetMask("cube_2d_terrain_2d");
                if(this.name == "2D_3D_2")  layerMask = LayerMask.GetMask("cube_3d_terrain_2d_2");
                // layerMask = LayerMask.GetMask("VQC_Mesh");
                
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                    Transform objectHit = hit.transform;
                    int vsc = reader.GetVSC(Int32.Parse(objectHit.gameObject.name));
                    // tooltipManager.SetToolTip(objectHit.gameObject.name, vsc);
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
                print("rea");
                layerMask = LayerMask.GetMask("2D_Terrain");

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                    if(Input.GetMouseButtonDown(0)){
                        // print(objectHit.gameObject.name + "VQC");
                        Vector3 pos = hit.point;
                        pos = new Vector3(pos.x, pos.y + 10000, pos.z);
                        print(pos + "2D2D");
                        LayerMask layerMask_ = LayerMask.GetMask("VQC_Mesh");
                        if(Physics.Raycast(pos, transform.TransformDirection(Vector3.down), out hit, Mathf.Infinity, layerMask_))   {
                            Transform objectHit = hit.transform;
                            print(objectHit.gameObject.name + "2D2D");
                        }
                        // barManager.SetSelectedBarColor(objectHit.gameObject.name);
                        // polygonManager.SetSelectedPolygonColor(objectHit.gameObject.name);
                        // polygonManager.SetSelectedPolygon(objectHit.gameObject.name);
                    }

                    if(Input.GetMouseButtonDown(1)){
                        // barManager.SetDeselectedBarColor(objectHit.gameObject.name);
                        // polygonManager.SetDeselectedPolygonColor(objectHit.gameObject.name);
                    }
                }

            }

            if(this.name == "2D_2D")  layerMask = LayerMask.GetMask("capsule_2d_terrain_2d");
            if(this.name == "2D_3D_2")  layerMask = LayerMask.GetMask("capsule_3d_terrain_2d_2");
        
            // for viewpoint
            
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
                Transform objectHit = hit.transform;
                // tooltipManager.SetToolTip(objectHit.gameObject.name);
                if(mainController.task5)    tooltipViewpointManager.SetToolTip(objectHit.gameObject.name);
                // below if for viewpoint selection
                if(!(mainController.task1 || mainController.task2))    {    
                    if(Input.GetMouseButtonDown(0)){
                        // print(objectHit.gameObject.name);
                        if(objectSelected.Contains(objectHit.gameObject.name))   {
                            // Debug.Log("Double click");
                            linkManager.SetViewPointSelected_Invisible(objectHit.gameObject.name);
                            objectSelected.Remove(objectHit.gameObject.name);
                        }else{
                            linkManager.SetViewPointSelected_Visible(objectHit.gameObject.name);
                            objectSelected.Add(objectHit.gameObject.name);
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

    }


    void FixedUpdate()  {
        

    }

    public void CameraMovement()    {
        Vector3 currPos = this.transform.position;

        Vector3 displacement = GetBaseInput();
        displacement *= mainSpeed;
        if(Input.GetKey(KeyCode.LeftShift)) {
            Vector3 newDisplacement = displacement * extraSpeed;
            transform.Translate(newDisplacement);
        }
        if(Input.GetKey(KeyCode.Q))    {
            // orthographicSize += 3;
            this.GetComponent<Camera>().orthographicSize += 10;
            movement3d3d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement3d2d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement2d3d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement2d2d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
        }
        if(Input.GetKey(KeyCode.E)) {
            // orthographicSize -= 3;
            this.GetComponent<Camera>().orthographicSize -= 10; 
            movement3d3d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement3d2d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement2d3d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement2d2d.SetDistance(this.GetComponent<Camera>().orthographicSize * 4.5f);
        }
        //transform.Translate(displacement);
        transform.position = currPos + displacement;
        Vector3 terrainPos = GetTerrainPos(transform.position);
        Vector3 terrainPos2D = GetTerrainPos2D(transform.position);

        Vector3 newPos = this.transform.position;
        if(newPos != currPos)   {
            Vector3 displacement_ = new Vector3(displacement.x, displacement.z, displacement.y);
            movement3d3d.SetPosition(terrainPos, this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement3d2d.SetPosition(terrainPos, this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement2d3d.SetPosition(terrainPos2D, this.GetComponent<Camera>().orthographicSize * 4.5f);
            movement2d2d.SetPosition(terrainPos2D, this.GetComponent<Camera>().orthographicSize * 4.5f);
        }
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

    private Vector3 GetTerrainPos2D(Vector3 position) {
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("2D_Terrain");
        if(Physics.Raycast(position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))    {
            return hit.point;
        }
        else{
            return Vector3.zero;
        }
    }

    private Vector3 GetBaseInput() {
        Vector3 currPos = this.transform.position;
        Vector3 velocity = Vector3.zero;

            if(Input.GetKey(KeyCode.D)) {
                velocity += new Vector3(Mathf.Sin((angle+90) * Mathf.Deg2Rad), 0, Mathf.Cos((angle+90) * Mathf.Deg2Rad));
            }else if(Input.GetKey(KeyCode.A)) {
                velocity -= new Vector3(Mathf.Sin((angle+90) * Mathf.Deg2Rad), 0, Mathf.Cos((angle+90) * Mathf.Deg2Rad));
            }else if(Input.GetKey(KeyCode.W)) {
                velocity += new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
            }else if(Input.GetKey(KeyCode.S)) {
                velocity -=  new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
            }
        
        // }else if(Input.GetKey(KeyCode.Equals))  {
        //     velocity += new Vector3(0, 1, 0);
        // }else if(Input.GetKey(KeyCode.Minus))  {
        //     velocity -= new Vector3(0, 1, 0);
        // }

        return velocity;
    }

    public void SetPosition(Vector3 terrainPos, Vector3 cameraPos, float distance, Camera camera_3d) {
        Vector3 currPos = this.transform.position;
        if(this.name == "2D_2D")    this.transform.position = new Vector3(terrainPos.x, currPos.y, terrainPos.z);
        // else                        this.transform.position = new Vector3(terrainPos.x, currPos.y, terrainPos.z);   //-6226.494f

        this.GetComponent<Camera>().orthographicSize = distance;

        //  Vector2 dist = (this.transform.position - cameraPos).maginitude;
        //  var direction = haeding/dist;
        //  float angle = Vector2.Angle(direction, new Vector2(1,0));
        //  print("Camera Direction: " + angle);

        angle = camera_3d.transform.rotation.eulerAngles.y;
        print("camera angle is: " + angle);
        indicator.transform.rotation = Quaternion.Euler(new Vector3(-90,0,angle));

        if(this.name == "2D_2D")    {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(90,0,-angle));
        }

        if(this.name == "2D_3D_2")  {
            this.gameObject.transform.rotation = Quaternion.Euler(new Vector3(30,angle,0));
            float zDist = Mathf.Cos(angle * Mathf.Deg2Rad) * 6226.494f;
            float xDist = Mathf.Sin(angle * Mathf.Deg2Rad) * 6226.494f;
            print("X: " + xDist + " Z: " + zDist + " Angle: " + angle + "Cos: " + Mathf.Cos(angle) + " Sin: " + Mathf.Sin(angle));

            this.transform.position = new Vector3(terrainPos.x - xDist, currPos.y, terrainPos.z - zDist);
            
        }

        

        // if(targetPos.z >= 0f && targetPos.x <= canvasRect.rect.width * canvasRect.localScale.x
        // && targetPos.y <= canvasRect.rect.height * canvasRect.localScale.x && targetPos.x >= 0f && targetPos.y >= 0f)   {}

        // else{

        // }
        
    }

    public void SetHeight(float diff)   {
        
    }

    private void ResetMovement() {
        objectSelected.Clear();
    }

    public void SetDistance(float distance) {
        this.GetComponent<Camera>().orthographicSize = distance;
    }

    // public void SetPosition(float angle, Vector3 camera3d)  {
    //     Vector3 currPos = this.transform.position;
    //     Debug.Log("2D actual pos: " + currPos);
    //     this.transform.position = new Vector3(camera3d.x, currPos.y, (camera3d.y / Mathf.Tan(angle) + camera3d.z));
    //     Debug.Log("New pos: " + this.transform.position);
    // }
}
