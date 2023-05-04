using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEditor.Recorder;
using UnityEditor.Recorder.Input;
using System.IO;
     

public class Experiment : MonoBehaviour
{
    private static SREYELINKLib.EL_EYE eye;
    private SREYELINKLib.EyeLink el;
    private SREYELINKLib.IELData elData;
    SREYELINKLib.EyeLinkUtil elutil;
    private double lastSampleTime = 0.0;

    private RecorderWindow recorderWindow;
    private int i = 1;
    private bool IsRecording = false;

    // Start is called before the first frame update
    void Start()
    {
        eye = SREYELINKLib.EL_EYE.EL_EYE_NONE;
        double st;
        elutil = new SREYELINKLib.EyeLinkUtil();
        el = new SREYELINKLib.EyeLink();

                                              
        el.open("100.1.1.1", 0);
        print("Connect opened successfully");     
        el.openDataFile("trial_10.edf"); 
        el.sendCommand("file_event_filter = LEFT,RIGHT,FIXATION,SACCADE,BLINK,MESSAGE,BUTTON,INPUT");
        el.sendCommand("file_sample_data = LEFT,RIGHT,GAZE,AREA,GAZERES,STATUS,INPUT");
        el.sendCommand("link_event_filter = LEFT,RIGHT,FIXATION,SACCADE,BLINK,BUTTON,INPUT");
        el.sendCommand("link_sample_data = LEFT,RIGHT,GAZE,GAZERES,AREA,STATUS,INPUT");
        el.sendCommand("screen_pixel_coords=0,0," + 1680 + "," + 1050);
        el.sendMessage("TRIALID 1");
        
        el.sendMessage("!V IAREA RECTANGLE 1 89 0 790 350 topleft");

        recorderWindow = GetRecorderWindow();
    }

    public void StartRecording()    {
        el.setOfflineMode();
        elutil.pumpDelay(500);

        el.startRecording(true, true, true, true);
        el.waitForBlockStart(50, true, true);

        eye = (SREYELINKLib.EL_EYE)el.eyeAvailable();
        if (eye == SREYELINKLib.EL_EYE.EL_BINOCULAR)    eye = SREYELINKLib.EL_EYE.EL_LEFT;

        // Start Recording
        if(!recorderWindow.IsRecording())    {
            recorderWindow.StartRecording();
            IsRecording = true;
        }
        // elutil.pumpDelay(500);
    }

    public void End_Recording()  {
        // Stop Recording
        el.stopRecording();
        el.setOfflineMode();
        elutil.pumpDelay(500);
        el.closeDataFile();

        // If el.isConnected <> -1 Then 'Skip file transfer if in dummy mode.
	    el.receiveDataFile("trial_10.edf", Application.dataPath + "/Results/" + "Video_Trial_5.edf");
        if(recorderWindow.IsRecording())    {
            recorderWindow.StopRecording();
            IsRecording = false;
        }

        // Change the file name of Unity Recorder to desired filename

        // Change the string to match Unity Recorder file path and name
        string filePath = Application.dataPath + "/Recordings/Trial_11.mp4";   

        // Change the string to match your file path and name
        string newFilePath = Application.dataPath + "/Recordings/Rec_41.mp4"; 
        File.Move(filePath, newFilePath);
    }

    public void Start_Trial(string str)   {
        el.sendMessage(str);
        
    }

    public void End_Trial(string str)   {
        el.sendMessage(str);
    }

    // Update is called once per frame
    void Update()
    {
        if(IsRecording) {
            el.sendMessage("!V VFRAME " + i++ + " 0 89 " + Application.dataPath + "/Recordings/Rec_41.mp4 resize 1680 1050");
        }
    }


    private RecorderWindow GetRecorderWindow()
        {
            return (RecorderWindow)EditorWindow.GetWindow(typeof(RecorderWindow));
        }
}
