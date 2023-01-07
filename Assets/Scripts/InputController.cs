using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class InputController : MonoBehaviour {
    private int uiLayer;

    private int prevLeftClickType = 0;
    private int prevLeftClickId = 0;

    private float leftClickTimer = 0;

    private int prevRightClickType = 0;
    private int prevRightClickId = 0;

    private float rightClickTimer = 0;

    private int prevMiddleClickType = 0;
    private int prevMiddleClickId = 0;

    private float middleClickTimer = 0;

    private int prevHoverType = 0;
    private int prevHoverId = 0;

    private float hoverTimer = 0;

    private bool shortHoverState = false;
    private bool longHoverState = false;

    private float scrollDelta = 0f;

    private void Start() {
        uiLayer = LayerMask.NameToLayer("UI");
    }

    private void Update() {
        if(IsPointerOverUIElement()) {
            Hover(0, 0);

            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        int actionType = 0;
        int actionId = 0;

        if(Physics.Raycast(ray, out hit)) {
            string hitPath = GlobalMethods.Instance.GetGameObjectPath(hit.transform.gameObject, 2);

            if(hit.transform.root.name == "Terrain") {
                actionType = 1;
                actionId = GlobalMethods.Instance.GetMKRFPointComplex(hit.point);

                if(actionId < 0) {
                    actionType = 0;
                    actionId = 0;
                }
            }
            else if(hitPath.Contains("KOP")) {
                actionType = 2;
                actionId = int.Parse(hit.transform.parent.name);
            }
            else if(hitPath.Contains("/Components/Bars")) {
                actionType = 3;
                actionId = int.Parse(hit.transform.parent.parent.name);
            }
            else if(hitPath.Contains("/Components/Links")) {
                actionType = 4;
                actionId = int.Parse(hit.transform.parent.parent.name);
            }
        }

        if(Input.GetMouseButtonDown(0)) {
            LeftClick(actionType, actionId, 0);
        }
        else if(Input.GetMouseButtonUp(0)) {
            LeftClick(actionType, actionId, 1);
        }

        if(Input.GetMouseButtonDown(1)) {
            RightClick(actionType, actionId, 0);
        }
        else if(Input.GetMouseButtonUp(1)) {
            RightClick(actionType, actionId, 1);
        }

        if(Input.GetMouseButtonDown(2)) {
            MiddleClick(actionType, actionId, 0);
        }
        else if(Input.GetMouseButtonUp(2)) {
            MiddleClick(actionType, actionId, 1);
        }

        if(!Input.GetMouseButton(0) && !Input.GetMouseButton(1) && !Input.GetMouseButton(2)) {
            Hover(actionType, actionId);
        }

        scrollDelta += Input.mouseScrollDelta.y;

        if(scrollDelta > 0) {
            for(int i = 0; i < Mathf.Floor(scrollDelta); i++) {
                Scroll(actionType, actionId, 0);

                scrollDelta -= 1.0f;
            }
        }
        else {
            for(int i = 0; i < (-1 * Mathf.Ceil(scrollDelta)); i++) {
                Scroll(actionType, actionId, 1);

                scrollDelta += 1.0f;
            }
        }

        if(Input.GetKeyUp(KeyCode.UpArrow)) {
            Scroll(actionType, actionId, 0);
        }

        if(Input.GetKeyUp(KeyCode.DownArrow)) {
            Scroll(actionType, actionId, 1);
        }
    }

    private bool IsPointerOverUIElement() {
        return IsPointerOverUIElement(GetEventSystemRaycastResults());
    }

    private bool IsPointerOverUIElement(List<RaycastResult> eventSystemRaycastResults) {
        foreach(RaycastResult eventSystemRaycastResult in eventSystemRaycastResults) {
            if(eventSystemRaycastResult.gameObject.layer == uiLayer) {
                return true;
            }
        }

        return false;
    }

    private List<RaycastResult> GetEventSystemRaycastResults() {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults;
    }

    private void LeftClick(int actionType, int actionId, int trigger) {
        if(trigger == 0) {
            prevLeftClickType = actionType;
            prevLeftClickId = actionId;

            leftClickTimer = Time.time;
        }
        else if(trigger == 1) {
            if(actionType == prevLeftClickType && actionId == prevLeftClickId) {
                float duration = Time.time - leftClickTimer;

                if(duration >= GlobalProperties.Instance.MouseShortActionDelay && duration < GlobalProperties.Instance.MouseLongActionDelay) {
                    switch(actionType) {
                        case 1:
                            GlobalProperties.Instance.PolygonManager.OnShortLeftClick(actionId);
                            break;
                        case 2:
                            GlobalProperties.Instance.KOPManager.OnShortLeftClick(actionId);
                            break;
                        case 3:
                            GlobalProperties.Instance.BarManager.OnShortLeftClick(actionId);
                            break;
                        case 4:
                            GlobalProperties.Instance.LinkManager.OnShortLeftClick(actionId);
                            break;
                        default:
                            break;
                    }
                }
                else if(duration >= GlobalProperties.Instance.MouseLongActionDelay) {
                    switch(actionType) {
                        case 1:
                            GlobalProperties.Instance.PolygonManager.OnLongLeftClick(actionId);
                            break;
                        case 2:
                            GlobalProperties.Instance.KOPManager.OnLongLeftClick(actionId);
                            break;
                        case 3:
                            GlobalProperties.Instance.BarManager.OnLongLeftClick(actionId);
                            break;
                        case 4:
                            GlobalProperties.Instance.LinkManager.OnLongLeftClick(actionId);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void RightClick(int actionType, int actionId, int trigger) {
        if(trigger == 0) {
            prevRightClickType = actionType;
            prevRightClickId = actionId;

            rightClickTimer = Time.time;
        }
        else if(trigger == 1) {
            if(actionType == prevRightClickType && actionId == prevRightClickId) {
                float duration = Time.time - rightClickTimer;

                if(duration >= GlobalProperties.Instance.MouseShortActionDelay && duration < GlobalProperties.Instance.MouseLongActionDelay) {
                    switch(actionType) {
                        case 1:
                            GlobalProperties.Instance.PolygonManager.OnShortRightClick(actionId);
                            break;
                        case 2:
                            GlobalProperties.Instance.KOPManager.OnShortRightClick(actionId);
                            break;
                        case 3:
                            GlobalProperties.Instance.BarManager.OnShortRightClick(actionId);
                            break;
                        case 4:
                            GlobalProperties.Instance.LinkManager.OnShortRightClick(actionId);
                            break;
                        default:
                            break;
                    }
                }
                else if(duration >= GlobalProperties.Instance.MouseLongActionDelay) {
                    switch(actionType) {
                        case 1:
                            GlobalProperties.Instance.PolygonManager.OnLongRightClick(actionId);
                            break;
                        case 2:
                            GlobalProperties.Instance.KOPManager.OnLongRightClick(actionId);
                            break;
                        case 3:
                            GlobalProperties.Instance.BarManager.OnLongRightClick(actionId);
                            break;
                        case 4:
                            GlobalProperties.Instance.LinkManager.OnLongRightClick(actionId);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void MiddleClick(int actionType, int actionId, int trigger) {
        if(trigger == 0) {
            prevMiddleClickType = actionType;
            prevMiddleClickId = actionId;

            middleClickTimer = Time.time;
        }
        else if(trigger == 1) {
            if(actionType == prevMiddleClickType && actionId == prevMiddleClickId) {
                float duration = Time.time - middleClickTimer;

                if(duration >= GlobalProperties.Instance.MouseShortActionDelay && duration < GlobalProperties.Instance.MouseLongActionDelay) {
                    switch(actionType) {
                        case 1:
                            GlobalProperties.Instance.PolygonManager.OnShortMiddleClick(actionId);
                            break;
                        case 2:
                            GlobalProperties.Instance.KOPManager.OnShortMiddleClick(actionId);
                            break;
                        case 3:
                            GlobalProperties.Instance.BarManager.OnShortMiddleClick(actionId);
                            break;
                        case 4:
                            GlobalProperties.Instance.LinkManager.OnShortMiddleClick(actionId);
                            break;
                        default:
                            break;
                    }
                }
                else if(duration >= GlobalProperties.Instance.MouseLongActionDelay) {
                    switch(actionType) {
                        case 1:
                            GlobalProperties.Instance.PolygonManager.OnLongMiddleClick(actionId);
                            break;
                        case 2:
                            GlobalProperties.Instance.KOPManager.OnLongMiddleClick(actionId);
                            break;
                        case 3:
                            GlobalProperties.Instance.BarManager.OnLongMiddleClick(actionId);
                            break;
                        case 4:
                            GlobalProperties.Instance.LinkManager.OnLongMiddleClick(actionId);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }

    private void Hover(int actionType, int actionId) {
        if(actionType == prevHoverType && actionId == prevHoverId) {
            float duration = Time.time - hoverTimer;

            if(duration >= GlobalProperties.Instance.MouseShortActionDelay && duration < GlobalProperties.Instance.MouseLongActionDelay) {
                shortHoverState = true;

                switch(actionType) {
                    case 1:
                        GlobalProperties.Instance.PolygonManager.OnShortMouseEnter(actionId);
                        break;
                    case 2:
                        GlobalProperties.Instance.KOPManager.OnShortMouseEnter(actionId);
                        break;
                    case 3:
                        GlobalProperties.Instance.BarManager.OnShortMouseEnter(actionId);
                        break;
                    case 4:
                        GlobalProperties.Instance.LinkManager.OnShortMouseEnter(actionId);
                        break;
                    default:
                        shortHoverState = false;
                        break;
                }
            }
            else if(duration >= GlobalProperties.Instance.MouseLongActionDelay) {
                longHoverState = true;

                switch(actionType) {
                    case 1:
                        GlobalProperties.Instance.PolygonManager.OnLongMouseEnter(actionId);
                        break;
                    case 2:
                        GlobalProperties.Instance.KOPManager.OnLongMouseEnter(actionId);
                        break;
                    case 3:
                        GlobalProperties.Instance.BarManager.OnLongMouseEnter(actionId);
                        break;
                    case 4:
                        GlobalProperties.Instance.LinkManager.OnLongMouseEnter(actionId);
                        break;
                    default:
                        longHoverState = false;
                        break;
                }
            }
        }
        else {
            if(shortHoverState) {
                shortHoverState = false;

                switch(prevHoverType) {
                    case 1:
                        GlobalProperties.Instance.PolygonManager.OnShortMouseExit(prevHoverId);
                        break;
                    case 2:
                        GlobalProperties.Instance.KOPManager.OnShortMouseExit(prevHoverId);
                        break;
                    case 3:
                        GlobalProperties.Instance.BarManager.OnShortMouseExit(prevHoverId);
                        break;
                    case 4:
                        GlobalProperties.Instance.LinkManager.OnShortMouseExit(prevHoverId);
                        break;
                    default:
                        break;
                }
            }

            if(longHoverState) {
                longHoverState = false;

                switch(prevHoverType) {
                    case 1:
                        GlobalProperties.Instance.PolygonManager.OnLongMouseExit(prevHoverId);
                        break;
                    case 2:
                        GlobalProperties.Instance.KOPManager.OnLongMouseExit(prevHoverId);
                        break;
                    case 3:
                        GlobalProperties.Instance.BarManager.OnLongMouseExit(prevHoverId);
                        break;
                    case 4:
                        GlobalProperties.Instance.LinkManager.OnLongMouseExit(prevHoverId);
                        break;
                    default:
                        break;
                }
            }

            prevHoverType = actionType;
            prevHoverId = actionId;

            hoverTimer = Time.time;
        }
    }

    private void Scroll(int actionType, int actionId, int trigger) {
        if(trigger == 0) {
            switch(actionType) {
                case 1:
                    GlobalProperties.Instance.PolygonManager.OnUpScroll(actionId);
                    break;
                case 2:
                    GlobalProperties.Instance.KOPManager.OnUpScroll(actionId);
                    break;
                case 3:
                    GlobalProperties.Instance.BarManager.OnUpScroll(actionId);
                    break;
                case 4:
                    GlobalProperties.Instance.LinkManager.OnUpScroll(actionId);
                    break;
                default:
                    break;
            }
        }
        else if(trigger == 1) {
            switch(actionType) {
                case 1:
                    GlobalProperties.Instance.PolygonManager.OnDownScroll(actionId);
                    break;
                case 2:
                    GlobalProperties.Instance.KOPManager.OnDownScroll(actionId);
                    break;
                case 3:
                    GlobalProperties.Instance.BarManager.OnDownScroll(actionId);
                    break;
                case 4:
                    GlobalProperties.Instance.LinkManager.OnDownScroll(actionId);
                    break;
                default:
                    break;
            }
        }
    }
}
