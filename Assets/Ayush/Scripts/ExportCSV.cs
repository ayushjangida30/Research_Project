using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
public class ExportCSV : MonoBehaviour
{
   
    public StringBuilder sb = new System.Text.StringBuilder();

    List<int> user_answer;
    List<int> answer;

    public MainController mainController;
    private string contentData;

    void Start()
    {
        user_answer = new List<int>();
        answer = new List<int>();
    }

    public void addHeaders()
    {
        sb.AppendLine("HealthyCount;InfectedCount;RecoveredCount;Time");
    }

    public void record()
    {
        decimal time = Decimal.Round((decimal)Time.time, 2);
        // sb.AppendLine(pandemicArea.healthyCounter.ToString() + ';' + pandemicArea.infectedCounter.ToString() + ";" + pandemicArea.recoveredCounter.ToString() + ";" + time.ToString());
        SaveToFile(sb.ToString());
    }
    public void SaveToFile(string content)
    {
        // Use the CSV generation from before
        //var content = ToCSV();

        // The target file path e.g.
        var folder = Application.streamingAssetsPath;

        if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);


        var filePath = Path.Combine(folder, "export.csv");

        using (var writer = new StreamWriter(filePath, false))
        {
            writer.Write(content);
        }
    }
}
