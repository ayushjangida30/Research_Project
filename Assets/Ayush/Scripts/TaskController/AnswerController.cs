using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AnswerController : MonoBehaviour
{
    public vsc_geojson_reader reader;
    public BarManager barManager;
    public LinkManager linkManager;
    public ViewpointManager viewpointManager;
    private List<int> list_task1;
    private Dictionary<string, List<int>> visiblebars_dict = new Dictionary<string, List<int>>();

    private float height = 0;
    private int id = 0;

    int id1 = 0;
    int id2 = 0;
    float res = 10000.0f;


    // Complex Task 1 Variables
    float height1 = 0;
    float height2 = 0;
    float height3 = 0;
    float height4 = 0;
    float height5 = 0;

    int complexid1 = 0;
    int complexid2 = 0;
    int complexid3 = 0;
    int complexid4 = 0;
    int complexid5 = 0;

    // Complex Task 2 variables
    List<string> viewpointList = new List<string>();

    //Complex Task 3 variables 

    private int maxCount;

    // Start is called before the first frame update
    void Start()
    {
        list_task1 = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public List<int> Task1_Answer(List<int> barVisible) {
    //     for(int i = 0; i < barVisible.Count; i++)   {
    //         int id = barVisible[i];
    //         if(reader.GetVSC(id) == 3)  list_task1.Add(id);  
    //     }

    //     return list_task1;
    // }

    public void GetAnswer_Task1(List<int> barVisible)   {
        for(int i = 0; i < barVisible.Count; i++)   {
            if(barManager.GetBarHeight(barVisible[i]) > height) {
                id = barVisible[i];
                height = barManager.GetBarHeight(barVisible[i]);
            }
        }

        WriteAnswerLog("task1", id);
    }

    public int GetAnswer_Task1_ID()  {
        int ID = id;
        id = 0;
        return ID;
    }

    public float GetAnswer_Task1_Height()  {
        float HEIGHT = height;
        height = 0;
        return HEIGHT;
    }

    public float GetAnswer_Task2_Distance() {
        float RES = res;
        res = 10000.0f;
        return RES;
    }

    public string GetAnswer_Task2_ID()    {
        if(id2 < id1)   {
            int temp = id1;
            id1 = id2;
            id2 = temp;
        }

        return id1 + "-" + id2;
    }

    public void GetAnswer_Task2(List<int> barVisible)   {

        for(int i = 0; i < barVisible.Count - 1; i++)   {
            for(int j = i + 1; j < barVisible.Count; j++)   {
                print("i"+ i);
                print("j"+ j);
                Vector3 barOne = barManager.GetBarPos(barVisible[i]);
                Vector3 barTwo = barManager.GetBarPos(barVisible[j]);

                float distance = Mathf.Sqrt(((barOne.x - barTwo.x) * (barOne.x - barTwo.x)) + ((barOne.z - barTwo.z) * (barOne.z - barTwo.z)));
                if(distance < res)  {
                    res = distance;
                    id1 = barVisible[i];
                    id2 = barVisible[j];
                }
                print("Answer: " + distance + "id1: " + barVisible[i] + " id2: " + barVisible[j] + " res: " + res);
            }
        }

        WriteAnswerLog("Task 2", id1, id2);
    }

    private void WriteAnswerLog(string text, float answer)  {
        System.IO.StreamWriter writer;
        string path = Application.dataPath + "/AnswerLog.txt";
        writer = new System.IO.StreamWriter(path, true);

        string tempString;
        tempString = "";
        tempString += text + ",";
        tempString += answer + ",";

        writer.WriteLine(tempString);
        writer.Close();
    }

    private void WriteAnswerLog(string text, int id1, int id2)  {
        System.IO.StreamWriter writer;
        string path = Application.dataPath + "/AnswerLog.txt";
        writer = new System.IO.StreamWriter(path, true);

        string tempString;
        tempString = "";
        tempString += text + ",";
        tempString += id1 + ",";
        tempString += id2 + ",";

        writer.WriteLine(tempString);
        writer.Close();
    }

    public float GetDistance(List<int> list) {
        if(list.Count == 0 || list.Count == 1) return 0;
        int ans = 0;
        Vector3 barOne = barManager.GetBarPos(list[0]);
        Vector3 barTwo = barManager.GetBarPos(list[1]);

        float distance = Mathf.Sqrt(((barOne.x - barTwo.x) * (barOne.x - barTwo.x)) + ((barOne.z - barTwo.z) * (barOne.z - barTwo.z)));
        

        return distance;
    }

    public void GetAnswerComplexTask1(List<int> list) {

        float[] heightList = new float[list.Count];

        for(int i = 0; i < list.Count; i++) {
            heightList[i] = barManager.GetBarPosHeight(list[i]);
        }

        for(int i = 0; i < heightList.Length - 1; i++)    {
            for(int j = i + 1; j < heightList.Length; j++)    {
                if(heightList[j] > heightList[i])   {
                    float temp = heightList[j];
                    heightList[j] = heightList[i];
                    heightList[i] = temp;
                }
            }
        }

        for(int i = 0; i < list.Count; i++) {
            int barId = list[i];
            float barHeight = barManager.GetBarPosHeight(barId);

            if(barHeight == heightList[0])      complexid1 = barId;
            else if(barHeight == heightList[1]) complexid2 = barId;
            else if(barHeight == heightList[2]) complexid3 = barId;
            else if(barHeight == heightList[3]) complexid4 = barId;
            else if(barHeight == heightList[4]) complexid5 = barId;
            else{}
        }

        print("Asc : " + complexid1 + " " + complexid2 + " " + complexid3 + " " + complexid4 + " " + complexid5);

        List<int> distanceList = new List<int>();
        distanceList.Add(complexid1);
        distanceList.Add(complexid2);
        distanceList.Add(complexid3);
        distanceList.Add(complexid4);
        distanceList.Add(complexid5);

        for(int i = 0; i < distanceList.Count - 1; i++)   {
            for(int j = i + 1; j < distanceList.Count; j++)   {
                Vector3 barOne = barManager.GetBarPos(distanceList[i]);
                Vector3 barTwo = barManager.GetBarPos(distanceList[j]);

                float distance = Mathf.Sqrt(((barOne.x - barTwo.x) * (barOne.x - barTwo.x)) + ((barOne.z - barTwo.z) * (barOne.z - barTwo.z)));
                if(distance < res)  {
                    res = distance;
                    id1 = distanceList[i];
                    id2 = distanceList[j];
                }
            }
        }

        print("Least distance: " + id1 + " " + id2);
    }

    public void GetAnswerComplexTask2(int a, int b) {
        print("Code reaching answer 2");
        visiblebars_dict = viewpointManager.GetVisiblePolygons(); 
        foreach(KeyValuePair<string, List<int>> viewpoint in visiblebars_dict)  {
            bool visibleA = false;
            bool visibleB = false;

            string key = viewpoint.Key;
            List<int> visibleBars = viewpoint.Value;
            
            for(int i = 0; i < visibleBars.Count; i++)  {
                if(visibleBars[i] == a) visibleA = true;
                if(visibleBars[i] == b) visibleB = true;
            }

            if(visibleA && visibleB)    viewpointList.Add(key);
        }

        for(int i = 0; i < viewpointList.Count; i++)    {
            print("Correct viewpoint: " + viewpointList[i]);
        }
    }

    public void GetAnswerComplexTask3(List<string> list) {
        Dictionary<string, List<int>> viewpoint_dict = viewpointManager.GetVisiblePolygons();
        foreach(KeyValuePair<string, List<int>> viewpoint in viewpoint_dict)    {
            if(list.Contains(viewpoint.Key)) {
                List<int> bars = viewpoint.Value;
                if(bars.Count > maxCount)  {
                    maxCount = bars.Count;
                }
            }
        }
        for(int i = 0; i < list.Count; i++) {
            if(viewpoint_dict[list[i]].Count == maxCount) viewpointList.Add(list[i]);
        }
    }

    public void ResetAnswer()   {
        viewpointList.Clear();
        maxCount = 0;
    }
}
