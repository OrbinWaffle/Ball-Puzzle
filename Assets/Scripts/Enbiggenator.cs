using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enbiggenator : MachineBase
{
    public Transform exit;
    protected override void ActivateMachine(Collider col)
    {
        base.ActivateMachine(col);
        col.transform.position = exit.transform.position;
        col.transform.localScale = Vector3.one * 4;
    }
}
