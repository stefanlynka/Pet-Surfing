using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScreen : Screen
{

    public void ExitShop(){
        ScreenManager.instance.popScreen();
    }
}
