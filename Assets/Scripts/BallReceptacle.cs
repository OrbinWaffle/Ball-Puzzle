using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallReceptacle : MonoBehaviour
{
    public UnityEvent<GameObject> OnBallReceived;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ReceiveBall(Collider collider)
    {
        //Destroy(collider.gameObject);
        EventBus.main.OnWin.Invoke();
        OnBallReceived.Invoke(collider.gameObject);
    }
}
