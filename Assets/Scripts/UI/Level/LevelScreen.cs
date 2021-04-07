using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScreen : Screen
{
    public override void OnEnter(){
        GameController.gameRunning = true;
    }
    public void Pause(){
        ScreenManager.instance.pushScreen(ScreenName.PAUSE_MENU);
    }
}
