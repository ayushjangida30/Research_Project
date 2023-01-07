using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class Experiment : MonoBehaviour
{
    [SerializeField] private List<int> mkrfFilteredId;
    // private Vector3 kopPosition;
    [SerializeField] private float radius = 2000f;
    // [SerializeField] Transform dragObject;
    private float sliderVal = 1000;
    // public float SliderVal{
    //     get{ return sliderVal}
    // }
    private Vector3 position = Vector3.zero;
    private bool sliderValueSet = false;
 

    private void Awake() {
        GlobalProperties.Instance.Experiment = this;
    }
    // Start is called before the first frame update
    void Start()
    {
         Invoke("SetMKRF", 1f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(sliderValueSet)  {
            sliderValueSet = false;
            ResetMKRF();
            SetMKRF();
            }
    }

    private void SetMKRF() {
        // int id = 5;
        mkrfFilteredId = null;
        // kopPosition = Vector3.zero;
        // kopPosition = GetKOPPosition(id);
        // Debug.Log("Kop position: " + kopPosition);
        mkrfFilteredId = GetMKRFFilteredId(position);
        SetToFilterController();
    }

    private void ResetMKRF()   {
        mkrfFilteredId = null;
        ResetToFilterController();
    }

    private Vector3 GetKOPPosition(int id)  {
        return GlobalProperties.Instance.KOPPositions[id];
    }

    // private int GetMKRFCount() {
    //     int count = 0;
    //     foreach(var m in GlobalProperties.Instance.MKRFPositions)   {
    //         count++;
    //     }

    //     return count;
    // }

    private List<int> GetMKRFFilteredId(Vector3 KOPPosition)    {
        List<int> list = new List<int>();

        foreach(var item in GlobalProperties.Instance.MKRFPositions)   {
            Vector3 pos = item.Value;

            float distance = GetDistance(pos, KOPPosition);
            if(distance <= sliderVal)   {
                list.Add(item.Key);
                // GlobalProperties.Instance.FilterController.SetMkrfFilteredDistance(item.Key);
            }
        }

        return list;
    }

    private float GetDistance(Vector3 mkrfPos, Vector3 kopPos)    {
        float distanceX = mkrfPos.x - kopPos.x;
        float distanceZ = mkrfPos.z - kopPos.z;

        return (float) Math.Sqrt((distanceX * distanceX) + (distanceZ * distanceZ));
    }

    private void SetToFilterController()  {
        foreach(var item in mkrfFilteredId) {
            //Debug.Log(item);
            GlobalProperties.Instance.FilterController.SetMkrfFilteredDistance(item);
        }
    }

    private void ResetToFilterController()  {
        GlobalProperties.Instance.FilterController.ResetMkrfFilteredDistance();
    }

    public void SetSliderValue(float value) {
        if(sliderVal != value)  {
            sliderValueSet = true;
            sliderVal = value;
        }
    }

    public void SetPosition(Vector3 worldPosition)  {
        if(position != worldPosition)   {
            sliderValueSet = true;
            Debug.Log("Position set" + worldPosition);
            position = worldPosition;
        }
       
    }
}