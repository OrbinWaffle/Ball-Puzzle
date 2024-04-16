using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineBase : MonoBehaviour
{
    CollisionHelper collisionHelper;
    void Start()
    {
        collisionHelper = GetComponentInChildren<CollisionHelper>();
        collisionHelper.HelperTriggerEnter.AddListener(TriggerReceiver);
    }
    void TriggerReceiver(Collider col)
    {
        ActivateMachine(col);
    }
    protected virtual void ActivateMachine(Collider col)
    {
        Debug.Log(col);
    }
}
