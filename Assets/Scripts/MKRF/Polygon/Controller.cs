using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.MKRF.Polygon {
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

        //

        public void OnShortLeftClick() {
            if(!GetEnabled()) {
                return;
            }

            if((mode % 10) == 0) {
                mode += 1;

                GlobalProperties.Instance.LineManager.OnShortLeftClick(id);
            }
            else if((mode % 10) == 1) {
                mode -= 1;

                GlobalProperties.Instance.LineManager.OnShortLeftClick(id);
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

                GlobalProperties.Instance.LineManager.OnShortRightClick(id);
            }
            else if((mode % 10) == 3) {
                mode -= 3;

                GlobalProperties.Instance.LineManager.OnShortRightClick(id);
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
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 0) {
                mode += 10;

                if(GlobalProperties.Instance.BarManager.ContainsKey(id)) {
                    GlobalProperties.Instance.BarManager.Highlight(id);
                }

                GlobalProperties.Instance.LinkManager.Highlight(-1, id);

                GlobalProperties.Instance.LineManager.OnShortMouseEnter(id);
            }
        }

        public void OnShortMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                if(GlobalProperties.Instance.BarManager.ContainsKey(id)) {
                    GlobalProperties.Instance.BarManager.Unhighlight(id);
                }

                GlobalProperties.Instance.LinkManager.Unhighlight(-1, id);

                GlobalProperties.Instance.LineManager.OnShortMouseExit(id);
            }
        }

        public void OnLongMouseEnter() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 1) {
                mode += 10;

                GlobalProperties.Instance.TooltipController.SetHeader("MKRF: " + id.ToString());
                GlobalProperties.Instance.TooltipController.SetContent("<sprite=0>: Show visible viewpoints\n<sprite=1>: Show invisible viewpoints\n<sprite=3>: Show additional information\n<sprite=4>: Hide additional information");
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

                GlobalProperties.Instance.BarManager.Add(id);
            }
            else if(((mode / 100) % 10) == 1) {
                mode += 100;

                GlobalProperties.Instance.LinkManager.Add(-1, id);
            }
        }

        public void OnDownScroll() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 100) % 10) == 1) {
                mode -= 100;

                GlobalProperties.Instance.BarManager.Remove(id);
            }
            else if(((mode / 100) % 10) == 2) {
                mode -= 100;

                GlobalProperties.Instance.LinkManager.Remove(-1, id);
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

            GlobalProperties.Instance.LineManager.Highlight(id);
        }

        public void Unhighlight() {
            if(!isHighlighted) {
                return;
            }

            isHighlighted = false;
            
            GlobalProperties.Instance.LineManager.Unhighlight(id);
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
