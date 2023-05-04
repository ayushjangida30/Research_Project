using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTask3 : MonoBehaviour
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


    void Start()
    {
        // answer_task1 = new List<int>();
    }


    private void Task_Setting()    {
        mainController.task1 = false;
        mainController.task2 = false;
        mainController.complexTask1 = false;
        mainController.complexTask2 = false;
        mainController.complexTask3 = true;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        height = new Dictionary<int, float>();
        // mainController.DisableAllViewpoints();


        startButtonController.SetPos();
    }

    public void Start_Task_1()  {
        // print("Complex task started");
        Task_Setting();
        mainController.ResetSettings();

        camera_3d_3d.gameObject.transform.position = new Vector3(7259.61f, 2557.078f, -4356.262f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(15.8f, -112.8f, 0f);

        camera_3d_2d.gameObject.transform.position = new Vector3(7259.61f, 2557.078f, -4356.262f);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(15.8f, -112.8f, 0f);

        camera_2d_3d.gameObject.transform.position = new Vector3(7259.61f, 2557.078f, -4356.262f);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(15.8f, -112.8f, 0f);

        camera_2d_2d_2.gameObject.transform.position = new Vector3(7259.61f, 2557.078f, -4356.262f);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(15.8f, -112.8f, 0f);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(-14.84375f, 4091.488f, -13640.65f);
        camera_2d_3d_2.gameObject.transform.localRotation = Quaternion.Euler(30, 0, 0);

        camera_2d_2d.gameObject.transform.position = new Vector3(-14.84375f, 4091.488f, -7414.152f);
        camera_2d_2d.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0f);


        // 1029, 198

        List<int> bars = barManager.GetAllBars();
        for(int i = 0; i < bars.Count; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        linkManager.CalculateVisibility(bars);
        viewpointManager.DisableSelectedViewpoint("LMT");
        viewpointManager.DisableSelectedViewpoint("E111");
        viewpointManager.DisableSelectedViewpoint("Old Weather Tower on F600");
        viewpointManager.DisableSelectedViewpoint("224&122");
        viewpointManager.DisableSelectedViewpoint("224&Dedwney");
        viewpointManager.DisableSelectedViewpoint("232&Dedwney");
        viewpointManager.DisableSelectedViewpoint("Jerry Sulina Park");
        viewpointManager.DisableSelectedViewpoint("Fire Hall 3");
        viewpointManager.DisableSelectedViewpoint("240&Dedwney");
    }

    public void Start_Task_2()  {
        List<string> viewpointsEnabled = new List<string>();
        // print("Complex task started");
        Task_Setting();
        mainController.ResetSettings();

        

        camera_3d_3d.gameObject.transform.position = new Vector3(4140.237f, 2790.049f, 4501.255f);
        camera_3d_3d.gameObject.transform.localRotation = Quaternion.Euler(15.3f, -151.7f, 0f);

        camera_3d_2d.gameObject.transform.position = new Vector3(4140.237f, 2790.049f, 4501.255f);
        camera_3d_2d.gameObject.transform.localRotation = Quaternion.Euler(15.3f, -151.7f, 0f);

        camera_2d_3d.gameObject.transform.position = new Vector3(4140.237f, 2790.049f, 4501.255f);
        camera_2d_3d.gameObject.transform.localRotation = Quaternion.Euler(15.3f, -151.7f, 0f);

        camera_2d_2d_2.gameObject.transform.position = new Vector3(4140.237f, 2790.049f, 4501.255f);
        camera_2d_2d_2.gameObject.transform.localRotation = Quaternion.Euler(15.3f, -151.7f, 0f);

        camera_2d_3d_2.gameObject.transform.position = new Vector3(281.5726f, 4091.488f, -8891.555f);
        camera_2d_3d_2.gameObject.transform.localRotation = Quaternion.Euler(30, 0, 0);

        camera_2d_2d.gameObject.transform.position = new Vector3(281.5726f, 4091.488f, -2665.061f);
        camera_2d_2d.gameObject.transform.localRotation = Quaternion.Euler(90, 0, 0f);

        // 1029, 198

        List<int> bars = barManager.GetAllBars();
        for(int i = 0; i < bars.Count; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        linkManager.CalculateVisibility(bars);
        viewpointManager.DisableSelectedViewpoint("232&Dedwney");
        viewpointManager.DisableSelectedViewpoint("LMT");
        viewpointManager.DisableSelectedViewpoint("203&Dedwney");
        viewpointManager.DisableSelectedViewpoint("Jerry Sulina Park");

        viewpointsEnabled.Add("Ionut's House");
        // viewpointsEnabled.Add("Jerry Sulina Park");
        // viewpointsEnabled.Add("232&Dedwney");
        viewpointsEnabled.Add("E111");
        // viewpointsEnabled.Add("LMT");
        viewpointsEnabled.Add("224&Dedwney");
        viewpointsEnabled.Add("240&Dedwney");
        viewpointsEnabled.Add("224&122");
        // viewpointsEnabled.Add("203&Dedwney");
        viewpointsEnabled.Add("Pitt River Bridge");
        viewpointsEnabled.Add("Loon lake Dock");
        viewpointsEnabled.Add("Fire Hall 3");
        viewpointsEnabled.Add("Old Weather Tower on F60");

        answerController.GetAnswerComplexTask3(viewpointsEnabled);

    }


    public void Start_Task_3()  {
        List<string> viewpointsEnabled = new List<string>();
        // print("Complex task started");
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
        
        // 1029, 198

        List<int> bars = barManager.GetAllBars();
        for(int i = 0; i < bars.Count; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        linkManager.CalculateVisibility(bars);
        viewpointManager.DisableSelectedViewpoint("Old Weather Tower on F600");
        viewpointManager.DisableSelectedViewpoint("Fire Hall 3");
        viewpointManager.DisableSelectedViewpoint("240&Dedwney");
        viewpointManager.DisableSelectedViewpoint("Jerry Sulina Park");
        viewpointManager.DisableSelectedViewpoint("Pitt River Bridge");


        viewpointsEnabled.Add("Ionut's House");
        // viewpointsEnabled.Add("Jerry Sulina Park");
        viewpointsEnabled.Add("232&Dedwney");
        viewpointsEnabled.Add("E111");
        viewpointsEnabled.Add("LMT");
        viewpointsEnabled.Add("224&Dedwney");
        // viewpointsEnabled.Add("240&Dedwney");
        viewpointsEnabled.Add("224&122");
        viewpointsEnabled.Add("203&Dedwney");
        // viewpointsEnabled.Add("Pitt River Bridge");
        viewpointsEnabled.Add("Loon lake Dock");
        // viewpointsEnabled.Add("Fire Hall 3");
        // viewpointsEnabled.Add("Old Weather Tower on F60");

        answerController.GetAnswerComplexTask3(viewpointsEnabled);
    }
}
