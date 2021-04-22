using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class LevelCard : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    public Image[] stars = new Image[3];
    public Sprite goldStar;
    public Sprite greyStar;
    public Sprite unlockedSprite;
    public Sprite lockedSprite;

    Action<LevelData> onClick;
    LevelData levelData;    
    
    public void Clear(){
        onClick = null;
    }
    public void SetUnlocked(bool unlocked){
        text?.gameObject.SetActive(unlocked);
        if (image != null){
            if(unlocked){
                image.sprite = unlockedSprite;
            }
            else {
                image.sprite = lockedSprite;
            }
        }
    }
    public void SetStars(int starCount){
        if (goldStar == null || greyStar == null){
            Debug.LogWarning("LevelCard.cs: Star sprite not found");
            return;
        }
        for(int i = 0; i < 3; i++){
            if (stars[i] != null){
                stars[i].sprite = i < starCount ? goldStar : greyStar;
            }
        }
    }
    public void SetOnClick(Action<LevelData> newAction, LevelData newLevelData){
        levelData = newLevelData;
        onClick += newAction;
    }
    void OnMouseUp()
    {
        if (onClick != null){
            onClick(levelData);
        }
    }
}
