using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class MovableObject : MonoBehaviour
{
    //XRSimpleInteractable interact;
    XRBaseInteractable _grabInteractable;
    Rigidbody _rigidbody;
    Vector3 _orgPos;
    Quaternion _orgRot;
    protected virtual void Start()
    {
        _grabInteractable = GetComponent<XRBaseInteractable>();
        _rigidbody = GetComponent<Rigidbody>();
        EventBus.main.OnStartAttempt.AddListener(AttemptStarted);
        EventBus.main.OnStopAttempt.AddListener(AttemptStopped);
        //interact = GetComponent<XRSimpleInteractable>();
        //interact.selectEntered.Invoke(null);
    }
    protected virtual void AttemptStarted()
    {
        _grabInteractable.enabled = false;
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        _orgPos = transform.position;
        _orgRot = transform.rotation;
    }
    protected virtual void AttemptStopped()
    {
        _grabInteractable.enabled = true;
        _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        transform.position = _orgPos;
        transform.rotation = _orgRot;
    }
    public void OnPickedUp()
    {
        EventBus.main.OnPickup.Invoke(true);
        /*foreach (StickingPoint p in stickingPoints)
        {
            p.isChecking = true;
        }*/
    }
    public void OnDropped()
    {
        EventBus.main.OnPickup.Invoke(false);
        /*foreach (StickingPoint p in stickingPoints)
        {
            p.isChecking = false;
        }*/
    }
}
