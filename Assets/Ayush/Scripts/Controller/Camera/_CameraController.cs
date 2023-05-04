using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CameraController : MonoBehaviour
{
    GameObject[] camera_2d;
    GameObject[] camera_3d;

    // Start is called before the first frame update
    void Start()
    {
        camera_2d = GameObject.FindGameObjectsWithTag("2D_Terrain_Camera");
        camera_3d = GameObject.FindGameObjectsWithTag("3D_Terrain_Camera");

        for(int i = 0; i < camera_2d.Length; i++)   {
            if(camera_2d[i].gameObject.name == "2D_2D")    {
                camera_2d[i].gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Terrain", "MKRF", "2D_Terrain", "cube_2d_terrain_2d", "VQC_Mesh", "capsule_2d_terrain_2d");
                continue;
            }

            if(camera_2d[i].gameObject.name == "2D_2D_2")    {
                camera_2d[i].gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Terrain", "MKRF", "2D_Terrain", "cube_2d_terrain_2d_2", "VQC_Mesh", "capsule_2d_terrain_2d_2");
                continue;
            }

            if(camera_2d[i].gameObject.name == "2D_3D_2")    {
                camera_2d[i].gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Terrain", "MKRF", "2D_Terrain", "cube_3d_terrain_2d_2", "VQC_Mesh", "capsule_3d_terrain_2d_2");
                continue;
            }

            camera_2d[i].gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Terrain", "MKRF", "2D_Terrain", "cube_3d_terrain_2d", "VQC_Mesh", "capsule_3d_terrain_2d");
        }

        for(int i = 0; i < camera_3d.Length; i++)   {
            if(camera_3d[i].gameObject.name == "3D_2D")    {
                camera_3d[i].gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Terrain", "MKRF", "3D_Terrain", "cube_2d_terrain_3d", "VQC_Mesh", "capsule_2d_terrain_3d");
                continue;
            }
            camera_3d[i].gameObject.GetComponent<Camera>().cullingMask = LayerMask.GetMask("Default", "TransparentFX", "Ignore Raycast", "Water", "UI", "Terrain", "MKRF", "3D_Terrain", "cube_3d_terrain_3d", "VQC_Mesh", "capsule_3d_terrain_3d");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
