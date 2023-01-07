using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    private bool click = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScaleButtonClicked()  {
        if(click == false)   {
            click = true;
            this.GetComponentInChildren<Text>().text = "Scale On";
        }
        else{
            click = false;
            this.GetComponentInChildren<Text>().text = "Scale Off";
        }
    }

    public bool GetClick()   {
        return click;
    }
}
