using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

namespace JL.UI.Tooltip {
    public class Controller : MonoBehaviour {
        private RectTransform rectTransform;
        private LayoutElement layoutElement;

        private TextMeshProUGUI headerText;
        private TextMeshProUGUI contentText;

        private void Start() {
            rectTransform = transform.GetComponent<RectTransform>();
            layoutElement = transform.GetComponent<LayoutElement>();

            headerText = transform.Find("Header").GetComponent<TextMeshProUGUI>();
            contentText = transform.Find("Content").GetComponent<TextMeshProUGUI>();

            SetEnabled(false);
        }

        private void Update() {
            Vector3 mousePosition = Input.mousePosition;

            transform.position = mousePosition;

            Vector2 pivot = Vector2.zero;

            if(mousePosition.x < (Screen.width / 2)) {
                pivot.x = -0.1f;
            }
            else {
                pivot.x = 1;
            }

            if(mousePosition.y < (Screen.height / 2)) {
                pivot.y = 0;
            }
            else {
                pivot.y = 1;
            }

            rectTransform.pivot = pivot;
        }

        //

        public void SetHeader(string s) {
            headerText.text = s;

            WrapCharacter();
        }

        public void SetContent(string s) {
            contentText.text = s;

            WrapCharacter();
        }

        //

        public bool GetEnabled() {
            return gameObject.activeSelf;
        }

        public void SetEnabled(bool enabled) {
            gameObject.SetActive(enabled);
        }

        //

        private void WrapCharacter() {
            int maxLength = headerText.text.Length;

            string[] content = contentText.text.Split(new [] {'\r', '\n'});

            foreach(string s in content) {
                if(s.Length > maxLength) {
                    maxLength = s.Length;
                }
            }

            layoutElement.enabled = (maxLength > GlobalProperties.Instance.TooltipCharacterWrapLimit);
        }
    }
}
