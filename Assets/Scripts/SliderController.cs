using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SliderController : MonoBehaviour, IPointerUpHandler
{
    public Slider sliderInstance;
    // public Text textInstance;
    private float myVal;
    public void Awake() {
        GlobalProperties.Instance.SliderController = this;
    }
    public void Start()  {
        sliderInstance.minValue = 1000;
        sliderInstance.maxValue = 6000;
        sliderInstance.wholeNumbers = true;
        sliderInstance.value = 0;
        
        // textInstance.text = "Value: " + 0;
        myVal = 0f;
    }
    public void OnValueChanged(float value) {
        GlobalProperties.Instance.Experiment.SetSliderValue(value);
    }

    public void Update()    {
        // textInstance.text = "Value: " + myVal;
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        
    }
}
