using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject rockPrefab;

    int timer = 0;
    bool levelStarted = false;
    string PREFABPATH = "Obstacles/";
    //float obstacleOffset = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (levelStarted){
            timer++;
            ProgressLevel();
        }
    }

    public void SpawnLevel(Level newLevel){
        /*
        Level.MakeObstacleDelegate[,] map = newLevel.map;
        for(int i = 0; i< map.GetLength(0); i++){
            for(int j = 0; j< map.GetLength(1); j++){
                Level.MakeObstacleDelegate makeComponentDelegate = map[i,j];
                if(makeComponentDelegate != null){
                    Obstacle obs = makeComponentDelegate.Invoke();
                    if(obs != null){
                        obs.Startup(i/2.0f,j, newLevel.speed);
                        if (obs is Coin){
                            LevelManager.instance.currentLevel.coinsOnThisLevel++;
                        }
                    }                    
                }
            }
        }
        */
        //
        foreach(ObstacleData data in newLevel.obstacleData){
            var obs = GenerateObstacle(data.obstacle);
            obs?.Startup(data.x, data.y, newLevel.speed);
            //GenerateObstacle(data.obstacle);
        }
    }
    Obstacle GenerateObstacle(Type obstacleType){
        string obstacleName = obstacleType.ToString();
        GameObject obstacleObject = LoadObstacle(obstacleName);
        if (obstacleObject != null){
            Obstacle obstacle = (Obstacle)obstacleObject.GetComponent(obstacleType);
            if (obstacle == null){
                obstacle = (Obstacle)obstacleObject.AddComponent(obstacleType);
            }
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
    void ProgressLevel(){}
}
