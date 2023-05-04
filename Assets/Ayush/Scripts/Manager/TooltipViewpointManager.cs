using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TooltipViewpointManager : MonoBehaviour
{
    public Text textToolTip;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetToolTip(string message)  {
        print("ToolTip visible");
        gameObject.SetActive(true);
        textToolTip.text = message;
    }

    public void SetToolTip(string message, Vector3 mousePosition) {
        gameObject.SetActive(true);
        textToolTip.text = message;
        transform.position = mousePosition;
    }

    public void HideToolTip()   {
        print("Tooltip hidden");
        gameObject.SetActive(false);
        textToolTip.text = string.Empty;
    }
}
