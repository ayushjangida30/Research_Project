using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Movement2D : MonoBehaviour
{
    private float mainSpeed = 20f;
    private float extraSpeed = 20f;

    public BarManager manager;
    public Movement movement3d3d;
    public Movement movement3d2d;
    public Movement movement2d3d;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        LayerMask layerMask = LayerMask.GetMask("cube_2d_terrain_2d");

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask)) {
            Transform objectHit = hit.transform;
            if(Input.GetMouseButtonDown(0)){
                manager.SetSelectedBarColor(objectHit.gameObject.name);
            }

            if(Input.GetMouseButtonDown(1)){
                manager.SetDeselectedBarColor(objectHit.gameObject.name);
            }

            
            // Do something with the object that was hit by the raycast.
        }

    }

    void FixedUpdate()  {
        Vector3 currPos = this.transform.position;

        Vector3 displacement = GetBaseInput();
        displacement *= mainSpeed;
        if(Input.GetKey(KeyCode.LeftShift)) {
            Vector3 newDisplacement = displacement * extraSpeed;
            transform.Translate(newDisplacement);
        }
        transform.Translate(displacement);

        Vector3 newPos = this.transform.position;
        if(newPos != currPos)   {
            movement3d3d.SetPosition(displacement);
            movement2d3d.SetPosition(displacement);
            movement3d2d.SetPosition(displacement);
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

    private Vector3 GetBaseInput() {
        Vector3 currPos = this.transform.position;
        Vector3 velocity = Vector3.zero;

        if(Input.GetKey(KeyCode.RightArrow)) {
            velocity += new Vector3(1, 0, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)) {
            velocity -= new Vector3(1, 0, 0);
        }
        // if(Input.GetKey(KeyCode.E)) {
        //     velocity += new Vector3(0, 1, 0);
        // }
        // if(Input.GetKey(KeyCode.Q)) {
        //     velocity -= new Vector3(0, 1, 0);
        // }
        if(Input.GetKey(KeyCode.UpArrow)) {
            velocity += new Vector3(0, 1, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow)) {
            velocity -= new Vector3(0, 1, 0);
        }

        return velocity;
    }

    public void SetPosition(Vector3 terrainPos, Vector3 cameraPos) {
        Vector3 currPos = this.transform.position;
        this.transform.position = new Vector3(terrainPos.x, currPos.y, terrainPos.z);
        
    }

    public void SetHeight(float diff)   {
        
    }

    // public void SetPosition(float angle, Vector3 camera3d)  {
    //     Vector3 currPos = this.transform.position;
    //     Debug.Log("2D actual pos: " + currPos);
    //     this.transform.position = new Vector3(camera3d.x, currPos.y, (camera3d.y / Mathf.Tan(angle) + camera3d.z));
    //     Debug.Log("New pos: " + this.transform.position);
    // }
}
