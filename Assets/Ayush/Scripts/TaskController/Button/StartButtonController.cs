using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButtonController : MonoBehaviour
{
    public MainController mainController;
    public Button nextTask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnStartButtonClicked()  {
        if(this.name == "Click to start")   {
            mainController.StartTask_1();
            this.gameObject.SetActive(false);
            nextTask.gameObject.SetActive(true);
        }
        else if(this.name == "Task 2")   {
            mainController.StartTask_2();
            this.gameObject.SetActive(false);
            nextTask.gameObject.SetActive(true);
        }
        else if(this.name == "Task 3")   {
            mainController.StartTask_3();
            this.gameObject.SetActive(false);
            nextTask.gameObject.SetActive(true);
        }else if(this.name == "Task 4")   {
            mainController.StartTask_4();
            this.gameObject.SetActive(false);
            nextTask.gameObject.SetActive(true);
        }else if(this.name == "Task 5") {
            mainController.StartTask_5();
            this.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
