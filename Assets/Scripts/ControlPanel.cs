using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : MonoBehaviour
{
    public void Attempt()
    {
        GameManager.main.StartAttempt();
    }
    public void ResetBall()
    {
        GameManager.main.StopAttempt();
    }
}
