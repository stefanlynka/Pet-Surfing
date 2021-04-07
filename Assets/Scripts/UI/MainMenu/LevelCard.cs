using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelCard : MonoBehaviour
{
    public int world = 0;
    public int level = 0;
    public TextMeshProUGUI text;
    public Image image;
    public Image[] stars = new Image[3];
    public Sprite goldStar;
    public Sprite greyStar;

    public Sprite unlockedSprite;
    public Sprite lockedSprite;


    // Start is called before the first frame update
    void Start()
    {
        LevelData levelData = LevelManager.instance.GetLevelData(world, level);
        if (levelData.stars >= 0){
            SetUnlocked(levelData.unlocked);
            SetStars(levelData.stars);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetUnlocked(bool unlocked){
        text.gameObject.SetActive(unlocked);
        if(unlocked){
            image.sprite = unlockedSprite;
        }
        else {
            image.sprite = lockedSprite;
        }
    }
    void SetStars(int starCount){
        for(int i = 0; i < 3; i++){
            stars[i].sprite = i < starCount ? goldStar : greyStar;
        }
    }


    void OnMouseUp()
    {
        LevelData levelData = LevelManager.instance.GetLevelData(world, level);
        if (levelData.unlocked){
            PlayerPrefs.SetInt("World",world);
            PlayerPrefs.SetInt("Level",level);
            PlayerPrefs.Save();
            SceneManager.LoadScene("World"+world.ToString());
        }
    }
}
