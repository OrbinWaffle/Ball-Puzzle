using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickingPoint : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    Rigidbody _rigidbody;
    float radius = 0.1f;
    private void Start()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
        Attach();
    }
    public void Attach()
    {
        Collider[] colliders;
        colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;
            if (rb == _rigidbody)
            {
                continue;
            }
            Debug.Log(rb);
            if (rb)
            {
                Debug.Log("HI");
                CreateJoint(rb);
            }
        }
    }
    void CreateJoint(Rigidbody rb)
    {
        ConfigurableJoint cj = _rigidbody.gameObject.AddComponent<ConfigurableJoint>();
        cj.connectedBody = rb;
        cj.anchor = transform.localPosition;
        cj.xMotion = ConfigurableJointMotion.Limited;
        cj.yMotion = ConfigurableJointMotion.Limited;
        cj.zMotion = ConfigurableJointMotion.Limited;
        SoftJointLimit sjl = new SoftJointLimit();
        sjl.limit = 0.01f;
        cj.linearLimit = sjl;
        SoftJointLimitSpring sjls = new SoftJointLimitSpring();
        sjls.spring = 1000f;
        sjls.damper = 1000f;
        cj.linearLimitSpring = sjls;
    }
}
