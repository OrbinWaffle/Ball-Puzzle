using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHelper : MonoBehaviour
{
    public List<string> tags = new List<string>();
    public UnityEvent<Collider> HelperTriggerEnter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider.tag);
        if(tags.Contains(collider.tag))
        {
            HelperTriggerEnter.Invoke(collider);
        }
    }
}
