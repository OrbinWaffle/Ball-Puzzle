using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnGUI()
    {

        if (GUILayout.Button("Start"))
        {
            GameManager.main.StartAttempt();
        }
        if (GUILayout.Button("Stop"))
        {
            GameManager.main.StopAttempt();
        }
    }
}
