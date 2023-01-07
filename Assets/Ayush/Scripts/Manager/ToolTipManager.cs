using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolTipManager : MonoBehaviour
{
    public Text textToolTip;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetToolTip(string message, int message_2)  {
        print("ToolTip visible");
        gameObject.SetActive(true);
        textToolTip.text = message + "/" + message_2;
    }

    public void HideToolTip()   {
        print("Tooltip hidden");
        gameObject.SetActive(false);
        textToolTip.text = string.Empty;
    }
}
