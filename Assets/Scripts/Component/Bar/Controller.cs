using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.Component.Bar {
    public class Controller : MonoBehaviour {
        [SerializeField] private int id = -1;

        [SerializeField] private Vector3 position = Vector3.zero;
        [SerializeField] private Quaternion rotation = Quaternion.identity;
        [SerializeField] private Vector3 scale = Vector3.one;

        [SerializeField] private Vector3 positionOffset = Vector3.zero;
        [SerializeField] private Quaternion rotationOffset = Quaternion.identity;
        [SerializeField] private Vector3 scaleOffset = Vector3.one;

        [SerializeField] private List<float> values = null;
        [SerializeField] private List<float> maxValues = null;

        [SerializeField] private List<Color> colors = null;
        [SerializeField] private List<float> alphas = null;

        [SerializeField] private Color outlineColor = Color.clear;
        [SerializeField] private float outlineWidth = 0f;

        [SerializeField] private Color outlineColorAlternative = Color.clear;
        [SerializeField] private float outlineWidthAlternative = 0f;

        [SerializeField, HideInInspector] private List<Renderer> renderers;
        [SerializeField, HideInInspector] private List<Transform> transforms;

        private bool isRebuilt = false;
        private bool isRefreshed = false;

        private int mode = -1;

        private bool isHighlighted = false;

        private void Start() {
            mode = 0;
        }

        private void Update() {
            if(!isRebuilt) {
                isRebuilt = true;

                Rebuild();
            }

            if(!isRefreshed) {
                isRefreshed = true;

                Refresh();
            }

            if((mode % 10) == 1 || ((mode / 10) % 10) == 2) {
                transform.localRotation = Quaternion.LookRotation(Vector3.Cross(Vector3.up,  Vector3.Cross(Vector3.up, (-1 * Camera.main.transform.forward))), Vector3.up);
            }
        }

        //

        public int GetId() {
            return id;
        }

        public void SetId(int id) {
            this.id = id;

            transform.name = id.ToString();

            isRefreshed = false;
        }

        public Vector3 GetPosition() {
            return position;
        }

        public void SetPosition(Vector3 position) {
            this.position = position;

            isRefreshed = false;
        }

        public Quaternion GetRotation() {
            return rotation;
        }

        public void SetRotation(Quaternion rotation) {
            this.rotation = rotation;

            isRefreshed = false;
        }

        public Vector3 GetScale() {
            return scale;
        }

        public void SetScale(Vector3 scale) {
            this.scale = scale;

            isRefreshed = false;
        }

        public Vector3 GetPositionOffset() {
            return positionOffset;
        }

        public void SetPositionOffset(Vector3 positionOffset) {
            this.positionOffset = positionOffset;

            isRefreshed = false;
        }

        public Quaternion GetRotationOffset() {
            return rotationOffset;
        }

        public void SetRotationOffset(Quaternion rotationOffset) {
            this.rotationOffset = rotationOffset;

            isRefreshed = false;
        }

        public Vector3 GetScaleOffset() {
            return scaleOffset;
        }

        public void SetScaleOffset(Vector3 scaleOffset) {
            this.scaleOffset = scaleOffset;

            isRefreshed = false;
        }

        public List<float> GetValues() {
            return values;
        }

        public void SetValues(List<float> values) {
            int tempCount = values.Count;

            this.values = values;

            if(tempCount != values.Count) {
                isRebuilt = false;
            }
            isRefreshed = false;
        }

        public List<float> GetMaxValues() {
            return maxValues;
        }

        public void SetMaxValues(List<float> maxValues) {
            this.maxValues = maxValues;

            isRefreshed = false;
        }

        public List<Color> GetColors() {
            return colors;
        }

        public void SetColors(List<Color> colors) {
            this.colors = colors;

            isRefreshed = false;
        }

        public List<float> GetAlphas() {
            return alphas;
        }

        public void SetAlphas(List<float> alphas) {
            this.alphas = alphas;

            isRefreshed = false;
        }

        public Color GetOutlineColor() {
            return outlineColor;
        }

        public void SetOutlineColor(Color outlineColor) {
            this.outlineColor = outlineColor;

            isRefreshed = false;
        }

        public float GetOutlineWidth() {
            return outlineWidth;
        }

        public void SetOutlineWidth(float outlineWidth) {
            this.outlineWidth = outlineWidth;

            isRefreshed = false;
        }

        public Color GetOutlineColorAlternative() {
            return outlineColorAlternative;
        }

        public void SetOutlineColorAlternative(Color outlineColorAlternative) {
            this.outlineColorAlternative = outlineColorAlternative;

            isRefreshed = false;
        }

        public float GetOutlineWidthAlternative() {
            return outlineWidthAlternative;
        }

        public void SetOutlineWidthAlternative(float outlineWidthAlternative) {
            this.outlineWidthAlternative = outlineWidthAlternative;

            isRefreshed = false;
        }

        //

        public void OnShortLeftClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 1;

                for(int i = 0; i < (values.Count - 1); i++) {
                    renderers[4 + (i * 3)].enabled = true;
                    renderers[5 + (i * 3)].enabled = true;
                    renderers[6 + (i * 3)].enabled = true;
                }
            }
            else if((mode % 10) == 1) {
                mode -= 1;

                if(((mode / 10) % 10) == 2) {
                    return;
                }

                for(int i = 0; i < (values.Count - 1); i++) {
                    renderers[4 + (i * 3)].enabled = false;
                    renderers[5 + (i * 3)].enabled = false;
                    renderers[6 + (i * 3)].enabled = false;
                }
            }
        }

        public void OnLongLeftClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 2;
            }
            else if((mode % 10) == 2) {
                mode -= 2;
            }
        }

        public void OnShortRightClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 3;
            }
            else if((mode % 10) == 3) {
                mode -= 3;
            }
        }

        public void OnLongRightClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 4;
            }
            else if((mode % 10) == 4) {
                mode -= 4;
            }
        }

        public void OnShortMiddleClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                //mode += 5;
            }
            else if((mode % 10) == 5) {
                //mode -= 5;
            }

            Vector3 originPosition = Camera.main.transform.position;
            Vector3 targetPosition = transform.Find("Simplified/Outline").GetComponent<Renderer>().bounds.center;

            Vector3 direction = (targetPosition - originPosition).normalized;

            Vector3 position = targetPosition - (500 * direction) + (Vector3.up * 100);
            position.y = targetPosition.y;

            GlobalProperties.Instance.CameraController.Teleport(position, targetPosition);
        }

        public void OnLongMiddleClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 6;
            }
            else if((mode % 10) == 6) {
                mode -= 6;
            }
        }

        public void OnShortMouseEnter() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 0) {
                mode += 10;

                Highlight();

                if(GlobalProperties.Instance.PolygonManager.ContainsKey(id)) {
                    GlobalProperties.Instance.PolygonManager.OnShortMouseEnter(id);
                }

                GlobalProperties.Instance.LinkManager.OnShortMouseEnter(-1, id);
            }
        }

        public void OnShortMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                Unhighlight();

                if(GlobalProperties.Instance.PolygonManager.ContainsKey(id)) {
                    GlobalProperties.Instance.PolygonManager.OnShortMouseExit(id);
                }

                GlobalProperties.Instance.LinkManager.OnShortMouseExit(-1, id);
            }
        }

        public void OnLongMouseEnter() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 1) {
                mode += 10;

                GlobalProperties.Instance.TooltipController.SetHeader("MKRF: " + id.ToString());
                GlobalProperties.Instance.TooltipController.SetContent("<sprite=0>: Show additional information\n<sprite=2>: Teleport\n<sprite=3>: Show additional information\n<sprite=4>: Hide additional information");
                GlobalProperties.Instance.TooltipController.SetEnabled(true);

                for(int i = 0; i < (values.Count - 1); i++) {
                    renderers[4 + (i * 3)].enabled = true;
                    renderers[5 + (i * 3)].enabled = true;
                    renderers[6 + (i * 3)].enabled = true;
                }
            }
        }

        public void OnLongMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                GlobalProperties.Instance.TooltipController.SetEnabled(false);

                if((mode % 10) == 1) {
                    return;
                }

                for(int i = 0; i < (values.Count - 1); i++) {
                    renderers[4 + (i * 3)].enabled = false;
                    renderers[5 + (i * 3)].enabled = false;
                    renderers[6 + (i * 3)].enabled = false;
                }
            }
        }

        public void OnUpScroll() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 100) % 10) == 0) {
                mode += 100;

                if(GlobalProperties.Instance.PolygonManager.ContainsKey(id)) {
                    GlobalProperties.Instance.PolygonManager.OnUpScroll(id);
                }
            }
        }

        public void OnDownScroll() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 100) % 10) != 0) {
                mode -= 100;

                if(GlobalProperties.Instance.PolygonManager.ContainsKey(id)) {
                    GlobalProperties.Instance.PolygonManager.OnDownScroll(id);
                }
            }
        }

        //

        public bool GetEnabled() {
            return gameObject.activeSelf;
        }

        public void SetEnabled(bool enabled) {
            gameObject.SetActive(enabled);
        }

        public int GetMode() {
            return mode;
        }

        public void SetMode(int mode) {
            ResetMode();

            if((mode % 10) == 0) {

            }
            else if((mode % 10) == 1) {
                OnShortLeftClick();
            }
            else if((mode % 10) == 2) {
                OnLongLeftClick();
            }
            else if((mode % 10) == 3) {
                OnShortRightClick();
            }
            else if((mode % 10) == 4) {
                OnLongRightClick();
            }
            else if((mode % 10) == 5) {
                OnShortMiddleClick();
            }
            else if((mode % 10) == 6) {
                OnLongMiddleClick();
            }

            if(((mode / 10) % 10) == 0) {

            }
            else if(((mode / 10) % 10) == 1) {
                OnShortMouseEnter();
            }
            else if(((mode / 10) % 10) == 2) {
                OnShortMouseEnter();
                OnLongMouseEnter();
            }

            for(int i = 0; i < ((mode / 100) % 10); i++) {
                OnUpScroll();
            }
        }

        public void ResetMode() {
            if((mode % 10) == 0) {

            }
            else if((mode % 10) == 1) {
                OnShortLeftClick();
            }
            else if((mode % 10) == 2) {
                OnLongLeftClick();
            }
            else if((mode % 10) == 3) {
                OnShortRightClick();
            }
            else if((mode % 10) == 4) {
                OnLongRightClick();
            }
            else if((mode % 10) == 5) {
                OnShortMiddleClick();
            }
            else if((mode % 10) == 6) {
                OnLongMiddleClick();
            }

            if(((mode / 10) % 10) == 0) {

            }
            else if(((mode / 10) % 10) == 1) {
                OnShortMouseExit();
            }
            else if(((mode / 10) % 10) == 2) {
                OnShortMouseExit();
                OnLongMouseExit();
            }

            while(((mode / 100) % 10) != 0) {
                OnDownScroll();
            }
        }

        public void Highlight() {
            if(isHighlighted) {
                return;
            }

            isHighlighted = true;

            Color tempOutlineColor = GetOutlineColorAlternative();
            float tempOutlineWidth = GetOutlineWidthAlternative();

            SetOutlineColorAlternative(GetOutlineColor());
            SetOutlineWidthAlternative(GetOutlineWidth());

            SetOutlineColor(tempOutlineColor);
            SetOutlineWidth(tempOutlineWidth);
        }

        public void Unhighlight() {
            if(!isHighlighted) {
                return;
            }

            isHighlighted = false;
            
            Color tempOutlineColor = GetOutlineColorAlternative();
            float tempOutlineWidth = GetOutlineWidthAlternative();

            SetOutlineColorAlternative(GetOutlineColor());
            SetOutlineWidthAlternative(GetOutlineWidth());

            SetOutlineColor(tempOutlineColor);
            SetOutlineWidth(tempOutlineWidth);
        }

        public void Destroy() {
            Object.Destroy(gameObject);
        }

        //

        private void Rebuild() {
            foreach(Transform child in transform) {
                if(child.name.Contains("Clone")) {
                    Object.Destroy(child.gameObject);
                }
            }

            GameObject prefab = transform.Find("Detailed").gameObject;

            Transform transform_;
            
            for(int i = 0; i < (values.Count - 1); i++) {
                GameObject gameObject_ = Instantiate(prefab);
                transform_ = gameObject_.transform;

                gameObject_.SetActive(true);

                transform_.parent = transform;
                transform_.name = "Detailed_Clone_" + (i + 1).ToString();
            }

            renderers = new List<Renderer>();
            transforms = new List<Transform>();

            transform_ = transform.Find("Overview");

            foreach(Transform child in transform_) {
                renderers.Add(child.GetComponent<Renderer>());
                transforms.Add(child);
            }

            transform_ = transform.Find("Simplified");

            renderers.Add(transform_.Find("Opaque").GetComponent<Renderer>());
            transforms.Add(transform_.Find("Opaque"));

            renderers.Add(transform_.Find("Transparent").GetComponent<Renderer>());
            transforms.Add(transform_.Find("Transparent"));

            renderers.Add(transform_.Find("Outline").GetComponent<Renderer>());
            transforms.Add(transform_.Find("Outline"));

            for(int i = 0; i < (values.Count - 1); i++) {
                transform_ = transform.Find("Detailed_Clone_" + (i + 1).ToString());

                renderers.Add(transform_.Find("Opaque").GetComponent<Renderer>());
                transforms.Add(transform_.Find("Opaque"));

                renderers.Add(transform_.Find("Transparent").GetComponent<Renderer>());
                transforms.Add(transform_.Find("Transparent"));

                renderers.Add(transform_.Find("Outline").GetComponent<Renderer>());
                transforms.Add(transform_.Find("Outline"));
            }

            for(int i = 0; i < (values.Count - 1); i++) {
                renderers[4 + (i * 3)].enabled = false;
                renderers[5 + (i * 3)].enabled = false;
                renderers[6 + (i * 3)].enabled = false;
            }
        }

        private void Refresh() {
            transform.localPosition = position + positionOffset;
            transform.localRotation = rotation * rotationOffset;
            transform.localScale = Vector3.Scale(scale, scaleOffset);

            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

            transforms[0].localPosition = new Vector3(-0.5f, maxValues[0] - 0.48f, -0.5f);
            transforms[0].localRotation = Quaternion.identity;
            transforms[0].localScale = Vector3.one;

            transforms[1].localPosition = new Vector3(0f, (values[0] - 1f) / 2f, 0f);
            transforms[1].localRotation = Quaternion.identity;
            transforms[1].localScale = new Vector3(1f, values[0], 1f);

            transforms[2].localPosition = new Vector3(0f, (maxValues[0] - 1f) / 2f, 0f);
            transforms[2].localRotation = Quaternion.identity;
            transforms[2].localScale = new Vector3(1f, maxValues[0], 1f);

            transforms[3].localPosition = new Vector3(-0.5f, -0.5f, 0.5f);
            transforms[3].localRotation = Quaternion.identity;
            transforms[3].localScale = new Vector3(1f, maxValues[0], 1f);

            materialPropertyBlock.SetColor("_Color", colors[0]);
            materialPropertyBlock.SetFloat("_Alpha", alphas[0]);

            materialPropertyBlock.SetColor("_OutlineColor", outlineColor);
            materialPropertyBlock.SetFloat("_OutlineWidth", outlineWidth);

            renderers[0].SetPropertyBlock(materialPropertyBlock);
            renderers[1].SetPropertyBlock(materialPropertyBlock);
            renderers[2].SetPropertyBlock(materialPropertyBlock);
            renderers[3].SetPropertyBlock(materialPropertyBlock);

            float totalCount = 0f;

            for(int i = 0; i < (values.Count - 1); i++) {
                float value = values[i + 1];
                float maxValue = maxValues[i + 1];

                if(value >= 0) {
                    Vector3 basePosition = new Vector3((i + 1) * 1.5f, totalCount, 0f);
                    totalCount += value;

                    transforms[4 + (i * 3)].localPosition = basePosition + new Vector3(0f, (value - 1f) / 2f, 0f);
                    transforms[4 + (i * 3)].localRotation = Quaternion.identity;
                    transforms[4 + (i * 3)].localScale = new Vector3(1f, value, 1f);

                    transforms[5 + (i * 3)].localPosition = basePosition + new Vector3(0f, (maxValue - 1f) / 2f, 0f);
                    transforms[5 + (i * 3)].localRotation = Quaternion.identity;
                    transforms[5 + (i * 3)].localScale = new Vector3(1f, maxValue, 1f);

                    transforms[6 + (i * 3)].localPosition = basePosition + new Vector3(-0.5f, -0.5f, 0.5f);
                    transforms[6 + (i * 3)].localRotation = Quaternion.identity;
                    transforms[6 + (i * 3)].localScale = new Vector3(1f, maxValue, 1f);
                }
                else {
                    value = -1 * value;

                    Vector3 basePosition = new Vector3((i + 1) * 1.5f, totalCount, 0f);
                    totalCount += value;

                    transforms[4 + (i * 3)].localPosition = basePosition + new Vector3(0f, (value - 1f) / 2f - value, 0f);
                    transforms[4 + (i * 3)].localRotation = Quaternion.identity;
                    transforms[4 + (i * 3)].localScale = new Vector3(1f, value, 1f);

                    transforms[5 + (i * 3)].localPosition = basePosition + new Vector3(0f, (maxValue - 1f) / 2f - maxValue, 0f);
                    transforms[5 + (i * 3)].localRotation = Quaternion.identity;
                    transforms[5 + (i * 3)].localScale = new Vector3(1f, maxValue, 1f);

                    transforms[6 + (i * 3)].localPosition = basePosition + new Vector3(-0.5f, -0.5f - maxValue, 0.5f);
                    transforms[6 + (i * 3)].localRotation = Quaternion.identity;
                    transforms[6 + (i * 3)].localScale = new Vector3(1f, maxValue, 1f);
                }

                materialPropertyBlock.SetColor("_Color", colors[i + 1]);
                materialPropertyBlock.SetFloat("_Alpha", alphas[i + 1]);

                materialPropertyBlock.SetColor("_OutlineColor", outlineColor);
                materialPropertyBlock.SetFloat("_OutlineWidth", outlineWidth);

                renderers[4 + (i * 3)].SetPropertyBlock(materialPropertyBlock);
                renderers[5 + (i * 3)].SetPropertyBlock(materialPropertyBlock);
                renderers[6 + (i * 3)].SetPropertyBlock(materialPropertyBlock);
            }
        }
    }
}
