using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Level currentLevel;
    public int coinsCollectedOnThisLevel = 0;
    public int timesHitOnThisLevel = 0;

    const float ratioCoinsNeededForStar = 0.9f;


    public void Setup(){
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            print("level manager instance up and running");
            instance = this;
        }
        coinsCollectedOnThisLevel = 0;
        timesHitOnThisLevel = 0;
    }
    public LevelData GetLevelData(int worldNum, int levelNum){
        if (!DataManager.instance.levelDict.ContainsKey((worldNum, levelNum))){
            print("level not found");
            return new LevelData(-1);
        }
        LevelData levelData = DataManager.instance.levelDict[(worldNum,levelNum)];
        return levelData;
    }


    public Dictionary<(int,int),LevelData> GenerateDefaultLevelData(){
        print("Generate default level data");
        Dictionary<(int,int),LevelData> levelData = new Dictionary<(int, int), LevelData>(){
            {(1,1), new LevelData(true)},
            {(1,2), new LevelData(false)},
            {(1,3), new LevelData(false)},
            {(1,4), new LevelData(false)},
            {(1,5), new LevelData(false)},
            {(1,6), new LevelData(false)},
            {(1,7), new LevelData(false)},
            {(1,8), new LevelData(false)},
            {(2,1), new LevelData(false)},
            {(2,2), new LevelData(false)},
            {(2,3), new LevelData(false)},
            {(2,4), new LevelData(false)},
            {(2,5), new LevelData(false)},
            {(2,6), new LevelData(false)},
            {(2,7), new LevelData(false)},
            {(2,8), new LevelData(false)},
        };
        return levelData;
    }
    public void RestartLevel(){
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void LoadNextLevel(){
        (int world, int level) = GetNextLevel(PlayerPrefs.GetInt("World"), PlayerPrefs.GetInt("Level"));
        if (world != -1 && level != -1){
            PlayerPrefs.SetInt("World", world);
            PlayerPrefs.SetInt("Level", level);
            PlayerPrefs.Save();
            if(world == PlayerPrefs.GetInt("World")){
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }
            else {
                SceneManager.LoadScene("World"+world.ToString());
            }
        }

    }
    public void FinishLevel(){
        print("level finished");
        GameController.gameRunning = false;
        ScreenManager.instance.pushScreen(ScreenName.LEVEL_WON);
        BeatLevel(PlayerPrefs.GetInt("World"), PlayerPrefs.GetInt("Level"), GetStarsForThisLevel());
        UnlockNextLevel();
        DataManager.instance.SaveAllData();
    }
    public int GetStarsForThisLevel(){
        int stars = 1;
        if (timesHitOnThisLevel <=0) stars++;

        if (coinsCollectedOnThisLevel >= currentLevel.coinRatioForStar * (float)coinsCollectedOnThisLevel/(float)currentLevel.coinsOnThisLevel) stars++;
        return stars;
    }
    public void CollectCoins(int coins){
        coinsCollectedOnThisLevel += coins;
    }
    public void BeatLevel(int world, int level, int stars){
        if(DataManager.instance.levelDict.ContainsKey((world,level))){
            LevelData newData = new LevelData();
            newData.unlocked = true;
            newData.beat = true;
            newData.stars = stars;
            DataManager.instance.levelDict[(world, level)] = newData;
        }
        DataManager.instance.playerData.coins += coinsCollectedOnThisLevel;
        DataManager.instance.SaveCharacterData();
    }
    void UnlockNextLevel(){
        (int world, int level) nextData = GetNextLevel(PlayerPrefs.GetInt("World"), PlayerPrefs.GetInt("Level"));
        if (nextData.world != -1){
            UnlockLevel(nextData.world, nextData.level);
        }
    }
    void UnlockLevel(int world, int level){
        if(DoesLevelExist(world,level)){
            LevelData newData = DataManager.instance.levelDict[(world, level)];
            newData.unlocked = true;
            DataManager.instance.levelDict[(world, level)] = newData;
            DataManager.instance.SaveLevelData();
        }
    }
    public bool DoesLevelExist(int world, int level){
        if (DataManager.instance.levelDict.ContainsKey((world,level))){
            return true;
        }
        return false;
    }
    (int,int) GetNextLevel(int world, int level){
        if (DoesLevelExist(world, level+1)){
            return (world, level+1);
        }
        else if (DoesLevelExist(world+1, 1)){
            return (world+1, 1);
        }
        return (-1, -1);
    }
    public void LoseLevel(){
        GameController.gameRunning = false;
        ScreenManager.instance.pushScreen(ScreenName.LEVEL_LOST);
    }
}

public class Level{
    public int worldNum = 0;
    public int levelNum = 0;
    public bool unlockedByDefault = false;


    const int mapHeight = 10;
    public float speed = 0.0f;
    public int coinsOnThisLevel = 0;
    public float coinRatioForStar = 0.75f;


    public delegate Obstacle MakeObstacleDelegate();
    public MakeObstacleDelegate[,] map;
    public Level(int mapLength, float mapSpeed){
        map = new MakeObstacleDelegate[mapLength, mapHeight];
        speed = mapSpeed;
    }
    public Level(int world, int level, bool unlocked = false){
        worldNum = world;
        levelNum = level;
        unlockedByDefault = unlocked;
    }
    public void AddObstacle(int x, int y, MakeObstacleDelegate action){
        map[x,y] = action;
    }
}