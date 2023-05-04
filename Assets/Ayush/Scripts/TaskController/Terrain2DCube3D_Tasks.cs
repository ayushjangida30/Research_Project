    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain2DCube3D_Tasks : MonoBehaviour
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
        mainController.camera2d3d = true;
        mainController.camera2d2d = false;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(true);
        camera_2d_3d_2.rect = new Rect(0, 0, 1, 1);
        camera_2d_2d.gameObject.SetActive(false);
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
        mainController.camera2d3d = true;
        mainController.camera2d2d = false;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(true);
        camera_2d_3d_2.rect = new Rect(0, 0, 1, 1);
        camera_2d_2d.gameObject.SetActive(false);
    }


    public void Trial_1()   {                                                                                    //Camera angle 25 || Distractor : 5
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

    public void Trial_2()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(3859, 4091.5f, -8444);
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,53.2f,0);

        int[] bars = {136, 192, 135};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(200, 600));
        // barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        // barManager.TransformCube();

        linkManager.CalculateVisibility(barVisible);
        mainController.DisableAllViewpoints();
    }



// TASK 1    

     public int StartTask_1_Iter_1()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1739, 4406.5f, -7424);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1415.15f;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,53.2f,0);

        int[] bars = {760, 778, 541, 528, 527};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        barManager.AdjustCubes(541, 900, 0);
        // barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        // barManager.TransformCube();

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_2()   {                                                                                     //Camera angle 35 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2959, 4091, -11924);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1328.15f;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {147, 1159, 1154, 118, 117, 1020, 1171, 152, 1177, 1178, 1170, 1164, 146, 116};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        barManager.AdjustCubes(547, 900, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_3()   {                                                                                     //Camera angle 45 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2399, 4091, -11124);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1502;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,44.5f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1183, 1178, 501, 184, 1020, 1014, 1027, 1043, 1034, 1033, 1037, 1159, 1028, 122, 1156, 121, 117, 1174, 133, 1171, 146, 1162, 1193, 1170, 1191};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(231, 693));
        barManager.AdjustCubes(184, 770, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_4()   {                                                                                     //Camera angle 25 || Distractor : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2119, 4091, -10209);
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,34.4f,0);
        // barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1027, 1035, 120, 1013, 1171};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(285, 855));
        barManager.AdjustCubes(1035, 950, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    


    

    public int StartTask_1_Iter_5()   {                                                                                     //Camera angle 35 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        // camera_3d_2d.gameObject.transform.position = new Vector3(4861, 5047, 3288);
        // camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-128,0);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1143, 4282, -7329);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1573;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,36.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);


        int[] bars = {761, 757, 170, 754, 755, 758, 772, 543, 538, 154, 541, 778, 186, 106, 548};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(294, 882));
        barManager.AdjustCubes(772, 980, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_6()   {                                                                                     //Camera angle 45 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1159, 4091, -6324);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1589;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,92.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {196, 106, 527, 778, 772, 755, 754, 103, 776, 172, 170, 174, 168, 765, 504, 165, 545, 539, 154, 547, 751, 792, 794, 143, 781};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(330, 990));
        barManager.AdjustCubes(755, 1100, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_7()   {                                                                                     //Camera angle 25 || Distractor : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1879, 4091, -5933);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1073.15f;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,43.2f,0);
        // barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {547, 165, 535, 751, 154};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(270, 810));
        barManager.AdjustCubes(547, 900, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_8()   {                                                                                     //Camera angle 35 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1599, 4091, -6524);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1523;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,-90.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {757, 778, 758, 170, 172, 509, 543, 539, 760, 540, 106, 751, 186, 795, 797};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(300, 900));
        barManager.AdjustCubes(170, 1000, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_1_Iter_9()   {                                                                                     //Camera angle 45 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1759, 4091, -10444);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1604;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,68,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1048, 1045, 506, 1033, 1030, 1043, 775, 1037, 1028, 1154, 128, 121, 526, 1004, 520, 1014, 515, 513, 1006, 120, 1025, 1174, 146, 158, 182};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(261, 783));
        barManager.AdjustCubes(1043, 870, 0);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }



// TASK 2

    public int StartTask_2_Iter_1()   {                                                                                      //Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(3159, 4091, -11744);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1082;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,59.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);
        

        int[] bars = {1025, 102, 158, 1178, 1164};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 30;    
    }

     public int StartTask_2_Iter_2()   {                                                                                     //Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2779, 4091, -11084);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1475;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,39,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1183, 501, 158, 1006, 1004, 1017, 1028, 775, 1038, 1037, 110, 1174, 1018, 128, 116};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_2_Iter_3()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2840, 4091, -11558);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1295;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,69.5f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1032, 1154, 128, 1156, 114, 121, 120, 113, 1025, 1171, 1174, 152, 184, 102, 1166, 1193, 133, 1183, 1185, 767, 151, 1175, 199, 1168};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();

        return 30;   
    }

    public int StartTask_2_Iter_4()   {                                                                                      //Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2239, 4091, -8724);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 917;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,73.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {525, 195, 134, 518, 1001};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 30;   
    }

    public int StartTask_2_Iter_5()   {                                                                                      //Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2097, 4091, -11444);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1424;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,48,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1043, 1162, 1037, 1160, 1152, 120, 118, 1171, 1034, 1028, 110, 1020, 1156, 1172, 1038};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_2_Iter_6()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1899, 4091, -5993);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1952;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,102.9f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {755, 757, 103, 171, 176, 504, 539, 543, 165, 762, 763, 772, 778, 196, 143, 790, 538, 154, 794, 792, 186, 532, 798, 781, 547};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 30; 
    }


    public int StartTask_2_Iter_7()   {                                                                                      //Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1619, 4091, -6604);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 914;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,73.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {781, 541, 544, 165, 528};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 30;  
    }

    public int StartTask_2_Iter_8()   {                                                                                      //Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2919, 4091, -10864);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1328;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,61.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {146, 110, 117, 1016, 1023, 1013, 1011, 1020, 1174, 1006, 184, 501, 1171, 1162, 151};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 30;
    }

    public int StartTask_2_Iter_9()   {                                                                                      //Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1907, 4091, -10352);
        camera_2d_3d_2.GetComponent<Camera>().orthographicSize = 1858;
        // camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,58.6f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1040, 1048, 1041, 1030, 1028, 1034, 1038, 1026, 772, 110, 1032, 526, 1002, 196, 513, 1006, 1011, 1020, 1014, 120, 1174, 1162, 152, 184, 520};
        for(int i = 0; i < bars.Length; i++)    barManager.AdjustCubes(bars[i], Random.Range(266, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 30;  
    }

    public void SetCameraActive()   {
        camera_2d_3d_2.rect = new Rect(0, 0, 1, 1);
    }
}
