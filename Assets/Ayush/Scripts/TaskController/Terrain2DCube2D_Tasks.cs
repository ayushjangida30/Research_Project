using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain2DCube2D_Tasks : MonoBehaviour
{
    public PolygonManager polygonManager;
    public BarManager barManager;
    public ViewpointManager viewpointManager;
    public LinkManager linkManager;
    public OutlineManager outlineManager;
    public MainController mainController;

    // public RayCastMethod movement_3d_3d;
    // public RayCastMethod movement_3d_2d;
    // public RayCastMethod movement_2d_3d;
    // public RayCastMethod movement_2d_2d;
    // public RayCastMethod movement2d;
    // public RayCastMethod movement2d_3d_2;

    public StartButtonController startButtonController;
    public AnswerController answerController;
    // public ExportCSV exportCsv;

    // public Button startButton;

    private GameObject[] terrain_3d_list;
    private GameObject[] terrain_2d_list;

    public Camera camera_3d_3d;
    public Camera camera_3d_2d;
    public Camera camera_2d_3d;
    public Camera camera_2d_2d;
    public Camera camera_2d_2d_2;
    public Camera camera_2d_3d_2;

    private List<int> barVisible;
    private List<int> answer_task1;

    private Vector3 centrePoint;
    private float xDist;
    private float yDist;
    private int angle;
    // Start is called before the first frame update
    void Start()
    {
        answer_task1 = new List<int>();
    }


    private void Task1_Setting()    {
        mainController.task1 = true;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        mainController.camera3d3d = false;
        mainController.camera3d2d = false;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = true;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(true);
        camera_2d_2d.rect = new Rect(0, 0, 1, 1);
    }

    private void Task2_Setting()    {
        mainController.task1 = false;
        mainController.task2 = true;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        mainController.camera3d3d = false;
        mainController.camera3d2d = false;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = true;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(true);
        camera_2d_2d.rect = new Rect(0, 0, 1, 1);
    }


    public int Trial_1()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1999, 4091, -3477);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1415.15f;    
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,53.2f,0);

        int[] bars = {1043, 526, 1011};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(200, 600));
        barManager.AdjustCubes(526, 800, 0);
        // barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        // barManager.TransformCube();

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public void Trial_2()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1999, 4091.5f, -9704);
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,53.2f,0);

        int[] bars = {1043, 526, 1011};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(200, 600));
        barManager.AdjustCubes(526, 800, 0);
        // barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        // barManager.TransformCube();

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();
    }


// TASK 1    

     public int StartTask_1_Iter_1()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2199, 4091, -2725);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1148.15f;    
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,53.2f,0);

        int[] bars = {526, 524, 520, 1001, 134};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(276, 828));
        barManager.AdjustCubes(524, 920, 0);
        // barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        // barManager.TransformCube();

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_2()   {                                                                                     //Camera angle 35 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1339, 4091, -5268);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1685.15f;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {126, 1045, 1033, 1037, 129, 117, 118, 123, 1152, 119, 1028, 775, 1034, 506, 1159};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        barManager.AdjustCubes(775, 900, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_3()   {                                                                                     //Camera angle 45 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1939, 4091, -453);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1955;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,44.5f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {138, 532, 799, 186, 751, 538, 154, 541, 545, 543, 168, 509, 170, 172, 165, 508, 546, 528, 774, 758, 760, 765, 103, 757, 756};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(231, 693));
        barManager.AdjustCubes(538, 770, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }


    public int StartTask_1_Iter_4()   {                                                                                     //Camera angle 25 || Distractor : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2359, 4091, -2737);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1139.15f; 
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,34.4f,0);
        // barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {526, 195, 513, 134, 1001};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(285, 855));
        barManager.AdjustCubes(134, 950, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_5()   {                                                                                     //Camera angle 35 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        // camera_3d_2d.gameObject.transform.position = new Vector3(4861, 5047, 3288);
        // camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-128,0);

        camera_2d_2d.gameObject.transform.position = new Vector3(2639, 4282, -5517);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1226;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,36.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);


        int[] bars = {151, 128, 1154, 118, 117, 129, 119, 1025, 1160, 1174, 1171, 1162, 1166, 158, 767};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(294, 882));
        barManager.AdjustCubes(1025, 980, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_6()   {                                                                                     //Camera angle 45 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1739, 4091, -4897);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1790;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,92.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1171, 1174, 1019, 128, 120, 113, 1014, 118, 110, 1154, 1027, 1028, 1037, 1035, 1043, 775, 139, 1030, 1033, 1041, 1049, 150, 1047, 126, 1046};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(282, 846));
        barManager.AdjustCubes(1028, 940, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_7()   {                                                                                     //Camera angle 25 || Distractor : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(3199, 4091, -5197);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1445.15f;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,43.2f,0);
        // barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {119, 501, 767, 1166, 517};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        barManager.AdjustCubes(1166, 900, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_8()   {                                                                                     //Camera angle 35 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2659, 4091, -5877);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1493;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,-90.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {1037, 1032, 123, 128, 133, 1025, 146, 102, 1166, 152, 1164, 1165, 1168, 1191, 1183};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(300, 900));
        barManager.AdjustCubes(128, 1000, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_1_Iter_9()   {                                                                                     //Camera angle 45 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1719, 4091, 98);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 2168;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,68,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {154, 541, 532, 186, 790, 538, 505, 507, 167, 165, 546, 782, 760, 758, 780, 168, 175, 504, 174, 509, 752, 172, 757, 776, 103, 13, };
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(261, 783));
        barManager.AdjustCubes(504, 870, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }



// TASK 2

    public int StartTask_2_Iter_1()   {                                                                                      //Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2179, 4091, -2577);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 821;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,59.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);
        

        int[] bars = {141, 522, 525, 521, 134};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;    
    }

     public int StartTask_2_Iter_2()   {                                                                                      //Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2779, 4091, -5277);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1379;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,39,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1020, 114, 1025, 1160, 182, 1174, 199, 128, 117, 501, 183, 1166, 1018, 151, 123};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();

        return 90; 
    }

    public int StartTask_2_Iter_3()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2659, 4091, -5417);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1649;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,58.6f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1049, 158, 1165, 1174, 1183, 152, 123, 1032, 133, 1164, 1170, 1185, 1180, 199, 1162, 1171, 1025, 128, 129, 118, 1035, 1028, 1034, 1037, 1033};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;   
    }

    public int StartTask_2_Iter_4()   {                                                                                      //Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2279, 4091, -5997);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1238;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,73.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1155, 133, 119, 146, 1157};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;   
    }

    public int StartTask_2_Iter_5()   {                                                                                      //Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2819, 4091, -5957);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1121;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,48,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1186, 1161, 1178, 151, 199, 1168, 1166, 1164, 101, 1025, 1156, 120, 1154, 128, 1032};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 90;
    }

    public int StartTask_2_Iter_6()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1510, 4091, 270);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1553;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,102.9f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {786, 186, 535, 508, 170, 543, 180, 175, 509, 539, 154, 538, 751, 788, 505, 168, 174, 507, 795, 789, 546, 165, 504, 792, 172};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;   
    }

    public int StartTask_2_Iter_7()   {                                                                                      //Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1799, 4091, -717);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1022;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,73.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {546, 540, 154, 781, 528};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;  
    }

    public int StartTask_2_Iter_8()   {                                                                                      //Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1619, 4091, 602);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1268;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,61.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {504, 791, 503, 788, 790, 536, 538, 505, 177, 543, 168, 169, 170, 752, 176};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;
    }  

    public int StartTask_2_Iter_9()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(1939, 4091, 422);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1469;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,58.6f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {174, 176, 168, 790, 186, 540, 165, 167, 535, 539, 154, 108, 797, 795, 792, 786, 505, 538, 180, 179, 175, 170, 509, 752, 172};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;    
    }

    public int StartTask_2_Iter_90()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d.gameObject.transform.position = new Vector3(2659, 4091, -5660);
        camera_2d_2d.GetComponent<Camera>().orthographicSize = 1649;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,58.6f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1049, 158, 1165, 1174, 1183, 152, 123, 1032, 133, 1164, 1170, 1185, 1180, 199, 1162, 1171, 1025, 128, 129, 118, 1035, 1028, 1034, 1037, 1033};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 90;    
    }

    public void SetCameraActive()   {
        camera_2d_2d.rect = new Rect(0, 0, 1, 1);
    }
}
