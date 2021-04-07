using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public PlayerData playerData = new PlayerData();
    public Dictionary<(int,int),LevelData> levelDict = new Dictionary<(int, int), LevelData>();
    public string playerDataPath;
    public string levelDataPath;

    const string PLAYERDATAFILENAME = "PlayerData.txt";
    const string LEVELDATAFILENAME = "LevelData.txt";


    public void Setup()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

        playerDataPath = Path.Combine(Application.persistentDataPath, PLAYERDATAFILENAME);
        levelDataPath = Path.Combine(Application.persistentDataPath, LEVELDATAFILENAME);

        if (!TryLoadPlayerData(out playerData)){
            playerData = PlayerManager.instance.MakeNewPlayerData();
            SaveCharacterData();
        }
        if (!TryLoadLevelData(out levelDict)){
            levelDict = LevelManager.instance.GenerateDefaultLevelData();
            SaveLevelData();
        }
    }


    public void AddCoins(int coinCount){
        playerData.coins += coinCount;
        SaveCharacterData();
    }

    public void SaveAllData(){
        SaveCharacterData();
        SaveLevelData();
    }
    public void SaveCharacterData(){
        SaveData(playerDataPath, playerData);
    }
    public void SaveLevelData(){
        SaveData(levelDataPath, levelDict);
    }
    public bool TryLoadPlayerData(out PlayerData outputData) {
        outputData = LoadData<PlayerData>(levelDataPath);
        return outputData != null;
    }
    public bool TryLoadLevelData(out Dictionary<(int,int),LevelData> outputData) {
        outputData = LoadData<Dictionary<(int,int),LevelData>>(levelDataPath);
        return outputData != null;
    }


    void SaveData<T>(string path, T data){
        using (Stream stream = File.OpenWrite(path))
         {    
             BinaryFormatter formatter = new BinaryFormatter();
             formatter.Serialize(stream, data);
         }
    }
    static T LoadData<T>(string path) where T : class{
        if (!File.Exists(path)){
            print("DataManager.cs: File Not Found");
            return null;
        }

        using (Stream stream = File.OpenRead(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            object loadedObject = formatter.Deserialize(stream);
            if (loadedObject is T){
                return loadedObject as T;
            }
            else {
                print("DataManager.cs: Failed to load");
                return null;
            }
        }
    }
}


[System.Serializable]
public class PlayerData{
    public int coins = 0;
    public PlayerPet currentPet;
}

[System.Serializable]
public enum PlayerPet {
    Cat,
    Dog,
    Rabbit
}

[System.Serializable]
public struct LevelData{
    public bool unlocked;
    public bool beat;
    public int stars;
    public LevelData(bool isUnlocked){
        unlocked = isUnlocked;
        beat = false;
        stars = 0;
    }
    public LevelData(int myStars){
        unlocked = false;
        beat = false;
        stars = myStars;
    }
}