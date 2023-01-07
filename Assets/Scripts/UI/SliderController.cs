using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JL.UI {
    public class SliderController : MonoBehaviour
    {
        public Slider sliderInstance;
        // public Text textInstance;
        private float myVal;

        public void Start()  {
            sliderInstance.minValue = 0;
            sliderInstance.maxValue = 5000;
            sliderInstance.wholeNumbers = true;
            sliderInstance.value = 0;
            
            // textInstance.text = "Value: " + 0;
            myVal = 0f;
        }
        public void OnValueChanged(float value) {
            myVal = value;
            // Debug.Log("New Value: " + value);
        }

        private float GetValue()    {
            return myVal;
        }

        public void Update()    {
            // textInstance.text = "Value: " + myVal;
        }
    }
}