using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain3DCube2D_Tasks : MonoBehaviour
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

    private void CameraActiveState()    {
        mainController.task1 = true;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        mainController.camera3d3d = false;
        mainController.camera3d2d = true;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(true);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(false);
    }

    private void Task1_Setting()    {
        mainController.task1 = true;
        mainController.task2 = false;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        mainController.camera3d3d = false;
        mainController.camera3d2d = true;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(true);
        camera_3d_2d.rect = new Rect(0, 0, 1, 1);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
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
        mainController.camera3d2d = true;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(true);
        camera_3d_2d.rect = new Rect(0, 0, 1, 1);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(false);
    }


// TASK 1    

    public void Trial_1()   {
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-710, 3051, -8314);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(26.4f,24.7f,0);
        barManager.TransformCube();

        int[] bars = {1047, 1043, 1028};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 600));
        barManager.SetVisiblePolygonsHeight(1043, 800);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();
    }


    public void Trial_2()   {                                                                                      //Camera angle 25 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-1285, 4459, -7364);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(40,52.5f,0);
        barManager.TransformCube();

        int[] bars = {775, 1018, 1016};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 600));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

    }

     public int StartTask_1_Iter_1()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(3987, 2735, -2185);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(25,-50,0);
        barManager.TransformCube();

        int[] bars = {175, 168, 509, 543, 539};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(240, 720));
        barManager.SetVisiblePolygonsHeight(543, 800);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_2()   {                                                                                     //Camera angle 25 || Distractor : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(4072, 2660, 2165);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(25,233,0);
        barManager.TransformCube();

        int[] bars = {154, 538, 535, 539, 536, 167, 165, 509, 173, 178, 179, 502, 170, 752, 172};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(180, 540));
        barManager.SetVisiblePolygonsHeight(165, 600);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_3()   {                                                                                     //Camera angle 25 || Distractor : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-2053, 4866, -7759);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(25,31.9f,0);
        barManager.TransformCube();

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {135, 142, 532, 144, 799, 143, 106, 778, 186, 794, 161, 539, 543, 509, 174, 172, 103, 757, 176, 756, 755, 765, 779, 154};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(234, 702));
        barManager.SetVisiblePolygonsHeight(161, 780);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }


    public int StartTask_1_Iter_4()   {                                                                                     //Camera angle 35 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(2760, 3630, -7739);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-30,0);
        barManager.TransformCube();

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {1043, 1029, 1039, 1035, 506};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(267, 801));
        barManager.SetVisiblePolygonsHeight(1029, 890);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;

    }

    public int StartTask_1_Iter_5()   {                                                                                     //Camera angle 35 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        // camera_3d_2d.gameObject.transform.position = new Vector3(4861, 5047, 3288);
        // camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-128,0);

        camera_3d_2d.gameObject.transform.position = new Vector3(6299, 5326, 897);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-95.8f ,0);
        barManager.TransformCube();

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);
        barManager.SetVisiblePolygonsHeight(170, 1030);

        int[] bars = {179, 176, 752, 170, 103, 172, 535, 536, 178, 177, 502, 166, 165, 776, 757};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(360, 1080));
        barManager.SetVisiblePolygonsHeight(176, 1200);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }

    public int StartTask_1_Iter_6()   {                                                                                     //Camera angle 35 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(6937, 5426, -887);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-132,0);
        barManager.TransformCube();

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {523, 1002, 1022, 1006, 1017, 1020, 113, 184, 1171, 156, 1162, 1175, 517, 1183, 116, 1193, 1164, 1157, 1152, 199, 1038, 1035, 775, 1043, 1046};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(234, 702));
        barManager.SetVisiblePolygonsHeight(1171, 780);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }


    public int StartTask_1_Iter_7()   {                                                                                     //Camera angle 45 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(6200, 4815, -453);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(45,-54,0);
        barManager.TransformCube();

        int[] bars = {187, 148, 144, 108, 797};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(252, 756));
        barManager.SetVisiblePolygonsHeight(797, 840);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_8()   {                                                                                     //Camera angle 45 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-3375, 5718, -3387);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(45,111,0);
        barManager.TransformCube();

        int[] bars = {1045, 150, 1041, 1043, 775, 1034, 1037, 1017, 1013, 1152, 1032, 526, 1028, 1046, 526, 1027};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(270, 810));
        barManager.SetVisiblePolygonsHeight(1043, 900);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_9()   {                                                                                     //Camera angle 45 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(6291, 6245, -2318);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(45,-131,0);
        barManager.TransformCube();

        int[] bars = {1011, 1020, 1014, 1017, 184, 182, 152, 1194, 1178, 1193, 1168, 1166, 146, 766, 102, 1157, 127, 1174, 113, 120, 118, 1037, 139, 1028, 775};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(279, 837));
        barManager.SetVisiblePolygonsHeight(152, 930);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }



// TASK 2

    public int StartTask_2_Iter_1()   {                                                                                      //Camera angle 25 || Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(243, 2053, -7072);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(25,72.8f,0);
        barManager.TransformCube();
        

        int[] bars = {1162, 516, 1160, 1194, 146};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints(); 

        return 25;  
    }

    public int StartTask_2_Iter_2()   {                                                                                      //Camera angle 25 || Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-1553, 2935, -7922);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(25,58,0);
        barManager.TransformCube();

        int[] bars = {1043, 1002, 515, 1013, 1035, 1018, 113, 501, 1171, 121, 1152, 1172, 1025, 1156, 1195};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();  

        return 25; 
    }

    public int StartTask_2_Iter_3()   {                                                                                      //Camera angle 25 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-4919, 5180, -4285);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(25,65.9f,0);
        barManager.TransformCube();

        int[] bars = {172, 170, 180, 148, 161, 788, 538, 165, 790, 793, 145, 163, 186, 762, 532, 768, 779, 533, 138, 143, 772, 520, 196, 192, 513};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints(); 

        return 25; 
    }


    public int StartTask_2_Iter_4()   {                                                                                      //Camera angle 35 || Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(285, 3491, -5445);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,31,0);
        barManager.TransformCube();

        int[] bars = {778, 527, 142, 525, 134};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 35; 
    }

    public int StartTask_2_Iter_5()   {                                                                                      //Camera angle 35 || Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(4549, 5252, -5064);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,-35,0);
        barManager.TransformCube();

        int[] bars = {757, 776, 763, 780, 171, 165, 781, 547, 539, 504, 538, 186, 795, 161};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();

        return 35; 
    }

    public int StartTask_2_Iter_6()   {                                                                                      //Camera angle 35 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(106, 6144, -10694);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(35,15.6f,0);
        barManager.TransformCube();

        int[] bars = {150, 1041, 1039, 761, 754, 755, 543, 154, 778, 765, 106, 196, 1026, 1029, 1035, 1002, 523, 513, 189, 192, 1006, 129, 1174, 184, 1177};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }


    public int StartTask_2_Iter_7()   {                                                                                      //Camera angle 45 || Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(454, 3883, -5410);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(45,44.1f,0);
        barManager.TransformCube();

        int[] bars = {513, 526, 134, 1003, 1007};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();

        return 45;   
    }

    public int StartTask_2_Iter_8()   {                                                                                      //Camera angle 45 || Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-3335, 6062, -3319);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(45,63.2f,0);
        barManager.TransformCube();

        int[] bars = {103, 776, 757, 755, 172, 174, 509, 170, 538, 154, 760, 774, 779};
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);   
        mainController.DisableAllViewpoints();

        return 45; 
    }

    public int StartTask_2_Iter_9()   {                                                                                      //Camera angle 45 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_2d.gameObject.transform.position = new Vector3(-2703, 6365, -5585);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(45,91,0);
        barManager.TransformCube();

        int[] bars = {1004, 1022, 1013, 1006, 1027, 1018, 1177, 184, 1016, 1028, 152, 1174, 110, 517, 1166, 114, 1152, 1178, 1160, 146, 1183, 1193, 1197, 133, 1032};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();  

        return 45;   
    }

    public void SetCameraActive()   {
        camera_3d_2d.rect = new Rect(0, 0, 1, 1);
    }
}
