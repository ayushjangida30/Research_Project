using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain25DCube2D_Tasks : TaskParent
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
        mainController.camera25d2d = true;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(true);
        camera_2d_2d_2.rect = new Rect(0, 0, 1, 1);
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
        mainController.camera25d3d = false;
        mainController.camera25d2d = true;
        mainController.camera2d3d = false;
        mainController.camera2d2d = false;
        // mainController.DisableAllViewpoints();

        camera_3d_3d.gameObject.SetActive(false);
        camera_3d_2d.gameObject.SetActive(false);
        camera_2d_3d.gameObject.SetActive(false);
        camera_2d_2d_2.gameObject.SetActive(true);
        camera_2d_2d_2.rect = new Rect(0, 0, 1, 1);
        camera_2d_3d_2.gameObject.SetActive(false);
        camera_2d_2d.gameObject.SetActive(false);
    }


    public void Trial_1()   {
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-710, 3870, -8314);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(26.4f,24.7f,0);
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-1285, 3870, -7364);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(40,52.5f,0);
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-3172, 3010, -7578);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,53.2f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1039, 1046, 1029, 149, 1045};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(270, 810));
        barManager.SetVisiblePolygonsHeight(1029, 900);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_2()   {                                                                                     //Camera angle 25 || Distractor : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-520, 2719, -8119);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,34.4f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1041, 1030, 1026, 195, 1002, 1022, 515, 775, 1035, 1023, 1011, 1017, 1020, 129, 110};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(204, 612));
        barManager.SetVisiblePolygonsHeight(195, 680);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }

    public int StartTask_1_Iter_3()   {                                                                                     //Camera angle 25 || Distractor : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-3441, 4223, -6548);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,43.2f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {526, 196, 524, 197, 143, 189, 532, 163, 186, 772, 770, 774, 768, 755, 756, 776, 103, 171, 752, 170, 168, 543, 790, 754, 163};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(300, 900));
        barManager.SetVisiblePolygonsHeight(189, 1000);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 25;
    }


    public int StartTask_1_Iter_4()   {                                                                                     //Camera angle 35 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-290, 3656, -8077);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,28.8f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {1030, 775, 1027, 1028, 1013};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(291, 873));
        barManager.SetVisiblePolygonsHeight(1028, 970);
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-1011, 4282, -8968);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,36.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);


        int[] bars = {102, 1174, 1152, 117, 1018, 515, 184, 1022, 1001, 1019, 1026, 1029, 775, 1035, 1028};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(225, 675));
        barManager.SetVisiblePolygonsHeight(515, 750);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }

    public int StartTask_1_Iter_6()   {                                                                                     //Camera angle 35 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(8708, 5622, -4875);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,-90.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        centrePoint = barManager.GetBarPos(506);
        xDist = 300;
        yDist = 400;
        angle = 0;

        // GetCameraPos(camera_3d_3d, centrePoint, xDist, yDist, angle);

        int[] bars = {1002, 1022, 1006, 1010, 1013, 1026, 1039, 506, 1029, 1048, 775, 126, 1018, 1020, 120, 123, 1033, 1152, 1157, 116, 1156, 1168, 1162, 1160, 501};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(279, 837));
        barManager.SetVisiblePolygonsHeight(1039, 930);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 35;
    }


    public int StartTask_1_Iter_7()   {                                                                                     //Camera angle 45 || Distractors : 5
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(297, 3658, -6310);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,44.5f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1027, 515, 1005, 1018, 1020};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(252, 585));
        barManager.SetVisiblePolygonsHeight(1018, 650);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_8()   {                                                                                     //Camera angle 45 || Distractors : 15
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-1679, 5025, -5510);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,92.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1013, 1014, 1023, 1016, 1028, 184, 182, 156, 1172, 110, 1154, 1025, 1164, 128, 1032};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(330, 990));
        barManager.SetVisiblePolygonsHeight(1028, 1100);
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task1(barVisible);
        mainController.DisableAllViewpoints();

        return 45;
    }

    public int StartTask_1_Iter_9()   {                                                                                     //Camera angle 45 || Distractors : 25
        Task1_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-1893, 5458, -7285);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,68,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1193, 1170, 133, 1166, 1172, 1161, 1174, 182, 113, 1017, 1013, 515, 1002, 1027, 1026, 1029, 775, 1035, 1028, 123, 1152, 1025, 1156, 1159};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(261, 783));
        barManager.SetVisiblePolygonsHeight(113, 870);
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-289, 2372, -6482);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,48,0);
        barManager.TransformCube(camera_2d_2d.transform.position);
        

        int[] bars = {523, 1027, 1022, 1012, 1018};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-3739, 3672, -6925);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,73.3f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {102, 1038, 1034, 1017, 109, 156, 184, 1006, 1013, 1022, 1002, 1030, 506, 1005, 775};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-5026, 4252, -6929);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(25,74.1f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1039, 1046, 1026, 1041, 521, 136, 1002, 1022, 1008, 1013, 1018, 1035, 1028, 1177, 113, 126, 140, 1033, 1161, 1165, 1025, 1032, 115, 1178};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(491, 2998, -5555);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,36,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {198, 526, 523, 1002, 513};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-2537, 4830, -9006);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,48,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1039, 1045, 150, 526, 513, 1013, 1027, 1029, 775, 140, 1037, 113, 1161, 1177, 1032};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-4149, 5635, -8811);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(35,61.7f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {126, 149, 1029, 775, 1034, 140, 1026, 1028, 1033, 1037, 129, 1159, 128, 1016, 1014, 515, 1022, 1006, 1177, 1171, 1161, 1162, 1160, 1156};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(194, 3924, -5958);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,104,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1166, 1178, 1195, 132, 1193};
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

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-1328, 5108, -6796);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,77,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {1011, 1017, 184, 113, 1171, 110, 1172, 1160, 516, 1152, 1178, 146, 1157, 133, 1193};
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible); 
        mainController.DisableAllViewpoints();

        return 45;  
    }

    public int StartTask_2_Iter_9()   {                                                                                      //Camera angle 45 || Distractor : 25
        Task2_Setting();

        mainController.ResetSettings();

        camera_2d_2d_2.gameObject.transform.position = new Vector3(-1665, 5367, -7917);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(45,58.6f,0);
        barManager.TransformCube(camera_2d_2d.transform.position);

        int[] bars = {526, 1002, 1022, 1029, 775, 1035, 1034, 515, 1006, 1013, 1018, 1016, 110, 113, 188, 1177, 1037, 1152, 1159, 152, 102, 1160, 146, 1195, 517};
        for(int i = 0; i < bars.Length; i++)    barManager.SetVisiblePolygonsHeight(bars[i], Random.Range(226, 791));
        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        answerController.GetAnswer_Task2(barVisible);  
        mainController.DisableAllViewpoints();

        return 45;  
    }


    public void SetCameraActive()   {
        camera_2d_2d_2.rect = new Rect(0, 0, 1, 1);
    }
}
