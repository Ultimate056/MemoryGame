using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   
    private void Start()
    {
        Timer.GameOn = true;
    }
    public void PlayGame(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
