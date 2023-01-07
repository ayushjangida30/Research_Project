using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.MKRF.Line {
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

        [SerializeField] private Color colorAlternative = Color.clear;
        [SerializeField] private float alphaAlternative = 0f;

        [SerializeField] private Color colorAlternative1 = Color.clear;
        [SerializeField] private float alphaAlternative1 = 0f;

        [SerializeField] private Color colorAlternative2 = Color.clear;
        [SerializeField] private float alphaAlternative2 = 0f;

        [SerializeField, HideInInspector] private List<Renderer> renderers;
        [SerializeField, HideInInspector] private List<Transform> transforms;

        private bool isRebuilt = false;
        private bool isRefreshed = false;

        private int mode = -1;

        private bool isHighlighted = false;

        // Can be removed if Polygon and Line are merged.
        private bool tempEnabled = false;

        private void Start() {
            mode = 0;

            SetEnabled(false);
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

        public Color GetColorAlternative() {
            return colorAlternative;
        }

        public void SetColorAlternative(Color colorAlternative) {
            this.colorAlternative = colorAlternative;

            isRefreshed = false;
        }

        public float GetAlphaAlternative() {
            return alphaAlternative;
        }

        public void SetAlphaAlternative(float alphaAlternative) {
            this.alphaAlternative = alphaAlternative;

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

        //

        public void OnShortLeftClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 1;

                Color tempColor = GetColorAlternative();
                float tempAlpha = GetAlphaAlternative();

                SetColorAlternative(GetColor());
                SetAlphaAlternative(GetAlpha());

                SetColor(tempColor);
                SetAlpha(tempAlpha);

                tempColor = GetColorAlternative1();
                tempAlpha = GetAlphaAlternative1();

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

                tempColor = GetColorAlternative();
                tempAlpha = GetAlphaAlternative();

                SetColorAlternative(GetColor());
                SetAlphaAlternative(GetAlpha());

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

                Color tempColor = GetColorAlternative();
                float tempAlpha = GetAlphaAlternative();

                SetColorAlternative(GetColor());
                SetAlphaAlternative(GetAlpha());

                SetColor(tempColor);
                SetAlpha(tempAlpha);

                tempColor = GetColorAlternative2();
                tempAlpha = GetAlphaAlternative2();

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

                tempColor = GetColorAlternative();
                tempAlpha = GetAlphaAlternative();

                SetColorAlternative(GetColor());
                SetAlphaAlternative(GetAlpha());

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
                mode += 5;
            }
            else if((mode % 10) == 5) {
                mode -= 5;
            }
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
            if(((mode / 10) % 10) == 0) {
                mode += 10;

                if(((mode % 10) != 1) && ((mode % 10) != 3)) {
                    Color tempColor = GetColorAlternative();
                    float tempAlpha = GetAlphaAlternative();

                    SetColorAlternative(GetColor());
                    SetAlphaAlternative(GetAlpha());

                    SetColor(tempColor);
                    SetAlpha(tempAlpha);
                }

                Highlight();
            }
        }

        public void OnShortMouseExit() {
            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                if(((mode % 10) != 1) && ((mode % 10) != 3)) {
                    SetEnabled(tempEnabled);

                    Color tempColor = GetColorAlternative();
                    float tempAlpha = GetAlphaAlternative();

                    SetColorAlternative(GetColor());
                    SetAlphaAlternative(GetAlpha());

                    SetColor(tempColor);
                    SetAlpha(tempAlpha);

                    Unhighlight();
                }
            }
        }

        public void OnLongMouseEnter() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 1) {
                mode += 10;
            }
        }

        public void OnLongMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;
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

            tempEnabled = GetEnabled();
            SetEnabled(true);
        }

        public void Unhighlight() {
            if(!isHighlighted) {
                return;
            }

            isHighlighted = false;

            SetEnabled(tempEnabled);
        }

        public void Destroy() {
            Object.Destroy(gameObject);
        }

        //

        private void Rebuild() {
            renderers = new List<Renderer>();
            transforms = new List<Transform>();

            if(transform.childCount == 0) {
                renderers.Add(transform.GetComponent<Renderer>());
                transforms.Add(transform);
            }
            else {
                foreach(Transform child in transform) {
                    renderers.Add(child.GetComponent<Renderer>());
                    transforms.Add(child);
                }
            }
        }

        private void Refresh() {
            transform.localPosition = position + positionOffset;
            transform.localRotation = rotation * rotationOffset;
            transform.localScale = Vector3.Scale(scale, scaleOffset);

            //Material material = Resources.Load("Materials/JL_MKRF_Polygon", typeof(Material)) as Material;

            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();

            materialPropertyBlock.SetColor("_Color", color);
            materialPropertyBlock.SetFloat("_Alpha", alpha);

            foreach(Renderer renderer in renderers) {
                //renderer.material = material;
                renderer.SetPropertyBlock(materialPropertyBlock);
            }
        }
    }
}
