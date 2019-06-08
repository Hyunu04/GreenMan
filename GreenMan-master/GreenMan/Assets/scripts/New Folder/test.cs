using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Awake()
    {
        List<Dictionary<string, object>> data = CSVReader.Read("qwerty");

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log(data[i]["ID"] + " " +
                      data[i]["이름"] + 
                " " + data[i]["대사"]);
        }
    }
    private void Start()
    {
        print("asdf");
    }
}
