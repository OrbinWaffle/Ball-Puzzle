using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    bool isPlaying = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartAttempt()
    {
        if(isPlaying) { return; }
        EventBus.instance.OnStartAttempt.Invoke();
        isPlaying = true;
    }
    public void StopAttempt()
    {
        if(!isPlaying ) { return; }
        EventBus.instance.OnStopAttempt.Invoke();
        isPlaying = false;
    }
}
