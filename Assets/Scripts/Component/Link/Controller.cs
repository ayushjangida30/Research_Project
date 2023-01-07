using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.Component.Link {
    public class Controller : MonoBehaviour {
        [SerializeField] private int idA = -1;
        [SerializeField] private int idB = -1;

        [SerializeField] private Vector3 position = Vector3.zero;
        [SerializeField] private Quaternion rotation = Quaternion.identity;
        [SerializeField] private Vector3 scale = Vector3.one;

        [SerializeField] private Vector3 positionOffset = Vector3.zero;
        [SerializeField] private Quaternion rotationOffset = Quaternion.identity;
        [SerializeField] private Vector3 scaleOffset = Vector3.one;

        [SerializeField] private float dashLength = 0f;
        [SerializeField] private float spaceLength = 0f;

        [SerializeField] private Color color = Color.clear;
        [SerializeField] private float alpha = 0f;

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
        }

        //

        public int GetIdA() {
            return idA;
        }

        public void SetIdA(int idA) {
            this.idA = idA;

            transform.name = ((10000 * idA) + idB).ToString();

            isRebuilt = false;
            isRefreshed = false;
        }

        public int GetIdB() {
            return idB;
        }

        public void SetIdB(int idB) {
            this.idB = idB;

            transform.name = ((10000 * idA) + idB).ToString();

            isRebuilt = false;
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

        public float GetDashLength() {
            return dashLength;
        }

        public void SetDashLength(float dashLength) {
            this.dashLength = dashLength;

            isRebuilt = false;
            isRefreshed = false;
        }

        public float GetSpaceLength() {
            return spaceLength;
        }

        public void SetSpaceLength(float spaceLength) {
            this.spaceLength = spaceLength;

            isRebuilt = false;
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
            }
            else if((mode % 10) == 1) {
                mode -= 1;
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

                Highlight();

                if(GlobalProperties.Instance.KOPManager.ContainsKey(idA)) {
                    GlobalProperties.Instance.KOPManager.OnShortMouseEnter(idA);
                }

                if(GlobalProperties.Instance.PolygonManager.ContainsKey(idB)) {
                    GlobalProperties.Instance.PolygonManager.OnShortMouseEnter(idB);
                }

                if(GlobalProperties.Instance.BarManager.ContainsKey(idB)) {
                    GlobalProperties.Instance.BarManager.OnShortMouseEnter(idB);
                }
            }
        }

        public void OnShortMouseExit() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) != 0) {
                mode -= 10;

                Unhighlight();

                if(GlobalProperties.Instance.KOPManager.ContainsKey(idA)) {
                    GlobalProperties.Instance.KOPManager.OnShortMouseExit(idA);
                }

                if(GlobalProperties.Instance.PolygonManager.ContainsKey(idB)) {
                    GlobalProperties.Instance.PolygonManager.OnShortMouseExit(idB);
                }

                if(GlobalProperties.Instance.BarManager.ContainsKey(idB)) {
                    GlobalProperties.Instance.BarManager.OnShortMouseExit(idB);
                }
            }
        }

        public void OnLongMouseEnter() {
            if(!GetEnabled()) {
                return;
            }

            if(((mode / 10) % 10) == 1) {
                mode += 10;

                GlobalProperties.Instance.TooltipController.SetHeader("KOP: " + idA.ToString() + "\n" + "MKRF: " + idB.ToString());
                GlobalProperties.Instance.TooltipController.SetContent("");
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
            foreach(Transform child in transform) {
                Object.Destroy(child.gameObject);
            }

            if(dashLength == 0 || spaceLength == 0) {
                GenerateTransform();
            }
            else {
                GenerateTransform(dashLength, spaceLength);
            }

            renderers = new List<Renderer>();
            transforms = new List<Transform>();

            foreach(Transform child in transform) {
                if(child.childCount == 0) {
                    renderers.Add(child.GetComponent<Renderer>());
                    transforms.Add(child);
                }
                else {
                    foreach(Transform grandChild in child) {
                        renderers.Add(grandChild.GetComponent<Renderer>());
                        transforms.Add(grandChild);
                    }
                }
            }
        }

        private void Refresh() {
            transform.localPosition = position + positionOffset;
            transform.localRotation = rotation * rotationOffset;
            transform.localScale = Vector3.Scale(scale, scaleOffset);

            Material material = Resources.Load("Materials/JL_Component_Link", typeof(Material)) as Material;

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

        private Transform GenerateTransform() {
            GameObject gameObject;

            UnityEngine.ProBuilder.ProBuilderMesh mesh;

            Vector3 positionA = Vector3.zero;
            Vector3 positionB = Vector3.zero;

            if(idA != 0 && idB != 0) {
                positionA = GlobalMethods.Instance.SnapToSceneHeightmap(GlobalProperties.Instance.KOPManager.GetPosition(idA));
                positionB = GlobalMethods.Instance.SnapToSceneHeightmap(GlobalProperties.Instance.BarManager.GetPosition(idB));
            }
            else if(idA != 0) {
                positionA = GlobalMethods.Instance.SnapToSceneHeightmap(GlobalProperties.Instance.KOPManager.GetPosition(idA));
                positionB = positionA + (Vector3.up * 100f) + (Vector3.right * 0.1f);
            }
            else if(idB != 0) {
                positionB = GlobalMethods.Instance.SnapToSceneHeightmap(GlobalProperties.Instance.BarManager.GetPosition(idB));
                positionA = positionB + (Vector3.up * 100f) + (Vector3.right * 0.1f);
            }

            Vector3 xPosition = (positionA.y <= positionB.y) ? positionA : positionB;
            Vector3 yPosition = (positionA.y <= positionB.y) ? positionB : positionA;

            float angle = GetAngle(xPosition, yPosition);
            float radius = GetRadius(xPosition, yPosition, angle);

            Vector3 position = xPosition;
            Vector3 eulerAngle = GetEulerAngle(xPosition, yPosition);

            angle = 180 - (angle * 2);

            gameObject = new GameObject();

            gameObject.transform.name = "meshes";
            gameObject.transform.parent = this.transform;

            gameObject.transform.position = position;
            gameObject.transform.eulerAngles = eulerAngle;

            mesh = UnityEngine.ProBuilder.ShapeGenerator.GenerateArch(UnityEngine.ProBuilder.PivotLocation.FirstVertex, angle, radius, 10f, 10f, 1000, true, true, true, true, true);

            UnityEditor.ProBuilder.EditorMeshUtility.Optimize(mesh);
            
            mesh.transform.name = "mesh";
            mesh.transform.parent = gameObject.transform;

            mesh.transform.position = position;
            mesh.transform.eulerAngles = eulerAngle;

            mesh.gameObject.AddComponent<MeshCollider>();

            return gameObject.transform;
        }

        private Transform GenerateTransform(float dashLength, float spaceLength) {
            GameObject gameObject;

            UnityEngine.ProBuilder.ProBuilderMesh mesh;

            Vector3 positionA = GlobalMethods.Instance.SnapToSceneHeightmap(GlobalProperties.Instance.KOPManager.GetPosition(idA));
            Vector3 positionB = GlobalMethods.Instance.SnapToSceneHeightmap(GlobalProperties.Instance.BarManager.GetPosition(idB));

            Vector3 xPosition = (positionA.y <= positionB.y) ? positionA : positionB;
            Vector3 yPosition = (positionA.y <= positionB.y) ? positionB : positionA;

            float angle = GetAngle(xPosition, yPosition);
            float radius = GetRadius(xPosition, yPosition, angle);

            Vector3 position = xPosition;
            Vector3 eulerAngle = GetEulerAngle(xPosition, yPosition);

            angle = 180 - (angle * 2);

            gameObject = new GameObject();

            gameObject.transform.name = "meshes";
            gameObject.transform.parent = this.transform;

            gameObject.transform.position = position;
            gameObject.transform.eulerAngles = eulerAngle;

            float dashUnitAngle = (360f * dashLength) / (2 * Mathf.PI * radius);
            float spaceUnitAngle = (360f * spaceLength) / (2 * Mathf.PI * radius);

            float currentAngle = ((angle - dashUnitAngle) % (dashUnitAngle + spaceUnitAngle)) / 2;

            for(int i = 0; i < (int)(((angle - dashUnitAngle) / (dashUnitAngle + spaceUnitAngle)) + 1); i++) {
                mesh = UnityEngine.ProBuilder.ShapeGenerator.GenerateArch(UnityEngine.ProBuilder.PivotLocation.FirstVertex, dashUnitAngle, radius, 10f, 10f, 100, true, true, true, true, true);

                UnityEditor.ProBuilder.EditorMeshUtility.Optimize(mesh);

                mesh.transform.name = "mesh";
                mesh.transform.parent = gameObject.transform;

                mesh.transform.localPosition = GetMeshPosition(currentAngle, radius);
                mesh.transform.localEulerAngles = new Vector3(0, 0, currentAngle);

                mesh.gameObject.AddComponent<MeshCollider>();

                currentAngle = currentAngle + dashUnitAngle + spaceUnitAngle;
            }

            return gameObject.transform;
        }

        private float GetAngle(Vector3 xPosition, Vector3 yPosition) {
            if(xPosition.y == yPosition.y) {
                return 180f;
            }

            float angle;

            Vector3 zPosition = new Vector3(yPosition.x, xPosition.y, yPosition.z);

            Vector3 aVector = yPosition - xPosition;
            Vector3 bVector = zPosition - xPosition;

            angle = Mathf.Acos(Vector3.Dot(aVector, bVector) / (aVector.magnitude * bVector.magnitude)) * Mathf.Rad2Deg;

            return angle;
        }

        private float GetRadius(Vector3 xPosition, Vector3 yPosition, float angle) {
            float radius = ((yPosition - xPosition).magnitude / 2) / Mathf.Cos(angle * Mathf.Deg2Rad);

            return radius;
        }

        private Vector3 GetEulerAngle(Vector3 xPosition, Vector3 yPosition) {
            Vector3 eulerAngle;

            Vector3 vector = yPosition - xPosition;

            eulerAngle = new Vector3(0, (Mathf.Atan2(vector.x, vector.z) * Mathf.Rad2Deg) + 90, 0);

            return eulerAngle;
        }

        private Vector3 GetMeshPosition(float angle, float radius) {
            Vector3 meshPosition = Vector3.zero;

            meshPosition.x = radius * Mathf.Cos(angle * Mathf.Deg2Rad) - radius;
            meshPosition.y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);

            return meshPosition;
        }
    }
}
