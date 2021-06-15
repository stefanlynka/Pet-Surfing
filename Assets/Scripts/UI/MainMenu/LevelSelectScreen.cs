using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelSelectScreen : Screen
{
    private const string WORLDTEXT = "World ";

    public TextMeshProUGUI worldText;
    public GameObject nextWorldButton;
    public GameObject previousWorldButton;
    public Image backgroundImage;
    public List<Sprite> worldBackgrounds;
    public List<LevelCard> levelCards;
    

    int currentWorld = 1;

    public override void OnEnter(){
        currentWorld = PlayerPrefs.GetInt("World", 1);
        SetupScreen();
    }
    void SetupScreen(){
        SetWorldText();
        SetNextWorldButtons();
        SetBackground();
        InitializeLevelCards();
    }

    void SetWorldText(){
        worldText.text = WORLDTEXT + currentWorld.ToString();
    }
    void SetNextWorldButtons(){
        nextWorldButton.SetActive(LevelManager.instance.WorldExists(currentWorld+1));
        previousWorldButton.SetActive(LevelManager.instance.WorldExists(currentWorld-1));
    }
    void SetBackground(){
        int worldIndex = currentWorld -1;
        if (worldIndex >= 0 && worldIndex < worldBackgrounds.Count){
            Sprite backgroundSprite = worldBackgrounds[worldIndex];
            if (backgroundSprite != null){
                backgroundImage.sprite = backgroundSprite;
            }
        }
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
            print("World: "+levelData.world);
            print("Level: "+levelData.level);
            
        }
    }
    public void GoBack(){
        ScreenManager.instance.popScreen();
    }
    public void LoadNextWorld(){
        if(LevelManager.instance.WorldExists(currentWorld+1)){
            currentWorld += 1;
            SetupScreen();
        }
    }
    public void LoadPreviousWorld(){
        if(LevelManager.instance.WorldExists(currentWorld-1)){
            currentWorld -= 1;
            SetupScreen();
        }
    }
}
