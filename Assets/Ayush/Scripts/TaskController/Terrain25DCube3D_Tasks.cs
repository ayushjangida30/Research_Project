using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain25DCube3D_Tasks : MonoBehaviour
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

        mainController.camera3d3d = false;
        mainController.camera3d2d = false;
        mainController.camera25d3d = true;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(true);
        camera_2d_3d.rect = new Rect(0, 0, 1, 1);
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
        mainController.camera3d2d = false;
        mainController.camera25d3d = true;
        mainController.camera25d2d = false;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(true);
        camera_2d_3d.rect = new Rect(0, 0, 1, 1);
        camera_2d_2d_2.gameObject.SetActive(false);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(false);
    }

    public void Trial_1()   {
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-710, 3051, -8314);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(26.4f,24.7f,0);
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-1285, 4180, -7364);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(40,52.5f,0);
        barManager.TransformCube();

        int[] bars = {775, 1018, 1016};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 600));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);  

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);
        mainController.DisableAllViewpoints();

    }


// TASK 1    

     public int StartTask_1_Iter_1()   {                                                                                    //Camera angle 25 || Distractor : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-529, 2797, -8259);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,30,0);
        barManager.TransformCube();

        int[] bars = {775, 1030, 1027, 1002, 1013};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(240, 720));
        barManager.SetVisiblePolygonsHeight(1027, 800);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_2()   {                                                                                     //Camera angle 25 || Distractor : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-45, 3492, -9072);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,22,0);
        barManager.TransformCube();

        int[] bars = {1030, 1026, 770, 778, 1043, 143, 189, 513, 135, 1006, 1014, 184, 1001, 134, 528};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(180, 540));
        barManager.SetVisiblePolygonsHeight(134, 600);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_3()   {                                                                                     //Camera angle 25 || Distractor : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-1971, 3507, -9274);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,52,0);
        barManager.TransformCube();

        int[] bars = {1037, 1034, 1027, 1002, 1022, 1028, 1006, 1018, 1016, 113, 188, 1152, 1177, 152, 102, 1160, 1157, 133, 146, 1178, 1181, 1191, 190, 159, 1190};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(300, 900));
        barManager.SetVisiblePolygonsHeight(1177, 1000);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }


    public int StartTask_1_Iter_4()   {                                                                                     //Camera angle 35 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-1502, 3956, -7501);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,50,0);
        barManager.TransformCube();

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {1030, 1002, 1020, 1035, 182};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(291, 873));
        barManager.SetVisiblePolygonsHeight(1035, 970);
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

        camera_2d_3d.gameObject.transform.position = new Vector3(4315, 4786, -10477);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,-25,0);
        barManager.TransformCube();

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);
        barManager.SetVisiblePolygonsHeight(170, 1030);

        int[] bars = {1038, 139, 150, 1034, 1041, 1035, 1029, 123, 1152, 1027, 117, 129, 1014, 1174, 1009};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(315, 945));
        barManager.SetVisiblePolygonsHeight(117, 1050);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }

    public int StartTask_1_Iter_6()   {                                                                                     //Camera angle 35 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-2847, 5383, -5912);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,43,0);
        barManager.TransformCube();

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {776, 103, 171, 504, 168, 170, 543, 757, 774, 758, 779, 186, 792, 795, 154, 532, 138, 143, 106, 778, 196, 192};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(249, 747));
        barManager.SetVisiblePolygonsHeight(774, 830);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }


    public int StartTask_1_Iter_7()   {                                                                                     //Camera angle 45 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(3711, 4812, -9060);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,-24,0);
        barManager.TransformCube();

        int[] bars = {1018, 129, 1028, 1154, 1025};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(252, 756));
        barManager.SetVisiblePolygonsHeight(129, 840);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_8()   {                                                                                     //Camera angle 45 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(6558, 7310, -7017);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,-55,0);
        barManager.TransformCube();

        int[] bars = {1006, 1009, 1016, 1023, 1029, 1039, 1040, 761, 755, 757, 772, 526, 1026, 1022, 522};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(330, 990));
        barManager.SetVisiblePolygonsHeight(1023, 1100);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_9()   {                                                                                     //Camera angle 45 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_3d.gameObject.transform.position = new Vector3(-2114, 5207, -7605);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,68,0);
        barManager.TransformCube();

        int[] bars = {775, 1035, 1029, 1027, 515, 1012, 1014, 113, 117, 1174, 182, 140, 1037, 109, 124, 1152, 1155, 1157, 101, 1161, 1162, 1166, 1195, 133, 1192};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(270, 810));
        barManager.SetVisiblePolygonsHeight(1174, 900);
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

        camera_2d_3d.gameObject.transform.position = new Vector3(2473, 2862, -9078);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,-29,0);
        barManager.TransformCube();
        

        int[] bars = {126, 1046, 1047, 1039, 140};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-2517, 2944, -7499);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,67.2f,0);
        barManager.TransformCube();

        int[] bars = {1035, 1018, 1020, 184, 117, 1174, 152, 140, 188, 1037, 128, 1162, 1160, 1156, 1005};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-784, 3414, -324);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(25,152.1f,0);
        barManager.TransformCube();

        int[] bars = {1002, 184, 515, 1180, 1009, 1014, 182, 1170, 1161, 1174, 120, 1026, 1025, 1193, 133, 110, 1028, 1157, 1032, 1037, 1038, 775, 1030, 1041};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-1707, 3591, -2631);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,45.7f,0);
        barManager.TransformCube();

        int[] bars = {172, 503, 168, 786, 165};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-1209, 3632, -7851);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,48,0);
        barManager.TransformCube();

        int[] bars = {1041, 1030, 1026, 1022, 1013, 775, 1034, 1028, 1011, 1017, 1020, 113, 1171, 110, 188};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-3209, 6140, -7554);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(35,36.1f,0);
        barManager.TransformCube();

        int[] bars = {103, 172, 176, 776, 504, 509, 543, 539, 788, 751, 794, 186, 532, 138, 143, 106, 154, 768, 758, 779, 778, 522, 528, 505, 533};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-958, 4340, -8006);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,54.7f,0);
        barManager.TransformCube();

        int[] bars = {1028, 1020, 1037, 1152, 101};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-1827, 5492, -7546);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,69.9f,0);
        barManager.TransformCube();

        int[] bars = {1018, 501, 113, 1028, 1171, 118, 1172, 517, 1166, 1182, 1187, 1193, 133, 1156, 1032};
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

        camera_2d_3d.gameObject.transform.position = new Vector3(-2694, 7486, -9531);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(45,40.2f,0);
        barManager.TransformCube();

        int[] bars = {761, 1040, 778, 1039, 149, 1041, 1026, 1029, 526, 1002, 143, 513, 1027, 1028, 140, 118, 1016, 1018, 1006, 1177, 158, 1174, 152, 1162, 1046};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(200, 700));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 45;  
    }

    public void SetCameraActive()   {
        camera_2d_3d.rect = new Rect(0, 0, 1, 1);
    }
}
