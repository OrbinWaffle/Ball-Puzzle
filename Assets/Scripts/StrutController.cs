using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StrutController : MovableObject
{
    //List<StickingPoint> attatchedTo;

    StickingPoint[] stickingPoints;
    protected override void Start()
    {
        base.Start();
        stickingPoints = GetComponentsInChildren<StickingPoint>();
    }
    protected override void AttemptStarted()
    {
        base.AttemptStarted();
        foreach(StickingPoint p in stickingPoints)
        {
            p.Attach();
        }
    }
    protected override void AttemptStopped()
    {
        base.AttemptStopped();
        foreach (StickingPoint p in stickingPoints)
        {
            p.Detach();
        }
    }
    public void OnPickedUp()
    {
        foreach (StickingPoint p in stickingPoints)
        {
            p.isChecking = true;
        }
    }
    public void OnDropped()
    {
        foreach (StickingPoint p in stickingPoints)
        {
            p.isChecking = false;
        }
    }
}
