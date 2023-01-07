using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.KOP {
    public class Controller : MonoBehaviour {
        [SerializeField] private int id = -1;

        [SerializeField] private Vector3 position = Vector3.zero;
        [SerializeField] private Quaternion rotation = Quaternion.identity;
        [SerializeField] private Vector3 scale = Vector3.one;

        [SerializeField] private Vector3 positionOffset = Vector3.zero;
        [SerializeField] private Quaternion rotationOffset = Quaternion.identity;
        [SerializeField] private Vector3 scaleOffset = Vector3.one;

        [SerializeField] private Color color = Color.clear;
        [SerializeField] private float alpha = 0f;

        [SerializeField] private Color colorAlternative1 = Color.clear;
        [SerializeField] private float alphaAlternative1 = 0f;

        [SerializeField] private Color colorAlternative2 = Color.clear;
        [SerializeField] private float alphaAlternative2 = 0f;

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

            Vector3 displacement = Camera.main.transform.position - transform.position;

            transform.localRotation = Quaternion.LookRotation(Vector3.Cross(Vector3.up,  Vector3.Cross(Vector3.up, (-1 * Camera.main.transform.forward))), Vector3.up);
            transform.localScale = Vector3.Scale(scale, scaleOffset) * displacement.magnitude * 0.001f;
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

        public Color GetColor() {
            return color;
        }

        public void SetColor(Color color) {
            this.color = color;

            isRefreshed = false;
        }

        public float GetAlpha() {
            return alpha;
        }

        public void SetAlpha(float alpha) {
            this.alpha = alpha;

            isRefreshed = false;
        }

        public Color GetColorAlternative1() {
            return colorAlternative1;
        }

        public void SetColorAlternative1(Color colorAlternative1) {
            this.colorAlternative1 = colorAlternative1;

            isRefreshed = false;
        }

        public float GetAlphaAlternative1() {
            return alphaAlternative1;
        }

        public void SetAlphaAlternative1(float alphaAlternative1) {
            this.alphaAlternative1 = alphaAlternative1;

            isRefreshed = false;
        }

        public Color GetColorAlternative2() {
            return colorAlternative2;
        }

        public void SetColorAlternative2(Color colorAlternative2) {
            this.colorAlternative2 = colorAlternative2;

            isRefreshed = false;
        }

        public float GetAlphaAlternative2() {
            return alphaAlternative2;
        }

        public void SetAlphaAlternative2(float alphaAlternative2) {
            this.alphaAlternative2 = alphaAlternative2;

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

                Color tempColor = GetColorAlternative1();
                float tempAlpha = GetAlphaAlternative1();

                SetColorAlternative1(GetColor());
                SetAlphaAlternative1(GetAlpha());

                SetColor(tempColor);
                SetAlpha(tempAlpha);
            }
            else if((mode % 10) == 1) {
                mode -= 1;

                Color tempColor = GetColorAlternative1();
                float tempAlpha = GetAlphaAlternative1();

                SetColorAlternative1(GetColor());
                SetAlphaAlternative1(GetAlpha());

                SetColor(tempColor);
                SetAlpha(tempAlpha);
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

                Color tempColor = GetColorAlternative2();
                float tempAlpha = GetAlphaAlternative2();

                SetColorAlternative2(GetColor());
                SetAlphaAlternative2(GetAlpha());

                SetColor(tempColor);
                SetAlpha(tempAlpha);
            }
            else if((mode % 10) == 3) {
                mode -= 3;

                Color tempColor = GetColorAlternative2();
                float tempAlpha = GetAlphaAlternative2();

                SetColorAlternative2(GetColor());
                SetAlphaAlternative2(GetAlpha());

                SetColor(tempColor);
                SetAlpha(tempAlpha);
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

            GlobalProperties.Instance.CameraController.SetMode(1);
            GlobalProperties.Instance.CameraController.Teleport(position + (GlobalProperties.Instance.ViewerHeight * Vector3.up));
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

                GlobalProperties.Instance.LinkManager.Highlight(id, -1);
            }
        }

        public void OnShortMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                Unhighlight();

                GlobalProperties.Instance.LinkManager.Highlight(id, -1);
            }
        }

        public void OnLongMouseEnter() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 1) {
                mode += 10;

                GlobalProperties.Instance.TooltipController.SetHeader("KOP: " + id.ToString());
                GlobalProperties.Instance.TooltipController.SetContent("<sprite=0>: Show visible polygons\n<sprite=1>: Show invisible polygons\n<sprite=2>: Teleport");
                GlobalProperties.Instance.TooltipController.SetEnabled(true);
            }
        }

        public void OnLongMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                GlobalProperties.Instance.TooltipController.SetEnabled(false);
            }
        }

        public void OnUpScroll() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 100) % 10) == 0) {
                mode += 100;
            }
        }

        public void OnDownScroll() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 100) % 10) != 0) {
                mode -= 100;
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
            renderers = new List<Renderer>();
            transforms = new List<Transform>();

            foreach(Transform child in transform) {
                renderers.Add(child.GetComponent<Renderer>());
                transforms.Add(child);
            }
        }

        private void Refresh() {
            transform.localPosition = position + positionOffset;
            transform.localRotation = rotation * rotationOffset;
            transform.localScale = Vector3.Scale(scale, scaleOffset);

            Material material = Resources.Load("Materials/JL_KOP", typeof(Material)) as Material;

            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

            materialPropertyBlock.SetColor("_Color", color);
            materialPropertyBlock.SetFloat("_Alpha", alpha);

            materialPropertyBlock.SetColor("_OutlineColor", outlineColor);
            materialPropertyBlock.SetFloat("_OutlineWidth", outlineWidth);

            foreach(Renderer renderer in renderers) {
                renderer.material = material;
                renderer.SetPropertyBlock(materialPropertyBlock);
            }
        }
    }
}
