using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StrutController : MonoBehaviour
{
    List<StickingPoint> attatchedTo;

    StickingPoint[] stickingPoints;
    // Start is called before the first frame update
    void Start()
    {
        stickingPoints = GetComponentsInChildren<StickingPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddStickingPoint(StickingPoint point)
    {

    }
    public void Attach()
    {
        foreach(StickingPoint p in stickingPoints)
        {
            p.Attach();
        }
    }
    public void Detach()
    {
        foreach (StickingPoint p in stickingPoints)
        {
            p.Detach();
        }
    }
}
