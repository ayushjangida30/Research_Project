using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

namespace JL.UI.Menu.Filters.Main.MKRF {
    public class Controller : MonoBehaviour {
        private Transform root;

        private Transform ids;
        private Transform brs;
        private Transform vcs;
        private Transform vrs;
        private Transform vacs;
        private Transform vscs;
        private Transform evcs;
        private Transform vqcs;

        private void Start() {
            root = transform.Find("Viewport/Content");

            ids = root.Find("Id/Ids/Viewport/Content");
            brs = root.Find("BR/BRs/Viewport/Content");
            vcs = root.Find("VC/VCs/Viewport/Content");
            vrs = root.Find("VR/VRs/Viewport/Content");
            vacs = root.Find("VAC/VACs/Viewport/Content");
            vscs = root.Find("VSC/VSCs/Viewport/Content");
            evcs = root.Find("EVC/EVCs/Viewport/Content");
            vqcs = root.Find("VQC/VQCs/Viewport/Content");

            for(int i = 0; i < GlobalProperties.Instance.MKRFPositions.Count; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredIdContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedId(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(ids, false);
                gameObject.transform.name = (i + 1).ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = (i + 1).ToString();
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = (i + 1).ToString();
            }

            for(int i = 0; i < 3; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredBrContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedBr(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(brs, false);
                gameObject.transform.name = (i + 1).ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = (i + 1).ToString();
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = (i + 1).ToString();
            }

            for(int i = 0; i < 3; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredVcContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedVc(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(vcs, false);
                gameObject.transform.name = (i + 1).ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = (i + 1).ToString();
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = (i + 1).ToString();
            }

            for(int i = 0; i < 3; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredVrContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedVr(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(vrs, false);
                gameObject.transform.name = (i + 1).ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = (i + 1).ToString();
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = (i + 1).ToString();
            }

            for(int i = 0; i < 3; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredVacContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedVac(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(vacs, false);
                gameObject.transform.name = (i + 1).ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = (i + 1).ToString();
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = (i + 1).ToString();
            }

            for(int i = 0; i < 8; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredVscContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedVsc(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(vscs, false);
                gameObject.transform.name = (i + 1).ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = (i + 1).ToString();
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = (i + 1).ToString();
            }

            for(int i = 0; i < 6; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredEvcContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedEvc(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(evcs, false);
                gameObject.transform.name = i.ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                string text = "";
                switch(i) {
                    case 0:
                        text = "Preserved";
                        break;

                    case 1:
                        text = "Retained";
                        break;

                    case 2:
                        text = "Partially Retained";
                        break;

                    case 3:
                        text = "Modified";
                        break;

                    case 4:
                        text = "Maximally Modified";
                        break;

                    case 5:
                        text = "Excessively Modified";
                        break;
                }

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = text;
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = i.ToString();
            }

            for(int i = 0; i < 6; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.MkrfFilteredVqcContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedVqc(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(vqcs, false);
                gameObject.transform.name = i.ToString();

                GameObject gameObject_ = new GameObject();

                gameObject_.AddComponent<RectTransform>();
                gameObject_.AddComponent<CanvasRenderer>();

                string text = "";
                switch(i) {
                    case 0:
                        text = "Preserved";
                        break;

                    case 1:
                        text = "Retained";
                        break;

                    case 2:
                        text = "Partially Retained";
                        break;

                    case 3:
                        text = "Modified";
                        break;

                    case 4:
                        text = "Maximally Modified";
                        break;

                    case 5:
                        text = "Excessively Modified";
                        break;
                }

                TextMeshProUGUI textMeshProUGUI = gameObject_.AddComponent<TextMeshProUGUI>();
                textMeshProUGUI.text = text;
                textMeshProUGUI.fontSize = 24;
                textMeshProUGUI.color = Color.black;
                textMeshProUGUI.alignment = TextAlignmentOptions.Center;

                gameObject_.transform.SetParent(gameObject.transform, false);
                gameObject_.transform.name = i.ToString();
            }

            Canvas.ForceUpdateCanvases();

            RectTransform canvas = transform.root.GetComponent<Canvas>().GetComponent<RectTransform>();
            RectTransform rectTransform = transform.GetComponent<RectTransform>();
            RectTransform rectTransformFull = root.GetComponent<RectTransform>();

            if(rectTransformFull.rect.height > canvas.rect.height + rectTransform.anchoredPosition.y - 20) {
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, canvas.rect.height + rectTransform.anchoredPosition.y - 20);
            }
            else {
                rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransformFull.rect.height);
            }
        }

        private void Update() {

        }

        private void ClickedId(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredId(id);
        }

        private void ClickedBr(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredBr(id);
        }

        private void ClickedVc(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredVc(id);
        }

        private void ClickedVr(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredVr(id);
        }

        private void ClickedVac(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredVac(id);
        }

        private void ClickedVsc(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredVsc(id);
        }

        private void ClickedEvc(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredEvc(id);
        }

        private void ClickedVqc(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetMkrfFilteredVqc(id);
        }

        private void InitializeHighlight(Image image) {
            image.color = Color.clear;
        }

        private void ToggleHightlight(Image image) {
            if(image.color == Color.clear) {
                image.color = Color.white;
            }
            else {
                image.color = Color.clear;
            }
        }
    }
}
