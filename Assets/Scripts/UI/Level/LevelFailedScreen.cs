using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelFailedScreen : Screen
{
    public override void OnEnter(){
        GameController.gameRunning = false;
    }

    
    public void GoBackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel(){
        LevelManager.instance.RestartLevel();
    }
}
