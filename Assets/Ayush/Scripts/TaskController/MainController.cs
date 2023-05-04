using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MainController : MonoBehaviour
{
    public PolygonManager polygonManager;
    public BarManager barManager;
    public ViewpointManager viewpointManager;
    public LinkManager linkManager;
    public OutlineManager outlineManager;

    public RayCastMethod movement_3d_3d;
    public RayCastMethod movement_3d_2d;
    public RayCastMethod movement_2d_3d;
    public RayCastMethod movement_2d_2d;
    public RayCastMethod movement2d;
    public RayCastMethod movement2d_3d_2;

    public StartButtonController startButtonController;
    public AnswerController answerController;
    // public ExportCSV exportCsv;

    public Button startButton;
    public Mouse_Pointer mouse_pointer;
    public PhaseTwoButtonController PhaseTwoButtonController;

    private GameObject[] terrain_3d_list;
    private GameObject[] terrain_2d_list;

    public Camera camera_3d_3d;
    public Camera camera_3d_2d;
    public Camera camera_2d_3d;
    public Camera camera_2d_2d;
    public Camera camera_2d_2d_2;
    public Camera camera_2d_3d_2;

    private Vector3 camera_3d_3d_position;
    private Vector3 camera_3d_2d_position;
    private Vector3 camera_2d_3d_position;
    private Vector3 camera_2d_2d_position;

    private List<int> barVisible;
    private List<int> answer_task1;

    public bool task1 = false;
    public bool task2 = false;
    public bool task3 = false;
    public bool task3_part1 = false;
    public bool task3_part2 = false;
    public bool task3_iteration1 = false;
    public bool task4 = false;
    public bool task4_part1 = false;   
    public bool task40 = false;
    public bool task40_part1 = false;
    public bool task40_iteration1 = false;

    public bool camera3d3d = false;
    public bool camera3d2d = false;
    public bool camera25d3d = false;
    public bool camera25d2d = false;
    public bool camera2d3d = false;
    public bool camera2d2d = false;

    public bool complexTask1 = false;
    public bool complexTask2 = false;
    public bool complexTask3 = false;
    public bool task5 = false;
    public int iteration = 0;
    public bool endTask = false;

    public int camera_3d_3d_active = 0;
    public int camera_3d_2d_active = 0;
    public int camera_2d_3d_active = 0;
    public int camera_2d_2d_active = 0;
    public int camera_2d_3d_2_active = 0;
    public int camera_2d_2d_2_active = 0;

    public Dictionary<int, int> barSelected_dict = new Dictionary<int, int>();
    public Dictionary<string, int> viewpointSelected_dict = new Dictionary<string, int>();

    public float task_time;

    public string logGuid = "";
    List<int> barSelectedTask2 = new List<int>();


    private Vector3 centrePoint;
    private float xDist;
    private float yDist;
    private int angle;

    public float yaw = 0f;
    public float pitch = 0f;

    // Start is called before the first frame update
    void Start()
    {
        answer_task1 = new List<int>();
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



    // public void StartTask_4()   {
    //     // Compare distance
    //     task1 = false;
    //     task2 = false;
    //     task3 = false;
    //     task4 = true;
    //     endTask = false;
    //     barVisible = new List<int>();
    //     task_time = Time.time;
    //     camera_2d_2d.gameObject.SetActive(false);
    //     camera_2d_2d_active = 0;
    //     camera_2d_3d.gameObject.SetActive(false);
    //     camera_2d_3d_active = 0;
    //     camera_3d_2d.gameObject.SetActive(false);
    //     camera_3d_2d_active = 0;
    //     camera_2d_3d_2.gameObject.SetActive(false);
    //     camera_2d_2d_2.gameObject.SetActive(false);
        
    //     camera_3d_3d.rect = new Rect(0, 0, 1, 1);
    //     camera_3d_3d_active = 1;

    //    ResetSettings();

    //     camera_3d_3d.gameObject.transform.position = new Vector3(565.4272f, 2110.637f, -3797.581f);
    //     camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(18.6f,-0.3f,0);

    //     int[] bars = {757, 762, 760};
    //     for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
       
    //     linkManager.CalculateVisibility(barVisible);
    // }


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

        endTask = true; 
        // ResetSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if(!(task1|| task2)) {
            if(camera_2d_3d_2.pixelRect.Contains(Input.mousePosition))    {
                print("Mouse in 2d3d_2 view");
                movement2d_3d_2.RaycastObject(Input.mousePosition);
            }
            if(camera_3d_2d.pixelRect.Contains(Input.mousePosition))    {
                print("Mouse in 3D 2D");
                movement_3d_2d.RaycastObject(Input.mousePosition);
            }
            if(camera_2d_3d.pixelRect.Contains(Input.mousePosition))    {
                print("Mouse in 2D 3D view");
                movement_2d_3d.RaycastObject(Input.mousePosition);
            }
            if(camera_2d_2d.pixelRect.Contains(Input.mousePosition))    {
                print("Mouse in 2D 2D");
                movement2d.RaycastObject(Input.mousePosition);
            }
            if(camera_3d_3d.pixelRect.Contains(Input.mousePosition)) {
                print("mouse in 3d 3d view");
                movement_3d_3d.RaycastObject(Input.mousePosition);
            }
            if(camera_2d_2d_2.pixelRect.Contains(Input.mousePosition)){
                print("Mouse in 2D 2D_2");
                movement_2d_2d.RaycastObject(Input.mousePosition);
            }
        }
            // if(camera_2d_2d_2.pixelRect.Contains(Input.mousePosition))  {
            //     movement_2d_2d.RaycastObject();
            // }

            if(startButtonController.GetLog())  ExportLog();
            if(Input.GetKeyDown(KeyCode.Alpha2))    {
                PhaseTwoButtonController.OnPhaseTwoControllerButtonClicked();
            }

            mouse_pointer.UpdatePosition(Input.mousePosition);
        
    }

    public void LogData(int cameraAngle, int distractors, int iteration, int userID)  {
        System.IO.StreamWriter writer;

        string path = Application.dataPath + "/Quantitative_Data.txt";

        writer = new System.IO.StreamWriter(path, true);

        string tempString;

        // TimeStamp
        tempString = "";
        tempString += System.DateTime.Now;
        tempString += ",";

        // UserID

        tempString += userID +",";

        // // camera active

            // camera 3d 3d
            if(startButtonController.quotient == 0 || startButtonController.quotient == 6)  {
                if(startButtonController.camera1.name == "3D_3D")           tempString += "1,0,0,0,0,0,";
                else if(startButtonController.camera1.name == "3D_2D")      tempString += "0,1,0,0,0,0,";
                else if(startButtonController.camera1.name == "2D_3D")      tempString += "0,0,1,0,0,0,";
                else if(startButtonController.camera1.name == "2D_2D_2")    tempString += "0,0,0,1,0,0,";
                else if(startButtonController.camera1.name == "2D_3D_2")    tempString += "0,0,0,0,1,0,";
                else if(startButtonController.camera1.name == "2D_2D")      tempString += "0,0,0,0,0,1,";
                else                                                        {}
            }

            else if(startButtonController.quotient == 1 || startButtonController.quotient == 7)  {
                if(startButtonController.camera2.name == "3D_3D")           tempString += "1,0,0,0,0,0,";
                else if(startButtonController.camera2.name == "3D_2D")      tempString += "0,1,0,0,0,0,";
                else if(startButtonController.camera2.name == "2D_3D")      tempString += "0,0,1,0,0,0,";
                else if(startButtonController.camera2.name == "2D_2D_2")    tempString += "0,0,0,1,0,0,";
                else if(startButtonController.camera2.name == "2D_3D_2")    tempString += "0,0,0,0,1,0,";
                else if(startButtonController.camera2.name == "2D_2D")      tempString += "0,0,0,0,0,1,";
                else                                                        {}
            }

            else if(startButtonController.quotient == 2 || startButtonController.quotient == 8)  {
                if(startButtonController.camera3.name == "3D_3D")           tempString += "1,0,0,0,0,0,";
                else if(startButtonController.camera3.name == "3D_2D")      tempString += "0,1,0,0,0,0,";
                else if(startButtonController.camera3.name == "2D_3D")      tempString += "0,0,1,0,0,0,";
                else if(startButtonController.camera3.name == "2D_2D_2")    tempString += "0,0,0,1,0,0,";
                else if(startButtonController.camera3.name == "2D_3D_2")    tempString += "0,0,0,0,1,0,";
                else if(startButtonController.camera3.name == "2D_2D")      tempString += "0,0,0,0,0,1,";
                else                                                        {}
            }

            else if(startButtonController.quotient == 3 || startButtonController.quotient == 9)  {
                if(startButtonController.camera4.name == "3D_3D")           tempString += "1,0,0,0,0,0,";
                else if(startButtonController.camera4.name == "3D_2D")      tempString += "0,1,0,0,0,0,";
                else if(startButtonController.camera4.name == "2D_3D")      tempString += "0,0,1,0,0,0,";
                else if(startButtonController.camera4.name == "2D_2D_2")    tempString += "0,0,0,1,0,0,";
                else if(startButtonController.camera4.name == "2D_3D_2")    tempString += "0,0,0,0,1,0,";
                else if(startButtonController.camera4.name == "2D_2D")      tempString += "0,0,0,0,0,1,";
                else                                                        {}
            }

            else if(startButtonController.quotient == 4 || startButtonController.quotient == 10)  {
                if(startButtonController.camera5.name == "3D_3D")           tempString += "1,0,0,0,0,0,";
                else if(startButtonController.camera5.name == "3D_2D")      tempString += "0,1,0,0,0,0,";
                else if(startButtonController.camera5.name == "2D_3D")      tempString += "0,0,1,0,0,0,";
                else if(startButtonController.camera5.name == "2D_2D_2")    tempString += "0,0,0,1,0,0,";
                else if(startButtonController.camera5.name == "2D_3D_2")    tempString += "0,0,0,0,1,0,";
                else if(startButtonController.camera5.name == "2D_2D")      tempString += "0,0,0,0,0,1,";
                else                                                        {}
            }

            else if(startButtonController.quotient == 5 || startButtonController.quotient == 11)  {
                if(startButtonController.camera6.name == "3D_3D")           tempString += "1,0,0,0,0,0,";
                else if(startButtonController.camera6.name == "3D_2D")      tempString += "0,1,0,0,0,0,";
                else if(startButtonController.camera6.name == "2D_3D")      tempString += "0,0,1,0,0,0,";
                else if(startButtonController.camera6.name == "2D_2D_2")    tempString += "0,0,0,1,0,0,";
                else if(startButtonController.camera6.name == "2D_3D_2")    tempString += "0,0,0,0,1,0,";
                else if(startButtonController.camera6.name == "2D_2D")      tempString += "0,0,0,0,0,1,";
                else                                                        {}
            }

        // Task 1

        if(task1)   tempString += "1,";

        // Task 2
        if(task2)   tempString += "2,";

        // Iteration

        tempString += iteration + ",";
        
        // Camera Angle
        tempString += cameraAngle + ",";

        // Distractors
        tempString += distractors + ",";

        // Bar Selected // Bar Height/Distance
        barSelected_dict = barManager.GetBarSelectedDict();
        foreach(KeyValuePair<int, int> pair in barSelected_dict)    {
            int key = pair.Key;
            int val = pair.Value;
            if(val == 1)  {
                if(task1)   {
                    tempString += key + ",";
                    tempString += barManager.GetBarHeight(key) + "";
                }
                else        {
                    tempString += key + "-";
                    barSelectedTask2.Add(key);
                }
            }

        }
        if(task2)   tempString += "," + answerController.GetDistance(barSelectedTask2) + "";
        barSelectedTask2.Clear();
        tempString += ",";

        // Correct Bar 
        if(task1)   tempString += answerController.GetAnswer_Task1_ID() + ",";

        if(task2)   tempString += answerController.GetAnswer_Task2_ID() + ",";

        // Correct Height/Distance
        if(task1)   tempString += answerController.GetAnswer_Task1_Height() + ",";
        if(task2)   tempString += answerController.GetAnswer_Task2_Distance() + ",";

        // Total Time
        tempString += (Time.time - task_time).ToString();


        writer.WriteLine(tempString);
        writer.Close();
    }

    public void ExportLog()    {
        // if(logGuid == "") {
        //     logGuid = System.Guid.NewGuid().ToString();
        // }
        
        System.IO.StreamWriter writer;

        string path = Application.dataPath + "/Log.txt";

        writer = new System.IO.StreamWriter(path, true);

        string tempString;

        tempString = "";
        tempString += System.DateTime.Now;
        tempString += ",";


        // camera angle
            // camera 3d 3d
            tempString += camera_3d_3d.gameObject.transform.localEulerAngles.x + "/" + camera_3d_3d.gameObject.transform.localEulerAngles.y + "/" + camera_3d_3d.gameObject.transform.localEulerAngles.z + ",";
            // camera 3d 2d
            tempString += camera_3d_2d.gameObject.transform.localEulerAngles.x + "/" + camera_3d_2d.gameObject.transform.localEulerAngles.y + "/" + camera_3d_2d.gameObject.transform.localEulerAngles.z + ",";
            // camera 2.5d 3d
            tempString += camera_2d_3d.gameObject.transform.localEulerAngles.x + "/" + camera_2d_3d.gameObject.transform.localEulerAngles.y + "/" + camera_2d_3d.gameObject.transform.localEulerAngles.z + ",";
            // camera 2.5d 2d
            tempString += camera_2d_2d_2.gameObject.transform.localEulerAngles.x + "/" + camera_2d_2d_2.gameObject.transform.localEulerAngles.y + "/" + camera_2d_2d_2.gameObject.transform.localEulerAngles.z + ",";
            // camera 2d 3d
            tempString += camera_2d_3d_2.gameObject.transform.localEulerAngles.x + "/" + camera_2d_3d_2.gameObject.transform.localEulerAngles.y + "/" + camera_2d_3d_2.gameObject.transform.localEulerAngles.z + ",";
            // camera 2d 2d
            tempString += camera_2d_2d.gameObject.transform.localEulerAngles.x + "/" + camera_2d_2d.gameObject.transform.localEulerAngles.y + "/" + camera_2d_2d.gameObject.transform.localEulerAngles.z + ",";

        // camera position
            // camera 3d 3d
            tempString += camera_3d_3d.gameObject.transform.position.x + "/" + camera_3d_3d.gameObject.transform.position.y + "/" + camera_3d_3d.gameObject.transform.position.z + ",";
            // camera 3d 2d
            tempString += camera_3d_2d.gameObject.transform.position.x + "/" + camera_3d_2d.gameObject.transform.position.y + "/" + camera_3d_2d.gameObject.transform.position.z + ",";
            // camera 2.5d 3d
            tempString += camera_2d_3d.gameObject.transform.position.x + "/" + camera_2d_3d.gameObject.transform.position.y + "/" + camera_2d_3d.gameObject.transform.position.z + ",";
            // camera 2.5d 2d
            tempString += camera_2d_2d_2.gameObject.transform.position.x + "/" + camera_2d_2d_2.gameObject.transform.position.y + "/" + camera_2d_2d_2.gameObject.transform.position.z + ",";
            // camera 2d 3d
            tempString += camera_2d_3d.gameObject.transform.position.x + "/" + camera_2d_3d.gameObject.transform.position.y + "/" + camera_2d_3d.gameObject.transform.position.z + ",";
            // camera 2d 2d
            tempString += camera_2d_2d.gameObject.transform.position.x + "/" + camera_2d_2d.gameObject.transform.position.y + "/" + camera_2d_2d.gameObject.transform.position.z + ",";
    

        if(complexTask1)    tempString += "1,";
        else                tempString += "0,";
        if(complexTask2)    tempString += "1,";
        else                tempString += "0,";
        if(complexTask3)    tempString += "1,";
        else                tempString += "0,";
        if(endTask)         tempString += "1,";
        else                tempString += "0,";
        if(linkManager.GetInvisibleStatus())    tempString += "1,";
        else                                    tempString += "0,";
        tempString += ((iteration % 2) + 1) + ",";

        // bar selected
        barSelected_dict = barManager.GetBarSelectedDict();
        foreach(KeyValuePair<int, int> pair in barSelected_dict)    {
            int key = pair.Key;
            int val = pair.Value;
            if(val == 1)  tempString += key + "-";
        }
        tempString += ",";

        // final answer bar
        barSelected_dict = barManager.GetBarSelectedDict();
        foreach(KeyValuePair<int, int> pair in barSelected_dict)    {
            int key = pair.Key;
            int val = pair.Value;
            if(val == 2)  tempString += key + "-";
        }
        tempString += ",";

        // Result Bar
        if(complexTask1)    tempString += answerController.GetAnswer_Task2_ID() + ",";
        if(complexTask2)    tempString += answerController.GetAnswer_Task1_ID() + ",";
        if(complexTask3)    tempString += ",";

        // Result
        if(complexTask1)    tempString += answerController.GetAnswer_Task2_Distance() + ",";
        if(complexTask2)    tempString += answerController.GetAnswer_Task1_Height() + ",";
        if(complexTask3)    tempString += ",";

        // viewpoint selected
        viewpointSelected_dict = linkManager.GetViewpointSelectedDict();
        foreach(KeyValuePair<string, int> pair in viewpointSelected_dict)   {
            string key = pair.Key;
            int val = pair.Value;
            if(val != 0)    tempString += key + "/" + val + "-"; 
        }
        tempString += ",";

        // Result Viewpoint



        tempString += (Time.time - task_time).ToString() + ",";


        writer.WriteLine(tempString);

        writer.Close();
    }

    public void ResetSettings() {
        linkManager.ResetViewpoints();
        barManager.ResetBarSelected();
        barManager.ResetAllBars();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();
        viewpointManager.ResetAllViewpoints();
        answerController.ResetAnswer();

        linkManager.ResetViewpoints();
        // barManager.ResetBarSelected();
        polygonManager.ResetPolygonSelected();
        movement_3d_3d.ResetMovement();

        camera_3d_3d.gameObject.transform.position = new Vector3(-264, 1434, -7258);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(6.228f, 37.432f, 0f);

        camera_3d_2d.gameObject.transform.position = new Vector3(-264, 1434, -7258);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(6.228f, 37.432f, 0f);

        camera_2d_3d.gameObject.transform.position = new Vector3(-264, 1434, -7258);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(6.228f, 37.432f, 0f);

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-264, 1434, -7258);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(6.228f, 37.432f, 0f);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(3319.298f, 4091.488f, 0);
        camera_2d_3d_2.gameObject.transform.localRotation = Quaternion.Euler(30, 0, 0);

        camera_2d_2d.gameObject.transform.position = new Vector3(3319.298f, 4091.488f, 0);
        camera_2d_2d.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0f);
    }

    public int GetCameraAngle(int num)  {
        switch(num) {
            case 1 : return 0;
            case 2 : return 35;
            case 3 : return 65;
            default : return 45;
        }
    }

    private void GetCameraPos(Camera cam, Vector3 position, float xDist, float yDist, int angle)    {
        Vector3 newPos = new Vector3(position.x, position.y + 780, position.z);

        cam.gameObject.transform.position = new Vector3(position.x + xDist, position.y + 700, position.z + yDist);

    }

    public void DisableAllViewpoints()  {
        viewpointManager.DisableAllViewpoints();
    }
}
