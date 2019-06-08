using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenAnker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Screen.SetResolution(1280, 720, true);
    }
}
