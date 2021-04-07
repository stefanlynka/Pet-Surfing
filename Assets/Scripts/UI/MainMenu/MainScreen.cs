using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScreen : Screen
{
    public void GoToPlay(){
        ScreenManager.instance.pushScreen(ScreenName.LEVEL_SELECT);
    }
    public void GoToShop(){
        ScreenManager.instance.pushScreen(ScreenName.SHOP);
    }
    public void GoToOptions(){

    }
}
