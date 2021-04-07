using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : Screen
{
    public override void OnEnter(){
        GameController.gameRunning = false;
    }
    public override void OnExit(){
        GameController.gameRunning = true;
    }
    public void Play()
    {
        ScreenManager.instance.popScreen();
    }

    public void RestartLevel(){
        LevelManager.instance.RestartLevel();
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenu");
        /*
        #if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        
        Application.Quit();
        */
    }
}
