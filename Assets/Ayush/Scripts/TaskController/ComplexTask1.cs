using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTask1 : MonoBehaviour
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

    private Dictionary<int, float> height;
    // Start is called before the first frame update
    void Start()
    {
        // answer_task1 = new List<int>();
    }

    private void Task_Setting()    {
        mainController.task1 = false;
        mainController.task2 = false;
        mainController.complexTask1 = true;
        mainController.complexTask2 = false;
        mainController.complexTask3 = false;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        height = new Dictionary<int, float>();
        // mainController.DisableAllViewpoints();


        startButtonController.SetPos();
    }

    public void Start_Task_1()  {
        Task_Setting();
        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(5862.4f, 1903.6f, 1164.2f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(10.8f, -140.1f, 0f);

        camera_3d_2d.gameObject.transform.position = new Vector3(5862.4f, 1903.6f, 1164.2f);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(10.8f, -140.1f, 0f);

        camera_2d_3d.gameObject.transform.position = new Vector3(5862.4f, 1903.6f, 1164.2f);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(10.8f, -140.1f, 0f);

        camera_2d_2d_2.gameObject.transform.position = new Vector3(5862.4f, 1903.6f, 1164.2f);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(10.8f, -140.1f, 0f);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1435.548f, 4091.488f, 10356);
        camera_2d_3d_2.gameObject.transform.localRotation = Quaternion.Euler(30, 0, 0);

        camera_2d_2d.gameObject.transform.position = new Vector3(1435.548f, 4091.488f, -4130);
        camera_2d_2d.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0f);

        mainController.yaw = -140.1f;
        mainController.pitch = 10.8f;

        int[] bars = {1040, 779, 506, 1026, 1027, 1029, 1035, 1047, 530, 107, 525, 189, 513, 1013, 1020, 533, 549, 543, 501, 121, 1033, 1037, 505, 754, 156, 1162, 1156, 199, 144, 187, 112, 160, 148, 174, 172};
        for(int i = 0; i < bars.Length; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        mainController.DisableAllViewpoints();
    }

    public void Start_Task_2()  {
        Task_Setting();
        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(4405.076f, 7396.884f, -2329.502f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(67.2f, -125.2f, 0f);

        camera_3d_2d.gameObject.transform.position = new Vector3(4405.076f, 7396.884f, -2329.502f);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(67.2f, -125.2f, 0f);

        camera_2d_3d.gameObject.transform.position = new Vector3(4405.076f, 7396.884f, -2329.502f);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(67.2f, -125.2f, 0f);

        camera_2d_2d_2.gameObject.transform.position = new Vector3(4405.076f, 7396.884f, -2329.502f);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(67.2f, -125.2f, 0f);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(2129.89f, 4091.488f, -10190.87f);
        camera_2d_3d_2.gameObject.transform.localRotation = Quaternion.Euler(30, 0, 0);

        camera_2d_2d.gameObject.transform.position = new Vector3(2129.89f, 4091.488f, -3964.377f);
        camera_2d_2d.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0f);

        mainController.yaw = -125.2f;
        mainController.pitch = 67.2f;

        int[] bars = {1191, 133, 1166, 199, 1176, 1171, 1157, 129, 1037, 1006, 1035, 1017, 513, 1022, 1026, 526, 772, 530, 1040, 1039, 149, 761, 780, 776, 509, 179, 177, 537, 538, 545, 108, 145, 532, 193, 781};
        for(int i = 0; i < bars.Length; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        mainController.DisableAllViewpoints();
        answerController.GetAnswerComplexTask1(barVisible);
    }

    public void Start_Task_3()  {
        Task_Setting();
        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(6682.114f, 1357.45f, -7297.719f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(6.9f, -55.5f, 0f);

        camera_3d_2d.gameObject.transform.position = new Vector3(6682.114f, 1357.45f, -7297.719f);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(6.9f, -55.5f, 0f);

        camera_2d_3d.gameObject.transform.position = new Vector3(6682.114f, 1357.45f, -7297.719f);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(6.9f, -55.5f, 0f);

        camera_2d_2d_2.gameObject.transform.position = new Vector3(6682.114f, 1357.45f, -7297.719f);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(6.9f, -55.5f, 0f);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(1509.034f, 4091.488f, -9968.846f);
        camera_2d_3d_2.gameObject.transform.localRotation = Quaternion.Euler(30, 0, 0);

        camera_2d_2d.gameObject.transform.position = new Vector3(1509.034f, 4091.488f, -3742.352f);
        camera_2d_2d.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0f);

        mainController.yaw = -55.5f;
        mainController.pitch = 6.9f;

        int[] bars = {133, 1033, 1157, 140, 1048, 149, 1039, 775, 118, 1040, 1043, 129, 101, 1171, 772, 1011, 1006, 158, 1189, 501, 1183, 516, 526, 142, 510, 545, 538, 794, 532, 138, 135, 163, 527, 160};
        for(int i = 0; i < bars.Length; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        for(int i = 0; i < bars.Length; i++)    barVisible.Add(bars[i]);

        linkManager.CalculateVisibility(barVisible);
        mainController.DisableAllViewpoints();
        answerController.GetAnswerComplexTask1(barVisible);
    }

    
}
