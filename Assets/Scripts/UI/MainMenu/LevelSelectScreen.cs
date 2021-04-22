using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScreen : Screen
{
    public List<LevelCard> levelCards;

    int currentWorld = 1;

    public override void OnEnter(){
        currentWorld = PlayerPrefs.GetInt("World", 1);
        InitializeLevelCards();
    }

    void InitializeLevelCards(){
        for(int i = 0; i < levelCards.Count; i++){
            int level = i + 1;
            LevelCard levelCard = levelCards[i];
            if (DataManager.instance.TryGetLevel(currentWorld, level, out LevelData levelData)){
                levelCard.gameObject.SetActive(true);
                levelCard.Clear();
                levelCard.SetUnlocked(levelData.unlocked);
                levelCard.SetStars(levelData.stars);
                levelCard.SetOnClick(ClickOnLevelCard, levelData);
            }
            else {
                levelCard.gameObject.SetActive(false);
            }
        }
    }
    void ClickOnLevelCard(LevelData levelData){
        if (levelData.unlocked){
            PlayerPrefs.SetInt("World",levelData.world);
            PlayerPrefs.SetInt("Level",levelData.level);
            PlayerPrefs.Save();
            SceneManager.LoadScene("World"+levelData.world.ToString());
        }
    }
    public void GoBack(){
        ScreenManager.instance.popScreen();
    }
}
