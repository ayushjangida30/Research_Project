using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexTask2 : MonoBehaviour
{
    public PolygonManager polygonManager;
    public BarManager barManager;
    public ViewpointManager viewpointManager;
    public LinkManager linkManager;
    public OutlineManager outlineManager;
    public MainController mainController;
    public Experiment exp;

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
    private List<int> highlightList;


    void Start()
    {
        // answer_task1 = new List<int>();
    }


    private void Task_Setting()    {
        mainController.task1 = false;
        mainController.task2 = false;
        mainController.complexTask1 = false;
        mainController.complexTask2 = true;
        mainController.complexTask3 = false;
        mainController.endTask = false;
        barVisible = new List<int>();
        mainController.task_time = Time.time;
        mainController.iteration++;

        height = new Dictionary<int, float>();
        highlightList = new List<int>();
        // mainController.DisableAllViewpoints();


        startButtonController.SetPos();
    }

    public void Start_Task_1()  {
        print("Complex task started");
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

        mainController.yaw = -151.7f;
        mainController.pitch = 15.3f;


        // 1029, 198

        List<int> bars = barManager.GetAllBars();
        for(int i = 0; i < bars.Count; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        highlightList.Add(1029);
        highlightList.Add(198);

        for(int i = 0; i < highlightList.Count; i++)    {
            polygonManager.SetSelectedPolygonColor(highlightList[i] + "");
        }

        barManager.SetSelectedBarHighlightColor(highlightList);
    }

    public void Start_Task_2()  {
        print("Complex task started");
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

        mainController.yaw = -112.8f;
        mainController.pitch = 15.8f;
        // 1029, 198

        List<int> bars = barManager.GetAllBars();
        for(int i = 0; i < bars.Count; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        highlightList.Add(752);
        highlightList.Add(1033);

        for(int i = 0; i < highlightList.Count; i++)    {
            polygonManager.SetSelectedPolygonColor(highlightList[i] + "");
        }

        barManager.SetSelectedBarHighlightColor(highlightList);

        answerController.GetAnswerComplexTask2(752, 1033);
    }


    public void Start_Task_3()  {
        print("Complex task started");
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

        mainController.yaw = -151.7f;
        mainController.pitch = 15.3f;
        // 1029, 198

        List<int> bars = barManager.GetAllBars();
        for(int i = 0; i < bars.Count; i++)    {
            float h = Random.Range(200, 850);
            barManager.SetVisiblePolygonsHeight(bars[i], h);
            height.Add(bars[i], h);
            barManager.AdjustCubes(bars[i], h);
        }

        highlightList.Add(161);
        highlightList.Add(150);

        for(int i = 0; i < highlightList.Count; i++)    {
            polygonManager.SetSelectedPolygonColor(highlightList[i] + "");
        }

        barManager.SetSelectedBarHighlightColor(highlightList);

        answerController.GetAnswerComplexTask2(161, 150);
    }

    
}
