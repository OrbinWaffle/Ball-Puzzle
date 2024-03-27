using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public static EventBus main;
    public UnityEvent OnWin;
    public UnityEvent OnStartAttempt;
    public UnityEvent OnStopAttempt;
    public void Initialize()
    {
        if (main == null)
        {
            main = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
