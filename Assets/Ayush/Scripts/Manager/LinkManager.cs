using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinkManager : MonoBehaviour
{
    public BarManager barManager;
    public ViewpointManager viewPointManager;
    public PolygonManager polygonManager;
    public OutlineManager outlineManager;
    public ToolTipManager tooltipManager;
    public MainController mainController;
    public AnswerController answerController;

    private int viewPointSelectedCount = 0;

    private Dictionary<int, Vector3> polygonPos_dict = new Dictionary<int, Vector3>();
    private Dictionary<string, int> viewPointSelected_dict = new Dictionary<string, int>();

    private Dictionary<string, List<int>> visiblePolygons_dict = new Dictionary<string, List<int>>();
    private Dictionary<string, List<int>> invisiblePolygons_dict = new Dictionary<string, List<int>>();

    private List<int> totalVisiblePolygonsList = new List<int>();
    private List<string> viewpointList = new List<string>();

    private bool invisible = false;

    
    // Start is called before the first frame update
    void Start()
    {
        Invoke("GetPos", 1.5f);
    }

    void Update()
    {
        if(Input.mouseScrollDelta.y > 0)   {
            invisible = false;
            barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        }
        if(Input.mouseScrollDelta.y < 0)    {
            invisible = true;
            tooltipManager.HideToolTip();
            barManager.MakeBarInvisible();
        }
    }

    private void GetPos()   {
        // polygonPos_dict = barManager.GetPolygonPosDict();
        // viewPointPos_dict = viewPointManager.GetViewPointPosDict();
        viewpointList = viewPointManager.GetViewpoints();

        visiblePolygons_dict = viewPointManager.GetVisiblePolygons(); 
        invisiblePolygons_dict = viewPointManager.GetInvisiblePolygons();
        
        for(int i = 0; i < viewpointList.Count; i++)   {
            viewPointSelected_dict.Add(viewpointList[i], 0);

        }

        // barManager.SetVisiblePolygons(new List<int>());
        print(viewPointSelected_dict.Count);
    }

    // Visible Polygons - Viewpoint Manager
    public void SetViewPointSelected_Visible(string id)  {
        if(mainController.complexTask3)     {
            ResetViewpoints();
            viewPointSelectedCount++;
        }
        if(mainController.complexTask2)     viewPointSelectedCount++;
            
        viewPointSelected_dict[id] = 1;
        viewPointManager.SetSelectedViewpointColor_Visible(id);
        totalVisiblePolygonsList = CheckTotalVisible();
        if(mainController.complexTask2 || mainController.complexTask3) answerController.GetAnswer_Task1(totalVisiblePolygonsList);
        if(!invisible)  barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        polygonManager.SetVisiblePolygons(totalVisiblePolygonsList);
        outlineManager.SetVisibleOutline(totalVisiblePolygonsList);
    }

    // Invisible Polygons - Viewpoint Manager
    public void SetViewPointSelected_Invisible(string id)  {
        if(mainController.complexTask3)    ResetViewpoints(); 
       
        viewPointSelected_dict[id] = 2;
        viewPointManager.SetSelectedViewpointColor_Invisible(id);
        totalVisiblePolygonsList = CheckTotalVisible();
        if(!invisible)  barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        polygonManager.SetVisiblePolygons(totalVisiblePolygonsList);
        outlineManager.SetVisibleOutline(totalVisiblePolygonsList);
    }

    public int GetViewpointSelectedCount()  {
        return viewPointSelectedCount;
    }

    public void SetViewPointDeselected(string id)   {
        viewPointSelectedCount--;
        viewPointSelected_dict[id] = 0;
        viewPointManager.SetDeselectedViewpointColor(id);
        totalVisiblePolygonsList = CheckTotalVisible();
        if(!invisible)  barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        polygonManager.SetVisiblePolygons(totalVisiblePolygonsList);
        outlineManager.SetVisibleOutline(totalVisiblePolygonsList);
    }

    private List<int> CheckTotalVisible()    {
        List<int> visibleList = new List<int>();
        int count = 0;
        foreach(KeyValuePair<string, int> viewpoint in viewPointSelected_dict) {
            print(viewpoint.Key + " " + viewpoint.Value + " Linkmanage checktotalvisible");
            if(viewpoint.Value == 1 || viewpoint.Value == 2) {
                print("Viewpoint clicked: " + viewpoint.Key);
                List<int> tempList = new List<int>();
                count += 1;
                if(count > 1)   {
                    if(viewpoint.Value == 1)    tempList = visiblePolygons_dict[viewpoint.Key];
                    else                        tempList = invisiblePolygons_dict[viewpoint.Key];

                    List<int> intersectList = Intersect(tempList, visibleList);
                    visibleList = intersectList;

                }else{
                    if(viewpoint.Value == 1)    visibleList = visiblePolygons_dict[viewpoint.Key];
                    else                        visibleList = invisiblePolygons_dict[viewpoint.Key];
                    print(visibleList.Count + " Visible COunt");
                }
            }
        }

        return visibleList;
    }

    private List<int> Intersect(List<int> newList, List<int> visible)   {
        IEnumerable<int> res = newList.AsQueryable().Intersect(visible);

        return res.ToList();
    }

    public List<int> GetVisiblePolygons(string id) {
        return visiblePolygons_dict[id];
    }

    public void ResetViewpoints()   {
        viewPointSelectedCount = 0;
        for(int i = 0; i < viewpointList.Count; i++)    {
            viewPointSelected_dict[viewpointList[i]] = 0;
            viewPointManager.SetDeselectedViewpointColor(viewpointList[i]);
        }
        // foreach(string viewpoint in viewpointList)    {
        //     viewPointSelected_dict[viewpoint] = 0;
        //     viewPointManager.SetDeselectedViewpointColor(viewpoint);
        // }

        totalVisiblePolygonsList = CheckTotalVisible();
        if(!invisible)  barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        polygonManager.SetVisiblePolygons(totalVisiblePolygonsList);
        outlineManager.SetVisibleOutline(totalVisiblePolygonsList);
    }

    public bool GetInvisibleStatus() {
        return invisible;
    }

    public void SetViewpointSelected(string str, int val)    {
        viewPointSelected_dict[str] = val;
    }

    public void CalculateVisibility()   {
        totalVisiblePolygonsList = CheckTotalVisible();
        if(!invisible)  barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        polygonManager.SetVisiblePolygons(totalVisiblePolygonsList);
        outlineManager.SetVisibleOutline(totalVisiblePolygonsList);
    }

    public void CalculateVisibility(List<int> barList)   {
        totalVisiblePolygonsList = barList;
        if(!invisible)  barManager.SetVisiblePolygons(totalVisiblePolygonsList);
        polygonManager.SetVisiblePolygons(totalVisiblePolygonsList);
        outlineManager.SetVisibleOutline(totalVisiblePolygonsList);
    }

    public string GetViewPointSelected_Task()  {
        foreach(KeyValuePair<string, int> pair in viewPointSelected_dict)   {
            string key = pair.Key;
            int id = pair.Value;

            if(id == 1 || id == 2)   return key; 
        }
        return "none";
    }

    public Dictionary<string, int> GetViewpointSelectedDict()  {
        return viewPointSelected_dict;
    }

    public void SetViewpointPos(Vector3 pos, string name)    {
        viewPointManager.SetViewpointPos(pos, name);
        visiblePolygons_dict = viewPointManager.GetVisiblePolygons(); 
        invisiblePolygons_dict = viewPointManager.GetInvisiblePolygons();
    }

    public List<int> GetVisibleBars()   {
        return CheckTotalVisible();
    }
}   
