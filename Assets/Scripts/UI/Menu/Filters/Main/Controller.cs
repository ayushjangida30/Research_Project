using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

namespace JL.UI.Menu.Filters.Main {
    public class Controller : MonoBehaviour {
        private Transform root;

        private Image kopImage;
        private Image mkrfImage;

        private bool isKOP = false;
        private bool isMKRF = false;

        private void Start() {
            Transform transform_ = transform;
            while(true) {
                if(transform_.name == "Filters") {
                    root = transform_;

                    break;
                }
                else {
                    transform_ = transform_.parent;
                }
            }

            kopImage = transform.Find("KOP").gameObject.GetComponent<Image>();
            kopImage.color = Color.clear;

            mkrfImage = transform.Find("MKRF").gameObject.GetComponent<Image>();
            mkrfImage.color = Color.clear;
        }

        private void Update() {

        }

        public void ToggleKOP() {
            if(!isKOP) {
                isKOP = true;
                isMKRF = false;

                UnhighlightAll();
                HighlightKop();

                RemoveAll();

                Instantiate("KOP");
            }
            else {
                isKOP = false;
                isMKRF = false;

                UnhighlightAll();

                RemoveAll();
            }
        }

        public void ToggleMKRF() {
            if(!isMKRF) {
                isKOP = false;
                isMKRF = true;

                UnhighlightAll();
                HighlightMkrf();

                RemoveAll();

                Instantiate("MKRF");
            }
            else {
                isKOP = false;
                isMKRF = false;

                UnhighlightAll();

                RemoveAll();
            }
        }

        private void HighlightKop() {
            kopImage.color = Color.white;
        }

        private void HighlightMkrf() {
            mkrfImage.color = Color.white;
        }

        private void UnhighlightAll() {
            kopImage.color = Color.clear;
            mkrfImage.color = Color.clear;
        }

        private void RemoveAll() {
            foreach(Transform child in root) {
                if(!child.name.Contains("2")) {
                    continue;
                }

                Object.Destroy(child.gameObject);
            }
        }

        private void Instantiate(string name) {
            GameObject prefab = Resources.Load("Prefabs/UI/Menu/Filters/" + name, typeof(GameObject)) as GameObject;

            GameObject gameObject_ = Instantiate(prefab);
            Transform transform_ = gameObject_.transform;

            transform_.SetParent(root, false);

            transform_.name = transform_.name + "2";
        }
    }
}
