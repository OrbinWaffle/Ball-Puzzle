using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovableObject : MonoBehaviour
{
    XRSimpleInteractable interact;
    XRGrabInteractable _grabInteractable;
    private void Start()
    {
        _grabInteractable = GetComponent<XRGrabInteractable>();
        EventBus.instance.OnStartAttempt.AddListener(AttemptStarted);
        EventBus.instance.OnStopAttempt.AddListener(AttemptStopped);
        interact.selectEntered.Invoke(null);
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
