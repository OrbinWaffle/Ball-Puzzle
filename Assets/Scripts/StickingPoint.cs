using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StickingPoint : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    Rigidbody _rigidbody;
    float radius = 0.1f;
    List<ConfigurableJoint> joints = new List<ConfigurableJoint>();
    MeshRenderer _meshRenderer;
    public bool isChecking;
    bool isInRange;
    bool wasInRange;
    Color invalidColor = Color.red;
    Color validColor = Color.green;
    float nextCheckTime;
    float checkInterval = 0.1f;
    private void Start()
    {
        _rigidbody = GetComponentInParent<Rigidbody>();
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _meshRenderer.material.color = invalidColor;
        EventBus.main.OnPickup.AddListener(CheckToggle);
    }
    private void FixedUpdate()
    {
        if(isChecking && Time.time > nextCheckTime)
        {
            nextCheckTime = Time.time + checkInterval;
            wasInRange = isInRange;
            isInRange = CheckForAttachPoint();
            UpdateColors(isInRange);
        }
    }
    void UpdateColors(bool inRange)
    {
        if (inRange && !wasInRange) { _meshRenderer.material.color = validColor; }
        if (!inRange && wasInRange) { _meshRenderer.material.color = invalidColor; }
    }
    public void CheckToggle(bool toggle)
    {
        isChecking = toggle;
    }
    bool CheckForAttachPoint()
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
            if (rb)
            {
                if (rb == _rigidbody)
                {
                    continue;
                }
                else
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void Attach()
    {
        UpdateColors(CheckForAttachPoint());
        Collider[] colliders;
        colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;
            Debug.Log(rb);
            if (rb)
            {
                if (rb == _rigidbody)
                {
                    continue;
                }
                else
                {
                    CreateJoint(rb);
                }
            }
        }
    }
    public void Detach()
    {
        foreach(ConfigurableJoint j in joints)
        {
            Destroy(j);
        }
        joints.Clear();
    }
    void CreateJoint(Rigidbody rb)
    {
        ConfigurableJoint cj = _rigidbody.gameObject.AddComponent<ConfigurableJoint>();
        joints.Add(cj);
        cj.connectedBody = rb;
        cj.anchor = transform.localPosition;
        cj.xMotion = ConfigurableJointMotion.Locked;
        cj.yMotion = ConfigurableJointMotion.Locked;
        cj.zMotion = ConfigurableJointMotion.Locked;
        cj.angularXMotion = ConfigurableJointMotion.Limited;
        cj.angularYMotion = ConfigurableJointMotion.Limited;
        cj.angularZMotion = ConfigurableJointMotion.Limited;
        SoftJointLimit sjl = new SoftJointLimit();
        SoftJointLimitSpring sjls = new SoftJointLimitSpring();
        sjl.limit = 0.01f;
        sjls.spring = 1000f;
        sjls.damper = 1000f;

        SoftJointLimit sjla = new SoftJointLimit();
        SoftJointLimitSpring sjlsa = new SoftJointLimitSpring();
        sjla.limit = 3f;
        sjlsa.spring = 1000f;
        sjlsa.damper = 1000f;

        cj.linearLimit = sjl;
        cj.linearLimitSpring = sjls;

        cj.highAngularXLimit = sjla;
        cj.lowAngularXLimit = sjla;
        cj.angularXLimitSpring = sjlsa;
        cj.angularYLimit = sjla;
        cj.angularZLimit = sjla;
        cj.angularYZLimitSpring = sjlsa;
    }
}
