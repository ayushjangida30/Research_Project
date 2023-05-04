using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Terrain3DCube3D_Tasks : MonoBehaviour
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
        mainController.task2 = false;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        mainController.camera3d3d = true;
        mainController.camera3d2d = false;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;

        camera_3d_3d.gameObject.SetActive(true);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);
        camera_3d_2d.gameObject.SetActive(false);
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

        mainController.camera3d3d = true;
        mainController.camera3d2d = false;
        mainController.camera25d3d = false;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;

        camera_3d_3d.gameObject.SetActive(true);
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(false);
    }

    public void Trial_1()   {
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-710, 2834, -8314);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(26.4f,24.7f,0);
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

        camera_3d_3d.gameObject.transform.position = new Vector3(-1285, 4459, -7364);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(40,52.5f,0);
        barManager.TransformCube();

        int[] bars = {775, 1018, 1016};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 600));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        mainController.DisableAllViewpoints();

    }


// TASK 1

    public int StartTask_1_Iter_1()   {                                                                                     //Camera angle 25 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(7073, 3621, -1151);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,-54,0);

        int[] bars = {187, 148, 144, 108, 797};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(252, 756));
        barManager.SetVisiblePolygonsHeight(797, 840);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_2()   {                                                                                     //Camera angle 25 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-3615, 3088, -3548);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,111,0);

        int[] bars = {1045, 150, 1041, 1043, 775, 1034, 1037, 1017, 1013, 1152, 1032, 526, 1028, 1046, 526, 1027};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(339, 1017));
        barManager.SetVisiblePolygonsHeight(1045, 1130);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_3()   {                                                                                     //Camera angle 25 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(5064, 3777, -5186);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,-43,0);

        int[] bars = {776, 779, 768, 780, 170, 171, 782, 198, 165, 106, 168, 546, 528, 154, 783, 751, 504, 180, 505, 507, 539, 545, 167, 542};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(300, 900));
        barManager.SetVisiblePolygonsHeight(106, 1000);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }


    

     public int StartTask_1_Iter_4()   {                                                                                    //Camera angle 35 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(4357, 4014, -2336);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,-50,0);

        int[] bars = {175, 168, 509, 543, 539};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(240, 720));
        barManager.SetVisiblePolygonsHeight(175, 800);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35; 
    }

    public int StartTask_1_Iter_5()   {                                                                                     //Camera angle 35 || Distractor : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(4072, 3547, 2165);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,233,0);

        int[] bars = {154, 538, 535, 539, 536, 167, 165, 509, 173, 178, 179, 502, 170, 752, 172};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(180, 540));
        barManager.SetVisiblePolygonsHeight(536, 600);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35; 
    }

    public int StartTask_1_Iter_6()   {                                                                                     //Camera angle 35 || Distractor : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-4098, 4589, -2595);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,75,0);

        int[] bars = {765, 780, 168, 165, 170, 103, 757, 760, 541, 535, 153, 781, 549, 143, 548, 761, 546, 508, 178, 507, 540, 542, 186, 751, 171};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(219, 657));
        barManager.SetVisiblePolygonsHeight(535, 730);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35; 
    }



    public int StartTask_1_Iter_7()   {                                                                                     //Camera angle 45 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(2494, 4300, -7349);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,-30,0);

        centrePoint = barManager.GetBarPos(506);
        mainController.DisableAllViewpoints();
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {1043, 1029, 1039, 1035, 506};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(267, 801));
        barManager.SetVisiblePolygonsHeight(1039, 890);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;

    }

    public int StartTask_1_Iter_8()   {                                                                                     //Camera angle 45 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(4641, 5552, 1892);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,-116.1f,0);

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);
        barManager.SetVisiblePolygonsHeight(170, 1030);

        int[] bars = {179, 176, 752, 170, 103, 172, 535, 536, 178, 177, 502, 166, 165, 776, 757};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(309, 927));
        barManager.SetVisiblePolygonsHeight(170, 1030);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_9()   {                                                                                     //Camera angle 45 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(5753, 4321, -3705);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,-112,0);

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {101, 102, 1161, 1174, 182, 158, 157, 501, 184, 1006, 1002, 515, 1010, 1009, 1013, 1018, 1020, 1016, 129, 110, 117, 121, 1025, 124, 128};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(225, 675));
        barManager.SetVisiblePolygonsHeight(1161, 750);
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

        camera_3d_3d.gameObject.transform.position = new Vector3(-507, 2400.53f, -7545);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,59,0);

        int[] bars = {117, 182, 1161, 101, 124};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();  

        return 25; 
    }

    public int StartTask_2_Iter_2()   {                                                                                      //Camera angle 25 || Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-1094, 3486, -5232);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,26,0);

        int[] bars = {752, 174, 504, 167, 535, 505, 790, 788, 792, 799, 154, 763, 508, 103};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 25;   
    }

    public int StartTask_2_Iter_3()   {                                                                                      //Camera angle 25 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(6830, 4627, -6209);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,-45,0);

        int[] bars = {138, 761, 757, 755, 770, 765, 780, 760, 198, 106, 165, 154, 528, 170, 174, 176, 751, 186, 794, 161, 532, 533, 784, 177, 781};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints(); 

        return 25;
    }



    public int StartTask_2_Iter_4()   {                                                                                      //Camera angle 35 || Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-230, 3596, -5762);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,47,0);

        int[] bars = {522, 520, 1003, 513, 518};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();

        return 35; 
    }

    public int StartTask_2_Iter_5()   {                                                                                      //Camera angle 35 || Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-661, 4158, -2745);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,136.4f,0);

        int[] bars = {1037, 1154, 1157, 1168, 1156, 117, 110, 146, 101, 1162, 1180, 1171, 1020, 184, 158};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 35;   
    }

    public int StartTask_2_Iter_6()   {                                                                                      //Camera angle 35 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-2959, 5170, -2392);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,120,0);

        int[] bars = {1022, 514, 1004, 1026, 1013, 1011, 1177, 184, 182, 129, 1017, 1043, 117, 1178, 1166, 1168, 1160, 146, 116, 123, 1035, 1034, 1152, 1032, 1038};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

        return 35; 
    }


    public int StartTask_2_Iter_7()   {                                                                                      //Camera angle 45 || Distractor : 5
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-325, 4370, -7609);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,56,0);

        int[] bars = {118, 129, 182, 102, 1025};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 45;  
    }

    public int StartTask_2_Iter_8()   {                                                                                      //Camera angle 45 || Distractor : 15
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-98, 4852, -8840);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,42,0);

        int[] bars = {1023, 1020, 1174, 130, 118, 122, 1152, 152, 1162, 1166, 146, 1195, 1180, 1156, 1163};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints(); 

        return 45;
    }

    public int StartTask_2_Iter_9()   {                                                                                      //Camera angle 45 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(-1800, 7084, -5699);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,39,0);

        int[] bars = {528, 776, 752, 179, 168, 170, 762, 543, 539, 790, 788, 794, 532, 186, 143, 106, 154, 765, 779, 782, 778, 196, 192, 138};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 45;  
    }

    public void SetCameraActive()   {
        camera_3d_3d.rect = new Rect(0, 0, 1, 1);
    }

}
