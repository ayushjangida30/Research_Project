using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerController : MonoBehaviour
{
    public vsc_geojson_reader reader;
    private List<int> list_task1;

    // Start is called before the first frame update
    void Start()
    {
        list_task1 = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<int> Task1_Answer(List<int> barVisible) {
        for(int i = 0; i < barVisible.Count; i++)   {
            int id = barVisible[i];
            if(reader.GetVSC(id) == 3)  list_task1.Add(id);  
        }

        return list_task1;
    }
}
