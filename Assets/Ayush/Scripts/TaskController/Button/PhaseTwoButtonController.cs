using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseTwoButtonController : MonoBehaviour
{
    public StartButtonController startButtonController;
    public MainController mainController;
    public PhaseOneButtonController phaseOneButtonController;
    public Experiment exp;

    // Start is called before the first frame update
    public void OnPhaseTwoControllerButtonClicked()
    {   exp.StartRecording();

        startButtonController.quotient = 12;
        startButtonController.total = 108;
        startButtonController.spaceClicked = true;
        mainController.endTask = true;
        startButtonController.CheckCondition();
        this.gameObject.SetActive(false);
        phaseOneButtonController.gameObject.SetActive(false);
    }
}
