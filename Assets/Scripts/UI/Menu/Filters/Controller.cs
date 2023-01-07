using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
using UnityEngine.UI;

namespace JL.UI.Menu.Filters {
    public class Controller : MonoBehaviour {
        private Transform root;

        private bool isMain = false;

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
        }

        private void Update() {

        }

        public void ToggleMain() {
            if(!isMain) {
                isMain = true;

                GameObject prefab = Resources.Load("Prefabs/UI/Menu/Filters/Main", typeof(GameObject)) as GameObject;

                GameObject gameObject_ = Instantiate(prefab);
                Transform transform_ = gameObject_.transform;

                transform_.SetParent(root, false);

                transform_.name = transform_.name + "1";
            }
            else {
                isMain = false;

                foreach(Transform child in root) {
                    if(!child.name.Contains("1") && !child.name.Contains("2") && !child.name.Contains("3")) {
                        continue;
                    }

                    Object.Destroy(child.gameObject);
                }
            }
        }
    }
}
