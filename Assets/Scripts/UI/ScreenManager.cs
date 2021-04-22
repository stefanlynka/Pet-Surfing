using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance;
    public ScreenName startingScreen;
    [SerializeField] private Screen[] screens;
    private Dictionary<ScreenName, Screen> screenDict = new Dictionary<ScreenName, Screen>();
    private Stack<Screen> screenStack = new Stack<Screen>();


    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        foreach(Screen screen in screens){
            if(!screenDict.ContainsKey(screen.screenName)){
                screenDict.Add(screen.screenName, screen);
                screen.gameObject.SetActive(false);
            }
        }

        pushScreen(startingScreen);
    }




    //The last sibling gets rendered last and appears on top of other screens
    public void pushScreen(ScreenName screenName)
    {
        //print("Push: "+screenName);
        if (screenDict.TryGetValue(screenName, out Screen newScreen)){
            if(screenStack.Count >0){
                Screen oldScreen = screenStack.Peek();
                oldScreen?.gameObject.SetActive(false);
            }



            GameObject screenObject = newScreen.gameObject;
            screenObject.SetActive(true);
            screenObject.transform.SetAsLastSibling();
            screenStack.Push(newScreen);
            newScreen.OnEnter();
        }
    }

    public void popScreen()
    {
        
        if(screenStack.Count != 0)
        {
            Screen oldScreen = screenStack.Pop();
            //print("Pop: "+oldScreen);
            GameObject screenObject = oldScreen.gameObject;
            screenObject.SetActive(false);
            screenObject.transform.SetAsFirstSibling();
            oldScreen.OnExit();

            if(screenStack.Count > 0){
                Screen newScreen = screenStack.Peek();
                newScreen?.gameObject.SetActive(true);
            }

        }
    }
    public void transitionToScreen(ScreenName screenName)
    {
        popScreen();
        pushScreen(screenName);
    }
}

public enum ScreenName
{
    MAIN_MENU,
    OPTIONS,
    SHOP,
    LEVEL_SELECT,
    PAUSE_MENU,
    LEVEL,
    LEVEL_LOST,
    LEVEL_WON
}
