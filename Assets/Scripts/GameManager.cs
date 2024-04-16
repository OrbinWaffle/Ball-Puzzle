using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    bool isPlaying = false;
    public static GameManager main;
    public EventBus bus;
    [SerializeField] string[] levels;
    int currentLevel;

    private void Awake()
    {
        if(main == null)
        {
            main = this;
            DontDestroyOnLoad(gameObject);
            bus.Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void StartAttempt()
    {
        if(isPlaying) { return; }
        EventBus.main.OnStartAttempt.Invoke();
        isPlaying = true;
    }
    public void StopAttempt()
    {
        if(!isPlaying ) { return; }
        EventBus.main.OnStopAttempt.Invoke();
        isPlaying = false;
    }
    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levels[levelIndex]);
        currentLevel = levelIndex;
        isPlaying = false;
    }
    public void NextLevel()
    {
        LoadLevel(currentLevel + 1);
    }
    public void GoToMainMenu()
    {
        LoadLevel(0);
    }
}
