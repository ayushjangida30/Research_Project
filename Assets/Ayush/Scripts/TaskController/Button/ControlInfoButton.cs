using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlInfoButton : MonoBehaviour
{
    public GameObject panel;
    bool active = false;

    public Canvas canvas;

    private RectTransform uiObjectRectTransform;
    private RectTransform parentRectTransform;


    void Start()    {
        // // Calculate the position in percentages
        // float xPos = Screen.width * 0.8f; // 50% of screen width
        // float yPos = Screen.height * 0.8f; // 50% of screen height

        // // Convert the percentages to a pixel position
        // Vector2 position = new Vector2(xPos, yPos);
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, position, canvas.worldCamera, out position);

        // // Set the position of the UI element
        // transform.localPosition = position;

        // uiObjectRectTransform = this.GetComponent<RectTransform>();
        // parentRectTransform = uiObjectRectTransform.parent.GetComponent<RectTransform>();

        // // Set the position of the UI object as a percent value
        // float xPercent = 0.5f; // 50%
        // // float yPercent = 0.5f; // 70%
        // Vector2 anchoredPosition = new Vector2(xPercent * parentRectTransform.rect.width, parentRectTransform.rect.height);
        // uiObjectRectTransform.anchoredPosition = anchoredPosition;
    }

    public void OnControlInfoButtonDown()   {
        if(!active) {
            active = true;
            panel.SetActive(true);
        }
        else{
            active = false;
            panel.SetActive(false);
        }
    }
}
