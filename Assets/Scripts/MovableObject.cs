using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovableObject : MonoBehaviour
{
    //XRSimpleInteractable interact;
    XRBaseInteractable _grabInteractable;
    private void Start()
    {
        _grabInteractable = GetComponent<XRBaseInteractable>();
        EventBus.main.OnStartAttempt.AddListener(AttemptStarted);
        EventBus.main.OnStopAttempt.AddListener(AttemptStopped);
        //interact = GetComponent<XRSimpleInteractable>();
        //interact.selectEntered.Invoke(null);
    }
    void AttemptStarted()
    {
        _grabInteractable.enabled = false;
    }
    void AttemptStopped()
    {
        _grabInteractable.enabled = true;
    }
}
