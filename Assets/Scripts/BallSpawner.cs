using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] GameObject ball;
    private GameObject _ballInstance;
    // Start is called before the first frame update
    void Start()
    {
        EventBus.main.OnStartAttempt.AddListener(SpawnBall);
        EventBus.main.OnStopAttempt.AddListener(StopAttempt);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBall()
    {
        _ballInstance = Instantiate(ball, transform.position, transform.rotation);
    }
    public void StopAttempt()
    {
        Destroy(_ballInstance);
    }
}
