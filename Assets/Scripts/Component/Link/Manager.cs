using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JL.Component.Link {
    public class Manager : MonoBehaviour {
        [SerializeField, HideInInspector] private Dictionary<int, Controller> controllers;

        private void Start() {
            controllers = new Dictionary<int, Controller>();
        }

        private void Update() {

        }

        //

        public bool ContainsKey(int id) {
            return controllers.ContainsKey(id);
        }

        public bool ContainsKey(int idA, int idB) {
            return controllers.ContainsKey((10000 * idA) + idB);
        }

        public List<int> GetKeys() {
            return new List<int>(controllers.Keys);
        }

        public List<int> GetKeys(int idA, int idB) {
            List<int> keys = new List<int>();

            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                keys.Add(key);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    keys.Add(key);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    keys.Add(key);
                }
            }

            return keys;
        }

        //

        public int GetIdA(int id) {
            return controllers[id].GetIdA();
        }

        public void SetIdA(int id, int idA) {
            controllers[id].SetIdA(idA);
        }

        public void SetIdA(int idA, int idB, int idA__) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetIdA(idA);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetIdA(idA);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetIdA(idA);
                }
            }
        }

        public void SetIdAAll(int idA) {
            foreach(var item in controllers) {
                item.Value.SetIdA(idA);
            }
        }

        public int GetIdB(int id) {
            return controllers[id].GetIdB();
        }

        public void SetIdB(int id, int idB) {
            controllers[id].SetIdB(idB);
        }

        public void SetIdB(int idA, int idB, int idB__) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetIdB(idB);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetIdB(idB);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetIdB(idB);
                }
            }
        }

        public void SetIdBAll(int idB) {
            foreach(var item in controllers) {
                item.Value.SetIdB(idB);
            }
        }

        public Vector3 GetPosition(int id) {
            return controllers[id].GetPosition();
        }

        public void SetPosition(int id, Vector3 position) {
            controllers[id].SetPosition(position);
        }

        public void SetPosition(int idA, int idB, Vector3 position) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetPosition(position);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetPosition(position);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetPosition(position);
                }
            }
        }

        public void SetPositionAll(Vector3 position) {
            foreach(var item in controllers) {
                item.Value.SetPosition(position);
            }
        }

        public Quaternion GetRotation(int id) {
            return controllers[id].GetRotation();
        }

        public void SetRotation(int id, Quaternion rotation) {
            controllers[id].SetRotation(rotation);
        }

        public void SetRotation(int idA, int idB, Quaternion rotation) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetRotation(rotation);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetRotation(rotation);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetRotation(rotation);
                }
            }
        }

        public void SetRotationAll(Quaternion rotation) {
            foreach(var item in controllers) {
                item.Value.SetRotation(rotation);
            }
        }

        public Vector3 GetScale(int id) {
            return controllers[id].GetScale();
        }

        public void SetScale(int id, Vector3 scale) {
            controllers[id].SetScale(scale);
        }

        public void SetScale(int idA, int idB, Vector3 scale) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetScale(scale);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetScale(scale);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetScale(scale);
                }
            }
        }

        public void SetScaleAll(Vector3 scale) {
            foreach(var item in controllers) {
                item.Value.SetScale(scale);
            }
        }

        public Vector3 GetPositionOffset(int id) {
            return controllers[id].GetPositionOffset();
        }

        public void SetPositionOffset(int id, Vector3 positionOffset) {
            controllers[id].SetPositionOffset(positionOffset);
        }

        public void SetPositionOffset(int idA, int idB, Vector3 positionOffset) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetPositionOffset(positionOffset);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetPositionOffset(positionOffset);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetPositionOffset(positionOffset);
                }
            }
        }

        public void SetPositionOffsetAll(Vector3 positionOffset) {
            foreach(var item in controllers) {
                item.Value.SetPositionOffset(positionOffset);
            }
        }

        public Quaternion GetRotationOffset(int id) {
            return controllers[id].GetRotationOffset();
        }

        public void SetRotationOffset(int id, Quaternion rotationOffset) {
            controllers[id].SetRotationOffset(rotationOffset);
        }

        public void SetRotationOffset(int idA, int idB, Quaternion rotationOffset) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetRotationOffset(rotationOffset);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetRotationOffset(rotationOffset);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetRotationOffset(rotationOffset);
                }
            }
        }

        public void SetRotationOffsetAll(Quaternion rotationOffset) {
            foreach(var item in controllers) {
                item.Value.SetRotationOffset(rotationOffset);
            }
        }

        public Vector3 GetScaleOffset(int id) {
            return controllers[id].GetScaleOffset();
        }

        public void SetScaleOffset(int id, Vector3 scaleOffset) {
            controllers[id].SetScaleOffset(scaleOffset);
        }

        public void SetScaleOffset(int idA, int idB, Vector3 scaleOffset) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetScaleOffset(scaleOffset);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetScaleOffset(scaleOffset);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetScaleOffset(scaleOffset);
                }
            }
        }

        public void SetScaleOffsetAll(Vector3 scaleOffset) {
            foreach(var item in controllers) {
                item.Value.SetScaleOffset(scaleOffset);
            }
        }

        public float GetDashLength(int id) {
            return controllers[id].GetDashLength();
        }

        public void SetDashLength(int id, float dashLength) {
            controllers[id].SetDashLength(dashLength);
        }

        public void SetDashLength(int idA, int idB, float dashLength) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetDashLength(dashLength);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetDashLength(dashLength);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetDashLength(dashLength);
                }
            }
        }

        public void SetDashLengthAll(float dashLength) {
            foreach(var item in controllers) {
                item.Value.SetDashLength(dashLength);
            }
        }

        public float GetSpaceLength(int id) {
            return controllers[id].GetSpaceLength();
        }

        public void SetSpaceLength(int id, float spaceLength) {
            controllers[id].SetSpaceLength(spaceLength);
        }

        public void SetSpaceLength(int idA, int idB, float spaceLength) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetSpaceLength(spaceLength);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetSpaceLength(spaceLength);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetSpaceLength(spaceLength);
                }
            }
        }

        public void SetSpaceLengthAll(float spaceLength) {
            foreach(var item in controllers) {
                item.Value.SetSpaceLength(spaceLength);
            }
        }

        public Color GetColor(int id) {
            return controllers[id].GetColor();
        }

        public void SetColor(int id, Color color) {
            controllers[id].SetColor(color);
        }

        public void SetColor(int idA, int idB, Color color) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetColor(color);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetColor(color);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetColor(color);
                }
            }
        }

        public void SetColorAll(Color color) {
            foreach(var item in controllers) {
                item.Value.SetColor(color);
            }
        }

        public float GetAlpha(int id) {
            return controllers[id].GetAlpha();
        }

        public void SetAlpha(int id, float alpha) {
            controllers[id].SetAlpha(alpha);
        }

        public void SetAlpha(int idA, int idB, float alpha) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetAlpha(alpha);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetAlpha(alpha);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetAlpha(alpha);
                }
            }
        }

        public void SetAlphaAll(float alpha) {
            foreach(var item in controllers) {
                item.Value.SetAlpha(alpha);
            }
        }

        public Color GetOutlineColor(int id) {
            return controllers[id].GetOutlineColor();
        }

        public void SetOutlineColor(int id, Color outlineColor) {
            controllers[id].SetOutlineColor(outlineColor);
        }

        public void SetOutlineColor(int idA, int idB, Color outlineColor) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetOutlineColor(outlineColor);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetOutlineColor(outlineColor);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetOutlineColor(outlineColor);
                }
            }
        }

        public void SetOutlineColorAll(Color outlineColor) {
            foreach(var item in controllers) {
                item.Value.SetOutlineColor(outlineColor);
            }
        }

        public float GetOutlineWidth(int id) {
            return controllers[id].GetOutlineWidth();
        }

        public void SetOutlineWidth(int id, float outlineWidth) {
            controllers[id].SetOutlineWidth(outlineWidth);
        }

        public void SetOutlineWidth(int idA, int idB, float outlineWidth) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetOutlineWidth(outlineWidth);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetOutlineWidth(outlineWidth);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetOutlineWidth(outlineWidth);
                }
            }
        }

        public void SetOutlineWidthAll(float outlineWidth) {
            foreach(var item in controllers) {
                item.Value.SetOutlineWidth(outlineWidth);
            }
        }

        public Color GetOutlineColorAlternative(int id) {
            return controllers[id].GetOutlineColorAlternative();
        }

        public void SetOutlineColorAlternative(int id, Color outlineColorAlternative) {
            controllers[id].SetOutlineColorAlternative(outlineColorAlternative);
        }

        public void SetOutlineColorAlternative(int idA, int idB, Color outlineColorAlternative) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetOutlineColorAlternative(outlineColorAlternative);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetOutlineColorAlternative(outlineColorAlternative);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetOutlineColorAlternative(outlineColorAlternative);
                }
            }
        }

        public void SetOutlineColorAlternativeAll(Color outlineColorAlternative) {
            foreach(var item in controllers) {
                item.Value.SetOutlineColorAlternative(outlineColorAlternative);
            }
        }

        public float GetOutlineWidthAlternative(int id) {
            return controllers[id].GetOutlineWidthAlternative();
        }

        public void SetOutlineWidthAlternative(int id, float outlineWidthAlternative) {
            controllers[id].SetOutlineWidthAlternative(outlineWidthAlternative);
        }

        public void SetOutlineWidthAlternative(int idA, int idB, float outlineWidthAlternative) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetOutlineWidthAlternative(outlineWidthAlternative);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetOutlineWidthAlternative(outlineWidthAlternative);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetOutlineWidthAlternative(outlineWidthAlternative);
                }
            }
        }

        public void SetOutlineWidthAlternativeAll(float outlineWidthAlternative) {
            foreach(var item in controllers) {
                item.Value.SetOutlineWidthAlternative(outlineWidthAlternative);
            }
        }

        //

        public void OnShortLeftClick(int id) {
            controllers[id].OnShortLeftClick();
        }

        public void OnShortLeftClick(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnShortLeftClick();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnShortLeftClick();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnShortLeftClick();
                }
            }
        }

        public void OnShortLeftClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortLeftClick();
            }
        }

        public void OnLongLeftClick(int id) {
            controllers[id].OnLongLeftClick();
        }

        public void OnLongLeftClick(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnLongLeftClick();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnLongLeftClick();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnLongLeftClick();
                }
            }
        }

        public void OnLongLeftClickAll() {
            foreach(var item in controllers) {
                item.Value.OnLongLeftClick();
            }
        }

        public void OnShortRightClick(int id) {
            controllers[id].OnShortRightClick();
        }

        public void OnShortRightClick(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnShortRightClick();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnShortRightClick();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnShortRightClick();
                }
            }
        }

        public void OnShortRightClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortRightClick();
            }
        }

        public void OnLongRightClick(int id) {
            controllers[id].OnLongRightClick();
        }

        public void OnLongRightClick(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnLongRightClick();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnLongRightClick();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnLongRightClick();
                }
            }
        }

        public void OnLongRightClickAll() {
            foreach(var item in controllers) {
                item.Value.OnLongRightClick();
            }
        }

        public void OnShortMiddleClick(int id) {
            controllers[id].OnShortMiddleClick();
        }

        public void OnShortMiddleClick(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnShortMiddleClick();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnShortMiddleClick();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnShortMiddleClick();
                }
            }
        }

        public void OnShortMiddleClickAll() {
            foreach(var item in controllers) {
                item.Value.OnShortMiddleClick();
            }
        }

        public void OnLongMiddleClick(int id) {
            controllers[id].OnLongMiddleClick();
        }

        public void OnLongMiddleClick(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnLongMiddleClick();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnLongMiddleClick();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnLongMiddleClick();
                }
            }
        }

        public void OnLongMiddleClickAll() {
            foreach(var item in controllers) {
                item.Value.OnLongMiddleClick();
            }
        }

        public void OnShortMouseEnter(int id) {
            controllers[id].OnShortMouseEnter();
        }

        public void OnShortMouseEnter(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnShortMouseEnter();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnShortMouseEnter();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;

                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnShortMouseEnter();
                }
            }
        }

        public void OnShortMouseEnterAll() {
            foreach(var item in controllers) {
                item.Value.OnShortMouseEnter();
            }
        }

        public void OnShortMouseExit(int id) {
            controllers[id].OnShortMouseExit();
        }

        public void OnShortMouseExit(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnShortMouseExit();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnShortMouseExit();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnShortMouseExit();
                }
            }
        }

        public void OnShortMouseExitAll() {
            foreach(var item in controllers) {
                item.Value.OnShortMouseExit();
            }
        }

        public void OnLongMouseEnter(int id) {
            controllers[id].OnLongMouseEnter();
        }

        public void OnLongMouseEnter(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnLongMouseEnter();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnLongMouseEnter();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnLongMouseEnter();
                }
            }
        }

        public void OnLongMouseEnterAll() {
            foreach(var item in controllers) {
                item.Value.OnLongMouseEnter();
            }
        }

        public void OnLongMouseExit(int id) {
            controllers[id].OnLongMouseExit();
        }

        public void OnLongMouseExit(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnLongMouseExit();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnLongMouseExit();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnLongMouseExit();
                }
            }
        }

        public void OnLongMouseExitAll() {
            foreach(var item in controllers) {
                item.Value.OnLongMouseExit();
            }
        }

        public void OnUpScroll(int id) {
            controllers[id].OnUpScroll();
        }

        public void OnUpScroll(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnUpScroll();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnUpScroll();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnUpScroll();
                }
            }
        }

        public void OnUpScrollAll() {
            foreach(var item in controllers) {
                item.Value.OnUpScroll();
            }
        }

        public void OnDownScroll(int id) {
            controllers[id].OnDownScroll();
        }

        public void OnDownScroll(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].OnDownScroll();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].OnDownScroll();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].OnDownScroll();
                }
            }
        }

        public void OnDownScrollAll() {
            foreach(var item in controllers) {
                item.Value.OnDownScroll();
            }
        }

        //

        public bool GetEnabled(int id) {
            return controllers[id].GetEnabled();
        }

        public void SetEnabled(int id, bool enabled) {
            controllers[id].SetEnabled(enabled);
        }

        public void SetEnabled(int idA, int idB, bool enabled) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetEnabled(enabled);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetEnabled(enabled);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetEnabled(enabled);
                }
            }
        }

        public void SetEnabledAll(bool enabled) {
            foreach(var item in controllers) {
                item.Value.SetEnabled(enabled);
            }
        }

        public int GetMode(int id) {
            return controllers[id].GetMode();
        }

        public void SetMode(int id, int mode) {
            controllers[id].SetMode(mode);
        }

        public void SetMode(int idA, int idB, int mode) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].SetMode(mode);
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].SetMode(mode);
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].SetMode(mode);
                }
            }
        }

        public void SetModeAll(int mode) {
            foreach(var item in controllers) {
                item.Value.SetMode(mode);
            }
        }

        public void ResetMode(int id) {
            controllers[id].ResetMode();
        }

        public void ResetMode(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].ResetMode();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].ResetMode();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].ResetMode();
                }
            }
        }

        public void ResetModeAll() {
            foreach(var item in controllers) {
                item.Value.ResetMode();
            }
        }

        public void Highlight(int id) {
            controllers[id].Highlight();
        }

        public void Highlight(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].Highlight();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].Highlight();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].Highlight();
                }
            }
        }

        public void HighlightAll() {
            foreach(var item in controllers) {
                item.Value.Highlight();
            }
        }

        public void Unhighlight(int id) {
            controllers[id].Unhighlight();
        }

        public void Unhighlight(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                controllers[key].Unhighlight();
            }
            else if(idA >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    controllers[key].Unhighlight();
                }
            }
            else if(idB >= 0) {
                foreach(var item in controllers) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    controllers[key].Unhighlight();
                }
            }
        }

        public void UnhighlightAll() {
            foreach(var item in controllers) {
                item.Value.Unhighlight();
            }
        }

        //

        public void Add(int id) {
            int idA = id / 10000;
            int idB = id % 10000;

            float visibility = GlobalProperties.Instance.Visibility[id];

            if(visibility <= 0.1f) {
                return;
            }

            float dashLength = 0f;
            float spaceLength = 0f;

            Color color = Color.clear;
            float alpha = 0f;

            if(visibility <= 0.5f) {
                dashLength = GlobalProperties.Instance.LinkDashLength[0];
                spaceLength = GlobalProperties.Instance.LinkSpaceLength[0];

                color = GlobalProperties.Instance.LinkColor[0];
                alpha = GlobalProperties.Instance.LinkAlpha[0];
            }
            else if(visibility <= 0.8f) {
                dashLength = GlobalProperties.Instance.LinkDashLength[1];
                spaceLength = GlobalProperties.Instance.LinkSpaceLength[1];

                color = GlobalProperties.Instance.LinkColor[1];
                alpha = GlobalProperties.Instance.LinkAlpha[1];
            }
            else if(visibility <= 1f) {
                dashLength = GlobalProperties.Instance.LinkDashLength[2];
                spaceLength = GlobalProperties.Instance.LinkSpaceLength[2];

                color = GlobalProperties.Instance.LinkColor[2];
                alpha = GlobalProperties.Instance.LinkAlpha[2];
            }

            Controller controller = Instantiate();

            controller.SetIdA(idA);
            controller.SetIdB(idB);

            controller.SetPosition(Vector3.zero);
            controller.SetRotation(Quaternion.identity);
            controller.SetScale(Vector3.one);

            controller.SetPositionOffset(GlobalProperties.Instance.LinkPositionOffset);
            controller.SetRotationOffset(GlobalProperties.Instance.LinkRotationOffset);
            controller.SetScaleOffset(GlobalProperties.Instance.LinkScaleOffset);

            controller.SetDashLength(dashLength);
            controller.SetSpaceLength(spaceLength);

            controller.SetColor(color);
            controller.SetAlpha(alpha);

            controller.SetOutlineColor(GlobalProperties.Instance.LinkOutlineColor);
            controller.SetOutlineWidth(GlobalProperties.Instance.LinkOutlineWidth);

            controller.SetOutlineColorAlternative(GlobalProperties.Instance.LinkOutlineColorAlternative);
            controller.SetOutlineWidthAlternative(GlobalProperties.Instance.LinkOutlineWidthAlternative);

            controllers.Add(id, controller);
        }

        public void Add(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                float visibility = GlobalProperties.Instance.Visibility[key];

                if(visibility <= 0.1f) {
                    return;
                }

                float dashLength = 0f;
                float spaceLength = 0f;

                Color color = Color.clear;
                float alpha = 0f;

                if(visibility <= 0.5f) {
                    dashLength = GlobalProperties.Instance.LinkDashLength[0];
                    spaceLength = GlobalProperties.Instance.LinkSpaceLength[0];

                    color = GlobalProperties.Instance.LinkColor[0];
                    alpha = GlobalProperties.Instance.LinkAlpha[0];
                }
                else if(visibility <= 0.8f) {
                    dashLength = GlobalProperties.Instance.LinkDashLength[1];
                    spaceLength = GlobalProperties.Instance.LinkSpaceLength[1];

                    color = GlobalProperties.Instance.LinkColor[1];
                    alpha = GlobalProperties.Instance.LinkAlpha[1];
                }
                else if(visibility <= 1f) {
                    dashLength = GlobalProperties.Instance.LinkDashLength[2];
                    spaceLength = GlobalProperties.Instance.LinkSpaceLength[2];

                    color = GlobalProperties.Instance.LinkColor[2];
                    alpha = GlobalProperties.Instance.LinkAlpha[2];
                }

                Controller controller = Instantiate();

                controller.SetIdA(idA);
                controller.SetIdB(idB);

                controller.SetPosition(Vector3.zero);
                controller.SetRotation(Quaternion.identity);
                controller.SetScale(Vector3.one);

                controller.SetPositionOffset(GlobalProperties.Instance.LinkPositionOffset);
                controller.SetRotationOffset(GlobalProperties.Instance.LinkRotationOffset);
                controller.SetScaleOffset(GlobalProperties.Instance.LinkScaleOffset);

                controller.SetDashLength(dashLength);
                controller.SetSpaceLength(spaceLength);

                controller.SetColor(color);
                controller.SetAlpha(alpha);

                controller.SetOutlineColor(GlobalProperties.Instance.LinkOutlineColor);
                controller.SetOutlineWidth(GlobalProperties.Instance.LinkOutlineWidth);

                controller.SetOutlineColorAlternative(GlobalProperties.Instance.LinkOutlineColorAlternative);
                controller.SetOutlineWidthAlternative(GlobalProperties.Instance.LinkOutlineWidthAlternative);

                controllers.Add(key, controller);

                if((GlobalProperties.Instance.FilterController.GetKopFilter()[idA] == false) || (GlobalProperties.Instance.FilterController.GetMkrfFilter()[idB] == false)) {
                    controller.SetEnabled(false);
                }
            }
            else if(idA >= 0) {
                bool isEmpty = true;

                foreach(var item in GlobalProperties.Instance.Visibility) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    float visibility = item.Value;

                    if(visibility <= 0.1f) {
                        continue;
                    }

                    isEmpty = false;

                    float dashLength = 0f;
                    float spaceLength = 0f;

                    Color color = Color.clear;
                    float alpha = 0f;

                    if(visibility <= 0.5f) {
                        dashLength = GlobalProperties.Instance.LinkDashLength[0];
                        spaceLength = GlobalProperties.Instance.LinkSpaceLength[0];

                        color = GlobalProperties.Instance.LinkColor[0];
                        alpha = GlobalProperties.Instance.LinkAlpha[0];
                    }
                    else if(visibility <= 0.8f) {
                        dashLength = GlobalProperties.Instance.LinkDashLength[1];
                        spaceLength = GlobalProperties.Instance.LinkSpaceLength[1];

                        color = GlobalProperties.Instance.LinkColor[1];
                        alpha = GlobalProperties.Instance.LinkAlpha[1];
                    }
                    else if(visibility <= 1f) {
                        dashLength = GlobalProperties.Instance.LinkDashLength[2];
                        spaceLength = GlobalProperties.Instance.LinkSpaceLength[2];

                        color = GlobalProperties.Instance.LinkColor[2];
                        alpha = GlobalProperties.Instance.LinkAlpha[2];
                    }

                    Controller controller = Instantiate();

                    controller.SetIdA(idA_);
                    controller.SetIdB(idB_);

                    controller.SetPosition(Vector3.zero);
                    controller.SetRotation(Quaternion.identity);
                    controller.SetScale(Vector3.one);

                    controller.SetPositionOffset(GlobalProperties.Instance.LinkPositionOffset);
                    controller.SetRotationOffset(GlobalProperties.Instance.LinkRotationOffset);
                    controller.SetScaleOffset(GlobalProperties.Instance.LinkScaleOffset);

                    controller.SetDashLength(dashLength);
                    controller.SetSpaceLength(spaceLength);

                    controller.SetColor(color);
                    controller.SetAlpha(alpha);

                    controller.SetOutlineColor(GlobalProperties.Instance.LinkOutlineColor);
                    controller.SetOutlineWidth(GlobalProperties.Instance.LinkOutlineWidth);

                    controller.SetOutlineColorAlternative(GlobalProperties.Instance.LinkOutlineColorAlternative);
                    controller.SetOutlineWidthAlternative(GlobalProperties.Instance.LinkOutlineWidthAlternative);

                    controllers.Add(key, controller);

                    if((GlobalProperties.Instance.FilterController.GetKopFilter()[idA_] == false) || (GlobalProperties.Instance.FilterController.GetMkrfFilter()[idB_] == false)) {
                        controller.SetEnabled(false);
                    }
                }

                if(isEmpty) {
                    Controller controller = Instantiate();

                    controller.SetIdA(idA);
                    controller.SetIdB(0);

                    controller.SetPosition(Vector3.zero);
                    controller.SetRotation(Quaternion.identity);
                    controller.SetScale(Vector3.one);

                    controller.SetPositionOffset(GlobalProperties.Instance.LinkPositionOffset);
                    controller.SetRotationOffset(GlobalProperties.Instance.LinkRotationOffset);
                    controller.SetScaleOffset(GlobalProperties.Instance.LinkScaleOffset);

                    controller.SetDashLength(0f);
                    controller.SetSpaceLength(0f);

                    controller.SetColor(Color.red);
                    controller.SetAlpha(1f);

                    controller.SetOutlineColor(GlobalProperties.Instance.LinkOutlineColor);
                    controller.SetOutlineWidth(GlobalProperties.Instance.LinkOutlineWidth);

                    controller.SetOutlineColorAlternative(GlobalProperties.Instance.LinkOutlineColorAlternative);
                    controller.SetOutlineWidthAlternative(GlobalProperties.Instance.LinkOutlineWidthAlternative);

                    controllers.Add((10000 * idA), controller);

                    if(GlobalProperties.Instance.FilterController.GetKopFilter()[idA] == false) {
                        controller.SetEnabled(false);
                    }
                }
            }
            else if(idB >= 0) {
                bool isEmpty = true;

                foreach(var item in GlobalProperties.Instance.Visibility) {
                    int key = item.Key;
                    
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    float visibility = item.Value;

                    if(visibility <= 0.1f) {
                        continue;
                    }

                    isEmpty = false;

                    float dashLength = 0f;
                    float spaceLength = 0f;

                    Color color = Color.clear;
                    float alpha = 0f;

                    if(visibility <= 0.5f) {
                        dashLength = GlobalProperties.Instance.LinkDashLength[0];
                        spaceLength = GlobalProperties.Instance.LinkSpaceLength[0];

                        color = GlobalProperties.Instance.LinkColor[0];
                        alpha = GlobalProperties.Instance.LinkAlpha[0];
                    }
                    else if(visibility <= 0.8f) {
                        dashLength = GlobalProperties.Instance.LinkDashLength[1];
                        spaceLength = GlobalProperties.Instance.LinkSpaceLength[1];

                        color = GlobalProperties.Instance.LinkColor[1];
                        alpha = GlobalProperties.Instance.LinkAlpha[1];
                    }
                    else if(visibility <= 1f) {
                        dashLength = GlobalProperties.Instance.LinkDashLength[2];
                        spaceLength = GlobalProperties.Instance.LinkSpaceLength[2];

                        color = GlobalProperties.Instance.LinkColor[2];
                        alpha = GlobalProperties.Instance.LinkAlpha[2];
                    }

                    Controller controller = Instantiate();

                    controller.SetIdA(idA_);
                    controller.SetIdB(idB_);

                    controller.SetPosition(Vector3.zero);
                    controller.SetRotation(Quaternion.identity);
                    controller.SetScale(Vector3.one);

                    controller.SetPositionOffset(GlobalProperties.Instance.LinkPositionOffset);
                    controller.SetRotationOffset(GlobalProperties.Instance.LinkRotationOffset);
                    controller.SetScaleOffset(GlobalProperties.Instance.LinkScaleOffset);

                    controller.SetDashLength(dashLength);
                    controller.SetSpaceLength(spaceLength);

                    controller.SetColor(color);
                    controller.SetAlpha(alpha);

                    controller.SetOutlineColor(GlobalProperties.Instance.LinkOutlineColor);
                    controller.SetOutlineWidth(GlobalProperties.Instance.LinkOutlineWidth);

                    controller.SetOutlineColorAlternative(GlobalProperties.Instance.LinkOutlineColorAlternative);
                    controller.SetOutlineWidthAlternative(GlobalProperties.Instance.LinkOutlineWidthAlternative);

                    controllers.Add(key, controller);

                    if((GlobalProperties.Instance.FilterController.GetKopFilter()[idA_] == false) || (GlobalProperties.Instance.FilterController.GetMkrfFilter()[idB_] == false)) {
                        controller.SetEnabled(false);
                    }
                }

                if(isEmpty) {
                    Controller controller = Instantiate();

                    controller.SetIdA(0);
                    controller.SetIdB(idB);

                    controller.SetPosition(Vector3.zero);
                    controller.SetRotation(Quaternion.identity);
                    controller.SetScale(Vector3.one);

                    controller.SetPositionOffset(GlobalProperties.Instance.LinkPositionOffset);
                    controller.SetRotationOffset(GlobalProperties.Instance.LinkRotationOffset);
                    controller.SetScaleOffset(GlobalProperties.Instance.LinkScaleOffset);

                    controller.SetDashLength(0f);
                    controller.SetSpaceLength(0f);

                    controller.SetColor(Color.red);
                    controller.SetAlpha(1f);

                    controller.SetOutlineColor(GlobalProperties.Instance.LinkOutlineColor);
                    controller.SetOutlineWidth(GlobalProperties.Instance.LinkOutlineWidth);

                    controller.SetOutlineColorAlternative(GlobalProperties.Instance.LinkOutlineColorAlternative);
                    controller.SetOutlineWidthAlternative(GlobalProperties.Instance.LinkOutlineWidthAlternative);

                    controllers.Add(idB, controller);

                    if(GlobalProperties.Instance.FilterController.GetMkrfFilter()[idB] == false) {
                        controller.SetEnabled(false);
                    }
                }
            }
        }

        public void Remove(int id) {
            controllers[id].Destroy();

            controllers.Remove(id);
        }

        public void Remove(int idA, int idB) {
            if(idA >= 0 && idB >= 0) {
                int key = (10000 * idA) + idB;

                Remove(key);
            }
            else if(idA >= 0) {
                List<int> keys = new List<int>(controllers.Keys);

                foreach(int key in keys) {
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idA_ != idA) {
                        continue;
                    }

                    Remove(key);
                }
            }
            else if(idB >= 0) {
                List<int> keys = new List<int>(controllers.Keys);

                foreach(int key in keys) {
                    int idA_ = key / 10000;
                    int idB_ = key % 10000;

                    if(idB_ != idB) {
                        continue;
                    }

                    Remove(key);
                }
            }
        }

        //

        private Controller Instantiate() {
            GameObject prefab = Resources.Load("Prefabs/Component/Link", typeof(GameObject)) as GameObject;

            GameObject gameObject_ = Instantiate(prefab);
            Transform transform_ = gameObject_.transform;

            transform_.parent = transform;

            Controller controller = gameObject_.AddComponent<Controller>();

            return controller;
        }
    }
}
