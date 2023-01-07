using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.MKRF.Polygon {
    public class Manager : MonoBehaviour {
        [SerializeField, HideInInspector] private Dictionary<int, Controller> controllers;

        private void Start() {
            controllers = new Dictionary<int, Controller>();

            for(int i = 0; i < GlobalProperties.Instance.MKRFPositions.Count; i++) {
                int id = i + 1;

                Vector3 position = GlobalProperties.Instance.MKRFPositions[id];
                JL.MKRF.FeaturePropertiesObject featureProperties = GlobalProperties.Instance.MKRFFeatureProperties[id];

                int evc = featureProperties.evc;
                int vqc = featureProperties.vqcFinal;

                Color color = Color.clear;
                float alpha = 0f;

                if(evc < vqc) {
                    color = GlobalProperties.Instance.MKRFPolygonColor[0];
                    alpha = GlobalProperties.Instance.MKRFPolygonAlpha[0];
                }
                else if(evc == vqc) {
                    color = GlobalProperties.Instance.MKRFPolygonColor[1];
                    alpha = GlobalProperties.Instance.MKRFPolygonAlpha[1];
                }
                else if(evc > vqc) {
                    color = GlobalProperties.Instance.MKRFPolygonColor[2];
                    alpha = GlobalProperties.Instance.MKRFPolygonAlpha[2];
                }

                Controller controller = Instantiate(id.ToString());

                controller.SetId(id);

                controller.SetPosition(Vector3.zero);
                controller.SetRotation(Quaternion.identity);
                controller.SetScale(Vector3.one);

                controller.SetPositionOffset(GlobalProperties.Instance.MKRFPolygonPositionOffset);
                controller.SetRotationOffset(GlobalProperties.Instance.MKRFPolygonRotationOffset);
                controller.SetScaleOffset(GlobalProperties.Instance.MKRFPolygonScaleOffset);

                controller.SetColor(color);
                controller.SetAlpha(alpha);

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

        private Controller Instantiate(string idName) {
            Transform transform_ = transform.Find(idName);
            GameObject gameObject_ = transform_.gameObject;

            Controller controller = gameObject_.AddComponent<Controller>();

            return controller;
        }

        private void UpdateFilteredVisibility() {
            Dictionary<int, bool> ids = new Dictionary<int, bool>();

            foreach(var item in GlobalProperties.Instance.KOPPositions) {
                ids.Add(item.Key, true);
            }

            foreach(var item in controllers) {
                Dictionary<int, bool> ids_ = GlobalMethods.Instance.GetVisibilityByMkrfId(item.Key);

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

            GlobalProperties.Instance.FilterController.ResetKopFilteredVisibility();

            foreach(var item in ids) {
                if(item.Value) {
                    GlobalProperties.Instance.FilterController.SetKopFilteredVisibility(item.Key);
                }
            }
        }
    }
}
