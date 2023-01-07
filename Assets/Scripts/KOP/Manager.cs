using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.KOP {
    public class Manager : MonoBehaviour {
        [SerializeField, HideInInspector] private Dictionary<int, Controller> controllers;

        private void Start() {
            controllers = new Dictionary<int, Controller>();

            for(int i = 0; i < GlobalProperties.Instance.KOPPositions.Count; i++) {
                int id = i + 1;

                Vector3 position = GlobalProperties.Instance.KOPPositions[id];
                JL.KOP.FeaturePropertiesObject featureProperties = GlobalProperties.Instance.KOPFeatureProperties[id];

                int importance = featureProperties.importance;

                Vector3 scale = Vector3.one;

                if(importance == 1) {
                    scale = GlobalProperties.Instance.KOPScale[0];
                }
                else if(importance == 2) {
                    scale = GlobalProperties.Instance.KOPScale[1];
                }
                else if(importance == 3) {
                    scale = GlobalProperties.Instance.KOPScale[2];
                }

                Controller controller = Instantiate();

                controller.SetId(id);

                controller.SetPosition(position);
                controller.SetRotation(Quaternion.identity);
                controller.SetScale(scale);

                controller.SetPositionOffset(GlobalProperties.Instance.KOPPointPositionOffset);
                controller.SetRotationOffset(GlobalProperties.Instance.KOPPointRotationOffset);
                controller.SetScaleOffset(GlobalProperties.Instance.KOPPointScaleOffset);

                controller.SetColor(GlobalProperties.Instance.KOPPointColor);
                controller.SetAlpha(GlobalProperties.Instance.KOPPointAlpha);

                controller.SetColorAlternative1(GlobalProperties.Instance.KOPPointColorAlternative1);
                controller.SetAlphaAlternative1(GlobalProperties.Instance.KOPPointAlphaAlternative1);

                controller.SetColorAlternative2(GlobalProperties.Instance.KOPPointColorAlternative2);
                controller.SetAlphaAlternative2(GlobalProperties.Instance.KOPPointAlphaAlternative2);

                controller.SetOutlineColor(GlobalProperties.Instance.KOPPointOutlineColor);
                controller.SetOutlineWidth(GlobalProperties.Instance.KOPPointOutlineWidth);

                controller.SetOutlineColorAlternative(GlobalProperties.Instance.KOPPointOutlineColorAlternative);
                controller.SetOutlineWidthAlternative(GlobalProperties.Instance.KOPPointOutlineWidthAlternative);

                controllers.Add(id, controller);
            }
        }

        private void Update() {

        }

        //

        public bool ContainsKey(int id) {
            return controllers.ContainsKey(id);
        }

        public List<int> GetKeys() {
            return new List<int>(controllers.Keys);
        }

        //

        public int GetId(int id) {
            return controllers[id].GetId();
        }

        public void SetId(int id, int id_) {
            controllers[id].SetId(id_);
        }

        public void SetIdAll(int id_) {
            foreach(var item in controllers) {
                item.Value.SetId(id_);
            }
        }

        public Vector3 GetPosition(int id) {
            return controllers[id].GetPosition();
        }

        public void SetPosition(int id, Vector3 position) {
            controllers[id].SetPosition(position);
        }

        public void SetPositionAll(Vector3 position) {
            foreach(var item in controllers) {
                item.Value.SetPosition(position);
            }
        }

        public Quaternion GetRotation(int id) {
            return controllers[id].GetRotation();
        }

        public void SetRotation(int id, Quaternion rotation) {
            controllers[id].SetRotation(rotation);
        }

        public void SetRotationAll(Quaternion rotation) {
            foreach(var item in controllers) {
                item.Value.SetRotation(rotation);
            }
        }

        public Vector3 GetScale(int id) {
            return controllers[id].GetScale();
        }

        public void SetScale(int id, Vector3 scale) {
            controllers[id].SetScale(scale);
        }

        public void SetScaleAll(Vector3 scale) {
            foreach(var item in controllers) {
                item.Value.SetScale(scale);
            }
        }

        public Vector3 GetPositionOffset(int id) {
            return controllers[id].GetPositionOffset();
        }

        public void SetPositionOffset(int id, Vector3 positionOffset) {
            controllers[id].SetPositionOffset(positionOffset);
        }

        public void SetPositionOffsetAll(Vector3 positionOffset) {
            foreach(var item in controllers) {
                item.Value.SetPositionOffset(positionOffset);
            }
        }

        public Quaternion GetRotationOffset(int id) {
            return controllers[id].GetRotationOffset();
        }

        public void SetRotationOffset(int id, Quaternion rotationOffset) {
            controllers[id].SetRotationOffset(rotationOffset);
        }

        public void SetRotationOffsetAll(Quaternion rotationOffset) {
            foreach(var item in controllers) {
                item.Value.SetRotationOffset(rotationOffset);
            }
        }

        public Vector3 GetScaleOffset(int id) {
            return controllers[id].GetScaleOffset();
        }

        public void SetScaleOffset(int id, Vector3 scaleOffset) {
            controllers[id].SetScaleOffset(scaleOffset);
        }

        public void SetScaleOffsetAll(Vector3 scaleOffset) {
            foreach(var item in controllers) {
                item.Value.SetScaleOffset(scaleOffset);
            }
        }

        public Color GetColor(int id) {
            return controllers[id].GetColor();
        }

        public void SetColor(int id, Color color) {
            controllers[id].SetColor(color);
        }

        public void SetColorAll(Color color) {
            foreach(var item in controllers) {
                item.Value.SetColor(color);
            }
        }

        public float GetAlpha(int id) {
            return controllers[id].GetAlpha();
        }

        public void SetAlpha(int id, float alpha) {
            controllers[id].SetAlpha(alpha);
        }

        public void SetAlphaAll(float alpha) {
            foreach(var item in controllers) {
                item.Value.SetAlpha(alpha);
            }
        }

        public Color GetColorAlternative1(int id) {
            return controllers[id].GetColorAlternative1();
        }

        public void SetColorAlternative1(int id, Color colorAlternative1) {
            controllers[id].SetColorAlternative1(colorAlternative1);
        }

        public void SetColorAlternative1All(Color colorAlternative1) {
            foreach(var item in controllers) {
                item.Value.SetColorAlternative1(colorAlternative1);
            }
        }

        public float GetAlphaAlternative1(int id) {
            return controllers[id].GetAlphaAlternative1();
        }

        public void SetAlphaAlternative1(int id, float alphaAlternative1) {
            controllers[id].SetAlphaAlternative1(alphaAlternative1);
        }

        public void SetAlphaAlternative1All(float alphaAlternative1) {
            foreach(var item in controllers) {
                item.Value.SetAlphaAlternative1(alphaAlternative1);
            }
        }

        public Color GetColorAlternative2(int id) {
            return controllers[id].GetColorAlternative2();
        }

        public void SetColorAlternative2(int id, Color colorAlternative2) {
            controllers[id].SetColorAlternative2(colorAlternative2);
        }

        public void SetColorAlternative2All(Color colorAlternative2) {
            foreach(var item in controllers) {
                item.Value.SetColorAlternative2(colorAlternative2);
            }
        }

        public float GetAlphaAlternative2(int id) {
            return controllers[id].GetAlphaAlternative2();
        }

        public void SetAlphaAlternative2(int id, float alphaAlternative2) {
            controllers[id].SetAlphaAlternative2(alphaAlternative2);
        }

        public void SetAlphaAlternative2All(float alphaAlternative2) {
            foreach(var item in controllers) {
                item.Value.SetAlphaAlternative2(alphaAlternative2);
            }
        }

        public Color GetOutlineColor(int id) {
            return controllers[id].GetOutlineColor();
        }

        public void SetOutlineColor(int id, Color outlineColor) {
            controllers[id].SetOutlineColor(outlineColor);
        }

        public void SetOutlineColorAll(Color outlineColor) {
            foreach(var item in controllers) {
                item.Value.SetOutlineColor(outlineColor);
            }
        }

        public float GetOutlineWidth(int id) {
            return controllers[id].GetOutlineWidth();
        }

        public void SetOutlineWidth(int id, float outlineWidth) {
            controllers[id].SetOutlineWidth(outlineWidth);
        }

        public void SetOutlineWidthAll(float outlineWidth) {
            foreach(var item in controllers) {
                item.Value.SetOutlineWidth(outlineWidth);
            }
        }

        public Color GetOutlineColorAlternative(int id) {
            return controllers[id].GetOutlineColorAlternative();
        }

        public void SetOutlineColorAlternative(int id, Color outlineColorAlternative) {
            controllers[id].SetOutlineColorAlternative(outlineColorAlternative);
        }

        public void SetOutlineColorAlternativeAll(Color outlineColorAlternative) {
            foreach(var item in controllers) {
                item.Value.SetOutlineColorAlternative(outlineColorAlternative);
            }
        }

        public float GetOutlineWidthAlternative(int id) {
            return controllers[id].GetOutlineWidthAlternative();
        }

        public void SetOutlineWidthAlternative(int id, float outlineWidthAlternative) {
            controllers[id].SetOutlineWidthAlternative(outlineWidthAlternative);
        }

        public void SetOutlineWidthAlternativeAll(float outlineWidthAlternative) {
            foreach(var item in controllers) {
                item.Value.SetOutlineWidthAlternative(outlineWidthAlternative);
            }
        }

        //

        public void OnShortLeftClick(int id) {
            controllers[id].OnShortLeftClick();

            UpdateFilteredVisibility();
        }

        public void OnShortLeftClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortLeftClick();
            }

            UpdateFilteredVisibility();
        }

        public void OnLongLeftClick(int id) {
            controllers[id].OnLongLeftClick();
        }

        public void OnLongLeftClickAll() {
            foreach(var item in controllers) {
                item.Value.OnLongLeftClick();
            }
        }

        public void OnShortRightClick(int id) {
            controllers[id].OnShortRightClick();

            UpdateFilteredVisibility();
        }

        public void OnShortRightClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortRightClick();
            }

            UpdateFilteredVisibility();
        }

        public void OnLongRightClick(int id) {
            controllers[id].OnLongRightClick();
        }

        public void OnLongRightClickAll() {
            foreach(var item in controllers) {
                item.Value.OnLongRightClick();
            }
        }

        public void OnShortMiddleClick(int id) {
            controllers[id].OnShortMiddleClick();
        }

        public void OnShortMiddleClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortMiddleClick();
            }
        }

        public void OnLongMiddleClick(int id) {
            controllers[id].OnLongMiddleClick();
        }

        public void OnLongMiddleClickAll() {
            foreach(var item in controllers) {
                item.Value.OnLongMiddleClick();
            }
        }

        public void OnShortMouseEnter(int id) {
            controllers[id].OnShortMouseEnter();
        }

        public void OnShortMouseEnterAll() {
            foreach(var item in controllers) {
                item.Value.OnShortMouseEnter();
            }
        }

        public void OnShortMouseExit(int id) {
            controllers[id].OnShortMouseExit();
        }

        public void OnShortMouseExitAll() {
            foreach(var item in controllers) {
                item.Value.OnShortMouseExit();
            }
        }

        public void OnLongMouseEnter(int id) {
            controllers[id].OnLongMouseEnter();
        }

        public void OnLongMouseEnterAll() {
            foreach(var item in controllers) {
                item.Value.OnLongMouseEnter();
            }
        }

        public void OnLongMouseExit(int id) {
            controllers[id].OnLongMouseExit();
        }

        public void OnLongMouseExitAll() {
            foreach(var item in controllers) {
                item.Value.OnLongMouseExit();
            }
        }

        public void OnUpScroll(int id) {
            controllers[id].OnUpScroll();
        }

        public void OnUpScrollAll() {
            foreach(var item in controllers) {
                item.Value.OnUpScroll();
            }
        }

        public void OnDownScroll(int id) {
            controllers[id].OnDownScroll();
        }

        public void OnDownScrollAll() {
            foreach(var item in controllers) {
                item.Value.OnDownScroll();
            }
        }

        //

        public bool GetEnabled(int id) {
            return controllers[id].GetEnabled();
        }

        public void SetEnabled(int id, bool enabled) {
            controllers[id].SetEnabled(enabled);
        }

        public void SetEnabledAll(bool enabled) {
            foreach(var item in controllers) {
                item.Value.SetEnabled(enabled);
            }
        }

        public int GetMode(int id) {
            return controllers[id].GetMode();
        }

        public void SetMode(int id, int mode) {
            controllers[id].SetMode(mode);
        }

        public void SetModeAll(int mode) {
            foreach(var item in controllers) {
                item.Value.SetMode(mode);
            }
        }

        public void ResetMode(int id) {
            controllers[id].ResetMode();
        }

        public void ResetModeAll() {
            foreach(var item in controllers) {
                item.Value.ResetMode();
            }
        }

        public void Highlight(int id) {
            controllers[id].Highlight();
        }

        public void HighlightAll() {
            foreach(var item in controllers) {
                item.Value.Highlight();
            }
        }

        public void Unhighlight(int id) {
            controllers[id].Unhighlight();
        }

        public void UnhighlightAll() {
            foreach(var item in controllers) {
                item.Value.Unhighlight();
            }
        }

        //

        private Controller Instantiate() {
            GameObject prefab = Resources.Load("Prefabs/KOP", typeof(GameObject)) as GameObject;

            GameObject gameObject_ = Instantiate(prefab);
            Transform transform_ = gameObject_.transform;

            transform_.parent = transform;

            Controller controller = gameObject_.AddComponent<Controller>();

            return controller;
        }

        private void UpdateFilteredVisibility() {
            Dictionary<int, bool> ids = new Dictionary<int, bool>();

            foreach(var item in GlobalProperties.Instance.MKRFPositions) {
                ids.Add(item.Key, true);
            }

            foreach(var item in controllers) {
                Dictionary<int, bool> ids_ = GlobalMethods.Instance.GetVisibilityByKopId(item.Key);

                int mode = item.Value.GetMode();

                if((mode % 10) == 1) {
                    foreach(var item_ in ids_) {
                        ids[item_.Key] = ids[item_.Key] && ids_[item_.Key];
                    }
                }
                else if((mode % 10) == 3) {
                    foreach(var item_ in ids_) {
                        ids[item_.Key] = ids[item_.Key] && !ids_[item_.Key];
                    }
                }
            }

            GlobalProperties.Instance.FilterController.ResetMkrfFilteredVisibility();

            foreach(var item in ids) {
                if(item.Value) {
                    GlobalProperties.Instance.FilterController.SetMkrfFilteredVisibility(item.Key);
                }
            }
        }
    }
}
