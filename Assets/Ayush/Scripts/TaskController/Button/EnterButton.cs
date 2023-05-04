using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterButton : MonoBehaviour
{
    public MainController mainController;
    public StartButtonController startButtonController;
    public GameObject panel;
    private bool isClicked = false;

    public void OnEnterButtonClicked()  {
        mainController.GetResult();
        startButtonController.SetStartButtonActive();
        OpenPanel();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool GetIsClickedEnterButton()   {
        this.gameObject.SetActive(false);
        return isClicked;
    }

    public void SetIsClickedEnterButton()   {
        isClicked = false;
        this.gameObject.SetActive(true);
    }

    private void OpenPanel()    {
        startButtonController.SetLogFalse();
        panel.gameObject.SetActive(true);
        // panel.GetComponentInChildren<Text>().text = "Wait for further instructions";
    }
}
