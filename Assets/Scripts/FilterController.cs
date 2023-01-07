using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class FilterController : MonoBehaviour {
    [SerializeField] private Dictionary<int, bool> kopFilter = null;
    [SerializeField] private Dictionary<int, bool> mkrfFilter = null;

    [SerializeField] private List<int> kopFilteredId = null;
    [SerializeField] private List<int> kopFilteredImportance = null;
    [SerializeField] private List<int> kopFilteredDistance = null;
    [SerializeField] private List<int> kopFilteredVisibility = null;

    [SerializeField] private List<int> mkrfFilteredId = null;
    [SerializeField] private List<int> mkrfFilteredBr = null;
    [SerializeField] private List<int> mkrfFilteredVc = null;
    [SerializeField] private List<int> mkrfFilteredVr = null;
    [SerializeField] private List<int> mkrfFilteredVac = null;
    [SerializeField] private List<int> mkrfFilteredVsc = null;
    [SerializeField] private List<int> mkrfFilteredEvc = null;
    [SerializeField] private List<int> mkrfFilteredVqc = null;
    [SerializeField] private List<int> mkrfFilteredDistance = null;
    [SerializeField] private List<int> mkrfFilteredVisibility = null;

    private bool isRebuiltKop = false;
    private bool isRebuiltMkrf = false;
    private bool isRefreshedKop = false;
    private bool isRefreshedMkrf = false;

    private void Start() {
        kopFilter = new Dictionary<int, bool>();

        foreach(var item in GlobalProperties.Instance.KOPPositions) {
            kopFilter.Add(item.Key, true);
        }

        mkrfFilter = new Dictionary<int, bool>();

        foreach(var item in GlobalProperties.Instance.MKRFPositions) {
            mkrfFilter.Add(item.Key, true);
        }

        kopFilteredId = new List<int>();
        kopFilteredImportance = new List<int>();
        kopFilteredDistance = new List<int>();
        kopFilteredVisibility = new List<int>();

        foreach(var item in GlobalProperties.Instance.KOPPositions) {
            kopFilteredVisibility.Add(item.Key);
        }

        mkrfFilteredId = new List<int>();
        mkrfFilteredBr = new List<int>();
        mkrfFilteredVc = new List<int>();
        mkrfFilteredVr = new List<int>();
        mkrfFilteredVac = new List<int>();
        mkrfFilteredVsc = new List<int>();
        mkrfFilteredEvc = new List<int>();
        mkrfFilteredVqc = new List<int>();
        mkrfFilteredDistance = new List<int>();
        mkrfFilteredVisibility = new List<int>();

        foreach(var item in GlobalProperties.Instance.MKRFPositions) {
            mkrfFilteredVisibility.Add(item.Key);
        }
    }

    private void Update() {
        if(!isRebuiltKop) {
            isRebuiltKop = true;

            RebuildKop();
        }

        if(!isRebuiltMkrf) {
            isRebuiltMkrf = true;

            RebuildMkrf();
        }

        if(!isRefreshedKop) {
            isRefreshedKop = true;

            RefreshKop();
        }

        if(!isRefreshedMkrf) {
            isRefreshedMkrf = true;

            RefreshMkrf();
        }
    }

    //

    public Dictionary<int, bool> GetKopFilter() {
        return kopFilter;
    }

    public Dictionary<int, bool> GetMkrfFilter() {
        return mkrfFilter;
    }

    //

    public bool KopFilteredIdContainsKey(int id) {
        return kopFilteredId.Contains(id);
    }

    public List<int> GetKopFilteredId() {
        return kopFilteredId;
    }

    public void SetKopFilteredId(int id) {
        if(!kopFilteredId.Contains(id)) {
            kopFilteredId.Add(id);
        }
        else {
            kopFilteredId.Remove(id);
        }

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public void ResetKopFilteredId() {
        kopFilteredId = new List<int>();

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public bool KopFilteredImportanceContainsKey(int id) {
        return kopFilteredImportance.Contains(id);
    }

    public List<int> GetKopFilteredImportance() {
        return kopFilteredImportance;
    }

    public void SetKopFilteredImportance(int id) {
        if(!kopFilteredImportance.Contains(id)) {
            kopFilteredImportance.Add(id);
        }
        else {
            kopFilteredImportance.Remove(id);
        }

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public void ResetKopFilteredImportance() {
        kopFilteredImportance = new List<int>();

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public bool KopFilteredDistanceContainsKey(int id) {
        return kopFilteredDistance.Contains(id);
    }

    public List<int> GetKopFilteredDistance() {
        return kopFilteredDistance;
    }

    public void SetKopFilteredDistance(int id) {
        if(!kopFilteredDistance.Contains(id)) {
            kopFilteredDistance.Add(id);
        }
        else {
            kopFilteredDistance.Remove(id);
        }

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public void ResetKopFilteredDistance() {
        kopFilteredDistance = new List<int>();

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public bool KopFilteredVisibilityContainsKey(int id) {
        return kopFilteredVisibility.Contains(id);
    }

    public List<int> GetKopFilteredVisibility() {
        return kopFilteredVisibility;
    }

    public void SetKopFilteredVisibility(int id) {
        if(!kopFilteredVisibility.Contains(id)) {
            kopFilteredVisibility.Add(id);
        }
        else {
            kopFilteredVisibility.Remove(id);
        }

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public void ResetKopFilteredVisibility() {
        kopFilteredVisibility = new List<int>();

        isRebuiltKop = false;
        isRefreshedKop = false;
    }

    public bool MkrfFilteredIdContainsKey(int id) {
        return mkrfFilteredId.Contains(id);
    }

    public List<int> GetMkrfFilteredId() {
        return mkrfFilteredId;
    }

    public void SetMkrfFilteredId(int id) {
        if(!mkrfFilteredId.Contains(id)) {
            mkrfFilteredId.Add(id);
        }
        else {
            mkrfFilteredId.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredId() {
        mkrfFilteredId = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredBrContainsKey(int id) {
        return mkrfFilteredBr.Contains(id);
    }

    public List<int> GetMkrfFilteredBr() {
        return mkrfFilteredBr;
    }

    public void SetMkrfFilteredBr(int id) {
        if(!mkrfFilteredBr.Contains(id)) {
            mkrfFilteredBr.Add(id);
        }
        else {
            mkrfFilteredBr.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredBr() {
        mkrfFilteredBr = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredVcContainsKey(int id) {
        return mkrfFilteredVc.Contains(id);
    }

    public List<int> GetMkrfFilteredVc() {
        return mkrfFilteredVc;
    }

    public void SetMkrfFilteredVc(int id) {
        if(!mkrfFilteredVc.Contains(id)) {
            mkrfFilteredVc.Add(id);
        }
        else {
            mkrfFilteredVc.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredVc() {
        mkrfFilteredVc = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredVrContainsKey(int id) {
        return mkrfFilteredVr.Contains(id);
    }

    public List<int> GetMkrfFilteredVr() {
        return mkrfFilteredVr;
    }

    public void SetMkrfFilteredVr(int id) {
        if(!mkrfFilteredVr.Contains(id)) {
            mkrfFilteredVr.Add(id);
        }
        else {
            mkrfFilteredVr.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredVr() {
        mkrfFilteredVr = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredVacContainsKey(int id) {
        return mkrfFilteredVac.Contains(id);
    }

    public List<int> GetMkrfFilteredVac() {
        return mkrfFilteredVac;
    }

    public void SetMkrfFilteredVac(int id) {
        if(!mkrfFilteredVac.Contains(id)) {
            mkrfFilteredVac.Add(id);
        }
        else {
            mkrfFilteredVac.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredVac() {
        mkrfFilteredVac = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredVscContainsKey(int id) {
        return mkrfFilteredVsc.Contains(id);
    }

    public List<int> GetMkrfFilteredVsc() {
        return mkrfFilteredVsc;
    }

    public void SetMkrfFilteredVsc(int id) {
        if(!mkrfFilteredVsc.Contains(id)) {
            mkrfFilteredVsc.Add(id);
        }
        else {
            mkrfFilteredVsc.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredVsc() {
        mkrfFilteredVsc = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredEvcContainsKey(int id) {
        return mkrfFilteredEvc.Contains(id);
    }

    public List<int> GetMkrfFilteredEvc() {
        return mkrfFilteredEvc;
    }

    public void SetMkrfFilteredEvc(int id) {
        if(!mkrfFilteredEvc.Contains(id)) {
            mkrfFilteredEvc.Add(id);
        }
        else {
            mkrfFilteredEvc.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredEvc() {
        mkrfFilteredEvc = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredVqcContainsKey(int id) {
        return mkrfFilteredVqc.Contains(id);
    }

    public List<int> GetMkrfFilteredVqc() {
        return mkrfFilteredVqc;
    }

    public void SetMkrfFilteredVqc(int id) {
        if(!mkrfFilteredVqc.Contains(id)) {
            mkrfFilteredVqc.Add(id);
        }
        else {
            mkrfFilteredVqc.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredVqc() {
        mkrfFilteredVqc = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredDistanceContainsKey(int id) {
        return mkrfFilteredDistance.Contains(id);
    }

    public List<int> GetMkrfFilteredDistance() {
        return mkrfFilteredDistance;
    }

    public void SetMkrfFilteredDistance(int id) {
        if(!mkrfFilteredDistance.Contains(id)) {
            print("run");
            mkrfFilteredDistance.Add(id);
        }
        else {
            mkrfFilteredDistance.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredDistance() {
        mkrfFilteredDistance = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public bool MkrfFilteredVisibilityContainsKey(int id) {
        return mkrfFilteredVisibility.Contains(id);
    }

    public List<int> GetMkrfFilteredVisibility() {
        return mkrfFilteredVisibility;
    }

    public void SetMkrfFilteredVisibility(int id) {
        if(!mkrfFilteredVisibility.Contains(id)) {
            mkrfFilteredVisibility.Add(id);
        }
        else {
            mkrfFilteredVisibility.Remove(id);
        }

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    public void ResetMkrfFilteredVisibility() {
        mkrfFilteredVisibility = new List<int>();

        isRebuiltMkrf= false;
        isRefreshedMkrf= false;
    }

    //

    private void RebuildKop() {
        foreach(var item in GlobalProperties.Instance.KOPPositions) {
            kopFilter[item.Key] = true;

            if(kopFilteredId.Count == 0) {

            }
            else {
                if(!kopFilteredId.Contains(item.Key)) {
                    kopFilter[item.Key] = false;
                    continue;
                }
            }

            if(kopFilteredImportance.Count == 0) {

            }
            else {
                if(!kopFilteredImportance.Contains(GlobalProperties.Instance.KOPFeatureProperties[item.Key].importance)) {
                    kopFilter[item.Key] = false;
                    continue;
                }
            }

            if(!kopFilteredDistance.Contains(item.Key)) {
                kopFilter[item.Key] = false;
                continue;
            }

            if(!kopFilteredVisibility.Contains(item.Key)) {
                kopFilter[item.Key] = false;
                continue;
            }
        }
    }

    private void RebuildMkrf() {
        foreach(var item in GlobalProperties.Instance.MKRFPositions) {
            mkrfFilter[item.Key] = true;

            if(mkrfFilteredId.Count == 0) {

            }
            else {
                if(!mkrfFilteredId.Contains(item.Key)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredBr.Count == 0) {

            }
            else {
                if(!mkrfFilteredBr.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].br)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredVc.Count == 0) {

            }
            else {
                if(!mkrfFilteredVc.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].vc)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredVr.Count == 0) {

            }
            else {
                if(!mkrfFilteredVr.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].vr)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredVac.Count == 0) {

            }
            else {
                if(!mkrfFilteredVac.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].vac)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredVsc.Count == 0) {

            }
            else {
                if(!mkrfFilteredVsc.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].vsc)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredEvc.Count == 0) {

            }
            else {
                if(!mkrfFilteredEvc.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].evc)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(mkrfFilteredVqc.Count == 0) {

            }
            else {
                if(!mkrfFilteredVqc.Contains(GlobalProperties.Instance.MKRFFeatureProperties[item.Key].vqcFinal)) {
                    mkrfFilter[item.Key] = false;
                    continue;
                }
            }

            if(!mkrfFilteredDistance.Contains(item.Key)) {
                mkrfFilter[item.Key] = false;
                continue;
            }

            if(!mkrfFilteredVisibility.Contains(item.Key)) {
                mkrfFilter[item.Key] = false;
                continue;
            }
        }
    }

    private void RefreshKop() {
        foreach(var item in kopFilter) {
            if(item.Value) {
                GlobalProperties.Instance.KOPManager.SetEnabled(item.Key, true);

                foreach(int key in GlobalProperties.Instance.LinkManager.GetKeys(item.Key, -1)) {
                    int idB = GlobalMethods.Instance.GetIdBFromKey(key);

                    if(mkrfFilter[idB] == true) {
                        GlobalProperties.Instance.LinkManager.SetEnabled(key, true);
                    }
                }
            }
            else {
                GlobalProperties.Instance.KOPManager.SetEnabled(item.Key, false);

                GlobalProperties.Instance.LinkManager.SetEnabled(item.Key, -1, false);
            }
        }
    }

    private void RefreshMkrf() {
        bool isOneTrue = false;
        bool isOneFalse = false;

        foreach(var item in mkrfFilter) {
            if(item.Value) {
                isOneTrue = true;
            }
            else {
                isOneFalse = true;
            }
        }

        bool isAllTrue = !isOneFalse;
        bool isAllFalse = !isOneTrue;

        foreach(var item in mkrfFilter) {
            if(item.Value) {
                GlobalProperties.Instance.PolygonManager.SetEnabled(item.Key, true);
                GlobalProperties.Instance.LineManager.SetEnabled(item.Key, true);

                if(GlobalProperties.Instance.BarManager.ContainsKey(item.Key)) {
                    GlobalProperties.Instance.BarManager.SetEnabled(item.Key, true);
                }

                foreach(int key in GlobalProperties.Instance.LinkManager.GetKeys(-1, item.Key)) {
                    int idA = GlobalMethods.Instance.GetIdAFromKey(key);

                    if(kopFilter[idA] == true) {
                        GlobalProperties.Instance.LinkManager.SetEnabled(key, true);
                    }
                }
            }
            else {
                GlobalProperties.Instance.PolygonManager.SetEnabled(item.Key, false);
                GlobalProperties.Instance.LineManager.SetEnabled(item.Key, false);

                if(GlobalProperties.Instance.BarManager.ContainsKey(item.Key)) {
                    GlobalProperties.Instance.BarManager.SetEnabled(item.Key, false);
                }

                GlobalProperties.Instance.LinkManager.SetEnabled(-1, item.Key, false);
            }
        }

        if(isAllTrue) {
            GlobalProperties.Instance.LineManager.SetEnabledAll(false);
        }
    }
}
