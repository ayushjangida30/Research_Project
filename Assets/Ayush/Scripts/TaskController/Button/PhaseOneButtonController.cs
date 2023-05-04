using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseOneButtonController : MonoBehaviour
{
    public StartButtonController startButtonController;
    public MainController mainController;
    public PhaseTwoButtonController phaseTwoButtonController;

    // Start is called before the first frame update
    public void OnPhaseOneControllerButtonClicked()
    {
        startButtonController.quotient = 0;
        startButtonController.total = 0;
        startButtonController.spaceClicked = true;
        mainController.endTask = true;
        startButtonController.CheckCondition();
        this.gameObject.SetActive(false);
        phaseTwoButtonController.gameObject.SetActive(false);
    }
}
