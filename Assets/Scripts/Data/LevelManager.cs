using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public const int LEVELSPERWORLD = 8;
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
            instance = this;
        }
        coinsCollectedOnThisLevel = 0;
        timesHitOnThisLevel = 0;
    }
    /*
    public LevelData GetLevelData(int worldNum, int levelNum){
        if (!DataManager.instance.HasLevel(worldNum, levelNum)){
            print("LevelManager.cs: Level not found");
            return new LevelData(-1);
        }
        LevelData levelData = DataManager.instance.GetLevel(worldNum,levelNum);
        return levelData;
    }
    */

    public Dictionary<(int,int),LevelData> GenerateDefaultLevelData(){
        Dictionary<(int,int),LevelData> levelData = new Dictionary<(int, int), LevelData>(){
            {(1,1), new LevelData(1,1, true)},
            {(1,2), new LevelData(1,2, false)},
            {(1,3), new LevelData(1,3, false)},
            {(1,4), new LevelData(1,4, false)},
            {(1,5), new LevelData(1,5, false)},
            {(1,6), new LevelData(1,6, false)},
            {(1,7), new LevelData(1,7, false)},
            {(1,8), new LevelData(1,8, false)},
            {(2,1), new LevelData(2,1, true)},
            {(2,2), new LevelData(2,2, false)},
            {(2,3), new LevelData(2,3, false)},
            {(2,4), new LevelData(2,4, false)},
            {(2,5), new LevelData(2,5, false)},
            {(2,6), new LevelData(2,6, false)},
            {(2,7), new LevelData(2,7, false)},
            {(2,8), new LevelData(2,8, false)},
            {(3,1), new LevelData(1,1, true)},
            {(3,2), new LevelData(1,2, false)},
            {(3,3), new LevelData(1,3, false)},
            {(3,4), new LevelData(1,4, false)},
            {(3,5), new LevelData(1,5, false)},
            {(3,6), new LevelData(1,6, false)},
            {(3,7), new LevelData(1,7, false)},
            {(3,8), new LevelData(1,8, false)},
            {(4,1), new LevelData(2,1, true)},
            {(4,2), new LevelData(2,2, false)},
            {(4,3), new LevelData(2,3, false)},
            {(4,4), new LevelData(2,4, false)},
            {(4,5), new LevelData(2,5, false)},
            {(4,6), new LevelData(2,6, false)},
            {(4,7), new LevelData(2,7, false)},
            {(4,8), new LevelData(2,8, false)},
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
        GameController.gameRunning = false;
        ScreenManager.instance.pushScreen(ScreenName.LEVEL_WON);
        BeatLevel(PlayerPrefs.GetInt("World"), PlayerPrefs.GetInt("Level"), GetStarsForThisLevel());
        UnlockNextLevel();
        DataManager.instance.SavePlayerData();
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
        if(DataManager.instance.HasLevel(world,level)){
            LevelData newData = new LevelData(world, level, true);
            newData.beat = true;
            newData.stars = stars;
            DataManager.instance.SetLevelData(world, level, newData);
        }
        DataManager.instance.ChangeCoinCount(coinsCollectedOnThisLevel);
    }
    void UnlockNextLevel(){
        (int world, int level) nextData = GetNextLevel(PlayerPrefs.GetInt("World"), PlayerPrefs.GetInt("Level"));
        if (nextData.world != -1){
            UnlockLevel(nextData.world, nextData.level);
        }
    }
    void UnlockLevel(int world, int level){
        if(DoesLevelExist(world,level)){
            LevelData newData = DataManager.instance.playerData.levelDict[(world, level)];
            newData.unlocked = true;
            DataManager.instance.SetLevelData(world, level, newData);
            DataManager.instance.SavePlayerData();
        }
    }
    public bool DoesLevelExist(int world, int level){
        return DataManager.instance.HasLevel(world,level);
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
    public bool WorldExists(int currentWorld){
        return DoesLevelExist(currentWorld, 1);
    }
}

public class Level{
    public int worldNum = 0;
    public int levelNum = 0;
    public bool unlockedByDefault = false;


    const int mapHeight = 11;
    public float speed = 0.0f;
    public int coinsOnThisLevel = 0;
    public float coinRatioForStar = 0.75f;


    //public delegate Obstacle MakeObstacleDelegate();
    //public MakeObstacleDelegate[,] map;
    public List<ObstacleData> obstacleData = new List<ObstacleData>();

    public Level(float mapSpeed){
        //map = new MakeObstacleDelegate[mapLength, mapHeight];
        speed = mapSpeed;
    }
    public Level(int world, int level, bool unlocked = false){
        worldNum = world;
        levelNum = level;
        unlockedByDefault = unlocked;
    }
    public void AddObstacle(float x, float y, Type obstacle){
        obstacleData.Add(new ObstacleData(obstacle, x, y));
        //obstacle.SetCollisionPosition(x,y);
        //obstacles.Add(obstacle);
        //map[x,y] = action;
    }
}
public struct ObstacleData{
    public Type obstacle;
    public float x;
    public float y;
    public ObstacleData(Type obstacle, float x, float y){
        this.obstacle = obstacle;
        this.x = x;
        this.y = y;
    }
}