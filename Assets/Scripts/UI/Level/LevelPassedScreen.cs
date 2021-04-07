using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelPassedScreen : Screen
{
    public TextMeshProUGUI coinText;
    public Image[] stars = new Image[3];

    public Sprite goldStar;
    public Sprite greyStar;


    public override void OnEnter(){
        GameController.gameRunning = false;
        int starCount = LevelManager.instance.GetStarsForThisLevel();
        int coinCount = LevelManager.instance.coinsCollectedOnThisLevel;
        Setup(starCount, coinCount);
    }


    public void GoBackToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void RestartLevel(){
        LevelManager.instance.RestartLevel();
    }
    public void NextLevel(){
        LevelManager.instance.LoadNextLevel();
    }
    public void Setup(int starCount, int coinCount){
        print("StarCount: "+starCount);
        print("CoinCount: "+coinCount);
        for(int i = 0; i < 3; i++){
            stars[i].sprite = i < starCount ? goldStar : greyStar;
        }
        coinText.text = coinCount.ToString();
    }
}
