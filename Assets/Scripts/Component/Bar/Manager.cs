using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.Component.Bar {
    public class Manager : MonoBehaviour {
        [SerializeField, HideInInspector] private Dictionary<int, Controller> controllers;

        private void Start() {
            controllers = new Dictionary<int, Controller>();
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

        public List<float> GetValues(int id) {
            return controllers[id].GetValues();
        }

        public void SetValues(int id, List<float> values) {
            controllers[id].SetValues(values);
        }

        public void SetValuesAll(List<float> values) {
            foreach(var item in controllers) {
                item.Value.SetValues(values);
            }
        }

        public List<float> GetMaxValues(int id) {
            return controllers[id].GetMaxValues();
        }

        public void SetMaxValues(int id, List<float> maxValues) {
            controllers[id].SetMaxValues(maxValues);
        }

        public void SetMaxValuesAll(List<float> maxValues) {
            foreach(var item in controllers) {
                item.Value.SetMaxValues(maxValues);
            }
        }

        public List<Color> GetColors(int id) {
            return controllers[id].GetColors();
        }

        public void SetColors(int id, List<Color> colors) {
            controllers[id].SetColors(colors);
        }

        public void SetColorsAll(List<Color> colors) {
            foreach(var item in controllers) {
                item.Value.SetColors(colors);
            }
        }

        public List<float> GetAlphas(int id) {
            return controllers[id].GetAlphas();
        }

        public void SetAlphas(int id, List<float> alphas) {
            controllers[id].SetAlphas(alphas);
        }

        public void SetAlphasAll(List<float> alphas) {
            foreach(var item in controllers) {
                item.Value.SetAlphas(alphas);
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
        }

        public void OnShortLeftClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortLeftClick();
            }
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
        }

        public void OnShortRightClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortRightClick();
            }
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

        public void Add(int id) {
            Vector3 position = GlobalProperties.Instance.MKRFPositions[id];
            JL.MKRF.FeaturePropertiesObject featureProperties = GlobalProperties.Instance.MKRFFeatureProperties[id];

            int evc = featureProperties.evc;
            int vqc = featureProperties.vqcFinal;

            int br = featureProperties.br;
            int vc = featureProperties.vc;
            int vr = featureProperties.vr;
            int vac = featureProperties.vac;

            List<float> values = new List<float> {
                (br + vc + vr - vac),
                br,
                vc,
                vr,
                -1 * vac
            };

            List<float> maxValues = new List<float> {
                8,
                3,
                3,
                3,
                3
            };

            Color color = Color.clear;
            float alpha = 0f;

            if(evc < vqc) {
                color = GlobalProperties.Instance.BarColor[0];
                alpha = GlobalProperties.Instance.BarAlpha[0];
            }
            else if(evc == vqc) {
                color = GlobalProperties.Instance.BarColor[1];
                alpha = GlobalProperties.Instance.BarAlpha[1];
            }
            else if(evc > vqc) {
                color = GlobalProperties.Instance.BarColor[2];
                alpha = GlobalProperties.Instance.BarAlpha[2];
            }

            List<Color> colors = new List<Color> {
                color,
                GlobalProperties.Instance.BarColorPalette[0],
                GlobalProperties.Instance.BarColorPalette[1],
                GlobalProperties.Instance.BarColorPalette[2],
                GlobalProperties.Instance.BarColorPalette[3]
            };

            List<float> alphas = new List<float> {
                alpha,
                GlobalProperties.Instance.BarAlphaPalette[0],
                GlobalProperties.Instance.BarAlphaPalette[1],
                GlobalProperties.Instance.BarAlphaPalette[2],
                GlobalProperties.Instance.BarAlphaPalette[3]
            };

            Controller controller = Instantiate();

            controller.SetId(id);

            controller.SetPosition(position);
            controller.SetRotation(Quaternion.identity);
            controller.SetScale(Vector3.one * 30);

            controller.SetPositionOffset(GlobalProperties.Instance.BarPositionOffset);
            controller.SetRotationOffset(GlobalProperties.Instance.BarRotationOffset);
            controller.SetScaleOffset(GlobalProperties.Instance.BarScaleOffset);

            controller.SetValues(values);
            controller.SetMaxValues(maxValues);

            controller.SetColors(colors);
            controller.SetAlphas(alphas);

            controller.SetOutlineColor(GlobalProperties.Instance.BarOutlineColor);
            controller.SetOutlineWidth(GlobalProperties.Instance.BarOutlineWidth);

            controller.SetOutlineColorAlternative(GlobalProperties.Instance.BarOutlineColorAlternative);
            controller.SetOutlineWidthAlternative(GlobalProperties.Instance.BarOutlineWidthAlternative);

            controllers.Add(id, controller);

            if(GlobalProperties.Instance.FilterController.GetMkrfFilter()[id] == false) {
                controller.SetEnabled(false);
            }
        }

        public void Remove(int id) {
            controllers[id].Destroy();

            controllers.Remove(id);
        }

        //

        private Controller Instantiate() {
            GameObject prefab = Resources.Load("Prefabs/Component/Bar", typeof(GameObject)) as GameObject;

            GameObject gameObject_ = Instantiate(prefab);
            Transform transform_ = gameObject_.transform;

            transform_.parent = transform;

            Controller controller = gameObject_.AddComponent<Controller>();

            return controller;
        }
    }
}
