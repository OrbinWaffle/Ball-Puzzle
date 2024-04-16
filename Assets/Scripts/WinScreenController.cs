using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenController : MonoBehaviour
{
    private void Start()
    {
        EventBus.main.OnWin.AddListener(Win);
    }
    public void NextLevel()
    {
        GameManager.main.NextLevel();
    }
    public void MainMenu()
    {
        GameManager.main.GoToMainMenu();
    }
    public void Win()
    {
        SetWinScreenState(true);
    }
    public void SetWinScreenState(bool active)
    {
        transform.GetChild(0).gameObject.SetActive(active);
    }
}
