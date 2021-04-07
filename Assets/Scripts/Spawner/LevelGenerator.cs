using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelGenerator : MonoBehaviour
{
    public LevelSpawner spawner;

    Level currentLevel;
    
    string PREFABPATH = "Obstacles/";
    
    // Start is called before the first frame update
    void Start()
    {
        
        int worldNum = PlayerPrefs.GetInt("World");
        int levelNum = PlayerPrefs.GetInt("Level");
        Level level = MakeLevel(worldNum, levelNum);
        if (level != null){
            LevelManager.instance.currentLevel = level;
            spawner?.SpawnLevel(level);
        }
        
    }

    Level MakeLevel(int world, int level){
        switch (world){
            case 1:
            switch(level){
                case 1:
                return MakeLevel1();
                case 2:
                return MakeLevel2();
            }
            break;
            case 2:
            break;
        }
        return null;
    }


    Component GenerateObstacle(Type obstacleType){
        string obstacleName = obstacleType.ToString();
        GameObject obstacleObject = LoadObstacle(obstacleName);
        if (obstacleObject != null){
            Component obstacle = (Obstacle)obstacleObject.AddComponent(obstacleType);
            if (obstacle != null) {
                return obstacle;
            }
        }
        return null;
    }
    GameObject LoadObstacle(string obstacleName){
        GameObject obstaclePrefab = Resources.Load<GameObject>(PREFABPATH + obstacleName);
        GameObject obstacleObject = Instantiate(obstaclePrefab);
        return obstacleObject;
    }

    Level MakeLevel1(){
        Level newLevel = new Level(100, 0.08f);
        newLevel.AddObstacle(20, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(24, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(28, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(44, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(48, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(52, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(56, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(60, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });


        newLevel.AddObstacle(76, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(77, 2, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(78, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(79, 4, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(80, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(81, 6, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(82, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(90, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }


    Level MakeLevel2(){
        Level newLevel = new Level(100, 0.1f);


        newLevel.AddObstacle(20, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(21, 4, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(22, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(24, 7, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(76, 1, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(77, 2, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(78, 3, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(79, 4, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(80, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(81, 6, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(82, 8, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });

        newLevel.AddObstacle(90, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }


    Level MakeLevel3(){
        Level newLevel = new Level(100, 0.08f);
        newLevel.AddObstacle(62, 3, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(70, 1, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(70, 5, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }
        Level MakeLevelDefault(){
        Level newLevel = new Level(100, 0.04f);
        newLevel.AddObstacle(5, 5, () => {
            Coin obs = (Coin)GenerateObstacle(typeof(Coin));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(10, 3, () => {
            Rock obs = (Rock)GenerateObstacle(typeof(Rock));
            obs?.Setup();
            return obs;
        });
        newLevel.AddObstacle(30, 0, () => {
            Beach obs = (Beach)GenerateObstacle(typeof(Beach));
            obs?.Setup();
            return obs;
        });
        return newLevel;
    }
}



