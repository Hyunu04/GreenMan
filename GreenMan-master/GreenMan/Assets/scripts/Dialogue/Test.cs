using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour
{

    public int _exp = 0;

    void Start()
    {
        List<Dictionary<string, object>> data = aaa.Read("knightIdle - playerChar");

        for (var i = 0; i < data.Count; i++)
        {
            Debug.Log("index " + (i).ToString() + " : " + data[i]["이름"] + " " + data[i]["대사"]);
        }

        _exp = (int)data[0]["attack"];
        Debug.Log(_exp);
    }
}