using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    
    [SerializeField] private float TimerStart;
    public Text timerText;
    public bool TimerRunning = true;
    [SerializeField] public static bool GameOn = true;
    private GameObject gmj;
    [SerializeField] private Canvas _canvasLose = null;
    [SerializeField] private Canvas _canvasWin = null;
    public AudioSource aud = null;
    public Canvas can = null;
    private bool Win = false;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = "Осталось " + TimerStart.ToString();
    }

    public void CloseorOpenMiniMenu()
    {
        bool act = can.gameObject.activeSelf == true ? false : true;
        can.gameObject.SetActive(act);
    }
    public void ChangeGameStatus()
    {
        GameOn = GameOn == true ? false : true;
        if (GameOn)
            aud.UnPause();
        else
            aud.Pause();
    }

    private void CheckWin()
    {
        if (Win)
        {
            gmj = _canvasWin.gameObject;
            gmj.SetActive(true);
        }
        else
        {
            gmj = _canvasLose.gameObject;
            gmj.SetActive(true);
        }
        aud.Stop();
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeGameStatus();
            CloseorOpenMiniMenu();
        }
        if(GameOn)
        {
            if (CardsSpawner.AllPlayingCards == 0)
            {
                TimerRunning = false;
                GameOn = false;
                Win = true;
                CheckWin();
            }
            if (TimerRunning)
            {
                TimerStart -= Time.deltaTime;
                timerText.text = "Осталось " + Mathf.Round(TimerStart).ToString();
                if (TimerStart <= 0)
                {
                    TimerRunning = false;
                    GameOn = false;
                    Win = false;
                    CheckWin();
                }
            }
        }   
    }
}
