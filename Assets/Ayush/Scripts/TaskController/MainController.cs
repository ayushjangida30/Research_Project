using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{
    public PolygonManager polygonManager;
    public BarManager barManager;
    public ViewpointManager viewpointManager;
    public LinkManager linkManager;
    public OutlineManager outlineManager;
    public Movement movement_3d_3d;
    public Movement movement_3d_2d;
    public Movement movement_2d_3d;
    public Movement movement_2d_2d;
    public AnswerController answerController;

    public Button startButton;

    private GameObject[] terrain_3d_list;
    private GameObject[] terrain_2d_list;

    public Camera camera_3d_3d;
    public Camera camera_3d_2d;
    public Camera camera_2d_3d;
    public Camera camera_2d_2d;

    private Vector3 camera_3d_3d_position;
    private Vector3 camera_3d_2d_position;
    private Vector3 camera_2d_3d_position;
    private Vector3 camera_2d_2d_position;

    private List<int> barVisible;
    private List<int> answer_task1;

    public bool task1 = false;
    public bool task2 = false;
    public bool task3 = false;
    public bool task4 = false;
    public bool task5 = false;
    private int task1_count = 0;

    private float task_time;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Initialize", 1.5f);
    }

    private void Initialize()   {
        terrain_3d_list = GameObject.FindGameObjectsWithTag("3D_Terrain");
        terrain_2d_list = GameObject.FindGameObjectsWithTag("2D_Terrain");

        camera_3d_3d_position = camera_3d_3d.gameObject.transform.position;
        camera_3d_2d_position = camera_3d_2d.gameObject.transform.position;
        camera_2d_3d_position = camera_2d_3d.gameObject.transform.position;
        camera_2d_2d_position = camera_2d_2d.gameObject.transform.position;
    }

    public void StartTask_1()   {
        // Search Task
        task1 = true;
        barVisible = new List<int>();
        task_time = Time.time;
        camera_2d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);

        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

            // Search Task
        camera_3d_3d.gameObject.transform.position = new Vector3(3546.886f, 1747.892f, -5259.852f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(11.9f,-39.8f,0);
            
            
        barVisible.Add(1027);
        barVisible.Add(1026);
        barVisible.Add(526);
        barVisible.Add(1001);
        barVisible.Add(523);
        barVisible.Add(518);
        barVisible.Add(513);
        barVisible.Add(134);
        barVisible.Add(521);
        barVisible.Add(196);
        barVisible.Add(198);
        barVisible.Add(142);
        barVisible.Add(161);
        barVisible.Add(780);
        barVisible.Add(760);
        barVisible.Add(763);
        barVisible.Add(765);
        barVisible.Add(776);
        barVisible.Add(757);
        barVisible.Add(754);
        linkManager.CalculateVisibility(barVisible);
        answer_task1 = answerController.Task1_Answer(barVisible);
        barManager.Blink(142);

        startButton.GetComponentInChildren<Text>().text = "Task 2";

        // startButton.gameObject.SetActive(false);
    }

    public void StartTask_2()   {
        // Select the largest bar
        task1 = false;
        task2 = true;
        barVisible = new List<int>();
        task_time = Time.time;
        camera_2d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);

        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

        camera_3d_3d.gameObject.transform.position = new Vector3(2809.399f, 1545.093f, -6146.149f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(11.6f,-62.2f,0);

        barVisible.Add(1043);
        barVisible.Add(1029);
        barVisible.Add(1039);
        barVisible.Add(1035);
        barVisible.Add(506);
        barVisible.Add(1045);
        barVisible.Add(140);
        linkManager.CalculateVisibility(barVisible);
    }

    public void StartTask_3()   {
        // Read value
        task1 = false;
        task2 = false;
        task3 = true;
        barVisible = new List<int>();
        task_time = Time.time;
        camera_2d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);

        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

        camera_3d_3d.gameObject.transform.position = new Vector3(1847.8f, 1679.38f, -1219.278f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(13,-103,0);

        // barVisible.Add(1043);
        // barVisible.Add(1029);
        // barVisible.Add(1039);
        // barVisible.Add(1035);
        // barVisible.Add(506);
        // barVisible.Add(1045);
        // barVisible.Add(140);
        // linkManager.CalculateVisibility(barVisible);
    }

    public void StartTask_4()   {
        // Compare distance
        task1 = false;
        task2 = false;
        task3 = false;
        task4 = true;
        barVisible = new List<int>();
        task_time = Time.time;
        camera_2d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);

        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

        camera_3d_3d.gameObject.transform.position = new Vector3(565.4272f, 2110.637f, -3797.581f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(18.6f,-0.3f,0);

        barVisible.Add(757);
        barVisible.Add(762);
        barVisible.Add(760);
        linkManager.CalculateVisibility(barVisible);
    }

    public void StartTask_5()   {
        // Select viewpoint
        task1 = false;
        task2 = false;
        task3 = false;
        task4 = false;
        task5 = true;

        barVisible = new List<int>();
        task_time = Time.time;

        camera_2d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);

        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

        camera_3d_3d.gameObject.transform.position = new Vector3(565.4272f, 2110.637f, -3797.581f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(18.6f,-0.3f,0);

        barManager.SetBarColor(757);

        viewpointManager.DisableSelectedViewpoint("Loon lake Dock");
    }

    public void GetResult() {
        float finalTime = Time.time - task_time;
        print("Time taken: " + finalTime);
        if(task1)       {
            print("Mesh/Bar Selected: " + barManager.GetBarSelected_Task1());
            List<int> user_answer = barManager.GetBarSelected_Task1();
        }else if(task2) {
            print("Mesh/Bar Selected: " + barManager.GetBarSelected_Task2());
            int user_answer = barManager.GetBarSelected_Task2();
        }else if(task5) {
            print("Viewpoint Selected: " + linkManager.GetViewPointSelected_Task());
            string user_answer = linkManager.GetViewPointSelected_Task();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if(!(task1 || task2))   {
            if(camera_3d_3d.pixelRect.Contains(Input.mousePosition))    {
                movement_3d_3d.RaycastObject();
            }
            if(camera_3d_2d.pixelRect.Contains(Input.mousePosition))    {
                movement_3d_2d.RaycastObject();
            }
            if(camera_2d_3d.pixelRect.Contains(Input.mousePosition))    {
                movement_2d_3d.RaycastObject();
            }
            if(camera_2d_2d.pixelRect.Contains(Input.mousePosition))    {
                movement_2d_2d.RaycastObject();
            }
        }
        
    }
}
