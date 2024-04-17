using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Cannon : MachineBase
{
    [SerializeField] float fireForce;
    [SerializeField] Transform fireSpot;
    protected override void ActivateMachine(Collider col)
    {
        base.ActivateMachine(col);
        col.transform.position = fireSpot.transform.position;
        col.attachedRigidbody.AddForce(fireSpot.transform.forward * fireForce, ForceMode.Impulse);
    }
}
