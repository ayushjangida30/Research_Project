using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

namespace JL.UI.Menu.Filters.Main.KOP {
    public class Controller : MonoBehaviour {
        private Transform root;

        private Transform ids;
        private Transform importances;

        private void Start() {
            root = transform.Find("Viewport/Content");

            ids = root.Find("Id/Ids/Viewport/Content");
            importances = root.Find("Importance/Importances/Viewport/Content");

            for(int i = 0; i < GlobalProperties.Instance.KOPPositions.Count; i++) {
                GameObject gameObject = new GameObject();

                gameObject.AddComponent<RectTransform>();
                gameObject.AddComponent<CanvasRenderer>();

                Image image = gameObject.AddComponent<Image>();
                InitializeHighlight(image);

                if(GlobalProperties.Instance.FilterController.KopFilteredIdContainsKey(i + 1)) {
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

                if(GlobalProperties.Instance.FilterController.KopFilteredImportanceContainsKey(i + 1)) {
                    ToggleHightlight(image);
                }

                Button button = gameObject.AddComponent<Button>();
                button.onClick.AddListener(delegate {
                    ClickedImportance(gameObject);
                });

                gameObject.AddComponent<VerticalLayoutGroup>();

                gameObject.transform.SetParent(importances, false);
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

            GlobalProperties.Instance.FilterController.SetKopFilteredId(id);
        }

        private void ClickedImportance(GameObject gameObject) {
            int id = int.Parse(gameObject.name);

            ToggleHightlight(gameObject.GetComponent<Image>());

            GlobalProperties.Instance.FilterController.SetKopFilteredImportance(id);
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
