using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    private int userID = 3;
    public MainController mainController;
    public EnterButton enterButton;
    public Button nextTask;
    public GameObject panel;
    public BarManager barManager;
    public LinkManager linkManager;
    public Experiment exp;

    public InputField viewpoint1;
    public InputField viewpoint2;

    public Camera camera_3d_3d;
    public Camera camera_3d_2d;
    public Camera camera_2d_3d;
    public Camera camera_2d_2d;
    public Camera camera_2d_2d_2;
    public Camera camera_2d_3d_2;

    public Image border_1;
    public Image border_2;
    public Image border_3;
    public Image indicator;


    public eyelink eyelink;
    private string trialName = "";


    // // User 1, 7, 13
    // private Terrain3DCube3D_Tasks view1;
    // private Terrain3DCube2D_Tasks view2;
    // private Terrain25DCube3D_Tasks view3;
    // private Terrain25DCube2D_Tasks view6;
    // private Terrain2DCube3D_Tasks view4;
    // private Terrain2DCube2D_Tasks view5;


    // // User 2, 8, 14
    // private Terrain3DCube3D_Tasks view2;
    // private Terrain3DCube2D_Tasks view3;
    // private Terrain25DCube3D_Tasks view1;
    // private Terrain25DCube2D_Tasks view4;
    // private Terrain2DCube3D_Tasks view6;
    // private Terrain2DCube2D_Tasks view5;

    // User 3, 9, 15
    private Terrain3DCube3D_Tasks view3;
    private Terrain3DCube2D_Tasks view4;
    private Terrain25DCube3D_Tasks view2;
    private Terrain25DCube2D_Tasks view5;
    private Terrain2DCube3D_Tasks view1;
    private Terrain2DCube2D_Tasks view6;

    // // User 4, 10, 16
    // private Terrain3DCube3D_Tasks view4;
    // private Terrain3DCube2D_Tasks view5;
    // private Terrain25DCube3D_Tasks view3;
    // private Terrain25DCube2D_Tasks view6;
    // private Terrain2DCube3D_Tasks view2;
    // private Terrain2DCube2D_Tasks view1;

    // // User 5, 11, 17
    // private Terrain3DCube3D_Tasks view5;
    // private Terrain3DCube2D_Tasks view6;
    // private Terrain25DCube3D_Tasks view4;
    // private Terrain25DCube2D_Tasks view1;
    // private Terrain2DCube3D_Tasks view3;
    // private Terrain2DCube2D_Tasks view2;

    // // User 6, 12, 18
    // private Terrain3DCube3D_Tasks view6;
    // private Terrain3DCube2D_Tasks view1;
    // private Terrain25DCube3D_Tasks view5;
    // private Terrain25DCube2D_Tasks view2;
    // private Terrain2DCube3D_Tasks view4;
    // private Terrain2DCube2D_Tasks view3;


// Complex task order
    // User 1, 2, 3, 4, 5, 6, 13, 14, 15, 16, 17, 18
    private ComplexTask1 complexTask_1;
    private ComplexTask3 complexTask_3;

    // // User 7, 8, 9, 10, 11, 12, 19, 20, 21, 22, 23, 24
    // private ComplexTask1 complexTask_3;
    // private complexTask3 complexTask_1;


    private string v1 = "View 1";
    private string v2 = "View 2";
    private string v3 = "View 3";
    private string v4 = "View 4";
    private string v5 = "View 5";
    private string v6 = "View 6";


    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;
    public GameObject camera5;
    public GameObject camera6;

    public bool spaceClicked = false;
    private string str = "Task 1 Panel";
    private string name = "";
    private int count = -4;
    // private int temp = -3;
    public int total = 0;
    public int quotient = 0;
    private int val = -1;
    private List<int> list = new List<int>();
    private int tick = 0;
    private bool task = false;
    private bool complexTask = false;
    private int cameraAngle = 0;
    private int distractors = 0;
    


    private bool log = false;

    // Start is called before the frst frame update
    void Start()
    {   

// SIMPLE TASKS
        // // if(userID == 1 || userId == 7 || userID == 13 || userID == 19) {
        //     view1 = GameObject.Find("GameObject").GetComponent<Terrain3DCube3D_Tasks>();
        //     view2 = GameObject.Find("GameObject").GetComponent<Terrain3DCube2D_Tasks>();
        //     view3 = GameObject.Find("GameObject").GetComponent<Terrain25DCube3D_Tasks>();
        //     view6 = GameObject.Find("GameObject").GetComponent<Terrain25DCube2D_Tasks>();
        //     view4 = GameObject.Find("GameObject").GetComponent<Terrain2DCube3D_Tasks>();
        //     view5 = GameObject.Find("GameObject").GetComponent<Terrain2DCube2D_Tasks>();

        //     camera1 = GameObject.Find("3D_3D");
        //     camera2 = GameObject.Find("3D_2D");
        //     camera3 = GameObject.Find("2D_3D");
        //     camera6 = GameObject.Find("2D_2D_2");
        //     camera4 = GameObject.Find("2D_3D_2");
        //     camera5 = GameObject.Find("2D_2D");
        // // }
        // // if(userID == 2 || userId == 8 || userID == 14 || userID == 20) {
        //     view2 = GameObject.Find("GameObject").GetComponent<Terrain3DCube3D_Tasks>();
        //     view3 = GameObject.Find("GameObject").GetComponent<Terrain3DCube2D_Tasks>();
        //     view1 = GameObject.Find("GameObject").GetComponent<Terrain25DCube3D_Tasks>();
        //     view4 = GameObject.Find("GameObject").GetComponent<Terrain25DCube2D_Tasks>();
        //     view6 = GameObject.Find("GameObject").GetComponent<Terrain2DCube3D_Tasks>();
        //     view5 = GameObject.Find("GameObject").GetComponent<Terrain2DCube2D_Tasks>();

        //     camera2 = GameObject.Find("3D_3D");
        //     camera3 = GameObject.Find("3D_2D");
        //     camera1 = GameObject.Find("2D_3D");
        //     camera4 = GameObject.Find("2D_2D_2");
        //     camera6 = GameObject.Find("2D_3D_2");
        //     camera5 = GameObject.Find("2D_2D");
        // // }
        // if(userID == 3 || userId == 9 || userID == 15 || userID == 21) {
            view3 = GameObject.Find("GameObject").GetComponent<Terrain3DCube3D_Tasks>();
            view4 = GameObject.Find("GameObject").GetComponent<Terrain3DCube2D_Tasks>();
            view2 = GameObject.Find("GameObject").GetComponent<Terrain25DCube3D_Tasks>();
            view5 = GameObject.Find("GameObject").GetComponent<Terrain25DCube2D_Tasks>();
            view1 = GameObject.Find("GameObject").GetComponent<Terrain2DCube3D_Tasks>();
            view6 = GameObject.Find("GameObject").GetComponent<Terrain2DCube2D_Tasks>();

            camera3 = GameObject.Find("3D_3D");
            camera4 = GameObject.Find("3D_2D");
            camera2 = GameObject.Find("2D_3D");
            camera5 = GameObject.Find("2D_2D_2");
            camera1 = GameObject.Find("2D_3D_2");
            camera6 = GameObject.Find("2D_2D");
        // }
        // // if(userID == 4 || userId == 10 || userID == 16 || userID == 22) {
        //     view4 = GameObject.Find("GameObject").GetComponent<Terrain3DCube3D_Tasks>();
        //     view5 = GameObject.Find("GameObject").GetComponent<Terrain3DCube2D_Tasks>();
        //     view3 = GameObject.Find("GameObject").GetComponent<Terrain25DCube3D_Tasks>();
        //     view6 = GameObject.Find("GameObject").GetComponent<Terrain25DCube2D_Tasks>();
        //     view2 = GameObject.Find("GameObject").GetComponent<Terrain2DCube3D_Tasks>();
        //     view1 = GameObject.Find("GameObject").GetComponent<Terrain2DCube2D_Tasks>();

        //     camera4 = GameObject.Find("3D_3D");
        //     camera5 = GameObject.Find("3D_2D");
        //     camera3 = GameObject.Find("2D_3D");
        //     camera6 = GameObject.Find("2D_2D_2");
        //     camera2 = GameObject.Find("2D_3D_2");
        //     camera1 = GameObject.Find("2D_2D");
        // // }
        // // if(userID == 5 || userId == 11 || userID == 17 || userID == 23) {
        //     view5 = GameObject.Find("GameObject").GetComponent<Terrain3DCube3D_Tasks>();
        //     view6 = GameObject.Find("GameObject").GetComponent<Terrain3DCube2D_Tasks>();
        //     view4 = GameObject.Find("GameObject").GetComponent<Terrain25DCube3D_Tasks>();
        //     view1 = GameObject.Find("GameObject").GetComponent<Terrain25DCube2D_Tasks>();
        //     view3 = GameObject.Find("GameObject").GetComponent<Terrain2DCube3D_Tasks>();
        //     view2 = GameObject.Find("GameObject").GetComponent<Terrain2DCube2D_Tasks>();

        //     camera5 = GameObject.Find("3D_3D");
        //     camera6 = GameObject.Find("3D_2D");
        //     camera4 = GameObject.Find("2D_3D");
        //     camera1 = GameObject.Find("2D_2D_2");
        //     camera3 = GameObject.Find("2D_3D_2");
        //     camera2 = GameObject.Find("2D_2D");
        // // }
        // // if(userID == 6 || userId == 12 || userID == 18 || userID == 24) {
        //     view6 = GameObject.Find("GameObject").GetComponent<Terrain3DCube3D_Tasks>();
        //     view1 = GameObject.Find("GameObject").GetComponent<Terrain3DCube2D_Tasks>();
        //     view5 = GameObject.Find("GameObject").GetComponent<Terrain25DCube3D_Tasks>();
        //     view2 = GameObject.Find("GameObject").GetComponent<Terrain25DCube2D_Tasks>();
        //     view4 = GameObject.Find("GameObject").GetComponent<Terrain2DCube3D_Tasks>();
        //     view3 = GameObject.Find("GameObject").GetComponent<Terrain2DCube2D_Tasks>();

        //     camera6 = GameObject.Find("3D_3D");
        //     camera1 = GameObject.Find("3D_2D");
        //     camera5 = GameObject.Find("2D_3D");
        //     camera2 = GameObject.Find("2D_2D_2");
        //     camera4 = GameObject.Find("2D_3D_2");
        //     camera3 = GameObject.Find("2D_2D");
        // // }

// Complex task order:

        // User 1, 2, 3, 4, 5, 6, 13, 14, 15, 16, 17, 18
        complexTask_1 = GameObject.Find("GameObject").GetComponent<ComplexTask1>();
        complexTask_3 = GameObject.Find("GameObject").GetComponent<ComplexTask3>();

        // // User 7, 8, 9, 10, 11, 12, 19, 20, 21, 22, 23, 24
        // complexTask_3 = GameObject.Find("GameObject").GetComponent<ComplexTask1>();
        // complexTask_1 = GameObject.Find("GameObject").GetComponent<ComplexTask3>();
    }


// COMPLEX TASK


    // // User 1, 2, 3, 4, 5, 6
    // //Pos 1 - Complex task
    public void SetPos()    {
        camera_2d_2d.gameObject.SetActive(true);
        camera_2d_2d.rect = new Rect(0.66f, 0.5f, 0.34f, 0.5f);

        camera_2d_3d_2.gameObject.SetActive(true);
        camera_2d_3d_2.rect = new Rect(0.66f, 0, 0.34f, 0.5f);

        camera_2d_2d_2.gameObject.SetActive(true);
        camera_2d_2d_2.rect = new Rect(0, 0.5f, 0.33f, 0.5f);

        camera_2d_3d.gameObject.SetActive(true);
        camera_2d_3d.rect = new Rect(0, 0, 0.33f, 0.5f);

        camera_3d_2d.gameObject.SetActive(true);
        camera_3d_2d.rect = new Rect(0.33f, 0.5f, 0.33f, 0.5f);
        
        camera_3d_3d.gameObject.SetActive(true);
        camera_3d_3d.rect = new Rect(0.33f, 0, 0.33f, 0.5f);
    }


    // User 7, 8, 9, 10, 11, 12
    // // // Pos 2 - Complex Task 
    // public void SetPos()    {
    //     camera_2d_2d.gameObject.SetActive(true);
    //     camera_2d_2d.rect = new Rect(0, 0.5f, 0.33f, 0.5f);

    //     camera_2d_3d_2.gameObject.SetActive(true);
    //     camera_2d_3d_2.rect = new Rect(0, 0, 0.33f, 0.5f);

    //     camera_2d_2d_2.gameObject.SetActive(true);
    //     camera_2d_2d_2.rect = new Rect(0.66f, 0.5f, 0.34f, 0.5f);

    //     camera_2d_3d.gameObject.SetActive(true);
    //     camera_2d_3d.rect = new Rect(0.66f, 0, 0.34f, 0.5f);

    //     camera_3d_2d.gameObject.SetActive(true);
    //     camera_3d_2d.rect = new Rect(0.33f, 0.5f, 0.33f, 0.5f);
        
    //     camera_3d_3d.gameObject.SetActive(true);
    //     camera_3d_3d.rect = new Rect(0.33f, 0, 0.33f, 0.5f);
        
    // }

    // // User 13, 14, 15, 16, 17, 18
    // // Pos 3 - Complex Task
    // public void SetPos()    {
    //     camera_2d_2d.gameObject.SetActive(true);
    //     camera_2d_2d.rect = new Rect(0.66f, 0, 0.34f, 0.5f);

    //     camera_2d_3d_2.gameObject.SetActive(true);
    //     camera_2d_3d_2.rect = new Rect(0.66f, 0.5f, 0.34f, 0.5f);

    //     camera_2d_2d_2.gameObject.SetActive(true);
    //     camera_2d_2d_2.rect = new Rect(0, 0, 0.33f, 0.5f);

    //     camera_2d_3d.gameObject.SetActive(true);
    //     camera_2d_3d.rect = new Rect(0.33f, 0.5f, 0.33f, 0.5f);

    //     camera_3d_2d.gameObject.SetActive(true);
    //     camera_3d_2d.rect = new Rect(0, 0.5f, 0.33f, 0.5f);
        
    //     camera_3d_3d.gameObject.SetActive(true);
    //     camera_3d_3d.rect = new Rect(0.33f, 0.5f, 0.33f, 0.5f);
    // }


    // User 19, 20, 21, 22, 23, 24
    // // Pos 4 - Complex Task
    // public void SetPos()    {
    //     camera_2d_2d.gameObject.SetActive(true);
    //     camera_2d_2d.rect = new Rect(0, 0, 0.33f, 0.5f);

    //     camera_2d_3d_2.gameObject.SetActive(true);
    //     camera_2d_3d_2.rect = new Rect(0, 0.5f, 0.33f, 0.5f);

    //     camera_2d_2d_2.gameObject.SetActive(true);
    //     camera_2d_2d_2.rect = new Rect(0.66f, 0, 0.34f, 0.5f);

    //     camera_2d_3d.gameObject.SetActive(true);
    //     camera_2d_3d.rect = new Rect(0.66f, 0.5f, 0.34f, 0.5f);

    //     camera_3d_2d.gameObject.SetActive(true);
    //     camera_3d_2d.rect = new Rect(0.33f, 0, 0.33f, 0.5f);
        
    //     camera_3d_3d.gameObject.SetActive(true);
    //     camera_3d_3d.rect = new Rect(0.33f, 0.5f, 0.33f, 0.5f);
    // }

    void Update()   {
        if(mainController.task1 || mainController.task2)    {
            border_1.gameObject.SetActive(false);
            border_2.gameObject.SetActive(false);
            border_3.gameObject.SetActive(false);
            indicator.gameObject.SetActive(false);
        }else if(mainController.complexTask1 || mainController.complexTask2 || mainController.complexTask3) {
            border_1.gameObject.SetActive(true);
            border_2.gameObject.SetActive(true);
            border_3.gameObject.SetActive(true);
            indicator.gameObject.SetActive(true);
        }
        Random.seed = tick++;
        print("List size: " + list.Count);

        if(Input.GetKeyDown(KeyCode.Space)) {
            CheckCondition();
        }
        if(complexTask) {
            mainController.ExportLog();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exp.End_Recording();
        }
    }

    public void CheckCondition()    {
        mainController.endTask = true;
            if(count < 0)   count += 1;
            print(this.name + "NAME");

            if((mainController.task1 && barManager.GetBarSelectedDictCount() > 0) || (mainController.task2 && barManager.GetBarSelectedDictCount() > 1) || (mainController.complexTask1 && barManager.GetBarSelectedDictCount() == 3 && barManager.GetBarFinalSeleced() == 2) || (mainController.complexTask2 && barManager.GetBarSelectedDictCount() == 1 && linkManager.GetViewpointSelectedCount() == 2) || (mainController.complexTask3 && linkManager.GetViewpointSelectedCount() == 1) && count > 0)    {
                if(task)    {
                    mainController.LogData(cameraAngle, distractors, (total % 9), userID);
                }
                quotient = total / 9;
                if(val != quotient && count >= 0) {
                    if(quotient == 0 || quotient == 6)   {
                        camera1.gameObject.SetActive(true);
                        val = quotient;
                    }
                    if(quotient == 1 || quotient == 7)   {
                        camera2.gameObject.SetActive(true);
                        val = quotient;
                    }
                    if(quotient == 2 || quotient == 8)   {
                        camera3.gameObject.SetActive(true);
                        val = quotient;
                    }
                    if(quotient == 3 || quotient == 9)   {
                        camera4.gameObject.SetActive(true);
                        val = quotient;
                    }
                    if(quotient == 4 || quotient == 10)   {
                        camera5.gameObject.SetActive(true);
                        val = quotient;
                    }
                    if(quotient == 5 || quotient == 11)   {
                        camera6.gameObject.SetActive(true);
                        val = quotient;
                    }   

                    if(quotient >= 12)  {
                        camera1.gameObject.SetActive(true);
                        camera2.gameObject.SetActive(true);
                        camera3.gameObject.SetActive(true);
                        camera4.gameObject.SetActive(true);
                        camera5.gameObject.SetActive(true);
                        camera6.gameObject.SetActive(true);
                        val = quotient;
                    }        
            }
                spaceClicked = true;
                if(trialName != "") {
                    exp.End_Trial(trialName + "_");
                }
                OnStartButtonClicked();
            }

        // if(mainController.task3_part1 && mainController.task3_iteration1 && quotient == 12)  {
        //     print("Code reaching part 2");
        //     complexTask_1.Start_Task_1_Part_2();
        // }

        // if(mainController.task3_part1 && mainController.task3_iteration1 && quotient == 13)  {
        //     print("Code reaching part 2");
        //     complexTask_2.Start_Task_1_Part_2();
        // }

        // if(mainController.task40_part1 && mainController.task40_iteration1 && quotient == 14)  {
        //     print("Code reaching part 2");
        //     complexTask_3.Start_Task_1_Part_2();
        // }

        if(count <= 0)   {
            spaceClicked = true;
            OnStartButtonClicked();
        }
    }

    public void OnStartButtonClicked()  {
        mainController.endTask = false;
        // eyelink.StartTracker("sdemo_3");
        // print("eye tracker: " + eyelink.getTime());
            if(spaceClicked)    {
                spaceClicked = false;
                // int quotient = total / 9;
                if(quotient == 0)   {
                    if(count == -3) {
                        task = false;
                        OpenPanel();
                    }
                    else if(count == -2) {
                        task = false;
                        ClosePanel();
                        if(userID < 13) view1.Trial_1();
                        else            view1.Trial_2();
                    }
                    else if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    else{}
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        distractors = 5;
                        task = true;
                        if(count == 0)  {
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13)    cameraAngle = view1.StartTask_1_Iter_1();
                            else                    cameraAngle = view1.StartTask_2_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13)    cameraAngle = view1.StartTask_1_Iter_4();
                            else                    cameraAngle = view1.StartTask_2_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13)    cameraAngle = view1.StartTask_1_Iter_7();
                            else                    cameraAngle = view1.StartTask_2_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view1.StartTask_1_Iter_2();
                            else            cameraAngle = view1.StartTask_2_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view1.StartTask_1_Iter_5();
                            else            cameraAngle = view1.StartTask_2_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view1.StartTask_1_Iter_8();
                            else            cameraAngle = view1.StartTask_2_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        print("Debug count" + count);
                        print("Debug list" + list.Count);

                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view1.StartTask_1_Iter_3();
                            else            cameraAngle = view1.StartTask_2_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view1.StartTask_1_Iter_6();
                            else            cameraAngle = view1.StartTask_2_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view1.StartTask_1_Iter_9();
                            else            cameraAngle = view1.StartTask_2_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 1)   {
                    if(count == 9)  count = -1;
                    if(count == -1)   {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_1();
                            else            cameraAngle = view2.StartTask_2_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_4();
                            else            cameraAngle = view2.StartTask_2_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_7();
                            else            cameraAngle = view2.StartTask_2_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;//list.Clear();
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_2();
                            else            cameraAngle = view2.StartTask_2_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_5();
                            else            cameraAngle = view2.StartTask_2_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_8();
                            else            cameraAngle = view2.StartTask_2_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);

                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_3();
                            else            cameraAngle = view2.StartTask_2_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_6();
                            else            cameraAngle = view2.StartTask_2_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view2.StartTask_1_Iter_9();
                            else            cameraAngle = view2.StartTask_2_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 2)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_1();
                            else            cameraAngle = view3.StartTask_2_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_4();
                            else            cameraAngle = view3.StartTask_2_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_7();
                            else            cameraAngle = view3.StartTask_2_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_2();
                            else            cameraAngle = view3.StartTask_2_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_5();
                            else            cameraAngle = view3.StartTask_2_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_8();
                            else            cameraAngle = view3.StartTask_2_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_3();
                            else            cameraAngle = view3.StartTask_2_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_6();
                            else            cameraAngle = view3.StartTask_2_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view3.StartTask_1_Iter_9();
                            else            cameraAngle = view3.StartTask_2_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 3)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_1();
                            else            cameraAngle = view4.StartTask_2_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_4();
                            else            cameraAngle = view4.StartTask_2_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_7();
                            else            cameraAngle = view4.StartTask_2_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_2();
                            else            cameraAngle = view4.StartTask_2_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_5();
                            else            cameraAngle = view4.StartTask_2_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_8();
                            else            cameraAngle = view4.StartTask_2_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_3();
                            else            cameraAngle = view4.StartTask_2_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_6();
                            else            cameraAngle = view4.StartTask_2_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view4.StartTask_1_Iter_9();
                            else            cameraAngle = view4.StartTask_2_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 4)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_1();
                            else            cameraAngle = view5.StartTask_2_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_4();
                            else            cameraAngle = view5.StartTask_2_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_7();
                            else            cameraAngle = view5.StartTask_2_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_2();
                            else            cameraAngle = view5.StartTask_2_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_5();
                            else            cameraAngle = view5.StartTask_2_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_8();
                            else            cameraAngle = view5.StartTask_2_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_3();
                            else            cameraAngle = view5.StartTask_2_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_6();
                            else            cameraAngle = view5.StartTask_2_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view5.StartTask_1_Iter_9();
                            else            cameraAngle = view5.StartTask_2_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }


                else if(quotient == 5)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_1();
                            else            cameraAngle = view6.StartTask_2_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_4();
                            else            cameraAngle = view6.StartTask_2_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_7();
                            else            cameraAngle = view6.StartTask_2_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_2();
                            else            cameraAngle = view6.StartTask_2_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_5();
                            else            cameraAngle = view6.StartTask_2_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_8();
                            else            cameraAngle = view6.StartTask_2_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_3();
                            else            cameraAngle = view6.StartTask_2_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_6();
                            else            cameraAngle = view6.StartTask_2_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view6.StartTask_1_Iter_9();
                            else            cameraAngle = view6.StartTask_2_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }
                
            }

            /*
            .
            .
            .
            .
            .
            .
            .
            .
            .
            .
            .
            .
            SECOND PART
            .
            .
            .
            .
            .
            .
            .
            .
            .
            */


            if(quotient == 6)   {
                if(count == 9)  count = -3;
                    if(count == -3) {
                        task = false;
                        OpenPanel();
                    }
                    else if(count == -2) {
                        task = false;
                        ClosePanel();
                        if(userID < 13) view1.Trial_2();
                        else            view1.Trial_1();
                    }
                    else if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    else{}
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        distractors = 5;
                        task = true;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            print("StartController: task 2");
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_1();
                            else            cameraAngle = view1.StartTask_1_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_4();
                            else            cameraAngle = view1.StartTask_1_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_7();
                            else            cameraAngle = view1.StartTask_1_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_2();
                            else            cameraAngle = view1.StartTask_1_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_5();
                            else            cameraAngle = view1.StartTask_1_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_8();
                            else            cameraAngle = view1.StartTask_1_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_3();
                            else            cameraAngle = view1.StartTask_1_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_6();
                            else            cameraAngle = view1.StartTask_1_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view1.StartTask_2_Iter_9();
                            else            cameraAngle = view1.StartTask_1_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 7)   {
                    if(count == 9)  count = -1;
                    if(count == -1)   {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_1();
                            else            cameraAngle = view2.StartTask_1_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_4();
                            else            cameraAngle = view2.StartTask_1_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_7();
                            else            cameraAngle = view2.StartTask_1_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_2();
                            else            cameraAngle = view2.StartTask_1_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_5();
                            else            cameraAngle = view2.StartTask_1_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_8();
                            else            cameraAngle = view2.StartTask_1_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_3();
                            else            cameraAngle = view2.StartTask_1_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_6();
                            else            cameraAngle = view2.StartTask_1_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view2.StartTask_2_Iter_9();
                            else            cameraAngle = view2.StartTask_1_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 8)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_1();
                            else            cameraAngle = view3.StartTask_1_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_4();
                            else            cameraAngle = view3.StartTask_1_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_7();
                            else            cameraAngle = view3.StartTask_1_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_2();
                            else            cameraAngle = view3.StartTask_1_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_5();
                            else            cameraAngle = view3.StartTask_1_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_8();
                            else            cameraAngle = view3.StartTask_1_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_3();
                            else            cameraAngle = view3.StartTask_1_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_6();
                            else            cameraAngle = view3.StartTask_1_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view3.StartTask_2_Iter_9();
                            else            cameraAngle = view3.StartTask_1_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 9)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_1();
                            else            cameraAngle = view4.StartTask_1_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_4();
                            else            cameraAngle = view4.StartTask_1_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_7();
                            else            cameraAngle = view4.StartTask_1_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_2();
                            else            cameraAngle = view4.StartTask_1_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_5();
                            else            cameraAngle = view4.StartTask_1_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_8();
                            else            cameraAngle = view4.StartTask_1_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_3();
                            else            cameraAngle = view4.StartTask_1_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_6();
                            else            cameraAngle = view4.StartTask_1_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view4.StartTask_2_Iter_9();
                            else            cameraAngle = view4.StartTask_1_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

                else if(quotient == 10)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_1();
                            else            cameraAngle = view5.StartTask_1_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_4();
                            else            cameraAngle = view5.StartTask_1_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_7();
                            else            cameraAngle = view5.StartTask_1_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_2();
                            else            cameraAngle = view5.StartTask_1_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_5();
                            else            cameraAngle = view5.StartTask_1_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_8();
                            else            cameraAngle = view5.StartTask_1_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_3();
                            else            cameraAngle = view5.StartTask_1_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_6();
                            else            cameraAngle = view5.StartTask_1_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view5.StartTask_2_Iter_9();
                            else            cameraAngle = view5.StartTask_1_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }


                else if(quotient == 11)   {
                    if(count == 9)  count = -1;

                    if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    
                    if(count >= 0 && count < 3)  {
                        ClosePanel();
                        task = true;
                        distractors = 5;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_1();
                            else            cameraAngle = view6.StartTask_1_Iter_1();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_4();
                            else            cameraAngle = view6.StartTask_1_Iter_4();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_7();
                            else            cameraAngle = view6.StartTask_1_Iter_7();
                            count++;
                            total++;
                        }
                    }else if(count >= 3 && count < 6)   {
                        task = true;
                        distractors = 15;
                        if(count == 3)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_2();
                            else            cameraAngle = view6.StartTask_1_Iter_2();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_5();
                            else            cameraAngle = view6.StartTask_1_Iter_5();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_8();
                            else            cameraAngle = view6.StartTask_1_Iter_8();
                            count++;
                            total++;
                        }
                    }
                    else if(count >= 6 && count < 9)    {
                        task = true;
                        distractors = 25;
                        if(count == 6)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                            list.Add(3);
                        }
                        print("Random Value: " + list.Count);
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_3();
                            else            cameraAngle = view6.StartTask_1_Iter_3();
                            count++;
                            total++;
                        }
                        else if(value == 2) {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_6();
                            else            cameraAngle = view6.StartTask_1_Iter_6();
                            count++;
                            total++;
                        }
                        else if(value == 3) {
                            if(userID < 13) cameraAngle = view6.StartTask_2_Iter_9();
                            else            cameraAngle = view6.StartTask_1_Iter_9();
                            count++;
                            total++;
                        }
                    }
                }

            /*
            .
            .
            .
            .
            .
            .
            .
            .
            .
            .
            .
            .
            COMPLEX TASK
            .
            .
            .
            .
            .
            .
            .
            .
            .
            */

                else if(quotient == 12)   {
                    if(count == 9)  count = -3;
                    if(count == -3) {
                        task = false;
                        OpenPanel();
                    }
                    else if(count == -2) {
                        task = false;
                        ClosePanel();
                        exp.Start_Trial("Complex_Task_2_Trial");
                        complexTask_1.Start_Task_1();
                    }
                    else if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    else{}
                    
                    if(count >= 0 && count < 2)  {
                        complexTask = true;
                        ClosePanel();
                        // task = true;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID == 1 || userID == 2 || userID == 3 || userID == 4 || userID == 5 || userID == 6 || userID == 13 || userID == 14 || userID == 15 || userID == 16 || userID == 17 || userID == 18)  {
                                str = "1_1";
                            }else{
                                str = "2_1";
                            }
                            exp.Start_Trial(str);
                            complexTask_1.Start_Task_2();
                            count++;
                            total += 4;
                        }
                        else if(value == 2) {
                            if(userID == 1 || userID == 2 || userID == 3 || userID == 4 || userID == 5 || userID == 6 || userID == 13 || userID == 14 || userID == 15 || userID == 16 || userID == 17 || userID == 18)  {
                                str = "1_2";
                            }else{
                                str = "2_2";
                            }
                            exp.Start_Trial(str);
                            complexTask_1.Start_Task_3();
                            count++;
                            total += 5;
                        }
                    }
                }


                else if(quotient == 13)   {
                    if(count == 2)  count = -3;
                    if(count == -3) {
                        complexTask = false;
                        OpenPanel();
                    }
                    else if(count == -2) {
                        task = false;
                        ClosePanel();
                        complexTask_3.Start_Task_1();
                    }
                    else if(count == -1) {
                        task = false;
                        OpenPanel();
                    }
                    else{}
                    
                    if(count >= 0 && count < 2)  {
                        ClosePanel();
                        complexTask = true;
                        // task = true;
                        if(count == 0)  {
                            //list.Clear();
                            list.Add(1);
                            list.Add(2);
                        }
                        int index = Random.Range(0, list.Count - 1);
                        
                        int value = list[Random.Range(0, list.Count - 1)];
                        print("Random Value: " + value + " " + list.Count);
                        list.Remove(value);
                        if(value == 1)  {
                            if(userID == 1 || userID == 2 || userID == 3 || userID == 4 || userID == 5 || userID == 6 || userID == 13 || userID == 14 || userID == 15 || userID == 16 || userID == 17 || userID == 18)  {
                                str = "2_1";
                            }else{
                                str = "1_1";
                            }
                            exp.Start_Trial(str);
                            complexTask_3.Start_Task_2();
                            count++;
                            total += 4;
                        }
                        else if(value == 2) {
                            if(userID == 1 || userID == 2 || userID == 3 || userID == 4 || userID == 5 || userID == 6 || userID == 13 || userID == 14 || userID == 15 || userID == 16 || userID == 17 || userID == 18)  {
                                str = "2_2";
                            }else{
                                str = "1_2";
                            }
                            exp.Start_Trial(str);
                            complexTask_3.Start_Task_2();
                            count++;
                            total += 5;
                        }
                    }
                }
       

        // else if(this.name == "Task 2 Panel")   {
        //     OpenPanel();
        //     view1.StartTask_1_Iter_2();
        //     this.name = "Task 2";
        // }else if(this.name == "Task 2") {
        //     log = true;
        //     ClosePanel();
        //     this.gameObject.SetActive(false);
        //     enterButton.gameObject.SetActive(true);
        //     this.name = "Task 2 Iteration 2 Panel";
        //     this.GetComponentInChildren<Text>().text = "Iteration 2";
        // }

        
    }

    // Update is called once per frame
    

    public bool GetLog()    {
        return log;
    }

    public void SetLogFalse()    {
        log = false;
    }

    public void SetLogTrue()    {
        log = true;
    }

    public void SetStartButtonActive()  {
        this.gameObject.SetActive(true);
        enterButton.gameObject.SetActive(false);

        if(this.name == "Task 3 Iteration 2 Part 1 Panel")   barManager.RemoveDictSparse(106);
    }

    public void OpenPanel() {
        log = false;
        panel.gameObject.SetActive(true);
        // mainController.ResetSettings();
        this.GetComponentInChildren<Text>().text = "Start";

        if(quotient == 0 && count == -3) {
            if(userID < 13) {
                panel.GetComponentInChildren<Text>().text = "TASK 1: From the bars visible, click on the BAR that has MAXIMUM LENGTH and then press SpaceBar to move to the next task. Press Space bar to start Trial";

            }else{
                panel.GetComponentInChildren<Text>().text = "TASK 1: From the bars visible, click on two BARS that are CLOSEST and then press SpaceBar to move to the next task. Press Space bar to start Trial";
 
            }
            str = v1;
        }


        else if(quotient == 6 && count == -3) {
            if(userID < 13) {
                panel.GetComponentInChildren<Text>().text = "TASK 2: From the bars visible, click on the BAR that has MAXIMUM LENGTH and then press SpaceBar to move to the next task. Press Space bar to start Trial";
            }else{
                panel.GetComponentInChildren<Text>().text = "TASK 2: From the bars visible, click on two BARS that are CLOSEST and then press SpaceBar to move to the next task. Press Space bar to start Trial";
            }
            str = v1;
        }


        else if(quotient == 12 && count == -3)    {
            if(userID == 1 || userID == 2 || userID == 3 || userID == 4 || userID == 5 || userID == 6 || userID == 13 || userID == 14 || userID == 15 || userID == 16 || userID == 17 || userID == 18)   {
                panel.GetComponentInChildren<Text>().text = "PHASE 2 : TASK 2 -> Select 5 BARS/POLYGONS that have the HIGHEST ELEVATION. Then select the 2 BARS (out of the 5 selected) which are CLOSEST. Press Spacebar to start Trial";
            }
            else{
                panel.GetComponentInChildren<Text>().text = "PHASE 2 : TASK 2 -> Select a VIEWPOINT from which MAXIMUM number of BARS/POLYGONS are VISIBLE. Press Spacebar to begin Trial.";
            }        
        }

        else if(quotient == 13 && count == -3)    {
            if(userID == 1 || userID == 2 || userID == 3 || userID == 4 || userID == 5 || userID == 6 || userID == 13 || userID == 14 || userID == 15 || userID == 16 || userID == 17 || userID == 18)   {
                panel.GetComponentInChildren<Text>().text = "PHASE 2 : TASK 2 -> Select a VIEWPOINT from which MAXIMUM number of BARS/POLYGONS are VISIBLE. Press Spacebar to begin Trial.";
            }
            else{
                panel.GetComponentInChildren<Text>().text = "PHASE 2 : TASK 2 -> Select 5 BARS/POLYGONS that have the HIGHEST ELEVATION. Then select the 2 BARS (out of the 5 selected) which are CLOSEST. Press Spacebar to start Trial";
            }       
        }

        else if(quotient == 15 && count == -3)    {
            panel.GetComponentInChildren<Text>().text = "END OF EXPERIMENT";        
        }

        else if(quotient >= 12 && count == -1)    {
            panel.GetComponentInChildren<Text>().text = "BEGIN TASK";
        }


        else if(quotient == 0 || quotient == 6)   {
            panel.GetComponentInChildren<Text>().text = "View 1";
            str = v2;
        }
        else if(quotient == 1 || quotient == 7)   {
            panel.GetComponentInChildren<Text>().text = "View 2";
            str = v3;
        }
        else if(quotient == 2 || quotient == 8)   {
            panel.GetComponentInChildren<Text>().text = "View 3";
            str = v4;
        }
        else if(quotient == 3 || quotient == 9)   {
            panel.GetComponentInChildren<Text>().text = "View 4";
            str = v5;
        }
        else if(quotient == 4 || quotient == 10)   {
            panel.GetComponentInChildren<Text>().text = "View 5";
            str = v6;
        }
        else if(quotient == 5 || quotient == 11)   {
            panel.GetComponentInChildren<Text>().text = "View 6";
            if(quotient < 6)   str = "Task 2 Panel";
            else                str = "End of Phase 1";
        }
        else{
            panel.GetComponentInChildren<Text>().text = "Something";
        }
    }

    private void ClosePanel()   {
        panel.gameObject.SetActive(false);
        // panel.GetComponentInChildren<Text>().text = "Wait for further Instructions";
    }

}
